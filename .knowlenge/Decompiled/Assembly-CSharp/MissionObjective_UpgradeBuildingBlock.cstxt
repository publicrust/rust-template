using System.Collections.Generic;
using Facepunch;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Upgrade Building Block")]
public class MissionObjective_UpgradeBuildingBlock : MissionObjective
{
	public bool ShouldPingBlocksLessThanTargetGrade;

	public BasePlayer.PingType PingType;

	public BuildingGrade.Enum TargetGrade;

	public int RequiredCount = 6;

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = RequiredCount;
		if (!ShouldPingBlocksLessThanTargetGrade)
		{
			return;
		}
		TutorialIsland currentTutorialIsland = forPlayer.GetCurrentTutorialIsland();
		if (!(currentTutorialIsland != null))
		{
			return;
		}
		Vector3 worldPosOfBuildTarget = currentTutorialIsland.GetWorldPosOfBuildTarget(0);
		List<BuildingBlock> obj = Pool.Get<List<BuildingBlock>>();
		Vis.Entities(worldPosOfBuildTarget, 32f, obj, 2097152);
		if (obj.Count != RequiredCount)
		{
			Debug.LogWarning("Non matching building block count, check RequiredCount on " + base.name);
		}
		foreach (BuildingBlock item in obj)
		{
			forPlayer.RegisterPingedEntity(item, PingType);
		}
		Pool.FreeUnmanaged(ref obj);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type == BaseMission.MissionEventType.UPGRADE_BUILDING_GRADE && !IsCompleted(index, instance) && CanProgress(index, instance) && payload.IntIdentifier >= (int)TargetGrade)
		{
			instance.objectiveStatuses[index].progressCurrent += 1f;
			if (instance.objectiveStatuses[index].progressCurrent >= (float)RequiredCount)
			{
				CompleteObjective(index, instance, playerFor);
			}
			playerFor.MissionDirty();
			if (ShouldPingBlocksLessThanTargetGrade)
			{
				playerFor.DeregisterPingedEntity(payload.NetworkIdentifier, PingType);
			}
		}
	}
}
