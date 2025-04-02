using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class ItemModProjectileRagdoll : ItemModProjectileMod
{
	public float radius = 0.5f;

	public float velocityInheritFactor = 0.25f;

	public override void ServerProjectileHit(HitInfo info)
	{
		List<BasePlayer> list = Pool.Get<List<BasePlayer>>();
		Vis.Entities(info.HitPositionWorld, radius, list, 131072);
		foreach (BasePlayer item in list)
		{
			if (item.isServer && !item.IsDead() && !item.InSafeZone())
			{
				Vector3 vector = ((!(info.HitEntity == item)) ? ((item.transform.position - info.HitPositionWorld + Vector3.up).normalized * 7.5f) : (info.ProjectileVelocity * velocityInheritFactor));
				item.Ragdoll(item.GetWorldVelocity() + vector);
			}
		}
	}
}
