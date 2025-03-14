public class ItemModReveal : ItemMod
{
	public static readonly Translate.Phrase RevealItemTitle = new Translate.Phrase("reveal_item", "Reveal BP");

	public static readonly Translate.Phrase RevealItemDesc = new Translate.Phrase("reveal_item_desc", "Reveal blueprint");

	public int numForReveal = 10;

	public ItemDefinition revealedItemOverride;

	public int revealedItemAmount = 1;

	public LootSpawn revealList;

	public GameObjectRef successEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (command == "reveal" && item.amount >= numForReveal)
		{
			int position = item.position;
			item.UseItem(numForReveal);
			Item item2 = null;
			if ((bool)revealedItemOverride)
			{
				item2 = ItemManager.Create(revealedItemOverride, revealedItemAmount, 0uL);
			}
			if (item2 != null && !item2.MoveToContainer(player.inventory.containerMain, (item.amount == 0) ? position : (-1)))
			{
				item2.Drop(player.GetDropPosition(), player.GetDropVelocity());
			}
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
