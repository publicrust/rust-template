using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Move")]
public class MissionObjective_Move : MissionObjective
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

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
		if (!ShouldThink(index, instance) || (requiredMountable != null && (!assignee.isMounted || assignee.GetMounted().prefabID != requiredMountable.prefabID)))
		{
			return;
		}
		Vector3 missionPoint = instance.GetMissionPoint(positionName, assignee);
		if (!((use2D ? Vector3Ex.Distance2D(missionPoint, assignee.transform.position) : Vector3.Distance(missionPoint, assignee.transform.position)) <= distForCompletion))
		{
			return;
		}
		CompleteObjective(index, instance, assignee);
		if (shouldPing)
		{
			TutorialIsland currentTutorialIsland = assignee.GetCurrentTutorialIsland();
			if (currentTutorialIsland != null)
			{
				assignee.RemovePingAtLocation(pingType, instance.missionLocation, float.MaxValue, currentTutorialIsland.net.ID);
			}
		}
	}
}
