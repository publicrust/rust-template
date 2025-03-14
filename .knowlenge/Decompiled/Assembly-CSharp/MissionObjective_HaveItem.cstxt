using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/HaveItem")]
public class MissionObjective_HaveItem : MissionObjective
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition targetItem;

	public int targetItemAmount;

	public bool canBeReset = true;

	public BaseEntityRef[] pingEntitiesOnTutorialIsland;

	public BasePlayer.PingType pingType = BasePlayer.PingType.GoTo;

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = targetItemAmount;
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
		if (!IsStarted(index, instance) || targetItem == null)
		{
			return;
		}
		int amount = assignee.inventory.GetAmount(targetItem.itemid);
		bool completed = instance.objectiveStatuses[index].completed;
		bool flag = amount >= targetItemAmount;
		if (!canBeReset && completed)
		{
			return;
		}
		if (completed != flag)
		{
			if (flag)
			{
				CompleteObjective(index, instance, assignee);
			}
			else
			{
				ResetObjective(index, instance, assignee);
			}
		}
		if (amount != (int)instance.objectiveStatuses[index].progressCurrent)
		{
			instance.objectiveStatuses[index].progressCurrent = amount;
			assignee.MissionDirty();
		}
	}
}
