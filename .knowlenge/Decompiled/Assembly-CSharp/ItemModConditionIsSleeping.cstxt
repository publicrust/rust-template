using UnityEngine;

public class ItemModConditionIsSleeping : ItemMod
{
	public bool requiredState;

	public override bool Passes(Item item)
	{
		BasePlayer ownerPlayer = item.GetOwnerPlayer();
		if ((Object)(object)ownerPlayer == (Object)null)
		{
			return false;
		}
		return ownerPlayer.IsSleeping() == requiredState;
	}
}
