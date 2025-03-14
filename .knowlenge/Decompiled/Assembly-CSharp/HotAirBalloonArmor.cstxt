public class HotAirBalloonArmor : HotAirBalloonEquipment
{
	public float AdditionalHealth = 100f;

	public override void Added(HotAirBalloon hab, bool fromSave)
	{
		base.Added(hab, fromSave);
		hab.SetMaxHealth(hab.MaxHealth() + AdditionalHealth);
		if (!fromSave)
		{
			hab.health += AdditionalHealth;
		}
		SendNetworkUpdate();
	}

	public override void Removed(HotAirBalloon hab)
	{
		base.Removed(hab);
		hab.DelayNextUpgrade(DelayNextUpgradeOnRemoveDuration);
	}

	public override void Hurt(HitInfo info)
	{
		if (HasParent() && GetParentEntity() is HotAirBalloon { baseProtection: var protectionProperties } hotAirBalloon)
		{
			hotAirBalloon.baseProtection = baseProtection;
			hotAirBalloon.Hurt(info);
			hotAirBalloon.baseProtection = protectionProperties;
		}
	}
}
