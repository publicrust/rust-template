public class ItemModConditionInWater : ItemMod
{
	public bool requiredState;

	public override bool Passes(Item item)
	{
		BasePlayer ownerPlayer = item.GetOwnerPlayer();
		if (ownerPlayer == null)
		{
			return false;
		}
		return ownerPlayer.IsHeadUnderwater() == requiredState;
	}
}
