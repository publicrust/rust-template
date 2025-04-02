public class ItemModConsumeContents : ItemMod
{
	public GameObjectRef consumeEffect;

	public override void DoAction(Item item, BasePlayer player)
	{
		foreach (Item item2 in item.contents.itemList)
		{
			ItemModConsume component = item2.info.GetComponent<ItemModConsume>();
			if (!(component == null) && component.CanDoAction(item2, player))
			{
				component.DoAction(item2, player);
				item.contents?.onItemRemovedFromStack?.Invoke(item2, 0);
				break;
			}
		}
	}

	public override bool CanDoAction(Item item, BasePlayer player)
	{
		if (!player.metabolism.CanConsume())
		{
			return false;
		}
		if (item.contents == null)
		{
			return false;
		}
		foreach (Item item2 in item.contents.itemList)
		{
			ItemModConsume component = item2.info.GetComponent<ItemModConsume>();
			if (!(component == null) && component.CanDoAction(item2, player))
			{
				return true;
			}
		}
		return false;
	}
}
