public class ItemModUseContent : ItemMod
{
	public int amountToConsume = 1;

	public override void DoAction(Item item, BasePlayer player)
	{
		if (item.contents != null && item.contents.itemList.Count != 0)
		{
			item.contents.itemList[0].UseItem(amountToConsume);
		}
	}
}
