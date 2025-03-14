using UnityEngine;

public class MissionObjective : ScriptableObject
{
	public virtual void MissionStarted(int index, BaseMission.MissionInstance instance)
	{
	}

	public virtual void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		instance.objectiveStatuses[index].started = true;
		playerFor.MissionDirty();
	}

	public bool IsStarted(int index, BaseMission.MissionInstance instance)
	{
		return instance.objectiveStatuses[index].started;
	}

	public bool CanProgress(int index, BaseMission.MissionInstance instance)
	{
		if (instance.GetMission().objectives[index].onlyProgressIfStarted)
		{
			return IsStarted(index, instance);
		}
		return true;
	}

	public bool ShouldObjectiveStart(int index, BaseMission.MissionInstance instance)
	{
		int[] startAfterCompletedObjectives = instance.GetMission().objectives[index].startAfterCompletedObjectives;
		foreach (int num in startAfterCompletedObjectives)
		{
			if (!instance.objectiveStatuses[num].completed && !instance.objectiveStatuses[num].failed)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsCompleted(int index, BaseMission.MissionInstance instance)
	{
		if (!instance.objectiveStatuses[index].completed)
		{
			return instance.objectiveStatuses[index].failed;
		}
		return true;
	}

	public virtual bool ShouldThink(int index, BaseMission.MissionInstance instance)
	{
		return !IsCompleted(index, instance);
	}

	public virtual void CompleteObjective(int index, BaseMission.MissionInstance instance, BasePlayer playerFor)
	{
		instance.objectiveStatuses[index].completed = true;
		instance.GetMission().OnObjectiveCompleted(index, instance, playerFor);
	}

	public virtual void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, string identifier, float amount)
	{
	}

	public virtual void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		if (ShouldObjectiveStart(index, instance) && !IsStarted(index, instance))
		{
			ObjectiveStarted(assignee, index, instance);
		}
	}
}
