using System;
using Facepunch.Rust;
using Oxide.Core;
using UnityEngine;

public class PlayerBelt
{
	public static int ClientAutoSelectSlot = -1;

	public static uint ClientAutoSeletItemUID = 0u;

	public static EncryptedValue<int> SelectedSlot = -1;

	protected BasePlayer player;

	public static int MaxBeltSlots => 6;

	public PlayerBelt(BasePlayer player)
	{
		this.player = player;
	}

	public void DropActive(Vector3 position, Vector3 velocity)
	{
		if (player.GetActiveShield(out var foundShield))
		{
			if (Interface.CallHook("OnPlayerActiveShieldDrop", player, foundShield) != null)
			{
				return;
			}
			DroppedItem droppedItem = foundShield.GetItem().Drop(position, velocity) as DroppedItem;
			if (droppedItem != null)
			{
				droppedItem.DropReason = DroppedItem.DropReasonEnum.Death;
				droppedItem.DroppedBy = player.userID;
				droppedItem.DroppedTime = DateTime.UtcNow;
				Facepunch.Rust.Analytics.Azure.OnItemDropped(player, droppedItem, DroppedItem.DropReasonEnum.Death);
			}
		}
		Item activeItem = player.GetActiveItem();
		if (activeItem == null || Interface.CallHook("OnPlayerDropActiveItem", player, activeItem) != null)
		{
			return;
		}
		using (TimeWarning.New("PlayerBelt.DropActive"))
		{
			DroppedItem droppedItem2 = activeItem.Drop(position, velocity) as DroppedItem;
			if (droppedItem2 != null)
			{
				droppedItem2.DropReason = DroppedItem.DropReasonEnum.Death;
				droppedItem2.DroppedBy = player.userID;
				droppedItem2.DroppedTime = DateTime.UtcNow;
				Facepunch.Rust.Analytics.Azure.OnItemDropped(player, droppedItem2, DroppedItem.DropReasonEnum.Death);
			}
			player.svActiveItemID = default(ItemId);
			player.SendNetworkUpdate();
		}
	}

	public Item GetItemInSlot(int slot)
	{
		if (player == null)
		{
			return null;
		}
		if (player.inventory == null)
		{
			return null;
		}
		if (player.inventory.containerBelt == null)
		{
			return null;
		}
		return player.inventory.containerBelt.GetSlot(slot);
	}

	public Handcuffs GetRestraintItem()
	{
		if (player == null)
		{
			return null;
		}
		if (player.inventory == null)
		{
			return null;
		}
		if (player.inventory.containerBelt == null)
		{
			return null;
		}
		foreach (Item item in player.inventory.containerBelt.itemList)
		{
			if (item != null)
			{
				Handcuffs handcuffs = item.GetHeldEntity() as Handcuffs;
				if (!(handcuffs == null) && handcuffs.Locked)
				{
					return handcuffs;
				}
			}
		}
		return null;
	}

	public bool CanHoldItem()
	{
		if (player == null)
		{
			return false;
		}
		if (player.IsWounded())
		{
			return false;
		}
		if (player.IsSleeping())
		{
			return false;
		}
		if (player.isMounted && !player.GetMounted().CanHoldItems())
		{
			return false;
		}
		return true;
	}
}
