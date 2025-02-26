/// <summary>
/// CombatBlock Plugin
///
/// This plugin adds a combat block system to Rust servers, preventing players from using certain commands during combat.
/// It displays a UI component to show the remaining duration of the combat block.
///
/// Configuration:
/// - BlockDuration (float): Duration of the combat block in seconds.
/// - BlockOnPlayerHit (bool): Apply combat block when hitting another player.
/// - BlockOnReceiveDamage (bool): Apply combat block when receiving damage from another player.
/// - RemoveBlockOnDeath (bool): Remove combat block when the player dies.
/// - BlockedCommands (List<string>): List of chat commands that should be blocked during combat block.
///
/// API:
/// - HasCombatBlock(ulong playerID): Returns a boolean indicating whether the specified player has an active combat block.
///
/// For more information, visit the plugin's page: https://foxplugins.ru/resources/combatblock.105/
/// Discord: https://discord.gg/sv6nF3gNU3
/// RustGPT: https://chatgpt.com/g/g-xunzDbv9b-rustgpt
/// Image: https://i.imgur.com/VQB20VZ_d.webp?maxwidth=760&fidelity=grand
/// </summary>
using System;
using System.Collections.Generic;
using System.Globalization;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("CombatBlock", "RustGPT", "1.0.0")]
    [Description("Adds a combat block system with a UI component to show the block duration.")]
    public class CombatBlock : RustPlugin
    {
        [PluginReference]
        private readonly Plugin? RaidBlock;

        private readonly Dictionary<ulong, Timer> combatTimers = new();
        private readonly HashSet<ulong> blockedPlayers = new();

        /// <summary>
        /// Configuration class for the CombatBlock plugin
        /// </summary>
        private sealed class PluginConfig
        {
            /// <summary>
            /// Duration of the combat block in seconds
            /// </summary>
            public float BlockDuration { get; set; }

            /// <summary>
            /// Determines if combat block should be applied when hitting another player
            /// </summary>
            public bool BlockOnPlayerHit { get; set; }

            /// <summary>
            /// Determines if combat block should be applied when receiving damage from another player
            /// </summary>
            public bool BlockOnReceiveDamage { get; set; }

            /// <summary>
            /// Determines if combat block should be removed upon player death
            /// </summary>
            public bool RemoveBlockOnDeath { get; set; }

            /// <summary>
            /// List of chat commands to block during combat block
            /// </summary>
            public List<string> BlockedCommands { get; set; } = new List<string>();

            public PluginConfig()
            {
                BlockDuration = 10.0f;
                BlockOnPlayerHit = true;
                BlockOnReceiveDamage = true;
                RemoveBlockOnDeath = true;
                BlockedCommands = new List<string> { "/tpr", "/tpa", "/home" };
            }
        }

        private PluginConfig config = new();

        /// <summary>
        /// Loads the default configuration settings
        /// </summary>
        protected override void LoadDefaultConfig()
        {
            config = new PluginConfig();
            Config.WriteObject(config, true);
        }

        /// <summary>
        /// Loads the configuration from file
        /// </summary>
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                config = Config.ReadObject<PluginConfig>() ?? new PluginConfig();
            }
            catch (FormatException ex)
            {
                Puts($"[CombatBlock] Invalid config format: {ex.Message}");
                LoadDefaultConfig();
            }
            catch (ArgumentException ex)
            {
                Puts($"[CombatBlock] Invalid config argument: {ex.Message}");
                LoadDefaultConfig();
            }
            catch (InvalidOperationException ex)
            {
                Puts($"[CombatBlock] Config operation error: {ex.Message}");
                LoadDefaultConfig();
            }
        }

        /// <summary>
        /// Saves the current configuration to file
        /// </summary>
        protected override void SaveConfig()
        {
            Config.WriteObject(config);
        }

        /// <summary>
        /// Initializes the plugin, clearing all existing UI elements and registering commands
        /// </summary>
        private void Init()
        {
            LoadConfig();
            ClearAllCombatBlockUI();
        }

        /// <summary>
        /// Loads default language messages for supported languages
        /// </summary>
        protected override void LoadDefaultMessages()
        {
            try
            {
                lang.RegisterMessages(
                    new Dictionary<string, string>
                    {
                        ["CombatBlock.Active"] = "Блокировка: {0} секунд",
                        ["CombatBlock.BlockedCommand"] =
                            "Вы не можете использовать эту команду во время боевой блокировки.",
                        ["CombatBlock.UIMessage"] =
                            "Вы не можете использовать эту команду, пока в боевой блокировке.",
                    },
                    this,
                    "ru"
                );

                lang.RegisterMessages(
                    new Dictionary<string, string>
                    {
                        ["CombatBlock.Active"] = "Combat Block: {0} seconds",
                        ["CombatBlock.BlockedCommand"] =
                            "You cannot use this command while in combat block.",
                        ["CombatBlock.UIMessage"] =
                            "You cannot use this command while in combat block.",
                    },
                    this,
                    "en"
                );
            }
            catch (ArgumentException ex)
            {
                Puts($"[CombatBlock] Invalid message format: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Puts($"[CombatBlock] Message registration error: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                Puts($"[CombatBlock] Message key not found: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a localized message for the specified player
        /// </summary>
        /// <param name="key">The key of the message</param>
        /// <param name="player">The player to retrieve the message for</param>
        /// <param name="args">Arguments to format into the message</param>
        /// <returns>The localized and formatted message</returns>
        private string GetMessage(string key, BasePlayer? player = null, params object[] args)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                lang.GetMessage(key, this, player?.UserIDString),
                args
            );
        }

        /// <summary>
        /// Clears all combat block UI elements from all active players
        /// </summary>
        private void ClearAllCombatBlockUI()
        {
            foreach (BasePlayer? player in BasePlayer.activePlayerList)
            {
                DestroyCombatBlockUI(player);
            }
        }

        /// <summary>
        /// Adds a combat block to a player for a specified duration
        /// </summary>
        /// <param name="player">The player to apply the combat block to</param>
        /// <param name="duration">The duration of the combat block in seconds</param>
        private void AddCombatBlock(BasePlayer player, float duration)
        {
            if (player?.IsConnected != true)
            {
                return;
            }

            ulong playerId = player.userID;

            if (blockedPlayers.Contains(playerId))
            {
                if (combatTimers.TryGetValue(playerId, out Timer? timer))
                {
                    timer.Destroy();
                    _ = combatTimers.Remove(playerId);
                }
                UpdateCombatBlockUI(player, duration);
            }
            else
            {
                _ = blockedPlayers.Add(playerId);
                CreateCombatBlockUI(player, duration);
            }

            float remainingTime = duration;
            Timer? uiUpdateTimer = null;

            uiUpdateTimer = timer.Repeat(
                1f,
                (int)duration,
                () =>
                {
                    if (player?.IsConnected != true)
                    {
                        uiUpdateTimer?.Destroy();
                        _ = blockedPlayers.Remove(playerId);
                        _ = combatTimers.Remove(playerId);
                        return;
                    }

                    remainingTime--;

                    if (remainingTime <= 0)
                    {
                        DestroyCombatBlockUI(player);
                        _ = blockedPlayers.Remove(playerId);
                        _ = combatTimers.Remove(playerId);
                        uiUpdateTimer?.Destroy();
                    }
                    else
                    {
                        UpdateCombatBlockUI(player, remainingTime);
                    }
                }
            );

            combatTimers[playerId] = uiUpdateTimer;
        }

        private void OnEntityTakeDamage(BaseCombatEntity entity, HitInfo info)
        {
            if (entity == null || info?.Initiator == null)
            {
                return;
            }

            if (
                entity is BasePlayer victim
                && info.Initiator is BasePlayer attacker
                && victim != attacker
            )
            {
                if (config.BlockOnReceiveDamage)
                {
                    AddCombatBlock(victim, config.BlockDuration);
                }

                if (config.BlockOnPlayerHit)
                {
                    AddCombatBlock(attacker, config.BlockDuration);
                }
            }
        }

        private sealed class CombatBlockUIManager
        {
            private const string UIPanel = "CombatBlock.UI";
            private const string UILabel = "CombatBlock.UI.Label";
            private const string UIProgress = "CombatBlock.UI.Progress";

            private readonly CombatBlock plugin;
            private readonly BasePlayer player;
            private readonly float maxDuration;

            public CombatBlockUIManager(CombatBlock plugin, BasePlayer player, float maxDuration)
            {
                this.plugin = plugin;
                this.player = player;
                this.maxDuration = maxDuration;
            }

            private (string min, string max) GetUIPosition()
            {
                try
                {
                    if (plugin == null)
                    {
                        return ("0.3447913 0.1135", "0.640625 0.1435");
                    }

                    // Проверяем наличие активного RaidBlock UI
                    bool hasRaidBlock = false;
                    if (plugin.RaidBlock != null)
                    {
                        try
                        {
                            // Проверяем наличие UI и активного блока
                            object? hasUI = plugin.RaidBlock.Call("HasRaidBlockUI", player.userID);
                            object? hasBlock = plugin.RaidBlock.Call("HasRaidBlock", player.userID);
                            if (
                                hasUI is bool hasUIValue
                                && hasBlock is bool hasBlockValue
                                && hasUIValue
                                && hasBlockValue
                            )
                            {
                                hasRaidBlock = true;
                            }
                        }
                        catch
                        {
                            plugin?.Puts("[CombatBlock] Error checking RaidBlock status");
                        }
                    }

                    // Если есть активный RaidBlock UI, размещаем наш UI выше
                    if (hasRaidBlock)
                    {
                        return ("0.3447913 0.1535", "0.640625 0.1835");
                    }

                    // Стандартная позиция
                    return ("0.3447913 0.1135", "0.640625 0.1435");
                }
                catch (Exception ex)
                {
                    plugin?.Puts($"[CombatBlock] Error getting UI position: {ex.Message}");
                    return ("0.3447913 0.1135", "0.640625 0.1435");
                }
            }

            public void Create(float duration)
            {
                try
                {
                    if (player?.IsConnected != true)
                    {
                        return;
                    }

                    Destroy();

                    CuiElementContainer container = new();
                    if (container == null || plugin == null)
                    {
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
                    plugin?.Puts($"[CombatBlock] Error creating UI: {ex.Message}");
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
                    if (container == null)
                    {
                        plugin.Puts("[CombatBlock] Failed to create UI container");
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
                catch (ArgumentException ex)
                {
                    plugin.Puts($"[CombatBlock] Invalid UI parameters: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    plugin.Puts($"[CombatBlock] UI operation error: {ex.Message}");
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
                    string message = plugin.GetMessage("CombatBlock.Active", player, (int)duration);
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
                    plugin.Puts($"[CombatBlock] Invalid label parameters: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    plugin.Puts($"[CombatBlock] Label operation error: {ex.Message}");
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

        private readonly Dictionary<ulong, CombatBlockUIManager> uiManagers = new();

        private void CreateCombatBlockUI(BasePlayer player, float duration)
        {
            if (player?.IsConnected != true)
            {
                return;
            }

            CombatBlockUIManager ui = GetOrCreateUIManager(player);
            ui.Create(duration);
        }

        private void UpdateCombatBlockUI(BasePlayer player, float duration)
        {
            if (player?.IsConnected != true)
            {
                return;
            }

            CombatBlockUIManager ui = GetOrCreateUIManager(player);
            ui.Update(duration);
        }

        private void DestroyCombatBlockUI(BasePlayer player)
        {
            if (player?.IsConnected != true)
            {
                return;
            }

            if (uiManagers.TryGetValue(player.userID, out CombatBlockUIManager? ui))
            {
                ui.Destroy();
                _ = uiManagers.Remove(player.userID);
            }
        }

        private CombatBlockUIManager GetOrCreateUIManager(BasePlayer player)
        {
            if (!uiManagers.TryGetValue(player.userID, out CombatBlockUIManager? ui))
            {
                ui = new CombatBlockUIManager(this, player, config.BlockDuration);
                uiManagers[player.userID] = ui;
            }
            return ui;
        }

        private void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            if (player == null)
            {
                return;
            }

            DestroyCombatBlockUI(player);
            _ = uiManagers.Remove(player.userID);
        }

        /// <summary>
        /// Handles the event when a player dies, removing combat block if configured to do so
        /// </summary>
        /// <param name="player">The player who died</param>
        /// <param name="info">The hit information</param>
        private void OnPlayerDeath(BasePlayer player, HitInfo info)
        {
            if (player == null)
            {
                return;
            }

            if (config.RemoveBlockOnDeath)
            {
                DestroyCombatBlockUI(player);
                _ = blockedPlayers.Remove(player.userID);
            }
        }

        /// <summary>
        /// Handles chat commands, blocking them if the player is under combat block
        /// </summary>
        /// <param name="player">The player executing the command</param>
        /// <param name="message">The command message</param>
        /// <param name="channel">The chat channel</param>
        /// <returns>Returns false to block the command, otherwise null</returns>
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
                blockedPlayers.Contains(player.userID)
                && config.BlockedCommands.Exists(cmd =>
                    cmd != null && message.StartsWith(cmd, StringComparison.OrdinalIgnoreCase)
                )
            )
            {
                player.ChatMessage(GetMessage("CombatBlock.BlockedCommand", player));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handles user commands, blocking them if the player is under combat block
        /// </summary>
        /// <param name="player">The player executing the command</param>
        /// <param name="command">The command name</param>
        /// <param name="args">The command arguments</param>
        /// <returns>Returns false to block the command, otherwise null</returns>
        private bool OnUserCommand(IPlayer player, string command, string[] args)
        {
            if (player?.Object is not BasePlayer basePlayer)
            {
                return true;
            }

            if (blockedPlayers.Contains(basePlayer.userID))
            {
                command = "/" + command.ToUpperInvariant();
                if (config.BlockedCommands.Contains(command))
                {
                    basePlayer.ChatMessage(GetMessage("CombatBlock.UIMessage", basePlayer));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if a player has an active combat block
        /// </summary>
        /// <param name="playerID">The ID of the player to check</param>
        /// <returns>Returns true if the player has an active combat block, otherwise false</returns>
        [HookMethod("HasCombatBlock")]
        public bool HasCombatBlock(ulong playerID)
        {
            return blockedPlayers.Contains(playerID);
        }

        private void OnServerInitialized(bool initial)
        {
            config = Config.ReadObject<PluginConfig>();
            if (config == null)
            {
                config = new PluginConfig
                {
                    BlockDuration = 10.0f,
                    BlockOnPlayerHit = true,
                    BlockOnReceiveDamage = true,
                    RemoveBlockOnDeath = true,
                    BlockedCommands = new List<string> { "/tpr", "/tpa", "/home" },
                };
                Config.WriteObject(config, true);
            }

            if (RaidBlock == null)
            {
                PrintError("RaidBlock plugin not found!");
            }

            ClearAllCombatBlockUI();
        }

        [HookMethod("HasCombatBlockUI")]
        public bool HasCombatBlockUI(ulong playerID)
        {
            return uiManagers.ContainsKey(playerID);
        }
    }
}
