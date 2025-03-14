using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/FreeCrate")]
public class MissionObjective_FreeCrate : MissionObjective
{
	public int targetAmount;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, string identifier, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, identifier, amount);
		if (!IsCompleted(index, instance) && CanProgress(index, instance) && type == BaseMission.MissionEventType.FREE_CRATE)
		{
			instance.objectiveStatuses[index].genericInt1 += (int)amount;
			if (instance.objectiveStatuses[index].genericInt1 >= targetAmount)
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
