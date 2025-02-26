using Newtonsoft.Json;

namespace Oxide.Plugins
{
    [Info("InstantFurnace", "fakerplayers", "1.0.0")]
    public sealed class InstantFurnace : RustPlugin
    {
        #region Configuration
        private PluginConfig config = null!;

        protected override void LoadDefaultConfig()
        {
            config = new PluginConfig();
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

        private sealed class PluginConfig
        {
            [JsonProperty("Моментальная плавка в обычной печи")]
            public bool InstantSmeltingFurnace { get; set; } = true;

            [JsonProperty("Моментальная плавка в электрической печи")]
            public bool InstantSmeltingElectricFurnace { get; set; } = true;

            [JsonProperty("Моментальная плавка в большой печи")]
            public bool InstantSmeltingLargeFurnace { get; set; } = true;

            [JsonProperty("Моментальная плавка в костре")]
            public bool InstantSmeltingCampfire { get; set; } = true;

            [JsonProperty("Логировать действия в консоль")]
            public bool LogActions { get; set; }

            public static PluginConfig DefaultConfig()
            {
                return new PluginConfig();
            }
        }
        #endregion Configuration

        #region Permissions
        private const string UsePermission = "instantfurnace.use";
        #endregion Permissions

        #region Initialization
        private void OnServerInitialized(bool initial)
        {
            permission.RegisterPermission(UsePermission, this);
        }
        #endregion Initialization

        #region Hooks
        private void OnItemAddedToContainer(ItemContainer container, Item item)
        {
            if (container?.entityOwner == null || item?.info == null)
            {
                return;
            }

            ItemContainer rootContainer = item.GetRootContainer();
            if (rootContainer == null)
            {
                return;
            }

            BasePlayer player = rootContainer.GetOwnerPlayer();
            if (player != null && !permission.UserHasPermission(player.UserIDString, UsePermission))
            {
                return;
            }

            if (container.entityOwner is not BaseOven oven)
            {
                return;
            }

            bool shouldProcess = oven switch
            {
                BaseOven when oven.ShortPrefabName == "furnace" => config.InstantSmeltingFurnace,
                BaseOven when oven.ShortPrefabName == "electric.furnace" =>
                    config.InstantSmeltingElectricFurnace,
                BaseOven when oven.ShortPrefabName == "furnace.large" =>
                    config.InstantSmeltingLargeFurnace,
                BaseOven when oven.ShortPrefabName == "campfire" => config.InstantSmeltingCampfire,
                _ => false,
            };

            if (!shouldProcess)
            {
                return;
            }

            ItemModCookable cookable = item.info.GetComponent<ItemModCookable>();
            if (cookable != null)
            {
                SmeltItem(oven, item, cookable);
            }
            else if (item.info.shortname == "wood")
            {
                ConvertWoodToCharcoal(oven, item);
            }
        }
        #endregion Hooks

        #region Smelting Logic
        private void SmeltItem(BaseOven oven, Item item, ItemModCookable cookable)
        {
            int amountToSmelt = item.amount;
            ItemDefinition output = cookable.becomeOnCooked;

            if (output != null)
            {
                Item newItem = ItemManager.Create(output, amountToSmelt);
                if (newItem != null)
                {
                    item.RemoveFromContainer();
                    item.Remove();
                    _ = oven.inventory.Insert(newItem);
                }
            }
        }

        private void ConvertWoodToCharcoal(BaseOven oven, Item item)
        {
            int amountToBurn = item.amount;
            ItemDefinition charcoalDef = ItemManager.FindItemDefinition("charcoal.item");

            if (charcoalDef != null)
            {
                Item newItem = ItemManager.Create(charcoalDef, amountToBurn / 2);
                if (newItem != null)
                {
                    item.RemoveFromContainer();
                    item.Remove();
                    _ = oven.inventory.Insert(newItem);
                }
            }
        }
        #endregion Smelting Logic
    }
}
