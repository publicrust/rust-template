using UnityEngine;

public class MissionObjective_EnterTrigger : MissionObjective
{
	public string positionName = "default";

	public float distForCompletion = 3f;

	public bool use2D;

	public BaseMountable requiredMountable;

	public bool shouldPing;

	public BasePlayer.PingType pingType = BasePlayer.PingType.GoTo;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		base.ObjectiveStarted(playerFor, index, instance);
		instance.missionLocation = instance.GetMissionPoint(positionName, playerFor);
		playerFor.MissionDirty();
		if (shouldPing)
		{
			TutorialIsland currentTutorialIsland = playerFor.GetCurrentTutorialIsland();
			if ((Object)(object)currentTutorialIsland != (Object)null)
			{
				playerFor.AddPingAtLocation(pingType, instance.missionLocation, 86400f, currentTutorialIsland.net.ID);
			}
		}
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (!ShouldThink(index, instance) || type != BaseMission.MissionEventType.ENTER_TRIGGER || ((Object)(object)requiredMountable != (Object)null && (!playerFor.isMounted || playerFor.GetMounted().prefabID != requiredMountable.prefabID)))
		{
			return;
		}
		CompleteObjective(index, instance, playerFor);
		if (shouldPing)
		{
			TutorialIsland currentTutorialIsland = playerFor.GetCurrentTutorialIsland();
			if ((Object)(object)currentTutorialIsland != (Object)null)
			{
				playerFor.RemovePingAtLocation(pingType, instance.missionLocation, float.MaxValue, currentTutorialIsland.net.ID);
			}
		}
	}
}
