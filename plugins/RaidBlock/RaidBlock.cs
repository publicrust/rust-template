using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using Rust;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("RaidBlock", "RustGPT", "1.0.7")]
    [Description(
        "Adds a raid block system with a UI component to show the block duration, applying to all players in the raid zone."
    )]
    public class RaidBlock : RustPlugin
    {
        [PluginReference]
        private readonly Plugin? CombatBlock;

        private readonly Dictionary<ulong, Dictionary<Vector3, Timer>> raidTimers = new();
        private readonly Dictionary<ulong, HashSet<Vector3>> playerZones = new();
        private readonly List<RaidZone> activeRaidZones = new();
        private readonly List<SphereEntity> activeDomes = new();
        private readonly Dictionary<ulong, RaidBlockUIManager> uiManagers = new();
        private readonly Dictionary<ulong, Dictionary<Vector3, float>> savedBlockTimes = new();
        private readonly Dictionary<ulong, Dictionary<Vector3, float>> remainingTimes = new();

        private sealed class PluginConfig
        {
            public float BlockDuration { get; set; }
            public bool BlockOnReceiveRaidDamage { get; set; }
            public bool RemoveBlockOnDeath { get; set; }
            public required List<string> BlockedCommands { get; set; }
            public float RaidZoneRadius { get; set; }
            public bool IsSphereEnabled { get; set; }
            public int SphereType { get; set; }
            public int DomeTransparencyLevel { get; set; }
            public float VisualMultiplier { get; set; }
            public bool DebugMode { get; set; }
        }

        private PluginConfig config = new() { BlockedCommands = new List<string>() };

        private sealed class RaidZone
        {
            public Vector3 Position { get; set; }
            public float ExpirationTime { get; set; }
        }

        private sealed class RaidBlockUIManager
        {
            private const string UIPanel = "RaidBlock.UI";
            private const string UILabel = "RaidBlock.UI.Label";
            private const string UIProgress = "RaidBlock.UI.Progress";

            private readonly RaidBlock plugin;
            private readonly BasePlayer player;
            private readonly float maxDuration;

            public RaidBlockUIManager(RaidBlock plugin, BasePlayer player, float maxDuration)
            {
                this.plugin = plugin;
                this.player = player;
                this.maxDuration = maxDuration;
            }

            private (string min, string max) GetUIPosition()
            {
                try
                {
                    bool hasCombatBlock = false;
                    if (plugin?.CombatBlock != null)
                    {
                        try
                        {
                            // Проверяем наличие UI и активного блока
                            object? hasUI = plugin.CombatBlock.Call(
                                "HasCombatBlockUI",
                                player.userID
                            );
                            object? hasBlock = plugin.CombatBlock.Call(
                                "HasCombatBlock",
                                player.userID
                            );
                            if (hasUI is bool hasUIValue && hasBlock is bool hasBlockValue)
                            {
                                hasCombatBlock = hasUIValue && hasBlockValue;
                            }
                        }
                        catch (Exception)
                        {
                            // Игнорируем ошибки при вызове CombatBlock, так как плагин может быть недоступен
                            plugin?.Puts("[RaidBlock] Error checking CombatBlock status");
                        }
                    }

                    // Если есть активный CombatBlock UI, размещаем наш UI ниже
                    if (hasCombatBlock)
                    {
                        return ("0.3447913 0.0735", "0.640625 0.1035");
                    }

                    // Стандартная позиция
                    return ("0.3447913 0.1135", "0.640625 0.1435");
                }
                catch (Exception)
                {
                    return ("0.3447913 0.1135", "0.640625 0.1435");
                }
            }

            public void Create(float duration)
            {
                try
                {
                    if (player?.IsConnected != true)
                    {
                        plugin?.Puts("[RaidBlock] Player is not connected");
                        return;
                    }

                    Destroy();

                    CuiElementContainer container = new();
                    if (container == null || plugin == null)
                    {
                        plugin?.Puts("[RaidBlock] Container or plugin is null");
                        return;
                    }

                    (string anchorMin, string anchorMax) = GetUIPosition();

                    // Background panel
                    _ = container.Add(
                        new CuiPanel
                        {
                            Image = { Color = "0.97 0.92 0.88 0.16" },
                            RectTransform = { AnchorMin = anchorMin, AnchorMax = anchorMax },
                            CursorEnabled = false,
                        },
                        "Hud",
                        UIPanel
                    );

                    AddLabel(container, duration);
                    AddProgressBar(container, duration);

                    _ = CuiHelper.AddUi(player, container);
                }
                catch (Exception ex)
                {
                    plugin?.Puts($"[RaidBlock] Error creating UI: {ex.Message}");
                }
            }

            public void Update(float duration)
            {
                if (player?.IsConnected != true)
                {
                    return;
                }

                try
                {
                    CuiElementContainer container = new();
                    if (container == null || plugin == null)
                    {
                        plugin?.Puts("[RaidBlock] Container or plugin is null");
                        return;
                    }

                    (string anchorMin, string anchorMax) = GetUIPosition();

                    // Обновляем позицию панели
                    _ = CuiHelper.DestroyUi(player, UIPanel);
                    _ = container.Add(
                        new CuiPanel
                        {
                            Image = { Color = "0.97 0.92 0.88 0.16" },
                            RectTransform = { AnchorMin = anchorMin, AnchorMax = anchorMax },
                            CursorEnabled = false,
                        },
                        "Hud",
                        UIPanel
                    );

                    AddLabel(container, duration);
                    AddProgressBar(container, duration);

                    _ = CuiHelper.DestroyUi(player, UIProgress);
                    _ = CuiHelper.DestroyUi(player, UILabel);
                    _ = CuiHelper.AddUi(player, container);
                }
                catch (Exception ex)
                {
                    plugin?.Puts($"[RaidBlock] Error updating UI: {ex.Message}");
                }
            }

            public void Destroy()
            {
                if (player?.IsConnected != true)
                {
                    return;
                }

                _ = CuiHelper.DestroyUi(player, UIProgress);
                _ = CuiHelper.DestroyUi(player, UILabel);
                _ = CuiHelper.DestroyUi(player, UIPanel);
            }

            private void AddLabel(CuiElementContainer container, float duration)
            {
                if (container == null || plugin == null)
                {
                    return;
                }

                try
                {
                    string message = plugin.GetMessage("RaidBlock.Active", player, (int)duration);
                    container.Add(
                        new CuiElement
                        {
                            Name = UILabel,
                            Parent = UIPanel,
                            Components =
                            {
                                new CuiTextComponent
                                {
                                    Text = message,
                                    FontSize = 15,
                                    Align = TextAnchor.MiddleCenter,
                                    Color = "1 1 1 0.5",
                                },
                                new CuiRectTransformComponent
                                {
                                    AnchorMin = "0 0",
                                    AnchorMax = "1 1",
                                },
                            },
                        }
                    );
                }
                catch (ArgumentException ex)
                {
                    plugin.Puts($"[RaidBlock] Invalid label parameters: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    plugin.Puts($"[RaidBlock] Label operation error: {ex.Message}");
                }
            }

            private void AddProgressBar(CuiElementContainer container, float duration)
            {
                float progress = Mathf.Clamp01(duration / maxDuration);
                container.Add(
                    new CuiElement
                    {
                        Name = UIProgress,
                        Parent = UIPanel,
                        Components =
                        {
                            new CuiImageComponent { Color = "0.60 0.80 0.20 0.5" },
                            new CuiRectTransformComponent
                            {
                                AnchorMin = "0 0",
                                AnchorMax = $"{progress} 0.1",
                            },
                        },
                    }
                );
            }
        }

        private RaidBlockUIManager GetOrCreateUIManager(BasePlayer player)
        {
            if (!uiManagers.TryGetValue(player.userID, out RaidBlockUIManager? ui))
            {
                ui = new RaidBlockUIManager(this, player, config.BlockDuration);
                uiManagers[player.userID] = ui;
            }
            return ui;
        }

        private void UpdateRaidBlockUI(BasePlayer player, float duration)
        {
            try
            {
                if (player?.IsConnected != true)
                {
                    return;
                }

                if (
                    !playerZones.TryGetValue(player.userID, out HashSet<Vector3>? zones)
                    || zones == null
                    || zones.Count == 0
                )
                {
                    DestroyRaidBlockUI(player);
                    return;
                }

                RaidBlockUIManager ui = GetOrCreateUIManager(player);
                ui.Update(duration);
            }
            catch (Exception ex)
            {
                Puts($"[RaidBlock] Error updating UI: {ex.Message}");
            }
        }

        private void DestroyRaidBlockUI(BasePlayer player)
        {
            if (player?.IsConnected != true)
            {
                return;
            }

            if (uiManagers.TryGetValue(player.userID, out RaidBlockUIManager? ui))
            {
                ui.Destroy();
                _ = uiManagers.Remove(player.userID);
            }
        }

        private void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            if (player == null)
            {
                return;
            }

            RemoveAllRaidBlocks(player);
            _ = uiManagers.Remove(player.userID);
        }

        protected override void LoadDefaultConfig()
        {
            config = new PluginConfig
            {
                BlockDuration = 300.0f,
                BlockOnReceiveRaidDamage = true,
                RemoveBlockOnDeath = true,
                BlockedCommands = new List<string> { "/tpr", "/tpa", "/home" },
                RaidZoneRadius = 50.0f,
                IsSphereEnabled = true,
                SphereType = 0,
                DomeTransparencyLevel = 7,
                VisualMultiplier = 1.0f,
                DebugMode = false,
            };
            SaveConfig();
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            config = Config.ReadObject<PluginConfig>();
            if (config == null)
            {
                LoadDefaultConfig();
            }
        }

        protected override void SaveConfig()
        {
            Config.WriteObject(config);
        }

        private void Init()
        {
            ClearAllRaidBlockUI();
        }

        private void Unload()
        {
            ClearAllRaidZonesAndDomes();
        }

        protected override void LoadDefaultMessages()
        {
            try
            {
                lang.RegisterMessages(
                    new Dictionary<string, string>
                    {
                        ["RaidBlock.Active"] = "Блокировка рейда: {0} сек",
                        ["RaidBlock.BlockedCommand"] =
                            "Вы не можете использовать эту команду во время блокировки рейда",
                        ["RaidBlock.UIMessage"] =
                            "Вы не можете использовать эту команду во время блокировки рейда",
                        ["RaidBlock.NoBuild"] = "Вы не можете строить в зоне рейда",
                    },
                    this,
                    "ru"
                );

                lang.RegisterMessages(
                    new Dictionary<string, string>
                    {
                        ["RaidBlock.Active"] = "Raid Block: {0} sec",
                        ["RaidBlock.BlockedCommand"] =
                            "You cannot use this command while in raid block",
                        ["RaidBlock.UIMessage"] = "You cannot use this command while in raid block",
                        ["RaidBlock.NoBuild"] = "You cannot build in the raid zone",
                    },
                    this,
                    "en"
                );
            }
            catch (ArgumentException ex)
            {
                Puts($"[RaidBlock] Invalid message format: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Puts($"[RaidBlock] Message registration error: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                Puts($"[RaidBlock] Message key not found: {ex.Message}");
            }
        }

        private string GetMessage(string key, BasePlayer? player = null, params object[] args)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                lang.GetMessage(key, this, player?.UserIDString),
                args
            );
        }

        private void ClearAllRaidBlockUI()
        {
            foreach (BasePlayer? player in BasePlayer.activePlayerList)
            {
                DestroyRaidBlockUI(player);
            }
        }

        private void ClearAllRaidZonesAndDomes()
        {
            foreach (SphereEntity dome in activeDomes)
            {
                if (dome?.IsDestroyed == false)
                {
                    dome.Kill();
                }
            }
            activeDomes.Clear();
            activeRaidZones.Clear();
        }

        private void RemoveRaidBlock(BasePlayer player, Vector3 zonePosition, bool saveTime = false)
        {
            if (player == null)
            {
                return;
            }

            ulong playerId = player.userID;

            if (raidTimers.TryGetValue(playerId, out Dictionary<Vector3, Timer>? timers))
            {
                if (timers.TryGetValue(zonePosition, out Timer? timer))
                {
                    timer.Destroy();
                    _ = timers.Remove(zonePosition);
                }

                if (timers.Count == 0)
                {
                    _ = raidTimers.Remove(playerId);
                }
            }

            if (playerZones.TryGetValue(playerId, out HashSet<Vector3>? zones))
            {
                _ = zones.Remove(zonePosition);

                if (zones.Count == 0)
                {
                    _ = playerZones.Remove(playerId);
                }
            }

            if (
                saveTime
                && remainingTimes.TryGetValue(playerId, out Dictionary<Vector3, float>? times)
            )
            {
                if (times.TryGetValue(zonePosition, out float remainingTime))
                {
                    if (
                        !savedBlockTimes.TryGetValue(
                            playerId,
                            out Dictionary<Vector3, float>? savedTimes
                        )
                    )
                    {
                        savedTimes = new Dictionary<Vector3, float>();
                        savedBlockTimes[playerId] = savedTimes;
                    }
                    savedTimes[zonePosition] = remainingTime;
                }
                _ = times.Remove(zonePosition);
                if (times.Count == 0)
                {
                    _ = remainingTimes.Remove(playerId);
                }
            }

            if (!playerZones.TryGetValue(playerId, out HashSet<Vector3>? value) || value.Count == 0)
            {
                DestroyRaidBlockUI(player);
            }
        }

        private void AddRaidBlock(
            BasePlayer player,
            Vector3 zonePosition,
            float duration,
            bool checkSaved = true
        )
        {
            try
            {
                if (player == null)
                {
                    return;
                }

                ulong playerId = player.userID;

                if (
                    checkSaved
                    && savedBlockTimes.TryGetValue(
                        playerId,
                        out Dictionary<Vector3, float>? savedTimes
                    )
                    && savedTimes.TryGetValue(zonePosition, out float savedDuration)
                )
                {
                    duration = savedDuration;
                    _ = savedTimes.Remove(zonePosition);
                    if (savedTimes.Count == 0)
                    {
                        _ = savedBlockTimes.Remove(playerId);
                    }
                }

                if (!raidTimers.TryGetValue(playerId, out Dictionary<Vector3, Timer>? timers))
                {
                    timers = new Dictionary<Vector3, Timer>();
                    raidTimers[playerId] = timers;
                }

                if (timers.TryGetValue(zonePosition, out Timer? existingTimer))
                {
                    existingTimer.Destroy();
                    _ = timers.Remove(zonePosition);
                }

                if (!playerZones.TryGetValue(playerId, out HashSet<Vector3>? zones))
                {
                    zones = new HashSet<Vector3>();
                    playerZones[playerId] = zones;
                }

                _ = zones.Add(zonePosition);

                if (!remainingTimes.TryGetValue(playerId, out Dictionary<Vector3, float>? times))
                {
                    times = new Dictionary<Vector3, float>();
                    remainingTimes[playerId] = times;
                }

                times[zonePosition] = duration;

                timers[zonePosition] = timer.Every(
                    1f,
                    () =>
                    {
                        try
                        {
                            if (player?.IsConnected != true)
                            {
                                if (timers.TryGetValue(zonePosition, out Timer? timer))
                                {
                                    timer.Destroy();
                                    _ = timers.Remove(zonePosition);
                                }
                                return;
                            }

                            if (times.TryGetValue(zonePosition, out float remainingTime))
                            {
                                remainingTime--;
                                times[zonePosition] = remainingTime;

                                if (remainingTime <= 0)
                                {
                                    RemoveRaidBlock(player, zonePosition);
                                    if (timers.TryGetValue(zonePosition, out Timer? timer))
                                    {
                                        timer.Destroy();
                                        _ = timers.Remove(zonePosition);
                                    }
                                }
                                else
                                {
                                    UpdateRaidBlockUI(player, remainingTime);
                                }
                            }
                            else if (timers.TryGetValue(zonePosition, out Timer? timer))
                            {
                                timer.Destroy();
                                _ = timers.Remove(zonePosition);
                            }
                        }
                        catch (Exception ex)
                        {
                            Puts($"[RaidBlock] Timer error: {ex.Message}");
                        }
                    }
                );
                UpdateRaidBlockUI(player, duration);
            }
            catch (Exception ex)
            {
                Puts($"[RaidBlock] Error adding raid block: {ex.Message}");
            }
        }

        private void IsPlayerInRaidZone(BasePlayer player, out HashSet<Vector3> activeZones)
        {
            activeZones = new HashSet<Vector3>();

            if (player == null)
            {
                return;
            }

            Vector3 playerPosition = player.transform.position;
            foreach (RaidZone raidZone in activeRaidZones)
            {
                if (Time.realtimeSinceStartup > raidZone.ExpirationTime)
                {
                    continue;
                }

                float distance = Vector3.Distance(playerPosition, raidZone.Position);
                if (distance <= config.RaidZoneRadius / 2)
                {
                    _ = activeZones.Add(raidZone.Position);
                }
            }
        }

        private void CheckPlayerInZone(BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            IsPlayerInRaidZone(player, out HashSet<Vector3> activeZones);

            ulong playerId = player.userID;

            if (!playerZones.TryGetValue(playerId, out HashSet<Vector3>? zones))
            {
                zones = new HashSet<Vector3>();
                playerZones[playerId] = zones;
            }

            foreach (
                Vector3 zonePos in activeZones.Where(zonePos =>
                    !zones.Any(playerZonePos =>
                        Vector3.Distance(playerZonePos, zonePos) <= config.RaidZoneRadius / 2
                    )
                )
            )
            {
                AddRaidBlock(player, zonePos, config.BlockDuration);
            }

            List<Vector3> zonesToRemove = zones
                .Where(playerZonePos =>
                    !activeZones.Any(activeZonePos =>
                        Vector3.Distance(playerZonePos, activeZonePos) <= config.RaidZoneRadius / 2
                    )
                )
                .ToList();

            foreach (Vector3 zonePos in zonesToRemove)
            {
                RemoveRaidBlock(player, zonePos, true);
            }
        }

        private void CreateRaidZone(Vector3 position)
        {
            // Проверяем, находится ли новая точка в радиусе существующей зоны
            RaidZone? existingZone = null;
            foreach (RaidZone zone in activeRaidZones)
            {
                if (Vector3.Distance(zone.Position, position) <= config.RaidZoneRadius / 2)
                {
                    existingZone = zone;
                    break;
                }
            }

            if (existingZone != null)
            {
                // Обновляем время существующей зоны
                existingZone.ExpirationTime = Time.realtimeSinceStartup + config.BlockDuration;
                return;
            }

            RaidZone raidZone = new()
            {
                Position = position,
                ExpirationTime = Time.realtimeSinceStartup + config.BlockDuration,
            };

            activeRaidZones.Add(raidZone);

            if (config.IsSphereEnabled)
            {
                bool isInExistingDome = false;
                foreach (SphereEntity dome in activeDomes)
                {
                    if (
                        dome?.IsDestroyed == false
                        && Vector3.Distance(dome.transform.position, position)
                            <= config.RaidZoneRadius / 2
                    )
                    {
                        isInExistingDome = true;
                        break;
                    }
                }

                if (!isInExistingDome)
                {
                    CreateDome(position);
                }
            }
        }

        private void CreateDome(Vector3 position)
        {
            // Проверяем, находится ли новая точка в радиусе существующего купола
            foreach (SphereEntity dome in activeDomes)
            {
                if (dome?.IsDestroyed == false)
                {
                    float distance = Vector3.Distance(dome.transform.position, position);
                    if (distance <= config.RaidZoneRadius / 2)
                    {
                        return;
                    }
                }
            }

            string spherePrefab =
                config.SphereType == 0
                    ? "assets/prefabs/visualization/sphere.prefab"
                    : "assets/prefabs/visualization/sphere_battleroyale.prefab";

            SphereEntity? sphere =
                GameManager.server.CreateEntity(spherePrefab, position) as SphereEntity;
            if (sphere != null)
            {
                sphere.enableSaving = false;
                // Возвращаем оригинальный размер купола
                sphere.currentRadius = config.RaidZoneRadius;
                sphere.lerpRadius = config.RaidZoneRadius;
                sphere.lerpSpeed = 1f;

                // Возвращаем оригинальный визуальный размер
                float visualScale = config.RaidZoneRadius * 2f * config.VisualMultiplier;
                sphere.transform.localScale = Vector3.one * visualScale;
                sphere.UpdateScale();

                sphere.Spawn();
                activeDomes.Add(sphere);
            }
        }

        private void OnPlayerDeath(BasePlayer player, HitInfo info)
        {
            if (player == null || player.userID == 0 || string.IsNullOrEmpty(player.displayName))
            {
                return;
            }

            if (config.RemoveBlockOnDeath)
            {
                RemoveAllRaidBlocks(player);
            }
        }

        private void RemoveAllRaidBlocks(BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            ulong playerId = player.userID;

            if (playerZones.TryGetValue(playerId, out HashSet<Vector3>? zones))
            {
                foreach (Vector3 zonePos in new HashSet<Vector3>(zones))
                {
                    RemoveRaidBlock(player, zonePos, false);
                }
            }

            DestroyRaidBlockUI(player);
        }

        private bool OnPlayerChat(
            BasePlayer player,
            string message,
            ConVar.Chat.ChatChannel channel
        )
        {
            if (player == null || string.IsNullOrEmpty(message))
            {
                return true;
            }

            if (
                playerZones.TryGetValue(player.userID, out HashSet<Vector3>? zones)
                && zones.Count > 0
                && config.BlockedCommands.Exists(cmd =>
                    cmd != null && message.StartsWith(cmd, StringComparison.OrdinalIgnoreCase)
                )
            )
            {
                player.ChatMessage(GetMessage("RaidBlock.BlockedCommand", player));
                return false;
            }

            return true;
        }

        private bool OnUserCommand(IPlayer player, string command, string[] args)
        {
            if (player?.Object is not BasePlayer basePlayer)
            {
                return true;
            }

            if (
                playerZones.TryGetValue(basePlayer.userID, out HashSet<Vector3>? zones)
                && zones.Count > 0
            )
            {
                command = "/" + command.ToUpperInvariant();
                if (config.BlockedCommands.Contains(command))
                {
                    basePlayer.ChatMessage(GetMessage("RaidBlock.UIMessage", basePlayer));
                    return false;
                }
            }

            return true;
        }

        [HookMethod("HasRaidBlock")]
        public bool HasRaidBlock(ulong playerID)
        {
            return remainingTimes.ContainsKey(playerID);
        }

        private void OnServerInitialized(bool initial)
        {
            LoadConfig();
            if (config.RaidZoneRadius <= 0)
            {
                config.RaidZoneRadius = 50.0f;
                SaveConfig();
            }
            if (config.BlockDuration <= 0)
            {
                config.BlockDuration = 300.0f;
                SaveConfig();
            }
            if (config.VisualMultiplier <= 0)
            {
                config.VisualMultiplier = 1.0f;
                SaveConfig();
            }

            if (CombatBlock == null)
            {
                PrintError("CombatBlock plugin not found!");
            }

            _ = timer.Every(
                1f,
                () =>
                {
                    _ = activeRaidZones.RemoveAll(zone =>
                        Time.realtimeSinceStartup > zone.ExpirationTime
                    );

                    foreach (BasePlayer? player in BasePlayer.activePlayerList)
                    {
                        if (player == null)
                        {
                            continue;
                        }

                        CheckPlayerInZone(player);
                    }
                }
            );
        }

        [HookMethod("HasRaidBlockUI")]
        public bool HasRaidBlockUI(ulong playerID)
        {
            return uiManagers.ContainsKey(playerID);
        }

        private void OnEntityTakeDamage(BaseCombatEntity entity, HitInfo info)
        {
            if (info?.damageTypes?.GetMajorityDamageType() == DamageType.Decay)
            {
                return;
            }

            if (
                entity == null
                || info?.Initiator == null
                || info?.damageTypes == null
                || entity.transform == null
            )
            {
                return;
            }

            if (info.Initiator is not BasePlayer attacker)
            {
                return;
            }

            if (
                entity.OwnerID != 0
                && entity.Health() <= info.damageTypes.Total()
                && (
                    info.damageTypes.Has(DamageType.Explosion)
                    || info.damageTypes.Has(DamageType.Bullet)
                )
            )
            {
                BasePlayer? victim = entity as BasePlayer;
                Vector3 damagePosition = entity.transform.position;

                RaidZone? existingZone = null;
                foreach (RaidZone zone in activeRaidZones)
                {
                    float distance = Vector3.Distance(zone.Position, damagePosition);
                    if (distance <= config.RaidZoneRadius / 2)
                    {
                        existingZone = zone;
                        zone.ExpirationTime = Time.realtimeSinceStartup + config.BlockDuration;
                        break;
                    }
                }

                if (existingZone == null)
                {
                    CreateRaidZone(damagePosition);
                    existingZone = activeRaidZones[activeRaidZones.Count - 1];
                }

                AddRaidBlock(attacker, existingZone.Position, config.BlockDuration, false);

                if (victim != null && config.BlockOnReceiveRaidDamage)
                {
                    AddRaidBlock(victim, existingZone.Position, config.BlockDuration, false);
                }
            }
        }

        private bool CanBuild(Planner planner, Construction prefab, Construction.Target target)
        {
            try
            {
                BasePlayer? player = planner?.GetOwnerPlayer();
                if (player == null)
                {
                    return true;
                }

                // Проверяем активные зоны рейда
                bool isInAnyRaidZone = false;
                foreach (RaidZone raidZone in activeRaidZones)
                {
                    if (Time.realtimeSinceStartup > raidZone.ExpirationTime)
                    {
                        continue;
                    }

                    float distance = Vector3.Distance(target.position, raidZone.Position);
                    if (distance <= config.RaidZoneRadius / 2)
                    {
                        isInAnyRaidZone = true;
                        break;
                    }
                }

                if (isInAnyRaidZone)
                {
                    player.ChatMessage(GetMessage("RaidBlock.NoBuild", player));
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        private bool OnStructureUpgrade(
            BuildingBlock block,
            BasePlayer player,
            BuildingGrade.Enum grade,
            ulong skinID
        )
        {
            try
            {
                if (player == null || block == null)
                {
                    return true;
                }

                // Проверяем активные зоны рейда
                bool isInAnyRaidZone = false;
                foreach (RaidZone raidZone in activeRaidZones)
                {
                    if (Time.realtimeSinceStartup > raidZone.ExpirationTime)
                    {
                        continue;
                    }

                    float distance = Vector3.Distance(block.transform.position, raidZone.Position);
                    if (distance <= config.RaidZoneRadius / 2)
                    {
                        isInAnyRaidZone = true;
                        break;
                    }
                }

                if (isInAnyRaidZone)
                {
                    player.ChatMessage(GetMessage("RaidBlock.BlockedUpgrade", player));
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
