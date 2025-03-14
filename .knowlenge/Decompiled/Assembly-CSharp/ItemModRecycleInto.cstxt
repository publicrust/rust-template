using UnityEngine;

public class ItemModRecycleInto : ItemMod
{
	public static readonly Translate.Phrase RecycleIntoTitle = new Translate.Phrase("recycle_into", "MISSING RECYCLE INTO PHRASE");

	public static readonly Translate.Phrase RecycleIntoDesc = new Translate.Phrase("recycle_into_desc", "MISSING RECYCLE INTO DESC PHRASE");

	public ItemDefinition recycleIntoItem;

	public int numRecycledItemMin = 1;

	public int numRecycledItemMax = 1;

	public GameObjectRef successEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (!(command == "recycle_item"))
		{
			return;
		}
		int num = Random.Range(numRecycledItemMin, numRecycledItemMax + 1);
		item.UseItem();
		if (num > 0)
		{
			Item item2 = ItemManager.Create(recycleIntoItem, num, 0uL);
			item2.SetItemOwnership(player, ItemOwnershipPhrases.Recycler);
			if (!item2.MoveToContainer(player.inventory.containerMain))
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
