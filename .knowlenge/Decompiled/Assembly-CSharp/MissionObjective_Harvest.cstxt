using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Harvest")]
public class MissionObjective_Harvest : MissionObjective
{
	public string[] itemShortnames;

	public int targetItemAmount;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, string identifier, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, identifier, amount);
		if (IsCompleted(index, instance) || !CanProgress(index, instance) || type != BaseMission.MissionEventType.HARVEST)
		{
			return;
		}
		string[] array = itemShortnames;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == identifier)
			{
				instance.objectiveStatuses[index].genericInt1 += (int)amount;
				if (instance.objectiveStatuses[index].genericInt1 >= targetItemAmount)
				{
					CompleteObjective(index, instance, playerFor);
					playerFor.MissionDirty();
				}
				break;
			}
		}
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
	}
}
