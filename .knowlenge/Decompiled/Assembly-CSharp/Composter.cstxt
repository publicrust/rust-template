using System;
using ConVar;
using Facepunch;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;

public class Composter : StorageContainer
{
	[Header("Composter")]
	public ItemDefinition FertilizerDef;

	[Tooltip("If enabled, entire item stacks will be composted each tick, instead of a single item of a stack.")]
	public bool CompostEntireStack;

	public float fertilizerProductionProgress;

	protected float UpdateInterval => Server.composterUpdateInterval;

	public override void ServerInit()
	{
		base.ServerInit();
		ItemContainer itemContainer = base.inventory;
		itemContainer.canAcceptItem = (Func<Item, int, bool>)Delegate.Combine(itemContainer.canAcceptItem, new Func<Item, int, bool>(InventoryItemFilter));
		InvokeRandomized(UpdateComposting, UpdateInterval, UpdateInterval, UpdateInterval * 0.1f);
	}

	public bool InventoryItemFilter(Item item, int targetSlot)
	{
		if (item == null)
		{
			return false;
		}
		if (item.info.GetComponent<ItemModCompostable>() != null || ItemIsFertilizer(item))
		{
			return true;
		}
		return false;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.composter = Facepunch.Pool.Get<ProtoBuf.Composter>();
		info.msg.composter.fertilizerProductionProgress = fertilizerProductionProgress;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.composter != null)
		{
			fertilizerProductionProgress = info.msg.composter.fertilizerProductionProgress;
		}
	}

	public bool ItemIsFertilizer(Item item)
	{
		return item.info.shortname == "fertilizer";
	}

	public void UpdateComposting()
	{
		if (Interface.CallHook("OnComposterUpdate", this) != null)
		{
			return;
		}
		for (int i = 0; i < base.inventory.capacity; i++)
		{
			Item slot = base.inventory.GetSlot(i);
			if (slot != null)
			{
				CompostItem(slot);
			}
		}
	}

	public void CompostItem(Item item)
	{
		if (!ItemIsFertilizer(item))
		{
			ItemModCompostable component = item.info.GetComponent<ItemModCompostable>();
			if (!(component == null))
			{
				int num = ((!CompostEntireStack) ? 1 : item.amount);
				item.UseItem(num);
				fertilizerProductionProgress += (float)num * component.TotalFertilizerProduced;
				ProduceFertilizer(Mathf.FloorToInt(fertilizerProductionProgress));
			}
		}
	}

	public void ProduceFertilizer(int amount)
	{
		if (amount > 0)
		{
			Item item = ItemManager.Create(FertilizerDef, amount, 0uL);
			if (!item.MoveToContainer(base.inventory))
			{
				item.Drop(base.inventory.dropPosition, base.inventory.dropVelocity);
			}
			fertilizerProductionProgress -= amount;
		}
	}
}
