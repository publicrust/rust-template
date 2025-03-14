using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Open Tutorial Storage")]
public class MissionObjective_OpenTutorialStorageContainer : MissionObjective
{
	public ItemAmount[] Items;

	public BaseEntity TargetEntity;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
		TutorialIsland currentTutorialIsland = playerFor.GetCurrentTutorialIsland();
		if (currentTutorialIsland != null && currentTutorialIsland.TutorialContainer != null)
		{
			currentTutorialIsland.TutorialContainer.LoadStorage(Items);
		}
		playerFor.RegisterPingedEntity(currentTutorialIsland.TutorialContainer, BasePlayer.PingType.Loot);
	}

	public override void ObjectiveCompleted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveCompleted(playerFor, index, instance);
		DeregisterPing(playerFor);
	}

	private void DeregisterPing(BasePlayer playerFor)
	{
		TutorialIsland currentTutorialIsland = playerFor.GetCurrentTutorialIsland();
		if (currentTutorialIsland != null && currentTutorialIsland.TutorialContainer != null)
		{
			playerFor.DeregisterPingedEntity(currentTutorialIsland.TutorialContainer.net.ID, BasePlayer.PingType.Loot);
		}
	}

	public override void ObjectiveFailed(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveFailed(playerFor, index, instance);
		DeregisterPing(playerFor);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type == BaseMission.MissionEventType.OPEN_STORAGE && !IsCompleted(index, instance) && CanProgress(index, instance) && payload.UintIdentifier == TargetEntity.prefabID)
		{
			CompleteObjective(index, instance, playerFor);
		}
	}
}
