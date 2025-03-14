public class ItemModConditionIsSleeping : ItemMod
{
	public bool requiredState;

	public override bool Passes(Item item)
	{
		BasePlayer ownerPlayer = item.GetOwnerPlayer();
		if (ownerPlayer == null)
		{
			return false;
		}
		return ownerPlayer.IsSleeping() == requiredState;
	}
}
