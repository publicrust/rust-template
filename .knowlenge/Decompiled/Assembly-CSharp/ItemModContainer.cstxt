#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using Facepunch;
using Rust;
using UnityEngine;

public class ItemModContainer : ItemMod
{
	public int capacity = 6;

	public int maxStackSize;

	public int containerVolume;

	public bool canLootInWorld;

	public float pickupInWorldDelay;

	public float maxWeight = -1f;

	public float worldWeightScale = 1f;

	[InspectorFlags]
	public ItemContainer.Flag containerFlags;

	public ItemContainer.ContentsType onlyAllowedContents = ItemContainer.ContentsType.Generic;

	public ItemDefinition onlyAllowedItemType;

	public List<ItemSlot> availableSlots = new List<ItemSlot>();

	public ItemDefinition[] validItemWhitelist = new ItemDefinition[0];

	public bool openInDeployed = true;

	public bool openInInventory = true;

	public List<ItemAmount> defaultContents = new List<ItemAmount>();

	[Tooltip("If true items in this container won't be usable as ammo for reloads")]
	public bool blockAmmoSource;

	[Header("Sounds")]
	public SoundDefinition openSound;

	public SoundDefinition closeSound;

	protected virtual bool ForceAcceptItemCheck => false;

	public override void OnItemCreated(Item item)
	{
		CreateContents(item);
	}

	protected void CreateContents(Item item)
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
		Debug.Assert(item.contents == null, "Double init of contents!");
		item.contents = Pool.Get<ItemContainer>();
		item.contents.flags = containerFlags;
		item.contents.allowedContents = ((onlyAllowedContents == (ItemContainer.ContentsType)0) ? ItemContainer.ContentsType.Generic : onlyAllowedContents);
		SetAllowedItems(item.contents);
		item.contents.UpdateAvailableSlots(availableSlots);
		ItemContainer contents = item.contents;
		contents.onItemAddedRemoved = (Action<Item, bool>)Delegate.Combine(contents.onItemAddedRemoved, new Action<Item, bool>(OnItemAddedOrRemoved));
		if ((validItemWhitelist != null && validItemWhitelist.Length != 0) || ForceAcceptItemCheck)
		{
			item.contents.canAcceptItem = CanAcceptItem;
		}
		item.contents.ServerInitialize(item, capacity);
		item.contents.containerVolume = containerVolume;
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

	private void OnItemAddedOrRemoved(Item item, bool added)
	{
		if (!Rust.Application.isLoadingSave)
		{
			DroppedItem droppedItem = item.parentItem?.GetWorldEntity() as DroppedItem;
			if (!(droppedItem == null))
			{
				droppedItem.UpdateItemMass();
			}
		}
	}

	public override void OnVirginItem(Item item, BasePlayer creatingPlayer)
	{
		base.OnVirginItem(item, creatingPlayer);
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
