using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/AcquireItem")]
public class MissionObjective_AcquireItem : MissionObjective
{
	public string itemShortname;

	public int targetItemAmount;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, string identifier, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, identifier, amount);
		if (!IsCompleted(index, instance) && CanProgress(index, instance) && type == BaseMission.MissionEventType.ACQUIRE_ITEM)
		{
			if (itemShortname == identifier)
			{
				instance.objectiveStatuses[index].genericInt1 += (int)amount;
			}
			if (instance.objectiveStatuses[index].genericInt1 >= targetItemAmount)
			{
				CompleteObjective(index, instance, playerFor);
				playerFor.MissionDirty();
			}
		}
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
	}
}
