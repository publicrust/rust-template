using System;
using UnityEngine;

public class TriggerMission : TriggerBase
{
	private BasePlayer cachedPlayer;

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if ((Object)(object)ent.ToPlayer() != (Object)null)
		{
			cachedPlayer = ent.ToPlayer();
			((FacepunchBehaviour)this).Invoke((Action)DelayedEntityCallback, 0f);
		}
	}

	private void DelayedEntityCallback()
	{
		if ((Object)(object)cachedPlayer != (Object)null)
		{
			cachedPlayer.ProcessMissionEvent(BaseMission.MissionEventType.ENTER_TRIGGER, 0, 0f);
		}
		cachedPlayer = null;
	}
}
