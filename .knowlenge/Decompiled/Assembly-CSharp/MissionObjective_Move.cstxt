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

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		base.Think(index, instance, assignee, delta);
		if (!ShouldThink(index, instance) || ((Object)(object)requiredMountable != (Object)null && (!assignee.isMounted || assignee.GetMounted().prefabID != requiredMountable.prefabID)))
		{
			return;
		}
		Vector3 missionPoint = instance.GetMissionPoint(positionName, assignee);
		if (!((use2D ? Vector3Ex.Distance2D(missionPoint, ((Component)assignee).transform.position) : Vector3.Distance(missionPoint, ((Component)assignee).transform.position)) <= distForCompletion))
		{
			return;
		}
		CompleteObjective(index, instance, assignee);
		if (shouldPing)
		{
			TutorialIsland currentTutorialIsland = assignee.GetCurrentTutorialIsland();
			if ((Object)(object)currentTutorialIsland != (Object)null)
			{
				assignee.RemovePingAtLocation(pingType, instance.missionLocation, float.MaxValue, currentTutorialIsland.net.ID);
			}
		}
	}
}
