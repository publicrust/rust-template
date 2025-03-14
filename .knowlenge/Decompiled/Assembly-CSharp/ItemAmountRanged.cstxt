using System;
using UnityEngine;

[Serializable]
public class ItemAmountRanged : ItemAmount
{
	public float maxAmount = -1f;

	public override void OnAfterDeserialize()
	{
		base.OnAfterDeserialize();
	}

	public ItemAmountRanged(ItemDefinition item = null, float amt = 0f, float max = -1f)
		: base(item, amt)
	{
		maxAmount = max;
	}

	public override float GetAmount()
	{
		if (maxAmount > 0f && maxAmount > amount)
		{
			return UnityEngine.Random.Range(amount, maxAmount);
		}
		return amount;
	}
}
