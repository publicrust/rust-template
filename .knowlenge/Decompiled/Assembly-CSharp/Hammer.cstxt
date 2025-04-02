using Oxide.Core;

public class Hammer : BaseMelee
{
	public override bool CanHit(HitTest info)
	{
		if (info.HitEntity == null)
		{
			return false;
		}
		if (info.HitEntity is BasePlayer)
		{
			return false;
		}
		return info.HitEntity is BaseCombatEntity;
	}

	public override void DoAttackShared(HitInfo info)
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		BaseCombatEntity baseCombatEntity = info.HitEntity as BaseCombatEntity;
		if (baseCombatEntity != null && ownerPlayer != null && base.isServer)
		{
			if (Interface.CallHook("OnHammerHit", ownerPlayer, info) != null)
			{
				return;
			}
			using (TimeWarning.New("DoRepair", 50))
			{
				baseCombatEntity.DoRepair(ownerPlayer);
			}
		}
		info.DoDecals = false;
		if (base.isServer)
		{
			Effect.server.ImpactEffect(info);
		}
		else
		{
			Effect.client.ImpactEffect(info);
		}
	}
}
