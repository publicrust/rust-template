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

	public ItemDefinition[] validItemWhitelist = new ItemDefinition[0];

	public bool openInDeployed = true;

	public bool openInInventory = true;

	public List<ItemAmount> defaultContents = new List<ItemAmount>();

	protected virtual bool ForceAcceptItemCheck => false;

	public override void OnItemCreated(Item item)
	{
		if (!item.isServer || capacity <= 0)
		{
			return;
		}
		if (item.contents != null)
		{
			if (validItemWhitelist != null && validItemWhitelist.Length != 0)
			{
				item.contents.canAcceptItem = CanAcceptItem;
			}
			return;
		}
		item.contents = new ItemContainer();
		item.contents.flags = containerFlags;
		item.contents.allowedContents = ((onlyAllowedContents == (ItemContainer.ContentsType)0) ? ItemContainer.ContentsType.Generic : onlyAllowedContents);
		SetAllowedItems(item.contents);
		item.contents.availableSlots = availableSlots;
		if ((validItemWhitelist != null && validItemWhitelist.Length != 0) || ForceAcceptItemCheck)
		{
			item.contents.canAcceptItem = CanAcceptItem;
		}
		item.contents.ServerInitialize(item, capacity);
		item.contents.maxStackSize = maxStackSize;
		item.contents.GiveUID();
	}

	protected virtual void SetAllowedItems(ItemContainer container)
	{
		container.SetOnlyAllowedItem(onlyAllowedItemType);
	}

	protected virtual bool CanAcceptItem(Item item, int count)
	{
		ItemDefinition[] array = validItemWhitelist;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].itemid == item.info.itemid)
			{
				return true;
			}
		}
		return false;
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
