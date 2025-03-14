public class ItemModAlterCondition : ItemMod
{
	public float conditionChange;

	public override void DoAction(Item item, BasePlayer player)
	{
		if (item.amount >= 1)
		{
			if (conditionChange < 0f)
			{
				item.LoseCondition(conditionChange * -1f);
			}
			else
			{
				item.RepairCondition(conditionChange);
			}
		}
	}
}
