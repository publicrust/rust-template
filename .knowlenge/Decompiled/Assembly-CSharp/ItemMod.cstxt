using UnityEngine;

public class ItemMod : MonoBehaviour
{
	protected ItemMod[] siblingMods;

	public virtual void ModInit()
	{
		siblingMods = GetComponents<ItemMod>();
	}

	public virtual void OnItemCreated(Item item)
	{
	}

	public virtual void OnVirginItem(Item item, BasePlayer creatingPlayer)
	{
	}

	public virtual void ServerCommand(Item item, string command, BasePlayer player)
	{
	}

	public virtual void DoAction(Item item, BasePlayer player)
	{
	}

	public virtual void OnRemove(Item item)
	{
	}

	public virtual void OnParentChanged(Item item)
	{
	}

	public virtual void CollectedForCrafting(Item item, BasePlayer crafter)
	{
	}

	public virtual void ReturnedFromCancelledCraft(Item item, BasePlayer crafter)
	{
	}

	public virtual void OnAttacked(Item item, HitInfo info)
	{
	}

	public virtual void OnChanged(Item item)
	{
	}

	public virtual bool CanDoAction(Item item, BasePlayer player)
	{
		ItemMod[] array = siblingMods;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].Passes(item))
			{
				return false;
			}
		}
		return true;
	}

	public virtual bool Passes(Item item)
	{
		return true;
	}

	public virtual void OnRemovedFromWorld(Item item)
	{
	}

	public virtual void OnMovedToWorld(Item item)
	{
	}
}
