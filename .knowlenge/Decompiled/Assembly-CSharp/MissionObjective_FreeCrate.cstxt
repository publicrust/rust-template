using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/FreeCrate")]
public class MissionObjective_FreeCrate : MissionObjective
{
	public int targetAmount;

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = targetAmount;
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type == BaseMission.MissionEventType.FREE_CRATE && !IsCompleted(index, instance) && CanProgress(index, instance))
		{
			instance.objectiveStatuses[index].progressCurrent += (int)amount;
			if (instance.objectiveStatuses[index].progressCurrent >= (float)targetAmount)
			{
				CompleteObjective(index, instance, playerFor);
			}
			playerFor.MissionDirty();
		}
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
	}
}
