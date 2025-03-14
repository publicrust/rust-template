using System.Collections.Generic;
using Facepunch;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Kill")]
public class MissionObjective_KillEntity : MissionObjective
{
	public string[] targetPrefabIDs;

	public int numToKill;

	public bool shouldUpdateMissionLocation;

	private float nextLocationUpdateTime;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, string identifier, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, identifier, amount);
		if (IsCompleted(index, instance) || !CanProgress(index, instance) || type != BaseMission.MissionEventType.KILL_ENTITY)
		{
			return;
		}
		string[] array = targetPrefabIDs;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == identifier)
			{
				instance.objectiveStatuses[index].genericInt1 += (int)amount;
				if (instance.objectiveStatuses[index].genericInt1 >= numToKill)
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
		if (shouldUpdateMissionLocation && IsStarted(index, instance) && Time.realtimeSinceStartup > nextLocationUpdateTime)
		{
			nextLocationUpdateTime = Time.realtimeSinceStartup + 1f;
			string[] array = targetPrefabIDs;
			foreach (string s in array)
			{
				uint result = 0u;
				uint.TryParse(s, out result);
				List<BaseCombatEntity> obj = Pool.GetList<BaseCombatEntity>();
				Vis.Entities(assignee.transform.position, 20f, obj, 133120);
				int num = -1;
				float num2 = float.PositiveInfinity;
				for (int j = 0; j < obj.Count; j++)
				{
					BaseCombatEntity baseCombatEntity = obj[j];
					if (baseCombatEntity.IsAlive() && baseCombatEntity.prefabID == result)
					{
						float num3 = Vector3.Distance(baseCombatEntity.transform.position, assignee.transform.position);
						if (num3 < num2)
						{
							num = j;
							num2 = num3;
						}
					}
				}
				if (num != -1)
				{
					instance.missionLocation = obj[num].transform.position;
					assignee.MissionDirty();
					Pool.FreeList(ref obj);
					break;
				}
				Pool.FreeList(ref obj);
			}
		}
		base.Think(index, instance, assignee, delta);
	}
}
