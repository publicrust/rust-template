using System;
using System.Collections.Generic;
using System.Linq;
using Facepunch.Extend;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/MountEntityType")]
public class MissionObjective_MountEntityType : MissionObjective
{
	public BaseEntityRef[] targetEntities;

	public int numToMount = 1;

	public bool shouldUpdateMissionLocation = true;

	private bool isInitalized;

	private uint[] targetPrefabIDs;

	private Func<BaseEntity, bool> searchFilter;

	private void EnsureInitialized()
	{
		if (!isInitalized)
		{
			isInitalized = true;
			targetPrefabIDs = (from e in targetEntities
				where e.isValid
				select e.Get().prefabID).ToArray();
		}
	}

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		if (numToMount > 1)
		{
			instance.objectiveStatuses[index].progressTarget = numToMount;
		}
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type != BaseMission.MissionEventType.MOUNT_ENTITY || IsCompleted(index, instance) || !CanProgress(index, instance))
		{
			return;
		}
		EnsureInitialized();
		EntityRef<BaseMountable> entityRef = default(EntityRef<BaseMountable>);
		entityRef.uid = payload.NetworkIdentifier;
		EntityRef<BaseMountable> entityRef2 = entityRef;
		BaseMountable baseMountable = entityRef2.Get(serverside: true);
		if (!baseMountable.IsValid())
		{
			return;
		}
		uint[] array = targetPrefabIDs;
		foreach (uint num in array)
		{
			BaseVehicle baseVehicle = baseMountable.VehicleParent();
			if (num == baseMountable.prefabID || (!(baseVehicle == null) && num == baseVehicle.prefabID))
			{
				instance.objectiveStatuses[index].progressCurrent += (int)amount;
				if (instance.objectiveStatuses[index].progressCurrent >= (float)numToMount)
				{
					CompleteObjective(index, instance, playerFor);
				}
				playerFor.MissionDirty();
				break;
			}
		}
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
		if (!shouldUpdateMissionLocation || !IsStarted(index, instance))
		{
			return;
		}
		ref RealTimeSince sinceLastThink = ref instance.objectiveStatuses[index].sinceLastThink;
		if ((float)sinceLastThink < 1f)
		{
			return;
		}
		sinceLastThink = 0f;
		if (searchFilter == null)
		{
			searchFilter = (BaseEntity e) => ((IReadOnlyCollection<uint>)(object)targetPrefabIDs).TryFindWith((uint id) => id, e.prefabID).HasValue;
		}
		if (TryFindNearby(assignee.transform.position, searchFilter, out var entity))
		{
			instance.missionLocation = entity.transform.position;
			assignee.MissionDirty();
		}
	}
}
