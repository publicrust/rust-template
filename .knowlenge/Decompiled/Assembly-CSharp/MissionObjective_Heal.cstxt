using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Heal")]
public class MissionObjective_Heal : MissionObjective
{
	[Range(0f, 1f)]
	public float RequiredHealthNormalised = 0.5f;

	public BaseEntityRef RequireHealSource;

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (!IsCompleted(index, instance) && CanProgress(index, instance) && type == BaseMission.MissionEventType.HEAL && (RequireHealSource == null || RequireHealSource.Get().prefabID == payload.UintIdentifier) && playerFor.healthFraction >= RequiredHealthNormalised)
		{
			CompleteObjective(index, instance, playerFor);
			playerFor.MissionDirty();
		}
	}
}
