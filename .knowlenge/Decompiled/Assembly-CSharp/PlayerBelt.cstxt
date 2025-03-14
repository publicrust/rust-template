using Oxide.Core;
using UnityEngine;

public class PlayerBelt
{
	public static int SelectedSlot = -1;

	protected BasePlayer player;

	public static int MaxBeltSlots => 6;

	public PlayerBelt(BasePlayer player)
	{
		this.player = player;
	}

	public void DropActive(Vector3 position, Vector3 velocity)
	{
		Item activeItem = player.GetActiveItem();
		if (activeItem == null || Interface.CallHook("OnPlayerDropActiveItem", player, activeItem) != null)
		{
			return;
		}
		using (TimeWarning.New("PlayerBelt.DropActive"))
		{
			activeItem.Drop(position, velocity);
			player.svActiveItemID = 0u;
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
}
