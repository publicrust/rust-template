public class ItemModConditionContainerFlag : ItemMod
{
	public ItemContainer.Flag flag;

	public bool requiredState;

	public override bool Passes(Item item)
	{
		if (item.parent == null)
		{
			return !requiredState;
		}
		if (!item.parent.HasFlag(flag))
		{
			return !requiredState;
		}
		return requiredState;
	}
}
