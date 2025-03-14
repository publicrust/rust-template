using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/HurtMissionEntity")]
public class MissionObjective_HurtMissionEntity : MissionObjective
{
	public string targetIdentifier;

	public float targetDamage = 1f;

	public bool shouldUpdateMissionLocation = true;

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
		MissionEntity missionEntity = instance.GetMissionEntity(targetIdentifier, playerFor);
		if (missionEntity == null)
		{
			FailObjective(index, instance, playerFor);
			return;
		}
		BaseEntity entity = missionEntity.GetEntity();
		if (!entity.IsValid())
		{
			FailObjective(index, instance, playerFor);
			return;
		}
		EntityRef<BaseCombatEntity> entityRef = default(EntityRef<BaseCombatEntity>);
		entityRef.uid = payload.NetworkIdentifier;
		EntityRef<BaseCombatEntity> entityRef2 = entityRef;
		BaseCombatEntity baseCombatEntity = entityRef2.Get(serverside: true);
		if (baseCombatEntity.IsValid() && baseCombatEntity.EqualNetID(entity))
		{
			instance.objectiveStatuses[index].progressCurrent += amount;
			if (instance.objectiveStatuses[index].progressCurrent >= targetDamage)
			{
				CompleteObjective(index, instance, playerFor);
			}
			playerFor.MissionDirty();
		}
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
		if (!IsStarted(index, instance) || IsCompleted(index, instance))
		{
			return;
		}
		ref RealTimeSince sinceLastThink = ref instance.objectiveStatuses[index].sinceLastThink;
		if ((float)sinceLastThink < 1f)
		{
			return;
		}
		sinceLastThink = 0f;
		MissionEntity missionEntity = instance.GetMissionEntity(targetIdentifier, assignee);
		if (missionEntity == null)
		{
			FailObjective(index, instance, assignee);
		}
		else if (shouldUpdateMissionLocation)
		{
			Vector3 position = missionEntity.transform.position;
			if (position != instance.missionLocation)
			{
				instance.missionLocation = position;
				assignee.MissionDirty();
			}
		}
	}
}
