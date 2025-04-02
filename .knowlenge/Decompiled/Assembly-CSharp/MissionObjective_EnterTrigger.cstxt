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
		base.ObjectiveStarted(playerFor, index, instance);
		instance.missionLocation = instance.GetMissionPoint(positionName, playerFor);
		playerFor.MissionDirty();
		if (shouldPing)
		{
			TutorialIsland currentTutorialIsland = playerFor.GetCurrentTutorialIsland();
			if (currentTutorialIsland != null)
			{
				playerFor.AddPingAtLocation(pingType, instance.missionLocation, 86400f, currentTutorialIsland.net.ID);
			}
		}
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (!ShouldThink(index, instance) || type != BaseMission.MissionEventType.ENTER_TRIGGER || (requiredMountable != null && (!playerFor.isMounted || playerFor.GetMounted().prefabID != requiredMountable.prefabID)))
		{
			return;
		}
		CompleteObjective(index, instance, playerFor);
		if (shouldPing)
		{
			TutorialIsland currentTutorialIsland = playerFor.GetCurrentTutorialIsland();
			if (currentTutorialIsland != null)
			{
				playerFor.RemovePingAtLocation(pingType, instance.missionLocation, float.MaxValue, currentTutorialIsland.net.ID);
			}
		}
	}
}
