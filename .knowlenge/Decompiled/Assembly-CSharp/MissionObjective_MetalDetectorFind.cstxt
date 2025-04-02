using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Metal Detector")]
public class MissionObjective_MetalDetectorFind : MissionObjective
{
	public int RequiredFinds = 3;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = RequiredFinds;
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type == BaseMission.MissionEventType.METAL_DETECTOR_FIND && !IsCompleted(index, instance) && CanProgress(index, instance))
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
