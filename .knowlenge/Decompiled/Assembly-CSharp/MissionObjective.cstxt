using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public abstract class MissionObjective : ScriptableObject
{
	public virtual void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
	}

	public virtual void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		instance.objectiveStatuses[index].started = true;
		BaseMission mission = instance.GetMission();
		if (mission != null && mission.objectives[index].requiredEntities != null)
		{
			string[] requiredEntities = mission.objectives[index].requiredEntities;
			foreach (string identifier in requiredEntities)
			{
				instance.GetMissionEntity(identifier, playerFor);
			}
		}
		playerFor.MissionDirty();
	}

	public virtual void ObjectiveCompleted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
	}

	public virtual void ObjectiveFailed(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
	}

	public bool IsStarted(int index, BaseMission.MissionInstance instance)
	{
		if (instance == null || instance.objectiveStatuses.Length <= index)
		{
			return false;
		}
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

	public void ResetObjective(int index, BaseMission.MissionInstance instance, BasePlayer playerFor)
	{
		if (instance.objectiveStatuses[index].completed || instance.objectiveStatuses[index].failed)
		{
			instance.objectiveStatuses[index].completed = false;
			instance.objectiveStatuses[index].failed = false;
			playerFor.MissionDirty();
		}
	}

	public void CompleteObjective(int index, BaseMission.MissionInstance instance, BasePlayer playerFor)
	{
		if (!instance.objectiveStatuses[index].completed && !instance.objectiveStatuses[index].failed)
		{
			instance.objectiveStatuses[index].completed = true;
			instance.GetMission().OnObjectiveCompleted(index, instance, playerFor);
			playerFor.MissionDirty();
			ObjectiveCompleted(playerFor, index, instance);
		}
	}

	public void FailObjective(int index, BaseMission.MissionInstance instance, BasePlayer playerFor)
	{
		if (!instance.objectiveStatuses[index].completed && !instance.objectiveStatuses[index].failed)
		{
			instance.objectiveStatuses[index].failed = true;
			instance.GetMission().OnObjectiveFailed(index, instance, playerFor);
			playerFor.MissionDirty();
			ObjectiveFailed(playerFor, index, instance);
		}
	}

	public virtual void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
	}

	public virtual void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		if (ShouldObjectiveStart(index, instance) && !IsStarted(index, instance))
		{
			ObjectiveStarted(assignee, index, instance);
		}
	}

	protected bool TryFindNearby<T>(Vector3 origin, Func<T, bool> filter, out T entity, float radius = 20f) where T : BaseEntity
	{
		List<T> obj = Pool.Get<List<T>>();
		Vis.Entities(origin, radius, obj);
		int num = -1;
		float num2 = float.PositiveInfinity;
		for (int i = 0; i < obj.Count; i++)
		{
			T val = obj[i];
			if (filter == null || filter(val))
			{
				float num3 = Vector3.Distance(val.transform.position, origin);
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
		}
		bool flag = num != -1;
		entity = (flag ? obj[num] : null);
		Pool.FreeUnmanaged(ref obj);
		return flag;
	}

	public virtual void PostServerLoad(BasePlayer player, BaseMission.MissionInstance.ObjectiveStatus status)
	{
	}
}
