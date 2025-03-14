using System.Collections.Generic;

public class ItemModContainer : ItemMod
{
	public int capacity = 6;

	public int maxStackSize;

	[InspectorFlags]
	public ItemContainer.Flag containerFlags;

	public ItemContainer.ContentsType onlyAllowedContents = ItemContainer.ContentsType.Generic;

	public ItemDefinition onlyAllowedItemType;

	public List<ItemSlot> availableSlots = new List<ItemSlot>();

	public bool openInDeployed = true;

	public bool openInInventory = true;

	public List<ItemAmount> defaultContents = new List<ItemAmount>();

	public override void OnItemCreated(Item item)
	{
		if (item.isServer && capacity > 0 && item.contents == null)
		{
			item.contents = new ItemContainer();
			item.contents.flags = containerFlags;
			item.contents.allowedContents = ((onlyAllowedContents == (ItemContainer.ContentsType)0) ? ItemContainer.ContentsType.Generic : onlyAllowedContents);
			item.contents.onlyAllowedItem = onlyAllowedItemType;
			item.contents.availableSlots = availableSlots;
			item.contents.ServerInitialize(item, capacity);
			item.contents.maxStackSize = maxStackSize;
			item.contents.GiveUID();
		}
	}

	public override void OnVirginItem(Item item)
	{
		base.OnVirginItem(item);
		foreach (ItemAmount defaultContent in defaultContents)
		{
			ItemManager.Create(defaultContent.itemDef, (int)defaultContent.amount, 0uL)?.MoveToContainer(item.contents);
		}
	}

	public override void CollectedForCrafting(Item item, BasePlayer crafter)
	{
		if (item.contents == null)
		{
			return;
		}
		for (int num = item.contents.itemList.Count - 1; num >= 0; num--)
		{
			Item item2 = item.contents.itemList[num];
			if (!item2.MoveToContainer(crafter.inventory.containerMain))
			{
				item2.Drop(crafter.GetDropPosition(), crafter.GetDropVelocity());
			}
		}
	}
}
