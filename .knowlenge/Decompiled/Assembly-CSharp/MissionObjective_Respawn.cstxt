using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Respawn")]
public class MissionObjective_Respawn : MissionObjective
{
	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type == BaseMission.MissionEventType.RESPAWN && !IsCompleted(index, instance) && CanProgress(index, instance))
		{
			CompleteObjective(index, instance, playerFor);
		}
	}
}
