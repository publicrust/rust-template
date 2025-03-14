public class ItemModSwitchFlag : ItemMod
{
	public Item.Flag flag;

	public bool state;

	public override void DoAction(Item item, BasePlayer player)
	{
		if (item.amount >= 1 && item.HasFlag(flag) != state)
		{
			item.SetFlag(flag, state);
			item.MarkDirty();
		}
	}
}
