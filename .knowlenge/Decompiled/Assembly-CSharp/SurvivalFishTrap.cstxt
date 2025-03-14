using System.Collections.Generic;
using Oxide.Core;
using UnityEngine;

public class SurvivalFishTrap : WildlifeTrap
{
	private WaterBody cachedWaterBody;

	private bool bypassItemFilter;

	public override void ServerInit()
	{
		base.ServerInit();
		if (GamePhysics.Trace(new Ray(base.transform.position + Vector3.up, Vector3.down), 0f, out var hitInfo, 1.5f, 16))
		{
			cachedWaterBody = RaycastHitEx.GetWaterBody(hitInfo);
		}
	}

	public override bool HasBait()
	{
		foreach (Item item in base.inventory.itemList)
		{
			if (item != null && item.info.TryGetComponent<ItemModCompostable>(out var component) && component.BaitValue > 0f)
			{
				return true;
			}
		}
		return false;
	}

	public override void TrapThink()
	{
		ItemDefinition itemDefinition = null;
		Item item = null;
		int usedLureAmount = 0;
		using (List<Item>.Enumerator enumerator = base.inventory.itemList.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				Item current = enumerator.Current;
				if ((current.info.TryGetComponent<ItemModCompostable>(out var component) ? component.BaitValue : 0f) > 0f)
				{
					item = current;
					itemDefinition = FishLookup.Instance.GetFish(base.transform.position, cachedWaterBody, current, out var _, current.info.GetComponent<ItemModFishable>(), out usedLureAmount, 5f);
				}
			}
		}
		item?.UseItem(usedLureAmount);
		if (UnityEngine.Random.Range(0f, 1f) <= trapSuccessRate || !(itemDefinition != null))
		{
			return;
		}
		try
		{
			bypassItemFilter = true;
			if (Interface.CallHook("OnWildlifeTrap", this, itemDefinition) == null)
			{
				Item item2 = ItemManager.Create(itemDefinition, 1, 0uL);
				if (base.LastLootedByPlayer != null)
				{
					item2.SetItemOwnership(base.LastLootedByPlayer, ItemOwnershipPhrases.SurvivalTrap);
				}
				if (!item2.MoveToContainer(base.inventory))
				{
					item2.Drop(base.transform.position, Vector3.zero, Quaternion.identity);
				}
				OnTrappedWildlife(setFlag: true);
			}
		}
		finally
		{
			bypassItemFilter = false;
		}
	}

	public override bool ItemFilter(Item item, int targetSlot)
	{
		if (FishLookup.Instance == null || item == null)
		{
			return false;
		}
		FishLookup.LoadFish();
		if (bypassItemFilter)
		{
			return true;
		}
		bool flag = false;
		ItemDefinition[] baitItems = FishLookup.BaitItems;
		for (int i = 0; i < baitItems.Length; i++)
		{
			if (baitItems[i] == item.info)
			{
				flag = true;
				break;
			}
		}
		return base.ItemFilter(item, targetSlot) && flag;
	}

	protected override bool CanAcceptItem(Item item, int slot)
	{
		if (FishLookup.Instance == null || item == null)
		{
			return false;
		}
		FishLookup.LoadFish();
		if (bypassItemFilter)
		{
			return true;
		}
		bool result = false;
		ItemDefinition[] baitItems = FishLookup.BaitItems;
		for (int i = 0; i < baitItems.Length; i++)
		{
			if (baitItems[i] == item.info)
			{
				result = true;
				break;
			}
		}
		return result;
	}
}
