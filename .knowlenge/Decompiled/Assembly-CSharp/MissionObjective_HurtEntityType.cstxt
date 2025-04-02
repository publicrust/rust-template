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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		base.Think(index, instance, assignee, delta);
		if (!shouldUpdateMissionLocation || !IsStarted(index, instance))
		{
			return;
		}
		ref RealTimeSince sinceLastThink = ref instance.objectiveStatuses[index].sinceLastThink;
		if (RealTimeSince.op_Implicit(sinceLastThink) < 1f)
		{
			return;
		}
		sinceLastThink = RealTimeSince.op_Implicit(0f);
		if (searchFilter == null)
		{
			searchFilter = (BaseCombatEntity e) => List.TryFindWith<uint, uint>((IReadOnlyCollection<uint>)(object)targetPrefabIDs, (Func<uint, uint>)((uint id) => id), e.prefabID, (IEqualityComparer<uint>)null).HasValue && e.IsAlive();
		}
		if (TryFindNearby(((Component)assignee).transform.position, searchFilter, out var entity))
		{
			instance.missionLocation = ((Component)entity).transform.position;
			assignee.MissionDirty();
		}
	}
}
