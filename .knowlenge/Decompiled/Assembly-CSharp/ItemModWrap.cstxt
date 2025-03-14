public class ItemModWrap : ItemMod
{
	public GameObjectRef successEffect;

	public ItemDefinition wrappedDefinition;

	public static Translate.Phrase wrap_gift = new Translate.Phrase("wrap_gift", "Wrap Gift");

	public static Translate.Phrase wrap_gift_desc = new Translate.Phrase("wrap_gift_desc", "Wrap this item and turn it in to an openable gift");

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (!(command == "wrap") || item.amount <= 0)
		{
			return;
		}
		Item slot = item.contents.GetSlot(0);
		if (slot != null)
		{
			int position = item.position;
			ItemContainer rootContainer = item.GetRootContainer();
			item.RemoveFromContainer();
			Item item2 = ItemManager.Create(wrappedDefinition, 1, 0uL);
			slot.MoveToContainer(item2.contents);
			item2.MoveToContainer(rootContainer, position);
			item.Remove();
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
