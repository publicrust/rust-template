using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Consume")]
public class MissionObjective_Consume : MissionObjective
{
	public ItemDefinition TargetItem;

	public int RequiredAmount;

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = RequiredAmount;
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type == BaseMission.MissionEventType.CONSUME && !IsCompleted(index, instance) && CanProgress(index, instance) && payload.IntIdentifier == TargetItem.itemid)
		{
			instance.objectiveStatuses[index].progressCurrent += 1f;
			if (instance.objectiveStatuses[index].progressCurrent >= instance.objectiveStatuses[index].progressTarget)
			{
				CompleteObjective(index, instance, playerFor);
			}
			playerFor.MissionDirty();
		}
	}
}
