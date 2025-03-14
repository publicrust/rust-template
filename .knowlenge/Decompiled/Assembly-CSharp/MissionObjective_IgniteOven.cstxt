using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Ignite Oven")]
public class MissionObjective_IgniteOven : MissionObjective
{
	public BaseEntityRef TargetOven;

	public bool PingTarget;

	public BasePlayer.PingType PingType = BasePlayer.PingType.GoTo;

	private Func<BaseCombatEntity, bool> searchFilter;

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		if (searchFilter == null)
		{
			searchFilter = (BaseCombatEntity e) => e.IsAlive() && e.prefabID == TargetOven.resourceID;
		}
		if (PingTarget && TryFindNearby(forPlayer.transform.position, searchFilter, out var entity, 200f))
		{
			instance.missionLocation = entity.transform.position;
			forPlayer.RegisterPingedEntity(entity, PingType);
		}
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type != BaseMission.MissionEventType.STARTOVEN || IsCompleted(index, instance) || !CanProgress(index, instance))
		{
			return;
		}
		if (TargetOven.resourceID == payload.UintIdentifier)
		{
			CompleteObjective(index, instance, playerFor);
			if (PingTarget)
			{
				playerFor.DeregisterPingedEntity(payload.NetworkIdentifier, PingType);
			}
		}
		playerFor.MissionDirty();
	}
}
