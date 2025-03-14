using UnityEngine;

public class HotAirBalloonEquipment : BaseCombatEntity
{
	[SerializeField]
	private DamageRenderer damageRenderer;

	[HideInInspector]
	public float DelayNextUpgradeOnRemoveDuration;

	private EntityRef<HotAirBalloon> hotAirBalloon;

	public virtual void Added(HotAirBalloon hab, bool fromSave)
	{
		hotAirBalloon.Set(hab);
	}

	public virtual void Removed(HotAirBalloon hab)
	{
		hotAirBalloon.Set(null);
	}

	public override void DoRepair(BasePlayer player)
	{
		HotAirBalloon hotAirBalloon = this.hotAirBalloon.Get(serverside: true);
		if (hotAirBalloon.IsValid())
		{
			hotAirBalloon.DoRepair(player);
		}
	}
}
