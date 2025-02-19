using System.Collections.Generic;
using System.Linq;

namespace Oxide.Plugins
{
    [Info("NoDeathItems", "fakerplayers", "0.0.4")]
    public class NoDeathItems : RustPlugin
    {
        public required HashSet<string> BlockedItems { get; set; } = new();

        protected override void LoadDefaultConfig()
        {
            Config["BlockedItems"] = new List<object> { "pants", "hoodie", "shoes.boots" };
            SaveConfig();
        }

        private void Init()
        {
            LogToFile("startup", "Для вас старался fakerplayers", this);
            LogToFile("startup", "Переведите мне 1 рубль, я буду благодарен", this);
            LogToFile("startup", "Карта - 2200700914172696", this);
            PrintWarning("[NoDeathItems] Plugin created by fakerplayers");
            PrintWarning("[NoDeathItems] If you like this plugin, please donate 1 RUB");
            PrintWarning("[NoDeathItems] Card number: 2200700914172696");

            List<object> blockedItemsList = Config.Get<List<object>>("BlockedItems");
            BlockedItems = new HashSet<string>(blockedItemsList.ConvertAll(x => x.ToString()));
        }

        private object? OnPlayerDeath(BasePlayer player, HitInfo info)
        {
            if (player?.inventory == null)
            {
                return null;
            }

            List<Item> items = new();
            _ = player.inventory.GetAllItems(items);

            items.Where(item => BlockedItems.Contains(item.info.shortname))
                .ToList()
                .ForEach(item =>
                {
                    item.RemoveFromContainer();
                    item.Remove();
                });

            return null;
        }
    }
}