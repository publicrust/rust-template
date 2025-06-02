using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Admin Monitor", "Braga", "1.3.0")]
    [Description("Monitors admin activity and tracks their time spent in-game")]
    public class AdminMonitor : RustPlugin
    {
        #region Fields
        private const string PermissionAdmin = "adminmonitor.admin";
        private const string PermissionView = "adminmonitor.view";
        private const string PermissionTracked = "adminmonitor.tracked";
        private const string PermissionReports = "adminmonitor.reports";
        private StoredData? storedData;
        private readonly Dictionary<ulong, AdminActivity> activeAdmins = new();
        private readonly Dictionary<ulong, Timer> activityTimers = new();
        private readonly Dictionary<ulong, Timer> uiUpdateTimers = new();
        private readonly Dictionary<ulong, Vector3> lastPositions = new();
        private readonly Dictionary<ulong, Quaternion> lastRotations = new();
        private readonly Dictionary<ulong, float> lastActionTimes = new();
        private readonly Dictionary<ulong, HashSet<string>> activeActions = new();
        private readonly string LayerMain = "AdminMonitor.UI";
        private readonly string LayerContent = "AdminMonitor.Content";

        [PluginReference]
        private readonly Plugin? ImageLibrary;
        private readonly Dictionary<ulong, string> avatarUrls = new();

        /// <summary>
        /// URL Discord вебхука для отправки уведомлений
        /// </summary>
        private string DiscordWebhookUrl => Config["DiscordWebhookUrl"]?.ToString() ?? string.Empty;

        /// <summary>
        /// Порог движения для определения AFK (в единицах)
        /// </summary>
        private const float MovementThreshold = 0.1f;

        /// <summary>
        /// Порог поворота для определения AFK (в градусах)
        /// </summary>
        private const float RotationThreshold = 1f;

        /// <summary>
        /// Интервал проверки активности в секундах
        /// </summary>
        private readonly float checkInterval = 1f;

        /// <summary>
        /// Порог неактивности в секундах
        /// </summary>
        private readonly float inactivityThreshold = 60f;
        private readonly Dictionary<ulong, List<AdminAction>> recentActionsCache = new();
        private readonly TimeSpan actionsCacheExpiration = TimeSpan.FromSeconds(5);
        private readonly Dictionary<ulong, DateTime> lastActionsCacheUpdate = new();
        private readonly Dictionary<string, string> filterSettings = new();
        private const string FilterAll = "all";
        private const string FilterOnline = "online";
        private const string FilterOffline = "offline";
        private const string FilterAfk = "afk";
        private const string SortTimeActive = "active";
        private const string SortTimeAfk = "afk";
        private const string SortName = "name";
        private const string ReportsFolderName = "Reports";
        #endregion Fields

        #region Data Classes
        private sealed class StoredData
        {
            public Dictionary<ulong, AdminStats> AdminStatistics { get; set; } = new();
            public List<WipeHistory> WipeHistory { get; set; } = new();
            public DateTime? CurrentWipeStart { get; set; }
        }

        private sealed class WipeHistory
        {
            public required DateTime StartDate { get; set; }
            public required DateTime EndDate { get; set; }
            public Dictionary<ulong, AdminWipeStats> AdminStats { get; set; } = new();
        }

        private sealed class AdminWipeStats
        {
            public required string LastName { get; set; }
            public float TotalActiveTime { get; set; }
            public float TotalAfkTime { get; set; }
            public Dictionary<string, int> CommandsUsed { get; set; } = new();
            public DateTime LastActive { get; set; }
        }

        private sealed class AdminStats
        {
            public required string LastName { get; set; }
            public float TotalActiveTime { get; set; }
            public float TotalAfkTime { get; set; }
            public Dictionary<string, int> CommandsUsed { get; set; } = new();
            public List<AdminAction> RecentActions { get; set; } = new();
            public DateTime LastActive { get; set; }
            public float CurrentWipeActiveTime { get; set; }
            public float CurrentWipeAfkTime { get; set; }
        }

        private sealed class AdminActivity
        {
            public float SessionStartTime { get; set; }
            public float LastActiveTime { get; set; }
            public float TotalAfkTime { get; set; }
            public bool IsAfk { get; set; }
            public Vector3 LastPosition { get; set; }
            public float AfkStartTime { get; set; }
        }

        private sealed class AdminAction
        {
            public required string ActionType { get; set; }
            public required string Details { get; set; }
            public required string Target { get; set; }
            public DateTime Timestamp { get; set; }
            public Vector3 Location { get; set; }
        }

        private sealed class AdminReport
        {
            public required DateTime GenerationDate { get; set; }
            public required string ReportType { get; set; }
            public required string Period { get; set; }
            public Dictionary<ulong, AdminReportStats> Statistics { get; set; } = new();
        }

        private sealed class AdminReportStats
        {
            public required string AdminName { get; set; }
            public float ActiveTime { get; set; }
            public float AfkTime { get; set; }
            public int CommandsUsed { get; set; }
            public int BuildActions { get; set; }
            public int DestroyActions { get; set; }
            public int PlayerInteractions { get; set; }
            public Dictionary<string, int> ActionTypes { get; set; } = new();
        }
        #endregion Data Classes

        #region Oxide Hooks
        private void Init()
        {
            permission.RegisterPermission(PermissionAdmin, this);
            permission.RegisterPermission(PermissionView, this);
            permission.RegisterPermission(PermissionTracked, this);
            permission.RegisterPermission(PermissionReports, this);
            LoadData();

            cmd.AddChatCommand("amonitor", this, nameof(CmdAdminMonitor));
            cmd.AddConsoleCommand("amonitor.check", this, nameof(CmdCheckAdmin));
            cmd.AddConsoleCommand("amonitor.report", this, nameof(CmdGenerateReport));

            // Создаем папку для отчетов
            if (
                !Interface.Oxide.DataFileSystem.ExistsDatafile(
                    $"{DataFolderName}/{ReportsFolderName}"
                )
            )
            {
                _ = Interface.Oxide.DataFileSystem.GetDatafile(
                    $"{DataFolderName}/{ReportsFolderName}"
                );
            }

            // Добавляем таймер для сохранения статистики каждую минуту
            _ = timer.Every(
                60f,
                () =>
                {
                    if (storedData == null)
                    {
                        return;
                    }

                    UpdateAllAdminStats();
                    SaveData();
                    Puts("Admin statistics saved (1-minute interval)");
                }
            );

            ScheduleReports();
        }

        private void OnServerInitialized(bool initial)
        {
            if (ImageLibrary == null)
            {
                PrintError("ImageLibrary plugin is not installed!");
            }

            if (storedData != null && storedData.CurrentWipeStart == null)
            {
                storedData.CurrentWipeStart = DateTime.Now;
                SaveData();
            }

            foreach (BasePlayer player in BasePlayer.activePlayerList)
            {
                if (player?.IsAdmin == true)
                {
                    StartMonitoring(player);
                    LoadPlayerAvatar(player);
                }
            }
        }

        private void OnNewSave(string filename)
        {
            if (storedData == null)
            {
                return;
            }

            // Сохраняем статистику предыдущего вайпа
            if (storedData.CurrentWipeStart.HasValue)
            {
                WipeHistory wipeHistory = new()
                {
                    StartDate = storedData.CurrentWipeStart.Value,
                    EndDate = DateTime.Now,
                };

                foreach (KeyValuePair<ulong, AdminStats> kvp in storedData.AdminStatistics)
                {
                    wipeHistory.AdminStats[kvp.Key] = new AdminWipeStats
                    {
                        LastName = kvp.Value.LastName,
                        TotalActiveTime = kvp.Value.CurrentWipeActiveTime,
                        TotalAfkTime = kvp.Value.CurrentWipeAfkTime,
                        CommandsUsed = new Dictionary<string, int>(kvp.Value.CommandsUsed),
                        LastActive = kvp.Value.LastActive,
                    };

                    // Сбрасываем статистику текущего вайпа
                    kvp.Value.CurrentWipeActiveTime = 0;
                    kvp.Value.CurrentWipeAfkTime = 0;
                    kvp.Value.CommandsUsed.Clear();
                }

                storedData.WipeHistory.Add(wipeHistory);
                storedData.CurrentWipeStart = DateTime.Now;
                SaveData();
            }
        }

        private void OnServerSave()
        {
            if (storedData == null)
            {
                return;
            }

            UpdateAllAdminStats();
            SaveData();
            Puts("Admin statistics saved (server save)");
        }

        private void OnPlayerConnected(BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            if (
                player.IsAdmin
                || permission.UserHasPermission(player.UserIDString, PermissionTracked)
            )
            {
                StartMonitoring(player);
                LoadPlayerAvatar(player);
                SendDiscordLoginMessage(player);
            }
        }

        private void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            if (
                player == null
                || (
                    !player.IsAdmin
                    && !permission.UserHasPermission(player.UserIDString, PermissionTracked)
                )
            )
            {
                return;
            }

            // Очищаем таймер обновления UI при отключении
            if (uiUpdateTimers.TryGetValue(player.userID, out Timer uiTimer))
            {
                uiTimer.Destroy();
                _ = uiUpdateTimers.Remove(player.userID);
            }

            SendDiscordLogoutMessage(player);
            StopMonitoring(player);
            SaveAdminStats(player);
        }

        private object? OnPlayerCommand(BasePlayer? player, string command, string[] args)
        {
            if (
                player == null
                || (
                    !player.IsAdmin
                    && !permission.UserHasPermission(player.UserIDString, PermissionTracked)
                )
            )
            {
                return null;
            }

            RecordAction(player, "Command", command, string.Join(" ", args));
            UpdateAdminStats(player, "command", command);
            return null;
        }

        private void OnPlayerViolation(BasePlayer? player, AntiHackType type, float amount, BaseEntity? entity)
        {
            if (player?.IsAdmin != true)
            {
                return;
            }

            RecordAction(player, "Violation", $"{type}", $"Amount: {amount}");
        }

        private void OnEntityBuilt(Planner planner, GameObject go)
        {
            if (planner == null || go == null)
            {
                return;
            }

            BasePlayer? player = planner.GetOwnerPlayer();
            if (player?.IsAdmin != true)
            {
                return;
            }

            string objectName = go.name ?? "unknown";
            RecordAction(player, "Build", objectName, "");
        }

        private void OnEntityKill(BaseCombatEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            BasePlayer? lastAttacker = entity.lastAttacker as BasePlayer;
            if (lastAttacker?.IsAdmin != true)
            {
                return;
            }

            RecordAction(lastAttacker, "Destroy", entity.ShortPrefabName, "");
        }

        private void OnPlayerAttack(BasePlayer? attacker, HitInfo? info)
        {
            if (attacker?.IsAdmin != true)
            {
                return;
            }

            BasePlayer? victim = info?.HitEntity as BasePlayer;
            if (victim != null)
            {
                RecordAction(attacker, "Attack", "Player", victim.displayName);
            }
        }

        private void OnPlayerInput(BasePlayer player, InputState input)
        {
            if (
                player == null
                || input == null
                || (
                    !player.IsAdmin
                    && !permission.UserHasPermission(player.UserIDString, PermissionTracked)
                )
            )
            {
                return;
            }

            if (!activeActions.TryGetValue(player.userID, out HashSet<string> actions))
            {
                actions = new HashSet<string>();
                activeActions[player.userID] = actions;
            }

            // Отслеживаем нажатия клавиш
            if (input.WasJustPressed(BUTTON.FIRE_PRIMARY))
            {
                _ = actions.Add("combat");
            }
            if (input.WasJustPressed(BUTTON.FIRE_SECONDARY))
            {
                _ = actions.Add("combat");
            }
            if (input.WasJustPressed(BUTTON.USE))
            {
                _ = actions.Add("interaction");
            }
            if (input.WasJustPressed(BUTTON.SPRINT))
            {
                _ = actions.Add("movement");
            }

            // Очищаем действия через небольшую задержку
            _ = timer.Once(
                1f,
                () =>
                {
                    if (actions.Count > 0)
                    {
                        actions.Clear();
                    }
                }
            );
        }

        private void OnUserPermissionGranted(string id, string permName)
        {
            if (permName != PermissionTracked)
            {
                return;
            }

            BasePlayer? player = BasePlayer.Find(id);
            if (player == null)
            {
                return;
            }

            // Начинаем отслеживание только если игрок не является админом
            if (!player.IsAdmin)
            {
                StartMonitoring(player);
                LoadPlayerAvatar(player);
                SendReply(player, "Вы добавлены в систему мониторинга активности.");
            }
        }

        private void OnUserPermissionRevoked(string id, string permName)
        {
            if (permName != PermissionTracked)
            {
                return;
            }

            BasePlayer? player = BasePlayer.Find(id);
            if (player == null)
            {
                return;
            }

            // Останавливаем отслеживание только если игрок не является админом
            if (!player.IsAdmin)
            {
                StopMonitoring(player);
                SendReply(player, "Вы удалены из системы мониторинга активности.");
            }
        }
        #endregion Oxide Hooks

        #region Core Functions
        private void StartMonitoring(BasePlayer player)
        {
            if (
                player == null
                || (
                    !player.IsAdmin
                    && !permission.UserHasPermission(player.UserIDString, PermissionTracked)
                )
            )
            {
                return;
            }

            // Если уже отслеживается - не начинаем заново
            if (activeAdmins.ContainsKey(player.userID))
            {
                return;
            }

            activeAdmins[player.userID] = new()
            {
                SessionStartTime = Time.realtimeSinceStartup,
                LastActiveTime = Time.realtimeSinceStartup,
                LastPosition = player.transform.position,
                IsAfk = false,
            };
            lastPositions[player.userID] = player.transform.position;
            lastActionTimes[player.userID] = Time.realtimeSinceStartup;

            activityTimers[player.userID] = timer.Every(checkInterval, () => CheckActivity(player));

            if (
                storedData?.AdminStatistics != null
                && !storedData.AdminStatistics.ContainsKey(player.userID)
            )
            {
                storedData.AdminStatistics[player.userID] = new AdminStats
                {
                    LastName = player.displayName,
                    LastActive = DateTime.Now,
                };
            }

            RecordAction(player, "Login", "Session Start", "");
        }

        private void StopMonitoring(BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            if (activityTimers.TryGetValue(player.userID, out Timer timer))
            {
                timer.Destroy();
                _ = activityTimers.Remove(player.userID);
            }

            if (activeAdmins.ContainsKey(player.userID))
            {
                AdminActivity activity = activeAdmins[player.userID];
                float sessionTime =
                    Time.realtimeSinceStartup - activity.SessionStartTime - activity.TotalAfkTime;

                if (
                    storedData?.AdminStatistics != null
                    && storedData.AdminStatistics.TryGetValue(player.userID, out AdminStats stats)
                )
                {
                    stats.TotalActiveTime += sessionTime;
                    stats.TotalAfkTime += activity.TotalAfkTime;
                    stats.LastActive = DateTime.Now;
                }

                _ = activeAdmins.Remove(player.userID);
            }

            _ = lastPositions.Remove(player.userID);
            _ = lastActionTimes.Remove(player.userID);

            RecordAction(player, "Logout", "Session End", "");
            SaveData();
        }

        private void CheckActivity(BasePlayer player)
        {
            if (player?.IsConnected != true || !activeAdmins.ContainsKey(player.userID))
            {
                return;
            }

            AdminActivity activity = activeAdmins[player.userID];
            Vector3 currentPos = player.transform.position;
            Quaternion currentRot = player.eyes.rotation;
            float currentTime = Time.realtimeSinceStartup;

            // Проверяем различные типы активности
            bool hasMoved = Vector3.Distance(activity.LastPosition, currentPos) > MovementThreshold;
            bool hasRotated =
                Quaternion.Angle(
                    lastRotations.TryGetValue(player.userID, out Quaternion lastRot)
                        ? lastRot
                        : currentRot,
                    currentRot
                ) > RotationThreshold;
            bool hasActiveActions =
                activeActions.TryGetValue(player.userID, out HashSet<string> actions)
                && actions.Count > 0;
            bool isInInventory = player.inventory.loot.IsLooting();
            bool isInCrafting = player.inventory.crafting.queue.Count > 0;

            bool isActive =
                hasMoved || hasRotated || hasActiveActions || isInInventory || isInCrafting;

            if (!isActive)
            {
                if (
                    !activity.IsAfk
                    && (currentTime - activity.LastActiveTime) >= inactivityThreshold
                )
                {
                    // Игрок только что стал AFK
                    activity.IsAfk = true;
                    activity.AfkStartTime = currentTime;
                    RecordAction(
                        player,
                        "Status",
                        "AFK Start",
                        GetAfkReason(
                            hasMoved,
                            hasRotated,
                            hasActiveActions,
                            isInInventory,
                            isInCrafting
                        )
                    );
                    SendDiscordStatusChangeMessage(player, true);

                    // Отправляем уведомление игроку
                    SendReply(player, "Вы перешли в режим AFK");
                }
            }
            else if (activity.IsAfk)
            {
                // Игрок вернулся из AFK
                float afkDuration = currentTime - activity.AfkStartTime;
                activity.TotalAfkTime += afkDuration;
                activity.IsAfk = false;
                activity.LastActiveTime = currentTime;
                RecordAction(player, "Status", "AFK End", $"Duration: {afkDuration:F1}s");
                SendDiscordStatusChangeMessage(player, false, afkDuration);
                SendReply(
                    player,
                    $"Вы вернулись из AFK режима. Время отсутствия: {FormatTime(afkDuration)}"
                );
            }

            // Обновляем последние известные позиции и время активности
            if (isActive)
            {
                activity.LastActiveTime = currentTime;
            }

            activity.LastPosition = currentPos;
            lastRotations[player.userID] = currentRot;
        }

        private string GetAfkReason(
            bool hasMoved,
            bool hasRotated,
            bool hasActiveActions,
            bool isInInventory,
            bool isInCrafting
        )
        {
            List<string> reasons = new();

            if (!hasMoved && !hasRotated)
            {
                reasons.Add("отсутствие движения");
            }
            if (!hasActiveActions)
            {
                reasons.Add("нет активных действий");
            }
            if (!isInInventory && !isInCrafting)
            {
                reasons.Add("нет взаимодействия с инвентарем");
            }

            return string.Join(", ", reasons);
        }

        private void UpdateAdminStats(BasePlayer? player, string type, string detail)
        {
            if (player == null || storedData == null || player.displayName == null)
            {
                return;
            }

            string displayName = player.displayName;
            ulong userId = player.userID;

            if (!storedData.AdminStatistics.TryGetValue(userId, out AdminStats stats))
            {
                stats = new AdminStats
                {
                    LastName = displayName,
                    CommandsUsed = new Dictionary<string, int>(),
                    RecentActions = new List<AdminAction>(),
                };
                storedData.AdminStatistics[userId] = stats;
            }

            if (type == "command")
            {
                if (!stats.CommandsUsed.TryGetValue(detail, out int count))
                {
                    count = 0;
                }
                stats.CommandsUsed[detail] = count + 1;
            }

            stats.LastActive = DateTime.Now;
            SaveAdminData(userId);
        }

        private void RecordAction(
            BasePlayer? player,
            string actionType,
            string details,
            string target
        )
        {
            if (
                player == null
                || storedData == null
                || player.displayName == null
                || player.transform == null
            )
            {
                return;
            }

            string displayName = player.displayName;
            ulong userId = player.userID;
            Vector3 position = player.transform.position;

            if (!storedData.AdminStatistics.TryGetValue(userId, out AdminStats stats))
            {
                stats = new AdminStats
                {
                    LastName = displayName,
                    RecentActions = new List<AdminAction>(),
                };
                storedData.AdminStatistics[userId] = stats;
            }

            AdminAction action = new()
            {
                ActionType = actionType,
                Details = details,
                Target = target,
                Timestamp = DateTime.Now,
                Location = position,
            };

            stats.RecentActions.Add(action);

            while (stats.RecentActions.Count > 100)
            {
                stats.RecentActions.RemoveAt(0);
            }

            SaveAdminData(userId);
        }

        private void SaveAdminStats(BasePlayer player)
        {
            if (storedData == null)
            {
                return;
            }

            if (!storedData.AdminStatistics.TryGetValue(player.userID, out AdminStats stats))
            {
                return;
            }

            if (activeAdmins.TryGetValue(player.userID, out AdminActivity activity))
            {
                float currentTime = Time.realtimeSinceStartup;
                float sessionDuration = currentTime - activity.SessionStartTime;
                float totalAfkTime = activity.TotalAfkTime;

                // Если игрок был AFK в момент выхода, добавляем последнее время AFK
                if (activity.IsAfk)
                {
                    totalAfkTime += currentTime - activity.AfkStartTime;
                }

                float activeTime = sessionDuration - totalAfkTime;

                if (activeTime > 0)
                {
                    stats.TotalActiveTime += activeTime;
                    stats.CurrentWipeActiveTime += activeTime;
                }

                if (totalAfkTime > 0)
                {
                    stats.TotalAfkTime += totalAfkTime;
                    stats.CurrentWipeAfkTime += totalAfkTime;
                }
            }

            stats.LastActive = DateTime.Now;
            SaveAdminData(player.userID);
        }

        private void UpdateAllAdminStats()
        {
            if (storedData == null)
            {
                return;
            }

            float currentTime = Time.realtimeSinceStartup;

            // Обновляем статистику для всех активных администраторов
            foreach (KeyValuePair<ulong, AdminActivity> kvp in activeAdmins)
            {
                if (storedData.AdminStatistics.TryGetValue(kvp.Key, out AdminStats stats))
                {
                    float sessionDuration = currentTime - kvp.Value.SessionStartTime;
                    float afkTime = kvp.Value.TotalAfkTime;
                    float activeTime;
                    if (kvp.Value.IsAfk)
                    {
                        // Если админ сейчас AFK:
                        // 1. Считаем активное время до начала AFK
                        activeTime =
                            kvp.Value.AfkStartTime
                            - kvp.Value.SessionStartTime
                            - kvp.Value.TotalAfkTime;
                        // 2. Добавляем текущее время AFK
                        afkTime += currentTime - kvp.Value.AfkStartTime;
                    }
                    else
                    {
                        // Если админ активен:
                        // Считаем чистое активное время (общее время минус все время AFK)
                        activeTime = sessionDuration - afkTime;
                    }

                    // Обновляем статистику только если есть изменения
                    if (activeTime > 0)
                    {
                        stats.CurrentWipeActiveTime += activeTime;
                        stats.TotalActiveTime += activeTime;
                    }

                    if (afkTime > 0)
                    {
                        stats.CurrentWipeAfkTime += afkTime;
                        stats.TotalAfkTime += afkTime;
                    }

                    // Сбрасываем счетчики сессии
                    kvp.Value.SessionStartTime = currentTime;
                    kvp.Value.TotalAfkTime = 0;
                    if (kvp.Value.IsAfk)
                    {
                        kvp.Value.AfkStartTime = currentTime;
                    }
                }
            }
        }
        #endregion Core Functions

        #region Commands
        private void CmdAdminMonitor(BasePlayer player, string command, string[] args)
        {
            if (!permission.UserHasPermission(player.UserIDString, PermissionView))
            {
                SendReply(player, "У вас нет прав для использования этой команды.");
                return;
            }

            if (args.Length == 0)
            {
                ShowAdminList(player);
                return;
            }

            switch (args[0].ToLower(CultureInfo.CurrentCulture))
            {
                case "check":
                    if (args.Length < 2)
                    {
                        SendReply(player, "Использование: /amonitor check <имя/id>");
                        return;
                    }
                    CheckAdminStats(player, args[1]);
                    break;

                case "reset":
                    if (!permission.UserHasPermission(player.UserIDString, PermissionAdmin))
                    {
                        SendReply(player, "У вас нет прав для сброса статистики.");
                        return;
                    }
                    ResetStats();
                    SendReply(player, "Статистика администраторов сброшена.");
                    break;

                default:
                    SendReply(
                        player,
                        "Доступные команды:\n/amonitor - список администраторов\n/amonitor check <имя/id> - проверить статистику\n/amonitor reset - сбросить статистику"
                    );
                    break;
            }
        }

        [ConsoleCommand("amonitor.check")]
        private void CmdCheckAdmin(ConsoleSystem.Arg arg)
        {
            if (
                arg.Player() != null
                && !permission.UserHasPermission(arg.Player().UserIDString, PermissionView)
            )
            {
                arg.ReplyWith("У вас нет прав для использования этой команды.");
                return;
            }

            if (!arg.HasArgs())
            {
                arg.ReplyWith("Использование: amonitor.check <steamid>");
                return;
            }

            if (!ulong.TryParse(arg.GetString(0), out ulong targetId))
            {
                arg.ReplyWith("Неверный формат SteamID.");
                return;
            }

            if (storedData?.AdminStatistics == null)
            {
                arg.ReplyWith("Ошибка: база данных не инициализирована.");
                return;
            }

            if (!storedData.AdminStatistics.TryGetValue(targetId, out AdminStats stats))
            {
                arg.ReplyWith("Статистика для указанного администратора не найдена.");
                return;
            }

            StringBuilder reply = new();
            _ = reply.AppendLine($"Статистика администратора: {stats.LastName}");
            float totalActiveTime = stats.TotalActiveTime;
            float totalAfkTime = stats.TotalAfkTime;

            if (activeAdmins.TryGetValue(targetId, out AdminActivity activity))
            {
                float currentTime = Time.realtimeSinceStartup;

                if (activity.IsAfk)
                {
                    // Если админ сейчас AFK:
                    // 1. Добавляем активное время до начала AFK
                    float activeTimeBeforeAfk =
                        activity.AfkStartTime - activity.SessionStartTime - activity.TotalAfkTime;
                    if (activeTimeBeforeAfk > 0)
                    {
                        totalActiveTime += activeTimeBeforeAfk;
                    }
                    // 2. Добавляем текущее время AFK
                    float currentAfkTime = currentTime - activity.AfkStartTime;
                    if (currentAfkTime > 0)
                    {
                        totalAfkTime += activity.TotalAfkTime + currentAfkTime;
                    }
                }
                else
                {
                    // Если админ активен:
                    // 1. Добавляем только активное время текущей сессии
                    float sessionDuration = currentTime - activity.SessionStartTime;
                    float activeTimeInSession = sessionDuration - activity.TotalAfkTime;
                    if (activeTimeInSession > 0)
                    {
                        totalActiveTime += activeTimeInSession;
                    }
                    // 2. Добавляем только накопленное время AFK (без текущего времени, т.к. админ активен)
                    totalAfkTime += activity.TotalAfkTime;
                }
            }

            _ = reply.AppendLine($"Активное время: {FormatTime(totalActiveTime)}");
            _ = reply.AppendLine($"Время AFK: {FormatTime(totalAfkTime)}");
            _ = reply.AppendLine($"Последняя активность: {FormatDateTime(stats.LastActive)}");

            if (stats.CommandsUsed.Count > 0)
            {
                _ = reply.AppendLine("\nИспользованные команды:");
                foreach (
                    KeyValuePair<string, int> cmd in stats
                        .CommandsUsed.OrderByDescending(x => x.Value)
                        .Take(10)
                )
                {
                    _ = reply.AppendLine($"- {cmd.Key}: {cmd.Value} раз");
                }
            }

            if (stats.RecentActions.Count > 0)
            {
                _ = reply.AppendLine("\nПоследние действия:");
                foreach (AdminAction action in GetCachedRecentActions(targetId, stats, 5))
                {
                    _ = reply.AppendLine(
                        $"- [{action.Timestamp:HH:mm:ss}] {action.ActionType}: {action.Details} {(string.IsNullOrEmpty(action.Target) ? "" : $"-> {action.Target}")}"
                    );
                }
            }

            arg.ReplyWith(reply.ToString());
        }
        #endregion Commands

        #region Helper Functions
        private void ShowAdminList(BasePlayer player)
        {
            if (storedData == null)
            {
                return;
            }

            // Очищаем предыдущий таймер обновления UI если есть
            if (uiUpdateTimers.TryGetValue(player.userID, out Timer oldTimer))
            {
                oldTimer.Destroy();
                _ = uiUpdateTimers.Remove(player.userID);
            }

            // Создаем новый таймер для обновления UI каждую секунду
            uiUpdateTimers[player.userID] = timer.Every(
                1f,
                () =>
                {
                    if (!player.IsConnected)
                    {
                        if (uiUpdateTimers.TryGetValue(player.userID, out Timer timer))
                        {
                            timer.Destroy();
                            _ = uiUpdateTimers.Remove(player.userID);
                        }
                        return;
                    }

                    // Обновляем статистику перед обновлением UI
                    UpdateAllAdminStats();
                    // Обновляем UI
                    UpdateAdminListUI(player);
                }
            );

            // Показываем UI первый раз
            UpdateAllAdminStats();
            UpdateAdminListUI(player);
        }

        private void UpdateAdminListUI(BasePlayer player)
        {
            if (storedData == null || !player.IsConnected)
            {
                return;
            }

            UpdateAllAdminStats();
            _ = CuiHelper.DestroyUi(player, LayerMain);
            CuiElementContainer container = new();

            // Основная панель с размытым фоном и градиентом
            _ = container.Add(
                new CuiPanel
                {
                    CursorEnabled = true,
                    RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" },
                    Image =
                    {
                        Color = "0.235 0.227 0.204 0.95",
                        Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                    },
                },
                "Overlay",
                LayerMain
            );

            // Добавляем стильный градиентный фон
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" },
                    Image =
                    {
                        Color = "0.235 0.227 0.204 0.7",
                        Sprite = "assets/content/ui/ui.background.transparent.radial.psd",
                    },
                },
                LayerMain
            );

            // Центральная панель с тенью
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform =
                    {
                        AnchorMin = "0.5 0.5",
                        AnchorMax = "0.5 0.5",
                        OffsetMin = "-500 -350",
                        OffsetMax = "500 350",
                    },
                    Image = { Color = "0.322 0.306 0.286 0" },
                },
                LayerMain,
                LayerContent
            );

            // Стильный заголовок с информацией о вайпе
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0 0.92", AnchorMax = "1 1" },
                    Image =
                    {
                        Color = "0.235 0.227 0.204 0.95",
                        Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                    },
                },
                LayerContent,
                "Header"
            );

            // Добавляем статистику сервера
            int totalAdmins = storedData.AdminStatistics.Count;
            int onlineAdmins = storedData.AdminStatistics.Count(x =>
                BasePlayer.FindByID(x.Key)?.IsConnected == true
            );
            int afkAdmins = activeAdmins.Count(x => x.Value.IsAfk);

            _ = container.Add(
                new CuiLabel
                {
                    RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" },
                    Text =
                    {
                        Text =
                            "<size=24><color=#e67e22>⚡ Мониторинг администраторов ⚡</color></size>\n"
                            + $"<size=14>Вайп начался: <color=#3498db>{storedData.CurrentWipeStart:dd.MM.yyyy HH:mm}</color> | "
                            + $"Админов онлайн: <color=#2ecc71>{onlineAdmins}</color>/<color=#95a5a6>{totalAdmins}</color> | "
                            + $"AFK: <color=#e74c3c>{afkAdmins}</color></size>",
                        Font = "robotocondensed-bold.ttf",
                        Align = TextAnchor.MiddleCenter,
                    },
                },
                "Header"
            );

            // Панель фильтров с улучшенным дизайном
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.05 0.85", AnchorMax = "0.95 0.91" },
                    Image =
                    {
                        Color = "0.15 0.15 0.15 0.98",
                        Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                    },
                },
                LayerContent,
                "FilterPanel"
            );

            // Улучшенные кнопки фильтров с иконками
            AddFilterButton(
                container,
                "FilterPanel",
                "0.02 0.2",
                "0.15 0.8",
                "🔍 Все",
                FilterAll,
                player.userID.ToString()
            );
            AddFilterButton(
                container,
                "FilterPanel",
                "0.16 0.2",
                "0.29 0.8",
                "🟢 Онлайн",
                FilterOnline,
                player.userID.ToString()
            );
            AddFilterButton(
                container,
                "FilterPanel",
                "0.30 0.2",
                "0.43 0.8",
                "⭕ Оффлайн",
                FilterOffline,
                player.userID.ToString()
            );
            AddFilterButton(
                container,
                "FilterPanel",
                "0.44 0.2",
                "0.57 0.8",
                "💤 AFK",
                FilterAfk,
                player.userID.ToString()
            );

            // Кнопки сортировки с иконками
            AddFilterButton(
                container,
                "FilterPanel",
                "0.65 0.2",
                "0.78 0.8",
                "⏱ По активности",
                SortTimeActive,
                player.userID.ToString()
            );
            AddFilterButton(
                container,
                "FilterPanel",
                "0.79 0.2",
                "0.92 0.8",
                "⌛ По AFK",
                SortTimeAfk,
                player.userID.ToString()
            );

            // Получаем отфильтрованный список администраторов
            IEnumerable<KeyValuePair<ulong, AdminStats>> filteredAdmins = GetFilteredAdmins(
                player.userID.ToString(),
                storedData.AdminStatistics
            );

            // Список администраторов с улучшенными карточками
            float yOffset = 0.83f;
            foreach (KeyValuePair<ulong, AdminStats> admin in filteredAdmins)
            {
                BasePlayer? adminPlayer = BasePlayer.FindByID(admin.Key);
                bool isOnline = adminPlayer?.IsConnected == true;
                _ = activeAdmins.TryGetValue(admin.Key, out AdminActivity? currentActivity);

                string cardName = $"AdminCard_{admin.Key}";
                _ = container.Add(
                    new CuiPanel
                    {
                        RectTransform =
                        {
                            AnchorMin = $"0.05 {yOffset - 0.15}",
                            AnchorMax = $"0.95 {yOffset}",
                        },
                        Image =
                        {
                            Color = "0.15 0.15 0.15 0.98",
                            Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                        },
                    },
                    LayerContent,
                    cardName
                );

                // Добавляем подсветку для онлайн статуса
                string borderColor = isOnline ? "0.18 0.8 0.44 0.3" : "0.5 0.5 0.5 0.1";
                _ = container.Add(
                    new CuiPanel
                    {
                        RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" },
                        Image = { Color = borderColor },
                    },
                    cardName,
                    $"{cardName}_border"
                );

                // Аватар с улучшенной рамкой
                if (ImageLibrary != null && avatarUrls.TryGetValue(admin.Key, out string avatarId))
                {
                    string? avatarImage = ImageLibrary.Call("GetImage", avatarId) as string;
                    if (!string.IsNullOrEmpty(avatarImage))
                    {
                        // Фоновый круг для аватара
                        _ = container.Add(
                            new CuiPanel
                            {
                                RectTransform = { AnchorMin = "0.02 0.1", AnchorMax = "0.08 0.9" },
                                Image =
                                {
                                    Color = "0.2 0.2 0.2 1",
                                    Sprite = "assets/content/ui/ui.circle.psd",
                                },
                            },
                            cardName
                        );

                        // Аватар
                        container.Add(
                            new CuiElement
                            {
                                Parent = cardName,
                                Components =
                                {
                                    new CuiRawImageComponent
                                    {
                                        Png = avatarImage,
                                        Color = "1 1 1 1",
                                    },
                                    new CuiRectTransformComponent
                                    {
                                        AnchorMin = "0.02 0.1",
                                        AnchorMax = "0.08 0.9",
                                    },
                                },
                            }
                        );
                    }
                }

                // Информация об администраторе с трендами
                float currentSessionTime = 0f;
                float currentAfkTime = 0f;
                if (currentActivity != null)
                {
                    currentSessionTime =
                        Time.realtimeSinceStartup
                        - currentActivity.SessionStartTime
                        - currentActivity.TotalAfkTime;
                    currentAfkTime = currentActivity.TotalAfkTime;
                }

                float totalActiveTime =
                    admin.Value.CurrentWipeActiveTime + (isOnline ? currentSessionTime : 0);
                float totalAfkTime =
                    admin.Value.CurrentWipeAfkTime + (isOnline ? currentAfkTime : 0);
                float activePercentage =
                    (totalActiveTime + totalAfkTime) > 0
                        ? totalActiveTime / (totalActiveTime + totalAfkTime) * 100
                        : 0;

                // Добавляем тренд активности
                string trendIcon = GetActivityTrendIcon(admin.Value);
                string trendColor = GetActivityTrendColor(admin.Value);

                _ = container.Add(
                    new CuiLabel
                    {
                        RectTransform = { AnchorMin = "0.1 0.5", AnchorMax = "0.4 0.9" },
                        Text =
                        {
                            Text =
                                $"<size=16>{admin.Value.LastName}</size>\n<size=12><color={trendColor}>{trendIcon}</color></size>",
                            Font = "robotocondensed-bold.ttf",
                            Align = TextAnchor.MiddleLeft,
                        },
                    },
                    cardName
                );

                // Статус с иконкой
                string status = GetAdminStatus(isOnline, currentActivity);
                string statusIcon = GetStatusIcon(isOnline, currentActivity);
                string statusColor = GetStatusColor(isOnline, currentActivity);

                _ = container.Add(
                    new CuiLabel
                    {
                        RectTransform = { AnchorMin = "0.1 0.1", AnchorMax = "0.4 0.5" },
                        Text =
                        {
                            Text =
                                $"<size=14><color={statusColor}>{statusIcon} {status}</color></size>",
                            Font = "robotocondensed-regular.ttf",
                            Align = TextAnchor.MiddleLeft,
                        },
                    },
                    cardName
                );

                // Время активности с процентами
                _ = container.Add(
                    new CuiLabel
                    {
                        RectTransform = { AnchorMin = "0.45 0.5", AnchorMax = "0.7 0.9" },
                        Text =
                        {
                            Text =
                                $"<size=12>Активность</size>\n<size=14><color=#2ecc71>{GetCachedFormattedTime(admin.Key, totalActiveTime)}</color> ({activePercentage:F1}%)</size>",
                            Font = "robotocondensed-regular.ttf",
                            Align = TextAnchor.MiddleLeft,
                        },
                    },
                    cardName
                );

                // Время AFK с процентами
                float afkPercentage = 100 - activePercentage;
                _ = container.Add(
                    new CuiLabel
                    {
                        RectTransform = { AnchorMin = "0.75 0.5", AnchorMax = "0.95 0.9" },
                        Text =
                        {
                            Text =
                                $"<size=12>AFK</size>\n<size=14><color=#e74c3c>{GetCachedFormattedTime(admin.Key, totalAfkTime)}</color> ({afkPercentage:F1}%)</size>",
                            Font = "robotocondensed-regular.ttf",
                            Align = TextAnchor.MiddleLeft,
                        },
                    },
                    cardName
                );

                // Прогресс-бар с градиентом
                _ = container.Add(
                    new CuiPanel
                    {
                        RectTransform = { AnchorMin = "0 0", AnchorMax = "1 0.05" },
                        Image = { Color = "0.2 0.2 0.2 1" },
                    },
                    cardName,
                    $"{cardName}.progress"
                );

                if (activePercentage > 0)
                {
                    _ = container.Add(
                        new CuiPanel
                        {
                            RectTransform =
                            {
                                AnchorMin = "0 0",
                                AnchorMax = $"{activePercentage / 100} 1",
                            },
                            Image = { Color = "0.18 0.8 0.44 1" },
                        },
                        $"{cardName}.progress"
                    );
                }

                if (afkPercentage > 0)
                {
                    _ = container.Add(
                        new CuiPanel
                        {
                            RectTransform =
                            {
                                AnchorMin = $"{activePercentage / 100} 0",
                                AnchorMax = "1 1",
                            },
                            Image = { Color = "0.9 0.3 0.24 1" },
                        },
                        $"{cardName}.progress"
                    );
                }

                yOffset -= 0.17f;
            }

            // Добавляем кнопку закрытия
            _ = container.Add(
                new CuiButton
                {
                    RectTransform = { AnchorMin = "0.95 0.93", AnchorMax = "0.98 0.97" },
                    Button =
                    {
                        Color = "0.7 0.3 0.3 0.8",
                        Close = LayerMain,
                        Command = "adminmonitor.close",
                    },
                    Text =
                    {
                        Text = "✕",
                        Font = "robotocondensed-bold.ttf",
                        FontSize = 20,
                        Align = TextAnchor.MiddleCenter,
                    },
                },
                LayerContent
            );

            _ = CuiHelper.AddUi(player, container);
        }

        private void AddFilterButton(
            CuiElementContainer container,
            string parent,
            string anchorMin,
            string anchorMax,
            string text,
            string filterType,
            string userId
        )
        {
            _ = container.Add(
                new CuiButton
                {
                    RectTransform = { AnchorMin = anchorMin, AnchorMax = anchorMax },
                    Button =
                    {
                        Color = GetFilterButtonColor(userId, filterType),
                        Command = $"adminmonitor.filter status {filterType}",
                    },
                    Text =
                    {
                        Text = text,
                        Font = "robotocondensed-regular.ttf",
                        FontSize = 12,
                        Align = TextAnchor.MiddleCenter,
                    },
                },
                parent
            );
        }

        private string GetActivityTrendIcon(AdminStats stats)
        {
            // Анализируем тренд активности за последние 24 часа
            DateTime now = DateTime.Now;
            DateTime yesterday = now.AddDays(-1);

            int recentActions = stats.RecentActions.Count(a => a.Timestamp >= yesterday);
            int previousActions = stats.RecentActions.Count(a =>
                a.Timestamp >= yesterday.AddDays(-1) && a.Timestamp < yesterday
            );

            // Разбиваем сложное тернарное выражение на простые условия
            if (recentActions > previousActions)
            {
                // Разбиваем сложное тернарное выражение на простые условия
                return "↑";
            }
            else if (recentActions < previousActions)
            {
                // Разбиваем сложное тернарное выражение на простые условия
                return "↓";
            }
            else
            {
                // Разбиваем сложное тернарное выражение на простые условия
                return "→";
            }
        }

        private string GetActivityTrendColor(AdminStats stats)
        {
            return GetActivityTrendIcon(stats) switch
            {
                "↑" => "#2ecc71",
                "↓" => "#e74c3c",
                _ => "#95a5a6",
            };
        }

        private string GetStatusIcon(bool isOnline, AdminActivity? activity)
        {
            // Разбиваем сложное тернарное выражение на простые условия
            if (!isOnline)
            {
                // Разбиваем сложное тернарное выражение на простые условия
                return "⭕";
            }
            else if (activity?.IsAfk == true)
            {
                // Разбиваем сложное тернарное выражение на простые условия
                return "💤";
            }
            else
            {
                // Разбиваем сложное тернарное выражение на простые условия
                return "🟢";
            }
        }

        private void CheckAdminStats(BasePlayer player, string target)
        {
            if (storedData == null)
            {
                return;
            }

            BasePlayer? targetPlayer = BasePlayer.Find(target);
            if (targetPlayer == null)
            {
                SendReply(player, "Игрок не найден.");
                return;
            }

            if (!storedData.AdminStatistics.ContainsKey(targetPlayer.userID))
            {
                SendReply(player, "Статистика для указанного игрока не найдена.");
                return;
            }

            // Очищаем предыдущий таймер обновления UI если есть
            if (uiUpdateTimers.TryGetValue(player.userID, out Timer oldTimer))
            {
                oldTimer.Destroy();
                _ = uiUpdateTimers.Remove(player.userID);
            }

            // Создаем новый таймер для обновления UI каждую секунду
            uiUpdateTimers[player.userID] = timer.Every(
                1f,
                () =>
                {
                    if (!player.IsConnected)
                    {
                        if (uiUpdateTimers.TryGetValue(player.userID, out Timer timer))
                        {
                            timer.Destroy();
                            _ = uiUpdateTimers.Remove(player.userID);
                        }
                        return;
                    }
                    UpdateAdminStatsUI(player, targetPlayer);
                }
            );

            // Показываем UI первый раз
            UpdateAdminStatsUI(player, targetPlayer);
        }

        private void UpdateAdminStatsUI(BasePlayer player, BasePlayer targetPlayer)
        {
            if (
                storedData == null
                || !player.IsConnected
                || !storedData.AdminStatistics.TryGetValue(
                    targetPlayer.userID,
                    out AdminStats stats
                )
            )
            {
                CleanupUI(player);
                return;
            }

            CuiElementContainer container = CreateBaseContainer();

            // Создаем основную панель с новым дизайном
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.1 0.1", AnchorMax = "0.9 0.9" },
                    Image = { Color = "0.235 0.227 0.204 1" }, // #3c3a34
                },
                LayerMain,
                LayerContent
            );

            // Верхняя панель с информацией об админе
            CreateHeaderPanel(container, targetPlayer, stats);

            // Создаем две колонки для симметричного расположения
            // Левая колонка
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.02 0.45", AnchorMax = "0.49 0.83" },
                    Image = { Color = "0.322 0.306 0.286 1" }, // #524e49
                },
                LayerContent,
                "LeftColumn"
            );

            // Правая колонка
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.51 0.45", AnchorMax = "0.98 0.83" },
                    Image = { Color = "0.322 0.306 0.286 1" }, // #524e49
                },
                LayerContent,
                "RightColumn"
            );

            // Нижняя панель на всю ширину
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.02 0.02", AnchorMax = "0.98 0.43" },
                    Image = { Color = "0.322 0.306 0.286 1" }, // #524e49
                },
                LayerContent,
                "BottomPanel"
            );

            // Заполняем контент
            CreateStatisticsPanel(container, targetPlayer, stats, "LeftColumn");
            CreateActivityPanel(container, stats, "RightColumn");
            CreateTimelinePanel(container, stats, "BottomPanel");

            // Кнопка закрытия
            _ = container.Add(
                new CuiButton
                {
                    RectTransform = { AnchorMin = "0.94 0.85", AnchorMax = "0.98 0.89" },
                    Button =
                    {
                        Color = "0.7 0.3 0.3 0.8",
                        Close = LayerMain,
                        Command = "adminmonitor.close",
                    },
                    Text =
                    {
                        Text = "✕",
                        Font = "robotocondensed-bold.ttf",
                        FontSize = 20,
                        Align = TextAnchor.MiddleCenter,
                    },
                },
                LayerContent
            );

            _ = CuiHelper.DestroyUi(player, LayerMain);
            _ = CuiHelper.AddUi(player, container);
        }

        private void CreateHeaderPanel(
            CuiElementContainer container,
            BasePlayer targetPlayer,
            AdminStats stats
        )
        {
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.02 0.85", AnchorMax = "0.98 0.98" },
                    Image = { Color = "0.322 0.306 0.286 1" },
                },
                LayerContent,
                "HeaderPanel"
            );

            // Аватар с круглой рамкой
            if (
                ImageLibrary != null
                && avatarUrls.TryGetValue(targetPlayer.userID, out string avatarId)
            )
            {
                string? avatarImage = ImageLibrary.Call("GetImage", avatarId) as string;
                if (!string.IsNullOrEmpty(avatarImage))
                {
                    // Фоновый круг
                    _ = container.Add(
                        new CuiPanel
                        {
                            RectTransform = { AnchorMin = "0.02 0.1", AnchorMax = "0.12 0.9" },
                            Image =
                            {
                                Color = "0.235 0.227 0.204 1",
                                Sprite = "assets/content/ui/ui.circle.psd",
                            },
                        },
                        "HeaderPanel",
                        "AvatarBackground"
                    );

                    // Аватар
                    container.Add(
                        new CuiElement
                        {
                            Parent = "AvatarBackground",
                            Components =
                            {
                                new CuiRawImageComponent { Png = avatarImage, Color = "1 1 1 1" },
                                new CuiRectTransformComponent
                                {
                                    AnchorMin = "0.1 0.1",
                                    AnchorMax = "0.9 0.9",
                                },
                            },
                        }
                    );
                }
            }

            bool isOnline = targetPlayer.IsConnected;
            _ = activeAdmins.TryGetValue(targetPlayer.userID, out AdminActivity? currentActivity);

            // Информация об админе с улучшенным форматированием
            _ = container.Add(
                new CuiLabel
                {
                    RectTransform = { AnchorMin = "0.14 0", AnchorMax = "0.98 1" },
                    Text =
                    {
                        Text =
                            $"<size=24><color=#{ColorToHex(0.902f, 0.494f, 0.133f)}>{stats.LastName}</color></size>\n"
                            + $"<size=14><color=#{ColorToHex(0.584f, 0.647f, 0.651f)}>SteamID:</color> <color=#{ColorToHex(0.18f, 0.8f, 0.44f)}>{targetPlayer.UserIDString}</color> | "
                            + $"<color=#{ColorToHex(0.584f, 0.647f, 0.651f)}>Статус:</color> <color={GetStatusColor(isOnline, currentActivity)}>{GetStatusIcon(isOnline, currentActivity)} {GetAdminStatus(isOnline, currentActivity)}</color> | "
                            + $"<color=#{ColorToHex(0.584f, 0.647f, 0.651f)}>Последняя активность:</color> <color=#{ColorToHex(0.18f, 0.8f, 0.44f)}>{FormatDateTime(stats.LastActive)}</color></size>",
                        Font = "robotocondensed-bold.ttf",
                        Align = TextAnchor.MiddleLeft,
                    },
                },
                "HeaderPanel"
            );
        }

        private string ColorToHex(float r, float g, float b)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0:X2}{1:X2}{2:X2}",
                (int)(r * 255),
                (int)(g * 255),
                (int)(b * 255)
            );
        }

        private void CreateStatisticsPanel(
            CuiElementContainer container,
            BasePlayer targetPlayer,
            AdminStats stats,
            string parent
        )
        {
            // Заголовок
            _ = container.Add(
                new CuiLabel
                {
                    RectTransform = { AnchorMin = "0.05 0.85", AnchorMax = "0.95 0.95" },
                    Text =
                    {
                        Text =
                            $"<size=18><color=#{ColorToHex(0.902f, 0.494f, 0.133f)}>📊 Общая статистика</color></size>",
                        Font = "robotocondensed-bold.ttf",
                        Align = TextAnchor.MiddleCenter,
                    },
                },
                parent
            );

            float currentSessionTime = 0f;
            float currentAfkTime = 0f;
            if (activeAdmins.TryGetValue(targetPlayer.userID, out AdminActivity? currentActivity))
            {
                currentSessionTime =
                    Time.realtimeSinceStartup
                    - currentActivity.SessionStartTime
                    - currentActivity.TotalAfkTime;
                currentAfkTime = currentActivity.TotalAfkTime;
            }

            float totalActiveTime =
                stats.CurrentWipeActiveTime + (targetPlayer.IsConnected ? currentSessionTime : 0);
            float totalAfkTime =
                stats.CurrentWipeAfkTime + (targetPlayer.IsConnected ? currentAfkTime : 0);
            float activePercentage =
                (totalActiveTime + totalAfkTime) > 0
                    ? totalActiveTime / (totalActiveTime + totalAfkTime) * 100
                    : 0;

            // Круговая диаграмма
            CreateActivityPieChart(container, parent, activePercentage);

            // Статистика с иконками
            string timeStats =
                "<size=14>\n"
                + "<color=#95a5a6>За все время:</color>\n"
                + $"⏱ Активность: <color=#2ecc71>{FormatTime(stats.TotalActiveTime)}</color>\n"
                + $"💤 AFK: <color=#e74c3c>{FormatTime(stats.TotalAfkTime)}</color>\n\n"
                + "<color=#95a5a6>Текущий вайп:</color>\n"
                + $"⏱ Активность: <color=#2ecc71>{FormatTime(totalActiveTime)}</color>\n"
                + $"💤 AFK: <color=#e74c3c>{FormatTime(totalAfkTime)}</color>\n"
                + $"📈 Эффективность: <color=#f1c40f>{activePercentage:F1}%</color></size>";

            _ = container.Add(
                new CuiLabel
                {
                    RectTransform = { AnchorMin = "0.4 0.1", AnchorMax = "0.95 0.8" },
                    Text =
                    {
                        Text = timeStats,
                        Font = "robotocondensed-regular.ttf",
                        Align = TextAnchor.UpperLeft,
                    },
                },
                parent
            );
        }

        private void CreateActivityPanel(
            CuiElementContainer container,
            AdminStats stats,
            string parent
        )
        {
            // Заголовок
            _ = container.Add(
                new CuiLabel
                {
                    RectTransform = { AnchorMin = "0.05 0.85", AnchorMax = "0.95 0.95" },
                    Text =
                    {
                        Text =
                            $"<size=18><color=#{ColorToHex(0.902f, 0.494f, 0.133f)}>🎯 Активность за 24 часа</color></size>",
                        Font = "robotocondensed-bold.ttf",
                        Align = TextAnchor.MiddleCenter,
                    },
                },
                parent
            );

            Dictionary<string, int> actionGroups = stats
                .RecentActions.Where(a => a.Timestamp >= DateTime.Now.AddDays(-1))
                .GroupBy(a => a.ActionType)
                .ToDictionary(g => g.Key, g => g.Count());

            int totalCommands = stats.CommandsUsed.Values.Sum();
            int buildActions = actionGroups.GetValueOrDefault("Build");
            int destroyActions = actionGroups.GetValueOrDefault("Destroy");
            int violations = actionGroups.GetValueOrDefault("Violation");
            int playerInteractions = actionGroups.GetValueOrDefault("Attack");

            string actionStats =
                "<size=14>\n"
                + $"⌨️ Команд: <color=#{ColorToHex(0.18f, 0.8f, 0.44f)}>{totalCommands}</color>\n"
                + $"🏗️ Построено: <color=#{ColorToHex(0.18f, 0.8f, 0.44f)}>{buildActions}</color>\n"
                + $"💥 Уничтожено: <color=#{ColorToHex(0.902f, 0.494f, 0.133f)}>{destroyActions}</color>\n"
                + $"👥 Взаимодействий: <color=#{ColorToHex(0.18f, 0.8f, 0.44f)}>{playerInteractions}</color>\n"
                + $"⚠️ Нарушений: <color=#{ColorToHex(0.905f, 0.298f, 0.235f)}>{violations}</color></size>";

            _ = container.Add(
                new CuiLabel
                {
                    RectTransform = { AnchorMin = "0.05 0.1", AnchorMax = "0.95 0.8" },
                    Text =
                    {
                        Text = actionStats,
                        Font = "robotocondensed-regular.ttf",
                        Align = TextAnchor.UpperLeft,
                    },
                },
                parent
            );
        }

        private void CreateTimelinePanel(
            CuiElementContainer container,
            AdminStats stats,
            string parent
        )
        {
            // Заголовок
            _ = container.Add(
                new CuiLabel
                {
                    RectTransform = { AnchorMin = "0.05 0.9", AnchorMax = "0.95 1" },
                    Text =
                    {
                        Text =
                            $"<size=18><color=#{ColorToHex(0.902f, 0.494f, 0.133f)}>📅 История действий</color></size>",
                        Font = "robotocondensed-bold.ttf",
                        Align = TextAnchor.MiddleCenter,
                    },
                },
                parent
            );

            // График активности
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.02 0.45", AnchorMax = "0.98 0.85" },
                    Image = { Color = "0.235 0.227 0.204 0.8" },
                },
                parent,
                "GraphPanel"
            );

            AddActivityGraph(container, "GraphPanel", stats);

            // Последние действия
            CreateRecentActionsList(container, parent, stats);
        }

        private void CreateActivityPieChart(
            CuiElementContainer container,
            string parent,
            float activePercentage
        )
        {
            const float centerX = 0.2f;
            const float centerY = 0.5f;
            const float radius = 0.15f;

            // Фоновый круг (AFK)
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform =
                    {
                        AnchorMin = $"{centerX - radius} {centerY - radius}",
                        AnchorMax = $"{centerX + radius} {centerY + radius}",
                    },
                    Image =
                    {
                        Color = "0.905 0.298 0.235 0.8",
                        Sprite = "assets/content/ui/ui.circle.psd",
                    },
                },
                parent,
                "PieChart"
            );

            // Активный сегмент
            if (activePercentage > 0)
            {
                _ = container.Add(
                    new CuiPanel
                    {
                        RectTransform =
                        {
                            AnchorMin = $"{centerX - radius} {centerY - radius}",
                            AnchorMax = $"{centerX + radius} {centerY + radius}",
                        },
                        Image =
                        {
                            Color = "0.18 0.8 0.44 0.8",
                            Sprite = "assets/content/ui/ui.circle.psd",
                        },
                    },
                    "PieChart"
                );
            }

            // Процент в центре
            _ = container.Add(
                new CuiLabel
                {
                    RectTransform =
                    {
                        AnchorMin = $"{centerX - radius} {centerY - radius}",
                        AnchorMax = $"{centerX + radius} {centerY + radius}",
                    },
                    Text =
                    {
                        Text =
                            $"<size=20>{activePercentage:F0}%</size>\n<size=12>Активность</size>",
                        Font = "robotocondensed-bold.ttf",
                        Align = TextAnchor.MiddleCenter,
                        Color = "1 1 1 1",
                    },
                },
                "PieChart"
            );
        }

        private void CreateRecentActionsList(
            CuiElementContainer container,
            string parent,
            AdminStats stats
        )
        {
            // Находим userId по LastName
            ulong userId =
                storedData
                    ?.AdminStatistics.FirstOrDefault(x => x.Value.LastName == stats.LastName)
                    .Key ?? 0;

            List<AdminAction> recentActions = GetCachedRecentActions(userId, stats, 5);
            const float startYOffset = 0.35f;
            const float itemHeight = 0.08f;
            float currentYOffset = startYOffset;

            foreach (AdminAction action in recentActions.OrderByDescending(a => a.Timestamp))
            {
                string actionColor = GetActionColor(action.ActionType);
                string targetInfo = string.IsNullOrEmpty(action.Target)
                    ? ""
                    : $" → <color=#{ColorToHex(0.584f, 0.647f, 0.651f)}>{action.Target}</color>";
                string locationInfo =
                    $"<color=#{ColorToHex(0.584f, 0.647f, 0.651f)}>({Math.Round(action.Location.x)}, {Math.Round(action.Location.y)}, {Math.Round(action.Location.z)})</color>";

                _ = container.Add(
                    new CuiPanel
                    {
                        RectTransform =
                        {
                            AnchorMin = $"0.02 {currentYOffset}",
                            AnchorMax = $"0.98 {currentYOffset + itemHeight}",
                        },
                        Image = { Color = "0.235 0.227 0.204 0.5" },
                    },
                    parent,
                    $"Action_{action.Timestamp.Ticks}"
                );

                _ = container.Add(
                    new CuiLabel
                    {
                        RectTransform = { AnchorMin = "0.02 0", AnchorMax = "0.98 1" },
                        Text =
                        {
                            Text =
                                $"<color=#{ColorToHex(0.584f, 0.647f, 0.651f)}>[{action.Timestamp:HH:mm:ss}]</color> "
                                + $"<color={actionColor}>{action.ActionType}</color>: {action.Details}{targetInfo} {locationInfo}",
                            Font = "robotocondensed-regular.ttf",
                            FontSize = 12,
                            Align = TextAnchor.MiddleLeft,
                        },
                    },
                    $"Action_{action.Timestamp.Ticks}"
                );

                currentYOffset -= itemHeight + 0.01f;
            }
        }

        private void CleanupUI(BasePlayer player)
        {
            if (uiUpdateTimers.TryGetValue(player.userID, out Timer timer))
            {
                timer.Destroy();
                _ = uiUpdateTimers.Remove(player.userID);
            }
            _ = CuiHelper.DestroyUi(player, LayerMain);
        }

        private void AddActivityGraph(
            CuiElementContainer container,
            string parent,
            AdminStats stats
        )
        {
            const int hoursToShow = 24;
            const float graphHeight = 0.7f;
            const float graphWidth = 0.9f;
            const float startX = 0.05f;
            const float startY = 0.1f;

            // Получаем данные активности по часам
            Dictionary<int, int> hourlyActivity = new();
            DateTime now = DateTime.Now;

            // Используем явный тип вместо var
            IEnumerable<int> actionHours = stats
                .RecentActions.Where(a => (now - a.Timestamp).TotalHours <= hoursToShow)
                .Select(a => a.Timestamp.Hour);

            foreach (int hour in actionHours)
            {
                if (!hourlyActivity.TryGetValue(hour, out int value))
                {
                    value = 0;
                }
                hourlyActivity[hour] = value + 1;
            }

            // Находим максимальное количество действий в час
            int maxActions = hourlyActivity.Values.Count > 0 ? hourlyActivity.Values.Max() : 1;

            // Рисуем оси
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform =
                    {
                        AnchorMin = $"{startX} {startY}",
                        AnchorMax = $"{startX + 0.01f} {startY + graphHeight}",
                    },
                    Image = { Color = "0.3 0.3 0.3 1" },
                },
                parent
            );

            _ = container.Add(
                new CuiPanel
                {
                    RectTransform =
                    {
                        AnchorMin = $"{startX} {startY}",
                        AnchorMax = $"{startX + graphWidth} {startY + 0.01f}",
                    },
                    Image = { Color = "0.3 0.3 0.3 1" },
                },
                parent
            );

            // Рисуем столбцы графика
            const float barWidth = graphWidth / hoursToShow;
            for (int i = 0; i < hoursToShow; i++)
            {
                int hour = (now.Hour - (hoursToShow - 1) + i + 24) % 24;
                int actions = hourlyActivity.TryGetValue(hour, out int value) ? value : 0;
                float barHeight = actions * (graphHeight / maxActions);

                if (barHeight > 0)
                {
                    _ = container.Add(
                        new CuiPanel
                        {
                            RectTransform =
                            {
                                AnchorMin = $"{startX + (i * barWidth)} {startY}",
                                AnchorMax =
                                    $"{startX + ((i + 1) * barWidth) - 0.005f} {startY + barHeight}",
                            },
                            Image = { Color = "0.18 0.8 0.44 0.8" },
                        },
                        parent
                    );
                }

                // Добавляем метки времени
                if (i % 4 == 0)
                {
                    _ = container.Add(
                        new CuiLabel
                        {
                            RectTransform =
                            {
                                AnchorMin = $"{startX + (i * barWidth)} {startY - 0.05f}",
                                AnchorMax = $"{startX + ((i + 1) * barWidth)} {startY}",
                            },
                            Text =
                            {
                                Text = $"{hour:00}:00",
                                Font = "robotocondensed-regular.ttf",
                                FontSize = 10,
                                Align = TextAnchor.MiddleCenter,
                                Color = "0.7 0.7 0.7 1",
                            },
                        },
                        parent
                    );
                }
            }
        }

        private string GetAdminStatus(bool isOnline, AdminActivity? activity)
        {
            if (!isOnline)
            {
                return "Оффлайн";
            }

            bool isAfk = activity?.IsAfk ?? false;
            return isAfk ? "AFK" : "Активен";
        }

        private string GetStatusColor(bool isOnline, AdminActivity? activity)
        {
            if (!isOnline)
            {
                return "0.584 0.647 0.651"; // Secondary text color
            }

            bool isAfk = activity?.IsAfk ?? false;
            return isAfk ? "0.905 0.298 0.235" : "0.18 0.8 0.44"; // Warning/Error or Primary color
        }

        private string GetActionColor(string actionType)
        {
            return actionType.ToLower(CultureInfo.CurrentCulture) switch
            {
                "attack" => "0.905 0.298 0.235", // Warning/Error
                "build" => "0.18 0.8 0.44", // Primary
                "destroy" => "0.902 0.494 0.133", // Secondary
                "command" => "0.18 0.8 0.44", // Primary
                "violation" => "0.905 0.298 0.235", // Warning/Error
                "login" => "0.18 0.8 0.44", // Primary
                "logout" => "0.584 0.647 0.651", // Secondary text
                "status" => "0.18 0.8 0.44", // Primary
                _ => "0.584 0.647 0.651", // Secondary text
            };
        }

        private void ResetStats()
        {
            if (storedData == null)
            {
                return;
            }
            storedData.AdminStatistics.Clear();
            SaveData();
        }

        private string FormatTime(float seconds)
        {
            if (seconds < 0)
            {
                return "0 секунд";
            }

            TimeSpan time = TimeSpan.FromSeconds(seconds);
            List<string> parts = new();

            if (time.Days > 0)
            {
                parts.Add($"{time.Days} {GetDayString(time.Days)}");
            }

            if (time.Hours > 0 || time.Days > 0)
            {
                parts.Add($"{time.Hours} {GetHourString(time.Hours)}");
            }

            if (time.Minutes > 0 || (time.Hours == 0 && time.Days == 0))
            {
                parts.Add($"{time.Minutes} {GetMinuteString(time.Minutes)}");
            }

            if (time.Hours == 0 && time.Days == 0)
            {
                parts.Add($"{time.Seconds} {GetSecondString(time.Seconds)}");
            }

            return string.Join(" ", parts);
        }

        private static string GetDayString(int days)
        {
            return days is >= 11 and <= 19
                ? "дней"
                : (days % 10) switch
                {
                    1 => "день",
                    2 or 3 or 4 => "дня",
                    _ => "дней",
                };
        }

        private static string GetHourString(int hours)
        {
            return hours is >= 11 and <= 19
                ? "часов"
                : (hours % 10) switch
                {
                    1 => "час",
                    2 or 3 or 4 => "часа",
                    _ => "часов",
                };
        }

        private static string GetMinuteString(int minutes)
        {
            return minutes is >= 11 and <= 19
                ? "минут"
                : (minutes % 10) switch
                {
                    1 => "минута",
                    2 or 3 or 4 => "минуты",
                    _ => "минут",
                };
        }

        private static string GetSecondString(int seconds)
        {
            return seconds is >= 11 and <= 19
                ? "секунд"
                : (seconds % 10) switch
                {
                    1 => "секунда",
                    2 or 3 or 4 => "секунды",
                    _ => "секунд",
                };
        }

        private string FormatDateTime(DateTime dateTime)
        {
            CultureInfo culture = new("ru-RU");
            TimeSpan timePassed = DateTime.UtcNow - dateTime.ToUniversalTime();

            if (timePassed.TotalMinutes < 1)
            {
                return "только что";
            }
            if (timePassed.TotalHours < 1)
            {
                int minutes = (int)timePassed.TotalMinutes;
                return $"{minutes} {GetMinuteString(minutes)} назад";
            }
            if (timePassed.TotalDays < 1)
            {
                int hours = (int)timePassed.TotalHours;
                return $"{hours} {GetHourString(hours)} назад";
            }
            if (timePassed.TotalDays < 7)
            {
                int days = (int)timePassed.TotalDays;
                return $"{days} {GetDayString(days)} назад";
            }

            return dateTime.ToString("dd.MM.yyyy HH:mm", culture);
        }

        private void LoadPlayerAvatar(BasePlayer player)
        {
            if (ImageLibrary == null || player == null)
            {
                return;
            }

            string steamId = player.UserIDString;
            if (ImageLibrary.Call("HasImage", steamId, player.userID) == null)
            {
                _ = ImageLibrary.Call("AddImage", null, steamId, player.userID);
            }
            avatarUrls[player.userID] = steamId;
        }

        private void Unload()
        {
            // Очищаем все таймеры при выгрузке плагина
            foreach (Timer timer in uiUpdateTimers.Values)
            {
                timer.Destroy();
            }
            uiUpdateTimers.Clear();

            foreach (Timer timer in activityTimers.Values)
            {
                timer.Destroy();
            }
            activityTimers.Clear();

            // Save all data before unloading
            UpdateAllAdminStats();
            SaveData();
        }

        /// <summary>
        /// Закрывает UI и очищает все связанные с ним таймеры
        /// </summary>
        /// <param name="arg">Аргументы команды</param>
        [ConsoleCommand("adminmonitor.close")]
        private void CloseUI(ConsoleSystem.Arg arg)
        {
            BasePlayer? player = arg.Player();
            if (player == null)
            {
                return;
            }

            // Очищаем таймер обновления UI
            if (uiUpdateTimers.TryGetValue(player.userID, out Timer timer))
            {
                timer.Destroy();
                _ = uiUpdateTimers.Remove(player.userID);
            }

            // Уничтожаем UI
            _ = CuiHelper.DestroyUi(player, LayerMain);
        }

        private string GetCachedFormattedTime(ulong userId, float seconds)
        {
            float totalSeconds = seconds;

            // Если игрок активен, добавляем текущее время сессии
            if (activeAdmins.TryGetValue(userId, out AdminActivity activity))
            {
                float currentTime = Time.realtimeSinceStartup;

                if (activity.IsAfk)
                {
                    // Если в AFK:
                    // 1. Считаем активное время до начала AFK
                    float activeTimeBeforeAfk =
                        activity.AfkStartTime - activity.SessionStartTime - activity.TotalAfkTime;
                    if (activeTimeBeforeAfk > 0)
                    {
                        totalSeconds += activeTimeBeforeAfk;
                    }
                }
                else
                {
                    // Если активен:
                    // 1. Считаем общую продолжительность сессии
                    float sessionDuration = currentTime - activity.SessionStartTime;
                    // 2. Вычитаем все время AFK
                    float activeTimeInSession = sessionDuration - activity.TotalAfkTime;
                    if (activeTimeInSession > 0)
                    {
                        totalSeconds += activeTimeInSession;
                    }
                }
            }

            return FormatTime(totalSeconds);
        }

        private List<AdminAction> GetCachedRecentActions(ulong userId, AdminStats stats, int count)
        {
            if (
                recentActionsCache.TryGetValue(userId, out List<AdminAction> cachedActions)
                && lastActionsCacheUpdate.TryGetValue(userId, out DateTime lastUpdate)
                && (DateTime.UtcNow - lastUpdate) < actionsCacheExpiration
            )
            {
                return cachedActions.TakeLast(count).ToList();
            }

            List<AdminAction> actions = stats.RecentActions.TakeLast(count).ToList();
            recentActionsCache[userId] = actions;
            lastActionsCacheUpdate[userId] = DateTime.UtcNow;
            return actions;
        }

        private string GetFilterButtonColor(string userId, string filterType)
        {
            string key = $"{userId}_{filterType}";
            return
                filterSettings.TryGetValue(key, out string currentFilter)
                && currentFilter == filterType
                ? "0.18 0.8 0.44 1" // Active state - Primary color
                : "0.322 0.306 0.286 1"; // Inactive state - Panel background
        }

        private List<KeyValuePair<ulong, AdminStats>> GetFilteredAdmins(
            string userId,
            Dictionary<ulong, AdminStats> admins
        )
        {
            IEnumerable<KeyValuePair<ulong, AdminStats>> query = admins.AsEnumerable();

            // Применяем фильтр по статусу
            string statusKey = $"{userId}_status";
            if (filterSettings.TryGetValue(statusKey, out string statusFilter))
            {
                query = statusFilter switch
                {
                    FilterOnline => query.Where(x =>
                        BasePlayer.FindByID(x.Key)?.IsConnected == true
                    ),
                    FilterOffline => query.Where(x =>
                        BasePlayer.FindByID(x.Key)?.IsConnected != true
                    ),
                    FilterAfk => query.Where(x =>
                        activeAdmins.TryGetValue(x.Key, out AdminActivity? activity)
                        && activity.IsAfk
                    ),
                    _ => query,
                };
            }

            // Применяем поиск по имени
            string searchKey = $"{userId}_search";
            if (
                filterSettings.TryGetValue(searchKey, out string searchText)
                && !string.IsNullOrEmpty(searchText)
            )
            {
                query = query.Where(x =>
                    x.Value.LastName.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Применяем сортировку
            string sortKey = $"{userId}_sort";
            if (filterSettings.TryGetValue(sortKey, out string sortType))
            {
                query = sortType switch
                {
                    SortTimeActive => query.OrderByDescending(x => x.Value.CurrentWipeActiveTime),
                    SortTimeAfk => query.OrderByDescending(x => x.Value.CurrentWipeAfkTime),
                    SortName => query.OrderBy(x => x.Value.LastName),
                    _ => query,
                };
            }

            return query.ToList();
        }

        [ConsoleCommand("adminmonitor.filter")]
        private void CmdFilter(ConsoleSystem.Arg arg)
        {
            BasePlayer? player = arg.Player();
            if (
                player == null
                || !permission.UserHasPermission(player.UserIDString, PermissionView)
            )
            {
                return;
            }

            string filterType = arg.GetString(0);
            string value = arg.GetString(1);
            string key = $"{player.userID}_{filterType}";

            filterSettings[key] = value;

            UpdateAdminListUI(player);
        }
        #endregion Helper Functions

        #region Data Management
        private const string DataFolderName = "AdminMonitor";
        private const string AdminDataFolder = "Admins";
        private const string StatsFolder = "Stats";
        private const string WipeHistoryFolder = "WipeHistory";

        private void LoadData()
        {
            // Создаем структуру папок
            EnsureDataFolders();

            // Загружаем основные данные
            LoadGeneralData();

            // Загружаем статистику администраторов
            LoadAdminStats();

            // Загружаем историю вайпов
            LoadWipeHistory();

            PrintDataSummary();
        }

        private void EnsureDataFolders()
        {
            string[] folders =
            {
                DataFolderName,
                $"{DataFolderName}/{AdminDataFolder}",
                $"{DataFolderName}/{StatsFolder}",
                $"{DataFolderName}/{WipeHistoryFolder}",
            };

            foreach (string folder in folders)
            {
                if (!Interface.Oxide.DataFileSystem.ExistsDatafile($"{folder}/data"))
                {
                    _ = Interface.Oxide.DataFileSystem.GetDatafile($"{folder}/data");
                }
            }
        }

        private void LoadGeneralData()
        {
            if (!Interface.Oxide.DataFileSystem.ExistsDatafile($"{DataFolderName}/general"))
            {
                storedData = new StoredData
                {
                    CurrentWipeStart = DateTime.Now,
                    AdminStatistics = new Dictionary<ulong, AdminStats>(),
                    WipeHistory = new List<WipeHistory>(),
                };
                SaveData();
            }
            else
            {
                storedData = Interface.Oxide.DataFileSystem.ReadObject<StoredData>(
                    $"{DataFolderName}/general"
                );
                storedData.AdminStatistics ??= new Dictionary<ulong, AdminStats>();
            }
        }

        private void LoadAdminStats()
        {
            if (storedData == null)
            {
                return;
            }

            foreach (
                string file in Interface.Oxide.DataFileSystem.GetFiles(
                    $"{DataFolderName}/{AdminDataFolder}"
                )
            )
            {
                if (!file.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string[] fileParts = file.Split('/');
                string fileName = fileParts[fileParts.Length - 1].Replace(".json", "");

                if (ulong.TryParse(fileName, out ulong adminId))
                {
                    string fullPath = $"{DataFolderName}/{AdminDataFolder}/{fileName}";
                    Dictionary<string, object> savedData =
                        Interface.Oxide.DataFileSystem.ReadObject<Dictionary<string, object>>(
                            fullPath
                        );

                    if (savedData != null)
                    {
                        storedData.AdminStatistics[adminId] = new()
                        {
                            LastName = savedData["LastName"]?.ToString() ?? "Unknown",
                            TotalActiveTime = Convert.ToSingle(
                                savedData["TotalActiveTime"],
                                CultureInfo.InvariantCulture
                            ),
                            TotalAfkTime = Convert.ToSingle(
                                savedData["TotalAfkTime"],
                                CultureInfo.InvariantCulture
                            ),
                            CurrentWipeActiveTime = Convert.ToSingle(
                                savedData["CurrentWipeActiveTime"],
                                CultureInfo.InvariantCulture
                            ),
                            CurrentWipeAfkTime = Convert.ToSingle(
                                savedData["CurrentWipeAfkTime"],
                                CultureInfo.InvariantCulture
                            ),
                            LastActive = DateTime.Parse(
                                savedData["LastActive"]?.ToString()
                                    ?? DateTime.Now.ToString(CultureInfo.InvariantCulture),
                                CultureInfo.InvariantCulture
                            ),
                            CommandsUsed = JsonConvert.DeserializeObject<Dictionary<string, int>>(
                                savedData["CommandsUsed"]?.ToString() ?? "{}"
                            ),
                            RecentActions = JsonConvert.DeserializeObject<List<AdminAction>>(
                                savedData["RecentActions"]?.ToString() ?? "[]"
                            ),
                        };

                        // Восстанавливаем сессию если игрок был онлайн
                        object currentSession = savedData["CurrentSession"];
                        if (
                            currentSession != null
                            && Convert.ToBoolean(
                                savedData["IsOnline"],
                                CultureInfo.InvariantCulture
                            )
                        )
                        {
                            Dictionary<string, object> sessionData = JsonConvert.DeserializeObject<
                                Dictionary<string, object>
                            >(currentSession.ToString() ?? "{}");
                            BasePlayer? player = BasePlayer.FindByID(adminId);

                            if (player?.IsConnected == true)
                            {
                                activeAdmins[adminId] = new AdminActivity
                                {
                                    SessionStartTime = Convert.ToSingle(
                                        sessionData["SessionStartTime"],
                                        CultureInfo.InvariantCulture
                                    ),
                                    LastActiveTime = Convert.ToSingle(
                                        sessionData["LastActiveTime"],
                                        CultureInfo.InvariantCulture
                                    ),
                                    TotalAfkTime = Convert.ToSingle(
                                        sessionData["TotalAfkTime"],
                                        CultureInfo.InvariantCulture
                                    ),
                                    IsAfk = Convert.ToBoolean(
                                        sessionData["IsAfk"],
                                        CultureInfo.InvariantCulture
                                    ),
                                    LastPosition = JsonConvert.DeserializeObject<Vector3>(
                                        sessionData["LastPosition"]?.ToString()
                                            ?? /*lang=json*/
                                            "{'x':0,'y':0,'z':0}"
                                    ),
                                    AfkStartTime = Convert.ToSingle(
                                        sessionData["AfkStartTime"],
                                        CultureInfo.InvariantCulture
                                    ),
                                };

                                // Запускаем таймер проверки активности
                                activityTimers[adminId] = timer.Every(
                                    checkInterval,
                                    () => CheckActivity(player)
                                );
                            }
                        }
                    }
                }
            }
        }

        private void LoadWipeHistory()
        {
            if (storedData == null)
            {
                return;
            }

            foreach (
                string file in Interface.Oxide.DataFileSystem.GetFiles(
                    $"{DataFolderName}/{WipeHistoryFolder}"
                )
            )
            {
                if (!file.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string[] fileParts = file.Split('/');
                string fileName = fileParts[fileParts.Length - 1].Replace(".json", "");
                string fullPath = $"{DataFolderName}/{WipeHistoryFolder}/{fileName}";
                WipeHistory? wipeData = Interface.Oxide.DataFileSystem.ReadObject<WipeHistory>(
                    fullPath
                );
                if (
                    wipeData != null
                    && !storedData.WipeHistory.Any(w => w.StartDate == wipeData.StartDate)
                )
                {
                    storedData.WipeHistory.Add(wipeData);
                }
            }

            // Сортируем историю вайпов по дате
            storedData.WipeHistory = storedData
                .WipeHistory.OrderByDescending(w => w.StartDate)
                .ToList();
        }

        private void SaveData()
        {
            if (storedData == null)
            {
                return;
            }

            // Сохраняем общие данные
            SaveGeneralData();

            // Сохраняем данные каждого администратора
            SaveAllAdminData();

            // Сохраняем историю вайпов
            SaveWipeHistory();

            PrintDataSummary();
        }

        private void SaveGeneralData()
        {
            if (storedData == null)
            {
                return;
            }

            Interface.Oxide.DataFileSystem.WriteObject($"{DataFolderName}/general", storedData);
        }

        private void SaveAllAdminData()
        {
            if (storedData?.AdminStatistics == null)
            {
                return;
            }

            foreach (KeyValuePair<ulong, AdminStats> kvp in storedData.AdminStatistics)
            {
                SaveAdminData(kvp.Key);
            }
        }

        private void SaveAdminData(ulong adminId)
        {
            if (
                storedData?.AdminStatistics == null
                || !storedData.AdminStatistics.TryGetValue(adminId, out AdminStats? stats)
            )
            {
                return;
            }

            // Сохраняем полные данные в JSON
            string path = $"{DataFolderName}/{AdminDataFolder}/{adminId}";
            Interface.Oxide.DataFileSystem.WriteObject(
                path,
                new
                {
                    stats.LastName,
                    stats.TotalActiveTime,
                    stats.TotalAfkTime,
                    stats.CurrentWipeActiveTime,
                    stats.CurrentWipeAfkTime,
                    stats.CommandsUsed,
                    stats.RecentActions,
                    stats.LastActive,
                    SaveTime = DateTime.Now,
                    IsOnline = BasePlayer.FindByID(adminId)?.IsConnected == true,
                    CurrentSession = activeAdmins.TryGetValue(adminId, out AdminActivity activity)
                        ? new
                        {
                            activity.SessionStartTime,
                            activity.LastActiveTime,
                            activity.TotalAfkTime,
                            activity.IsAfk,
                            activity.LastPosition,
                            activity.AfkStartTime,
                        }
                        : null,
                }
            );

            // Сохраняем текущую статистику в отдельный файл для удобства просмотра
            string currentStatsPath = $"{DataFolderName}/{StatsFolder}/{adminId}_current";
            Interface.Oxide.DataFileSystem.WriteObject(
                currentStatsPath,
                new
                {
                    AdminName = stats.LastName,
                    ActiveTime = FormatTime(stats.CurrentWipeActiveTime),
                    AfkTime = FormatTime(stats.CurrentWipeAfkTime),
                    LastActive = FormatDateTime(stats.LastActive),
                    CommandsUsed = stats
                        .CommandsUsed.OrderByDescending(x => x.Value)
                        .Take(10)
                        .ToDictionary(x => x.Key, x => x.Value),
                    RecentActions = stats
                        .RecentActions.TakeLast(10)
                        .Select(a => new
                        {
                            Time = a.Timestamp.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
                            Type = a.ActionType,
                            a.Details,
                            a.Target,
                            Location = $"({Math.Round(a.Location.x)}, {Math.Round(a.Location.y)}, {Math.Round(a.Location.z)})",
                        })
                        .ToList(),
                }
            );
        }

        private void SaveWipeHistory()
        {
            if (storedData?.WipeHistory == null)
            {
                return;
            }

            foreach (WipeHistory wipe in storedData.WipeHistory)
            {
                string fileName = $"wipe_{wipe.StartDate:yyyyMMdd}_{wipe.EndDate:yyyyMMdd}";
                string path = $"{DataFolderName}/{WipeHistoryFolder}/{fileName}";
                Interface.Oxide.DataFileSystem.WriteObject(path, wipe);
            }
        }

        private void PrintDataSummary()
        {
            if (storedData == null)
            {
                return;
            }

            StringBuilder summary = new();
            _ = summary.AppendLine("=== Статистика AdminMonitor ===");
            _ = summary.AppendLine($"Всего администраторов: {storedData.AdminStatistics.Count}");
            _ = summary.AppendLine($"История вайпов: {storedData.WipeHistory.Count}");
            _ = summary.AppendLine(
                $"Текущий вайп начался: {storedData.CurrentWipeStart:dd.MM.yyyy HH:mm}"
            );
            _ = summary.AppendLine("===========================");

            Puts(summary.ToString());
        }
        #endregion Data Management

        #region Reports
        private void GenerateReport(
            BasePlayer? player,
            string reportType,
            DateTime startDate,
            DateTime endDate
        )
        {
            if (storedData == null)
            {
                return;
            }

            AdminReport report = new()
            {
                GenerationDate = DateTime.Now,
                ReportType = reportType,
                Period = $"{startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}",
            };

            foreach (KeyValuePair<ulong, AdminStats> kvp in storedData.AdminStatistics)
            {
                AdminReportStats reportStats = new()
                {
                    AdminName = kvp.Value.LastName,
                    ActiveTime = kvp.Value.CurrentWipeActiveTime,
                    AfkTime = kvp.Value.CurrentWipeAfkTime,
                    CommandsUsed = kvp.Value.CommandsUsed.Values.Sum(),
                };

                // Анализируем действия за период
                IEnumerable<string> actionTypes = kvp
                    .Value.RecentActions.Where(a =>
                        a.Timestamp >= startDate && a.Timestamp <= endDate
                    )
                    .Select(action =>
                    {
                        switch (action.ActionType.ToLower(CultureInfo.CurrentCulture))
                        {
                            case "build":
                                reportStats.BuildActions++;
                                break;
                            case "destroy":
                                reportStats.DestroyActions++;
                                break;
                            case "attack":
                            case "command":
                            case "violation":
                                reportStats.PlayerInteractions++;
                                break;
                            default:
                                // No specific stats to update for these actions
                                break;
                        }

                        return action.ActionType;
                    });

                foreach (string actionType in actionTypes)
                {
                    if (!reportStats.ActionTypes.TryGetValue(actionType, out int count))
                    {
                        count = 0;
                    }
                    reportStats.ActionTypes[actionType] = count + 1;
                }

                report.Statistics[kvp.Key] = reportStats;
            }

            // Сохраняем отчет
            string fileName = $"report_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}_{reportType}.json";
            Interface.Oxide.DataFileSystem.WriteObject(
                $"{DataFolderName}/{ReportsFolderName}/{fileName}",
                report
            );

            // Отправляем уведомление
            if (player != null)
            {
                SendReply(player, $"Отчет сгенерирован: {fileName}");
                ShowReport(player, report);
            }
        }

        private void ShowReport(BasePlayer player, AdminReport report)
        {
            StringBuilder message = new();
            _ = message.AppendLine("Отчет по активности администраторов");
            _ = message.AppendLine($"Период: {report.Period}");
            _ = message.AppendLine($"Тип отчета: {report.ReportType}");
            _ = message.AppendLine("----------------------------------------");

            foreach (
                AdminReportStats stats in report
                    .Statistics.OrderByDescending(x => x.Value.ActiveTime)
                    .Select(kvp => kvp.Value)
            )
            {
                float totalTime = stats.ActiveTime + stats.AfkTime;
                float activePercentage = totalTime > 0 ? stats.ActiveTime / totalTime * 100 : 0;

                _ = message.AppendLine($"\nАдминистратор: {stats.AdminName}");
                _ = message.AppendLine(
                    $"Активное время: {FormatTime(stats.ActiveTime)} ({activePercentage:F1}%)"
                );
                _ = message.AppendLine($"Время AFK: {FormatTime(stats.AfkTime)}");
                _ = message.AppendLine($"Использовано команд: {stats.CommandsUsed}");
                _ = message.AppendLine($"Построено объектов: {stats.BuildActions}");
                _ = message.AppendLine($"Уничтожено объектов: {stats.DestroyActions}");
                _ = message.AppendLine($"Взаимодействий с игроками: {stats.PlayerInteractions}");

                if (stats.ActionTypes.Count > 0)
                {
                    _ = message.AppendLine("\nТипы действий:");
                    foreach (
                        KeyValuePair<string, int> action in stats.ActionTypes.OrderByDescending(x =>
                            x.Value
                        )
                    )
                    {
                        _ = message.AppendLine($"- {action.Key}: {action.Value}");
                    }
                }
            }

            SendReply(player, message.ToString());
        }

        [ConsoleCommand("amonitor.report")]
        private void CmdGenerateReport(ConsoleSystem.Arg arg)
        {
            BasePlayer? player = arg.Player();
            if (
                player != null
                && !permission.UserHasPermission(player.UserIDString, PermissionReports)
            )
            {
                arg.ReplyWith("У вас нет прав для генерации отчетов.");
                return;
            }

            string reportType = arg.GetString(0, "daily");
            DateTime endDate = DateTime.Now;
            DateTime startDate = reportType.ToLower(CultureInfo.CurrentCulture) switch
            {
                "daily" => endDate.AddDays(-1),
                "weekly" => endDate.AddDays(-7),
                "monthly" => endDate.AddMonths(-1),
                _ => endDate.AddDays(-1),
            };

            GenerateReport(player, reportType, startDate, endDate);
        }

        private void ScheduleReports()
        {
            // Ежедневный отчет в 00:00
            _ = timer.Every(
                86400,
                () =>
                {
                    if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0)
                    {
                        GenerateReport(null, "daily", DateTime.Now.AddDays(-1), DateTime.Now);
                    }
                }
            );

            // Еженедельный отчет в воскресенье
            _ = timer.Every(
                86400,
                () =>
                {
                    if (
                        DateTime.Now.DayOfWeek == DayOfWeek.Sunday
                        && DateTime.Now.Hour == 0
                        && DateTime.Now.Minute == 0
                    )
                    {
                        GenerateReport(null, "weekly", DateTime.Now.AddDays(-7), DateTime.Now);
                    }
                }
            );
        }
        #endregion Reports

        #region Discord Integration
        private void SendDiscordLoginMessage(BasePlayer player)
        {
            if (string.IsNullOrEmpty(DiscordWebhookUrl) || player == null)
            {
                return;
            }

            object embed = new
            {
                title = "👮 Администратор вошел в игру",
                description = $"Администратор **{player.displayName}** присоединился к серверу",
                color = 3066993, // Зеленый цвет
                fields = new[]
                {
                    new
                    {
                        name = "📝 Информация",
                        value = $"**SteamID:** {player.UserIDString}\n**IP:** {player.net?.connection?.ipaddress}\n**Клиент:** {player.net?.connection?.os}",
                        inline = false,
                    },
                    new
                    {
                        name = "📍 Локация",
                        value = $"**Координаты:** {Math.Round(player.transform.position.x)}, {Math.Round(player.transform.position.y)}, {Math.Round(player.transform.position.z)}",
                        inline = false,
                    },
                    new
                    {
                        name = "⏰ Время входа",
                        value = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                        inline = false,
                    },
                },
                thumbnail = new
                {
                    url = $"https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars//{player.UserIDString}",
                },
                timestamp = DateTime.UtcNow.ToString("o"),
            };

            SendDiscordEmbed(embed);
        }

        private void SendDiscordLogoutMessage(BasePlayer player)
        {
            if (
                string.IsNullOrEmpty(DiscordWebhookUrl)
                || player == null
                || storedData?.AdminStatistics == null
            )
            {
                return;
            }

            if (!storedData.AdminStatistics.TryGetValue(player.userID, out AdminStats stats))
            {
                return;
            }

            float totalActiveTime = stats.TotalActiveTime;
            float totalAfkTime = stats.TotalAfkTime;

            if (activeAdmins.TryGetValue(player.userID, out AdminActivity activity))
            {
                float currentTime = Time.realtimeSinceStartup;
                float sessionDuration = currentTime - activity.SessionStartTime;
                float sessionAfkTime = activity.TotalAfkTime;

                if (activity.IsAfk)
                {
                    sessionAfkTime += currentTime - activity.AfkStartTime;
                }

                float sessionActiveTime = sessionDuration - sessionAfkTime;
                totalActiveTime += sessionActiveTime;
                totalAfkTime += sessionAfkTime;
            }

            // Собираем статистику действий за последние 24 часа
            Dictionary<string, int> actionStats = stats
                .RecentActions.Where(a => a.Timestamp >= DateTime.Now.AddHours(-24))
                .GroupBy(a => a.ActionType)
                .ToDictionary(g => g.Key, g => g.Count());

            string activityField = string.Join(
                "\n",
                actionStats.Select(kvp => $"{GetActionEmoji(kvp.Key)} **{kvp.Key}:** {kvp.Value}")
            );

            if (string.IsNullOrEmpty(activityField))
            {
                activityField = "*Нет действий за последние 24 часа*";
            }

            object embed = new
            {
                title = "🚪 Администратор вышел из игры",
                description = $"Администратор **{player.displayName}** покинул сервер",
                color = 15158332, // Красный цвет
                fields = new[]
                {
                    new
                    {
                        name = "📝 Информация",
                        value = $"**SteamID:** {player.UserIDString}\n**Последняя локация:** {Math.Round(player.transform.position.x)}, {Math.Round(player.transform.position.y)}, {Math.Round(player.transform.position.z)}",
                        inline = false,
                    },
                    new
                    {
                        name = "⏱ Статистика сессии",
                        value = $"**Активное время:** {FormatTime(totalActiveTime)}\n**Время AFK:** {FormatTime(totalAfkTime)}",
                        inline = false,
                    },
                    new
                    {
                        name = "📊 Действия за 24 часа",
                        value = activityField,
                        inline = false,
                    },
                    new
                    {
                        name = "⏰ Время выхода",
                        value = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                        inline = false,
                    },
                },
                thumbnail = new
                {
                    url = $"https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars//{player.UserIDString}",
                },
                timestamp = DateTime.UtcNow.ToString("o"),
            };

            SendDiscordEmbed(embed);
        }

        private void SendDiscordStatusChangeMessage(
            BasePlayer player,
            bool isAfk,
            float duration = 0
        )
        {
            if (string.IsNullOrEmpty(DiscordWebhookUrl) || player == null)
            {
                return;
            }

            object embed = new
            {
                title = isAfk
                    ? "💤 Администратор перешел в AFK"
                    : "✅ Администратор вернулся из AFK",
                description = isAfk
                    ? $"Администратор **{player.displayName}** перешел в режим AFK"
                    : $"Администратор **{player.displayName}** вернулся из AFK",
                color = isAfk ? 16776960 : 3066993, // Желтый для AFK, зеленый для возвращения
                fields = new[]
                {
                    new
                    {
                        name = "📝 Информация",
                        value = $"**SteamID:** {player.UserIDString}\n**Локация:** {Math.Round(player.transform.position.x)}, {Math.Round(player.transform.position.y)}, {Math.Round(player.transform.position.z)}",
                        inline = false,
                    },
                    new
                    {
                        name = "⏱ Время",
                        value = isAfk
                            ? $"**Начало AFK:** {DateTime.Now:dd.MM.yyyy HH:mm:ss}"
                            : $"**Длительность AFK:** {FormatTime(duration)}\n**Время возвращения:** {DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                        inline = false,
                    },
                },
                thumbnail = new
                {
                    url = $"https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars//{player.UserIDString}",
                },
                timestamp = DateTime.UtcNow.ToString("o"),
            };

            SendDiscordEmbed(embed);
        }

        private void SendDiscordEmbed(object embed)
        {
            webrequest.Enqueue(
                DiscordWebhookUrl,
                JsonConvert.SerializeObject(new { embeds = new[] { embed } }),
                (code, response) =>
                {
                    if (code != 204)
                    {
                        PrintError(
                            $"Failed to send Discord message. Code: {code}, Response: {response}"
                        );
                    }
                },
                this,
                Core.Libraries.RequestMethod.POST,
                new Dictionary<string, string> { ["Content-Type"] = "application/json" }
            );
        }

        private string GetActionEmoji(string actionType)
        {
            return actionType.ToLower(CultureInfo.CurrentCulture) switch
            {
                "attack" => "⚔️",
                "build" => "🏗️",
                "destroy" => "💥",
                "command" => "⌨️",
                "violation" => "⚠️",
                "login" => "➡️",
                "logout" => "⬅️",
                "status" => "📊",
                _ => "📌",
            };
        }
        #endregion Discord Integration

        protected override void LoadDefaultConfig()
        {
            Config["DiscordWebhookUrl"] = string.Empty; // Set your webhook URL in the config file
            Config["MaxPlayers"] = 100;
        }

        private CuiElementContainer CreateBaseContainer()
        {
            CuiElementContainer container = new();

            // Основной фон с новым цветом
            _ = container.Add(
                new CuiPanel
                {
                    CursorEnabled = true,
                    RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" },
                    Image =
                    {
                        Color = "0.235 0.227 0.204 0.95",
                        Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                    }, // #3c3a34
                },
                "Overlay",
                LayerMain
            );

            // Градиентный фон
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" },
                    Image =
                    {
                        Color = "0.235 0.227 0.204 0.7",
                        Sprite = "assets/content/ui/ui.background.transparent.radial.psd",
                    }, // #3c3a34 с прозрачностью
                },
                LayerMain
            );

            // Основная панель контента с новым цветом
            _ = container.Add(
                new CuiPanel
                {
                    RectTransform = { AnchorMin = "0.1 0.1", AnchorMax = "0.9 0.9" },
                    Image = { Color = "0.322 0.306 0.286 1" }, // #524e49
                },
                LayerMain,
                LayerContent
            );

            return container;
        }
    }
}
