using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Game.Rust.Cui;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Mineral Economy", "YourName", "1.0.0")]
    [Description("Динамическая экономика для минералов с автоматическим изменением цен")]
    public class MineralEconomy : RustPlugin
    {
        #region Fields
        private const string PermissionUse = "mineraleconomy.use";
        private const string PermissionAdmin = "mineraleconomy.admin";
        private const string PermissionCommand = "mineraleconomy.command";
        private const string PermissionButton = "mineraleconomy.button";
        private Configuration config = null!;
        private StoredData storedData = null!;
        private const string UiMain = "MineralEconomy.UI";
        private const string MineralShortname = "coal";
        private const ulong MineralSkinId = 3165461999;
        private readonly Dictionary<ulong, Recycler> playerRecyclers = new();
        private Timer? distanceCheckTimer;
        private const float MaxDistanceFromRecycler = 3f;
        #endregion Fields

        #region Configuration
        private sealed class Configuration
        {
            [JsonProperty("Стоимость продажи минерала в зависимости от наличия")]
            public required List<PriceRange> SellPrices { get; set; }

            [JsonProperty("Стоимость покупки минерала в зависимости от наличия")]
            public required List<PriceRange> BuyPrices { get; set; }

            [JsonProperty("Настройки меню")]
            public required MenuSettings MenuSettings { get; set; }

            public static Configuration DefaultConfig()
            {
                return new Configuration
                {
                    SellPrices = new List<PriceRange>
                    {
                        new()
                        {
                            MinAmount = 0,
                            MaxAmount = 10,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 50,
                            },
                        },
                        new()
                        {
                            MinAmount = 11,
                            MaxAmount = 20,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 40,
                            },
                        },
                        new()
                        {
                            MinAmount = 21,
                            MaxAmount = 30,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 30,
                            },
                        },
                        new()
                        {
                            MinAmount = 31,
                            MaxAmount = 50,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 20,
                            },
                        },
                        new()
                        {
                            MinAmount = 51,
                            MaxAmount = 10000,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 10,
                            },
                        },
                    },
                    BuyPrices = new List<PriceRange>
                    {
                        new()
                        {
                            MinAmount = 0,
                            MaxAmount = 10,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 100,
                            },
                        },
                        new()
                        {
                            MinAmount = 11,
                            MaxAmount = 20,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 80,
                            },
                        },
                        new()
                        {
                            MinAmount = 21,
                            MaxAmount = 30,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 60,
                            },
                        },
                        new()
                        {
                            MinAmount = 31,
                            MaxAmount = 50,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 40,
                            },
                        },
                        new()
                        {
                            MinAmount = 51,
                            MaxAmount = 10000,
                            Price = new()
                            {
                                ShortName = "scrap",
                                SkinId = 0,
                                Amount = 20,
                            },
                        },
                    },
                    MenuSettings = new MenuSettings
                    {
                        AnchorSettings = new AnchorSettings
                        {
                            RecyclerButton = new ButtonSettings
                            {
                                AnchorMin = "0.5 0.2",
                                AnchorMax = "0.6 0.25",
                                OffsetMin = "0 0",
                                OffsetMax = "0 0",
                            },
                        },
                    },
                };
            }
        }

        internal sealed class PriceRange
        {
            [JsonProperty("Минимальное количество")]
            public int MinAmount { get; set; }

            [JsonProperty("Максимальное количество")]
            public int MaxAmount { get; set; }

            [JsonProperty("Цена")]
            public required ItemAmount Price { get; set; }
        }

        internal sealed class ItemAmount
        {
            [JsonProperty(nameof(ShortName))]
            public required string ShortName { get; set; }

            [JsonProperty(nameof(SkinId))]
            public ulong SkinId { get; set; }

            [JsonProperty(nameof(Amount))]
            public int Amount { get; set; }
        }

        internal sealed class MenuSettings
        {
            [JsonProperty("Настройки привязки")]
            public required AnchorSettings AnchorSettings { get; set; }
        }

        internal sealed class AnchorSettings
        {
            [JsonProperty("Кнопка переработчика")]
            public required ButtonSettings RecyclerButton { get; set; }
        }

        internal sealed class ButtonSettings
        {
            [JsonProperty(nameof(AnchorMin))]
            public required string AnchorMin { get; set; }

            [JsonProperty(nameof(AnchorMax))]
            public required string AnchorMax { get; set; }

            [JsonProperty(nameof(OffsetMin))]
            public required string OffsetMin { get; set; }

            [JsonProperty(nameof(OffsetMax))]
            public required string OffsetMax { get; set; }
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                config = Config.ReadObject<Configuration>();
                if (config == null)
                {
                    LoadDefaultConfig();
                }
            }
            catch (Exception ex) when (ex is JsonException or InvalidCastException)
            {
                LoadDefaultConfig();
            }
            SaveConfig();
        }

        protected override void LoadDefaultConfig()
        {
            config = Configuration.DefaultConfig();
        }

        protected override void SaveConfig()
        {
            Config.WriteObject(config);
        }
        #endregion Configuration

        #region Data
        private sealed class StoredData
        {
            [JsonProperty("Всего продано минералов")]
            public int TotalMineralsSold { get; set; }

            [JsonProperty("Всего куплено минералов")]
            public int TotalMineralsBought { get; set; }

            [JsonProperty("Текущий баланс минералов")]
            public int CurrentMineralAmount => TotalMineralsSold - TotalMineralsBought;

            public StoredData()
            {
                TotalMineralsSold = 0;
                TotalMineralsBought = 0;
            }
        }

        private void LoadData()
        {
            storedData = Interface.Oxide.DataFileSystem.ReadObject<StoredData>("MineralEconomy");
            if (storedData == null)
            {
                storedData = new StoredData();
                SaveData();
            }
        }

        private void SaveData()
        {
            Interface.Oxide.DataFileSystem.WriteObject("MineralEconomy", storedData);
        }
        #endregion Data

        #region Oxide Hooks
        private void Init()
        {
            permission.RegisterPermission(PermissionUse, this);
            permission.RegisterPermission(PermissionAdmin, this);
            permission.RegisterPermission(PermissionCommand, this);
            permission.RegisterPermission(PermissionButton, this);
            LoadData();

            distanceCheckTimer = timer.Every(1f, CheckPlayersDistance);
        }

        private void OnServerInitialized(bool initial)
        {
            // Register commands
            cmd.AddChatCommand("mineral", this, CmdMineral);
            cmd.AddChatCommand("minerals", this, CmdMineral);
            cmd.AddChatCommand("givemineral", this, CmdGiveMineral);
        }

        private void Unload()
        {
            distanceCheckTimer?.Destroy();

            foreach (BasePlayer player in BasePlayer.activePlayerList)
            {
                if (player == null)
                {
                    continue;
                }

                _ = CuiHelper.DestroyUi(player, UiMain);
                _ = CuiHelper.DestroyUi(player, "MarketRecyclerButton");
            }
        }

        private void CheckPlayersDistance()
        {
            foreach (KeyValuePair<ulong, Recycler> kvp in playerRecyclers.ToList())
            {
                BasePlayer player = BasePlayer.FindByID(kvp.Key);
                Recycler recycler = kvp.Value;

                if (player == null || recycler == null)
                {
                    _ = playerRecyclers.Remove(kvp.Key);
                    continue;
                }

                float distance = Vector3.Distance(
                    player.transform.position,
                    recycler.transform.position
                );
                if (distance > MaxDistanceFromRecycler)
                {
                    DestroyUI(player);
                    SendReply(
                        player,
                        GetLocalizedMessage("TooFarFromRecycler", player.UserIDString)
                    );
                    _ = playerRecyclers.Remove(kvp.Key);
                }
            }
        }
        #endregion Oxide Hooks

        #region Commands
        private void CmdMineral(BasePlayer player, string command, string[] args)
        {
            if (!permission.UserHasPermission(player.UserIDString, PermissionCommand))
            {
                SendReply(player, GetLocalizedMessage("NoPermissionCommand", player.UserIDString));
                return;
            }

            ShowUI(player);
        }

        private void CmdGiveMineral(BasePlayer player, string command, string[] args)
        {
            if (!permission.UserHasPermission(player.UserIDString, PermissionAdmin))
            {
                SendReply(player, "У вас нет разрешения на использование этой команды!");
                return;
            }

            if (args.Length < 2)
            {
                SendReply(player, "Использование: /givemineral <игрок> <количество>");
                return;
            }

            BasePlayer target = BasePlayer.Find(args[0]);
            if (target == null)
            {
                SendReply(player, "Игрок не найден!");
                return;
            }

            if (!int.TryParse(args[1], out int amount) || amount <= 0)
            {
                SendReply(player, "Укажите корректное количество минералов!");
                return;
            }

            GiveItem(target, MineralShortname, MineralSkinId, amount);
            storedData.TotalMineralsSold += amount;
            SaveData();

            SendReply(player, $"Вы выдали {amount} минералов игроку {target.displayName}");
            SendReply(target, $"Вы получили {amount} минералов от администратора");
        }

        [ConsoleCommand("mineraleconomy.sell")]
        private void CmdSell(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            if (player == null)
            {
                return;
            }

            int amount = arg.GetInt(0, 1);
            if (amount is not (1 or 10))
            {
                SendReply(player, "Неверное количество минералов!");
                return;
            }

            int currentPrice = GetCurrentSellPrice();

            if (!HasItem(player, MineralShortname, MineralSkinId, amount))
            {
                SendReply(player, "У вас недостаточно минералов!");
                return;
            }

            TakeItem(player, MineralShortname, MineralSkinId, amount);
            GiveItem(player, "scrap", 0, currentPrice * amount);
            storedData.TotalMineralsSold += amount;
            SaveData();

            SendReply(player, $"Вы продали {amount} минералов за {currentPrice * amount} скрапа!");
            ShowUI(player);
        }

        [ConsoleCommand("mineraleconomy.buy")]
        private void CmdBuy(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            if (player == null)
            {
                return;
            }

            int amount = arg.GetInt(0, 1);
            if (amount is not (1 or 10))
            {
                SendReply(player, "Неверное количество минералов!");
                return;
            }

            int currentPrice = GetCurrentBuyPrice();

            if (!HasItem(player, "scrap", 0, currentPrice * amount))
            {
                SendReply(player, "У вас недостаточно скрапа!");
                return;
            }

            if (storedData.CurrentMineralAmount < amount)
            {
                SendReply(player, "На сервере недостаточно минералов!");
                return;
            }

            TakeItem(player, "scrap", 0, currentPrice * amount);
            GiveItem(player, MineralShortname, MineralSkinId, amount);
            storedData.TotalMineralsBought += amount;
            SaveData();

            SendReply(player, $"Вы купили {amount} минералов за {currentPrice * amount} скрапа!");
            ShowUI(player);
        }
        #endregion Commands

        #region UI
        private void ShowUI(BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            try
            {
                DestroyUI(player);

                Recycler? nearestRecycler = null;
                float minDistance = float.MaxValue;

                foreach (Recycler recycler in UnityEngine.Object.FindObjectsOfType<Recycler>())
                {
                    float distance = Vector3.Distance(
                        player.transform.position,
                        recycler.transform.position
                    );
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestRecycler = recycler;
                    }
                }

                if (nearestRecycler == null || minDistance > MaxDistanceFromRecycler)
                {
                    SendReply(
                        player,
                        GetLocalizedMessage("TooFarFromRecycler", player.UserIDString)
                    );
                    return;
                }

                playerRecyclers[player.userID] = nearestRecycler;

                int currentSellPrice = GetCurrentSellPrice();
                int currentBuyPrice = GetCurrentBuyPrice();

                CuiElementContainer container = new()
                {
                    // Основная панель
                    {
                        new CuiPanel
                        {
                            Image =
                            {
                                Color = HexToRustFormat("#3c3a34"),
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            RectTransform = { AnchorMin = "0.25 0.15", AnchorMax = "0.75 0.85" },
                            CursorEnabled = true,
                        },
                        "Overlay",
                        UiMain
                    },
                    // Верхняя панель заголовка
                    {
                        new CuiPanel
                        {
                            Image =
                            {
                                Color = HexToRustFormat("#524e49"),
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            RectTransform = { AnchorMin = "0 0.9", AnchorMax = "1 1" },
                        },
                        UiMain
                    },
                    // Заголовок
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = GetLocalizedMessage("MarketTitle", player.UserIDString),
                                FontSize = 20,
                                Font = "robotocondensed-bold.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0 0.9", AnchorMax = "1 1" },
                        },
                        UiMain
                    },
                    // Добавляем подзаголовок с описанием
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = "Цены зависят от количества минералов на рынке",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0 0.86", AnchorMax = "1 0.89" },
                        },
                        UiMain
                    },
                    // Кнопка закрытия
                    {
                        new CuiButton
                        {
                            Button =
                            {
                                Color = "0.7 0.3 0.2 0.98",
                                Command = "mineraleconomy.close",
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            Text =
                            {
                                Text = "✕",
                                FontSize = 20,
                                Font = "robotocondensed-bold.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.92 0.91", AnchorMax = "0.98 0.99" },
                        },
                        UiMain
                    },
                    // Информационная панель
                    {
                        new CuiPanel
                        {
                            Image =
                            {
                                Color = HexToRustFormat("#524e49"),
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            RectTransform = { AnchorMin = "0.05 0.75", AnchorMax = "0.95 0.85" },
                        },
                        UiMain
                    },
                    // Баланс минералов с дополнительной информацией
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text =
                                    $"Текущий баланс рынка: {storedData.CurrentMineralAmount} минералов",
                                FontSize = 16,
                                Font = "robotocondensed-bold.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.1 0.79", AnchorMax = "0.9 0.85" },
                        },
                        UiMain
                    },
                    // Актуальный курс продажи с пояснением
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = $"Текущая цена продажи: {currentSellPrice} ⚙ за минерал",
                                FontSize = 14,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleRight,
                                Color = HexToRustFormat("#7FD47F"),
                            },
                            RectTransform = { AnchorMin = "0.1 0.75", AnchorMax = "0.48 0.79" },
                        },
                        UiMain
                    },
                    // Актуальный курс покупки с пояснением
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = $"Текущая цена покупки: {currentBuyPrice} ⚙ за минерал",
                                FontSize = 14,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleLeft,
                                Color = HexToRustFormat("#FF6B6B"),
                            },
                            RectTransform = { AnchorMin = "0.52 0.75", AnchorMax = "0.9 0.79" },
                        },
                        UiMain
                    },
                    // Панель продажи
                    {
                        new CuiPanel
                        {
                            Image =
                            {
                                Color = HexToRustFormat("#524e49"),
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            RectTransform = { AnchorMin = "0.05 0.45", AnchorMax = "0.475 0.7" },
                        },
                        UiMain
                    },
                    // Заголовок продажи
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = GetLocalizedMessage("SellToServer", player.UserIDString),
                                FontSize = 16,
                                Font = "robotocondensed-bold.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.05 0.65", AnchorMax = "0.475 0.7" },
                        },
                        UiMain
                    },
                    // Кнопки продажи
                    {
                        new CuiButton
                        {
                            Button =
                            {
                                Color = HexToRustFormat("#637640"),
                                Command = "mineraleconomy.sell 1",
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            Text =
                            {
                                Text = $"ПРОДАТЬ 1 МИНЕРАЛ\nВы получите {currentSellPrice} ⚙",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.07 0.55", AnchorMax = "0.455 0.62" },
                        },
                        UiMain
                    },
                    {
                        new CuiButton
                        {
                            Button =
                            {
                                Color = HexToRustFormat("#637640"),
                                Command = "mineraleconomy.sell 10",
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            Text =
                            {
                                Text =
                                    $"ПРОДАТЬ 10 МИНЕРАЛОВ\nВы получите {currentSellPrice * 10} ⚙",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.07 0.46", AnchorMax = "0.455 0.53" },
                        },
                        UiMain
                    },
                    // Панель покупки
                    {
                        new CuiPanel
                        {
                            Image =
                            {
                                Color = HexToRustFormat("#524e49"),
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            RectTransform = { AnchorMin = "0.525 0.45", AnchorMax = "0.95 0.7" },
                        },
                        UiMain
                    },
                    // Заголовок покупки
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = GetLocalizedMessage("BuyFromServer", player.UserIDString),
                                FontSize = 16,
                                Font = "robotocondensed-bold.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.525 0.65", AnchorMax = "0.95 0.7" },
                        },
                        UiMain
                    },
                    // Кнопки покупки
                    {
                        new CuiButton
                        {
                            Button =
                            {
                                Color = HexToRustFormat("#783838"),
                                Command = "mineraleconomy.buy 1",
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            Text =
                            {
                                Text = $"КУПИТЬ 1 МИНЕРАЛ\nСтоимость: {currentBuyPrice} ⚙",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.545 0.55", AnchorMax = "0.93 0.62" },
                        },
                        UiMain
                    },
                    {
                        new CuiButton
                        {
                            Button =
                            {
                                Color = HexToRustFormat("#783838"),
                                Command = "mineraleconomy.buy 10",
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            Text =
                            {
                                Text = $"КУПИТЬ 10 МИНЕРАЛОВ\nСтоимость: {currentBuyPrice * 10} ⚙",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.545 0.46", AnchorMax = "0.93 0.53" },
                        },
                        UiMain
                    },
                    // Таблица цен
                    {
                        new CuiPanel
                        {
                            Image =
                            {
                                Color = HexToRustFormat("#524e49"),
                                Material = "assets/content/ui/uibackgroundblur-ingame.mat",
                            },
                            RectTransform = { AnchorMin = "0.05 0.05", AnchorMax = "0.95 0.4" },
                        },
                        UiMain
                    },
                    // Заголовок таблицы с подробным описанием
                    {
                        new CuiLabel
                        {
                            Text =
                            {
                                Text =
                                    "СИСТЕМА ДИНАМИЧЕСКОГО ЦЕНООБРАЗОВАНИЯ\n"
                                    + "Цены автоматически меняются в зависимости от количества минералов на рынке:\n"
                                    + "• Чем меньше минералов, тем выше цена покупки\n"
                                    + "• Чем больше минералов, тем ниже цена продажи",
                                FontSize = 12,
                                Font = "robotocondensed-bold.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform = { AnchorMin = "0.05 0.35", AnchorMax = "0.95 0.4" },
                        },
                        UiMain
                    },
                };

                // Заголовки колонок с пояснениями
                string[] headers = { "Баланс рынка", "Цена продажи (⚙)", "Цена покупки (⚙)" };

                const float columnWidth = 0.28f;
                const float startX = 0.055f;

                for (int i = 0; i < headers.Length; i++)
                {
                    _ = container.Add(
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = headers[i],
                                FontSize = 12,
                                Font = "robotocondensed-bold.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform =
                            {
                                AnchorMin = $"{startX + (i * (columnWidth + 0.02))} 0.3",
                                AnchorMax = $"{startX + ((i + 1) * columnWidth) + (i * 0.02)} 0.35",
                            },
                        },
                        UiMain
                    );
                }

                // Данные таблицы с пояснениями
                for (int i = 0; i < config.SellPrices.Count; i++)
                {
                    float yMin = 0.25f - (i * 0.04f);
                    float yMax = yMin + 0.035f;

                    _ = container.Add(
                        new CuiLabel
                        {
                            Text =
                            {
                                Text =
                                    $"{config.SellPrices[i].MinAmount}-{config.SellPrices[i].MaxAmount} шт.",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#dcd3cc"),
                            },
                            RectTransform =
                            {
                                AnchorMin = $"{startX} {yMin}",
                                AnchorMax = $"{startX + columnWidth} {yMax}",
                            },
                        },
                        UiMain
                    );

                    _ = container.Add(
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = $"{config.SellPrices[i].Price.Amount} ⚙ за шт.",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#7FD47F"),
                            },
                            RectTransform =
                            {
                                AnchorMin = $"{startX + columnWidth + 0.02} {yMin}",
                                AnchorMax = $"{startX + (2 * columnWidth) + 0.02} {yMax}",
                            },
                        },
                        UiMain
                    );

                    _ = container.Add(
                        new CuiLabel
                        {
                            Text =
                            {
                                Text = $"{config.BuyPrices[i].Price.Amount} ⚙ за шт.",
                                FontSize = 12,
                                Font = "robotocondensed-regular.ttf",
                                Align = TextAnchor.MiddleCenter,
                                Color = HexToRustFormat("#FF6B6B"),
                            },
                            RectTransform =
                            {
                                AnchorMin = $"{startX + (2 * columnWidth) + 0.04} {yMin}",
                                AnchorMax = $"{startX + (3 * columnWidth) + 0.04} {yMax}",
                            },
                        },
                        UiMain
                    );
                }

                _ = CuiHelper.AddUi(player, container);
            }
            catch (Exception ex)
            {
                PrintError($"Error showing UI for {player.displayName}: {ex}");
            }
        }

        private void DestroyUI(BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            try
            {
                _ = CuiHelper.DestroyUi(player, UiMain);
            }
            catch (ArgumentException ex)
            {
                PrintError(
                    $"Invalid UI arguments while destroying for {player.displayName}: {ex.Message}"
                );
            }
            catch (InvalidOperationException ex)
            {
                PrintError(
                    $"Invalid UI operation while destroying for {player.displayName}: {ex.Message}"
                );
            }
        }
        #endregion UI

        #region Helpers
        private string HexToRustFormat(string hex)
        {
            if (hex.StartsWith('#'))
            {
                hex = hex.Substring(1);
            }

            if (hex.Length is 6 or 8)
            {
                int r = Convert.ToInt32(hex.Substring(0, 2), 16);
                int g = Convert.ToInt32(hex.Substring(2, 2), 16);
                int b = Convert.ToInt32(hex.Substring(4, 2), 16);
                float a = hex.Length == 8 ? Convert.ToInt32(hex.Substring(6, 2), 16) / 255f : 1f;

                return $"{r / 255f} {g / 255f} {b / 255f} {a}";
            }

            return "1 1 1 1";
        }

        private int GetCurrentSellPrice()
        {
            PriceRange range = config.SellPrices.FirstOrDefault(r =>
                storedData.CurrentMineralAmount >= r.MinAmount
                && storedData.CurrentMineralAmount <= r.MaxAmount
            );

            return range?.Price.Amount ?? 0;
        }

        private int GetCurrentBuyPrice()
        {
            PriceRange range = config.BuyPrices.FirstOrDefault(r =>
                storedData.CurrentMineralAmount >= r.MinAmount
                && storedData.CurrentMineralAmount <= r.MaxAmount
            );

            return range?.Price.Amount ?? 0;
        }

        [ConsoleCommand("mineraleconomy.close")]
        private void CmdCloseUI(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            if (player == null)
            {
                return;
            }

            DestroyUI(player);
        }

        private bool HasItem(BasePlayer player, string shortname, ulong skinId, int amount)
        {
            ItemDefinition definition = ItemManager.FindItemDefinition(shortname);
            if (definition == null)
            {
                return false;
            }

            int totalAmount = 0;
            ItemContainer mainContainer = player.inventory.containerMain;
            foreach (Item item in mainContainer.itemList)
            {
                if (item.info.itemid == definition.itemid && item.skin == skinId)
                {
                    totalAmount += item.amount;
                }
            }
            return totalAmount >= amount;
        }

        private void TakeItem(BasePlayer player, string shortname, ulong skinId, int amount)
        {
            ItemDefinition definition = ItemManager.FindItemDefinition(shortname);
            if (definition == null)
            {
                return;
            }

            int remainingAmount = amount;
            ItemContainer mainContainer = player.inventory.containerMain;
            List<Item> itemsToRemove = new();

            foreach (Item item in mainContainer.itemList)
            {
                if (remainingAmount <= 0)
                {
                    break;
                }
                if (item.info.itemid == definition.itemid && item.skin == skinId)
                {
                    int amountToTake = Math.Min(remainingAmount, item.amount);
                    if (amountToTake >= item.amount)
                    {
                        remainingAmount -= item.amount;
                        itemsToRemove.Add(item);
                    }
                    else
                    {
                        item.amount -= amountToTake;
                        remainingAmount -= amountToTake;
                        item.MarkDirty();
                    }
                }
            }

            foreach (Item item in itemsToRemove)
            {
                item.Remove();
            }
        }

        private void GiveItem(BasePlayer player, string shortname, ulong skinId, int amount)
        {
            Item item = ItemManager.CreateByName(shortname, amount, skinId);
            if (item != null)
            {
                player.GiveItem(item);
            }
        }
        #endregion Helpers

        #region Localization
        protected override void LoadDefaultMessages()
        {
            lang.RegisterMessages(
                new Dictionary<string, string>
                {
                    ["MarketTitle"] = "MINERAL MARKET",
                    ["MarketTitleRu"] = "ТОРГОВАЯ ПЛОЩАДКА МИНЕРАЛОВ",
                    ["MarketButton"] = "Mineral market",
                    ["MarketButtonRu"] = "РЫНОК МИНЕРАЛОВ",
                    ["AvailableAmount"] = "AVAILABLE ON MARKET",
                    ["AvailableAmountRu"] = "ДОСТУПНО НА РЫНКЕ",
                    ["CurrentRate"] = "CURRENT RATE",
                    ["CurrentRateRu"] = "АКТУАЛЬНЫЙ КУРС",
                    ["SellToServer"] = "SELL TO SERVER",
                    ["SellToServerRu"] = "ПРОДАЖА СЕРВЕРУ",
                    ["BuyFromServer"] = "BUY FROM SERVER",
                    ["BuyFromServerRu"] = "ПОКУПКА У СЕРВЕРА",
                    ["SellDescription"] = "Sell your minerals to the server at a profitable price",
                    ["SellDescriptionRu"] = "Продайте ваши минералы серверу по выгодной цене",
                    ["BuyDescription"] = "Buy minerals from the server at current rate",
                    ["BuyDescriptionRu"] = "Приобретайте минералы у сервера по текущему курсу",
                    ["PricingSystem"] = "DYNAMIC PRICING SYSTEM",
                    ["PricingSystemRu"] = "СИСТЕМА ДИНАМИЧЕСКОГО ЦЕНООБРАЗОВАНИЯ",
                    ["MarketAmount"] = "MARKET AMOUNT",
                    ["MarketAmountRu"] = "КОЛИЧЕСТВО НА РЫНКЕ",
                    ["SellPrice"] = "SELL PRICE",
                    ["SellPriceRu"] = "ЦЕНА ПРОДАЖИ",
                    ["BuyPrice"] = "BUY PRICE",
                    ["BuyPriceRu"] = "ЦЕНА ПОКУПКИ",
                    ["TooFarFromRecycler"] = "Вы слишком далеко от переработчика!",
                },
                this
            );
        }

        private string GetLocalizedMessage(string key, string? userId = null)
        {
            return lang.GetMessage(key, this, userId);
        }
        #endregion Localization

        #region UI Hooks
        private void OnLootEntity(BasePlayer player, StorageContainer container)
        {
            if (player == null || container == null)
            {
                return;
            }

            Recycler? recycler = container as Recycler;
            if (recycler != null)
            {
                if (!permission.UserHasPermission(player.UserIDString, PermissionButton))
                {
                    SendReply(
                        player,
                        GetLocalizedMessage("NoPermissionButton", player.UserIDString)
                    );
                    return;
                }

                CuiElementContainer elements = new()
                {
                    {
                        new CuiPanel
                        {
                            CursorEnabled = false,
                            RectTransform =
                            {
                                AnchorMin = "0.5 0",
                                AnchorMax = "0.5 0",
                                OffsetMin = "470 400",
                                OffsetMax = "572 420",
                            },
                            Image = { Color = "0 0 0 0" },
                        },
                        "Overlay",
                        "MarketRecyclerPanel"
                    },
                    {
                        new CuiButton
                        {
                            Button =
                            {
                                Color = "0.4313726 0.5372549 0.2705882 1",
                                Command = "chat.say /mineral",
                                Material = "assets/icons/greyout.mat",
                            },
                            Text =
                            {
                                Text = GetLocalizedMessage("MarketButton", player.UserIDString),
                                Font = "robotocondensed-bold.ttf",
                                FontSize = 12,
                                Align = TextAnchor.MiddleCenter,
                                Color = "0.9686275 0.9215687 0.8705883 1",
                            },
                            RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" },
                        },
                        "MarketRecyclerPanel",
                        "MarketRecyclerButton"
                    },
                };

                _ = CuiHelper.DestroyUi(player, "MarketRecyclerPanel");
                _ = CuiHelper.AddUi(player, elements);
            }
        }

        private void OnLootEntityEnd(BasePlayer player, StorageContainer container)
        {
            if (player == null)
            {
                return;
            }

            Recycler? recycler = container as Recycler;
            if (recycler != null)
            {
                _ = CuiHelper.DestroyUi(player, "MarketRecyclerPanel");
            }
        }

        private void OnEntityDismounted(BaseMountable entity, BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            _ = CuiHelper.DestroyUi(player, "MarketRecyclerPanel");
        }

        private void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            if (player == null)
            {
                return;
            }

            _ = CuiHelper.DestroyUi(player, "MarketRecyclerPanel");
        }

        private void OnPlayerSleepEnded(BasePlayer player)
        {
            if (player == null)
            {
                return;
            }

            _ = CuiHelper.DestroyUi(player, "MarketRecyclerPanel");
        }
        #endregion UI Hooks
    }
}
