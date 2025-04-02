using UnityEngine;

public class ItemModConditionHasCondition : ItemMod
{
	public float conditionTarget = 1f;

	[Tooltip("If set to above 0 will check for fraction instead of raw value")]
	public float conditionFractionTarget = -1f;

	public bool lessThan;

	public override bool Passes(Item item)
	{
		if (!item.hasCondition)
		{
			return false;
		}
		if (conditionFractionTarget > 0f)
		{
			if (lessThan || !(item.conditionNormalized > conditionFractionTarget))
			{
				if (lessThan)
				{
					return item.conditionNormalized < conditionFractionTarget;
				}
				return false;
			}
			return true;
		}
		if (lessThan || !(item.condition >= conditionTarget))
		{
			if (lessThan)
			{
				return item.condition < conditionTarget;
			}
			return false;
		}
		return true;
	}
}
