using System;
using UnityEngine;

[Serializable]
public class ItemAmount : ISerializationCallbackReceiver
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition itemDef;

	public float amount;

	[NonSerialized]
	public float startAmount;

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
}
