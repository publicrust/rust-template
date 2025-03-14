using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

[Serializable]
public class ItemAmount : ISerializationCallbackReceiver
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition itemDef;

	public float amount;

	[NonSerialized]
	public float startAmount;

	public bool ignoreInTutorial;

	public bool isBP;

	public int itemid
	{
		get
		{
			if (itemDef == null)
			{
				return 0;
			}
			return itemDef.itemid;
		}
	}

	public ItemAmount(ItemDefinition item = null, float amt = 0f)
	{
		itemDef = item;
		amount = amt;
		startAmount = amount;
	}

	public virtual float GetAmount()
	{
		return amount;
	}

	public virtual void OnAfterDeserialize()
	{
		startAmount = amount;
	}

	public virtual void OnBeforeSerialize()
	{
	}

	public static ItemAmountList SerialiseList(List<ItemAmount> list)
	{
		ItemAmountList itemAmountList = Pool.Get<ItemAmountList>();
		itemAmountList.amount = Pool.Get<List<float>>();
		itemAmountList.itemID = Pool.Get<List<int>>();
		foreach (ItemAmount item in list)
		{
			itemAmountList.amount.Add(item.amount);
			itemAmountList.itemID.Add(item.itemid);
		}
		return itemAmountList;
	}

	public static void DeserialiseList(List<ItemAmount> target, ItemAmountList source)
	{
		target.Clear();
		if (source.amount.Count == source.itemID.Count)
		{
			for (int i = 0; i < source.amount.Count; i++)
			{
				target.Add(new ItemAmount(ItemManager.FindItemDefinition(source.itemID[i]), source.amount[i]));
			}
		}
	}
}
