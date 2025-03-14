using System;
using System.Collections.Generic;
using System.Linq;
using Facepunch.Extend;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/HurtEntityType")]
public class MissionObjective_HurtEntityType : MissionObjective
{
	public BaseEntityRef[] targetEntities;

	public float targetDamage = 1f;

	public bool shouldUpdateMissionLocation = true;

	private bool isInitalized;

	private uint[] targetPrefabIDs;

	private Func<BaseCombatEntity, bool> searchFilter;

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
		instance.objectiveStatuses[index].progressTarget = targetDamage;
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type != BaseMission.MissionEventType.HURT_ENTITY || IsCompleted(index, instance) || !CanProgress(index, instance))
		{
			return;
		}
		EnsureInitialized();
		EntityRef<BaseCombatEntity> entityRef = default(EntityRef<BaseCombatEntity>);
		entityRef.uid = payload.NetworkIdentifier;
		EntityRef<BaseCombatEntity> entityRef2 = entityRef;
		BaseCombatEntity baseCombatEntity = entityRef2.Get(serverside: true);
		if (!baseCombatEntity.IsValid())
		{
			return;
		}
		uint[] array = targetPrefabIDs;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == baseCombatEntity.prefabID)
			{
				instance.objectiveStatuses[index].progressCurrent += amount;
				if (instance.objectiveStatuses[index].progressCurrent >= targetDamage)
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
			searchFilter = (BaseCombatEntity e) => ((IReadOnlyCollection<uint>)(object)targetPrefabIDs).TryFindWith((uint id) => id, e.prefabID).HasValue && e.IsAlive();
		}
		if (TryFindNearby(assignee.transform.position, searchFilter, out var entity))
		{
			instance.missionLocation = entity.transform.position;
			assignee.MissionDirty();
		}
	}
}
