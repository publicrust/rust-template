public class ItemModConditionHasFlag : ItemMod
{
	public Item.Flag flag;

	public bool requiredState;

	public override bool Passes(Item item)
	{
		return item.HasFlag(flag) == requiredState;
	}
}
