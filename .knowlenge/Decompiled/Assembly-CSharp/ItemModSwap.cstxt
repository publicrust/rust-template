using UnityEngine;

public class ItemModSwap : ItemMod
{
	public GameObjectRef actionEffect;

	public ItemAmount[] becomeItem;

	public bool sendPlayerPickupNotification;

	public bool sendPlayerDropNotification;

	public float xpScale = 1f;

	public ItemAmount[] RandomOptions;

	public override void DoAction(Item item, BasePlayer player)
	{
		if (item.amount < 1)
		{
			return;
		}
		ItemAmount[] array = becomeItem;
		foreach (ItemAmount itemAmount in array)
		{
			Item item2 = ItemManager.Create(itemAmount.itemDef, (int)itemAmount.amount, 0uL);
			if (item2 != null)
			{
				if (!item2.MoveToContainer(item.parent))
				{
					player.GiveItem(item2);
				}
				if (sendPlayerPickupNotification)
				{
					player.Command("note.inv", item2.info.itemid, item2.amount);
				}
			}
		}
		if (RandomOptions.Length != 0)
		{
			int num = Random.Range(0, RandomOptions.Length);
			Item item3 = ItemManager.Create(RandomOptions[num].itemDef, (int)RandomOptions[num].amount, 0uL);
			if (item3 != null)
			{
				if (!item3.MoveToContainer(item.parent))
				{
					player.GiveItem(item3);
				}
				if (sendPlayerPickupNotification)
				{
					player.Command("note.inv", item3.info.itemid, item3.amount);
				}
			}
		}
		if (sendPlayerDropNotification)
		{
			player.Command("note.inv", item.info.itemid, -1);
		}
		if (actionEffect.isValid)
		{
			Effect.server.Run(actionEffect.resourcePath, player.transform.position, Vector3.up);
		}
		item.UseItem();
	}
}
