public class TriggerMission : TriggerBase
{
	private BasePlayer cachedPlayer;

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if (ent.ToPlayer() != null)
		{
			cachedPlayer = ent.ToPlayer();
			Invoke(DelayedEntityCallback, 0f);
		}
	}

	private void DelayedEntityCallback()
	{
		if (cachedPlayer != null)
		{
			cachedPlayer.ProcessMissionEvent(BaseMission.MissionEventType.ENTER_TRIGGER, 0, 0f);
		}
		cachedPlayer = null;
	}
}
