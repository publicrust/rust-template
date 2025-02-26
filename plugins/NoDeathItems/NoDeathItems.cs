using System.Collections.Generic;
using System.Linq;

namespace Oxide.Plugins
{
    [Info("NoDeathItems", "fakerplayers", "0.0.4")]
    public class NoDeathItems : RustPlugin
    {
        public static HashSet<string> BlockedItems { get; set; } = new HashSet<string>();

        protected override void LoadDefaultConfig()
        {
            Config["BlockedItems"] = new List<object> { "pants", "hoodie", "shoes.boots" };
            SaveConfig();
        }

        private void Init()
        {
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

            items
                .Where(item => BlockedItems.Contains(item.info.shortname))
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
