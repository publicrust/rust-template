using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/PlayerInput")]
public class MissionObjective_PlayerInput : MissionObjective
{
	public BUTTON requiredButton;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
		instance.EnablePlayerInput();
	}

	public override void ObjectiveCompleted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveCompleted(playerFor, index, instance);
		instance.DisablePlayerInput();
	}

	public override void ObjectiveFailed(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveFailed(playerFor, index, instance);
		instance.DisablePlayerInput();
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type == BaseMission.MissionEventType.PLAYER_TICK && !IsCompleted(index, instance) && CanProgress(index, instance) && playerFor.serverInput.IsDown(requiredButton))
		{
			CompleteObjective(index, instance, playerFor);
		}
	}
}
