using System.Collections.Generic;
using Facepunch;
using Rust;
using UnityEngine;

public class ItemModProjectileRadialDamage : ItemModProjectileMod
{
	public float radius = 0.5f;

	public DamageTypeEntry damage;

	public GameObjectRef effect;

	public bool ignoreHitObject = true;

	public bool onlyDoors;

	public int vibrationLevel = 2;

	public override void ServerProjectileHit(HitInfo info)
	{
		if (effect.isValid)
		{
			Effect.server.Run(effect.resourcePath, info.HitPositionWorld, info.HitNormalWorld);
		}
		List<BaseCombatEntity> obj = Pool.Get<List<BaseCombatEntity>>();
		List<BaseCombatEntity> obj2 = Pool.Get<List<BaseCombatEntity>>();
		Vis.Entities(info.HitPositionWorld, radius, obj2, 1237003025);
		if (damage.type == DamageType.Explosion)
		{
			SeismicSensor.Notify(info.HitPositionWorld, vibrationLevel);
		}
		foreach (BaseCombatEntity item in obj2)
		{
			if (!item.isServer || obj.Contains(item) || (onlyDoors && !(item is Door)) || (item == info.HitEntity && ignoreHitObject))
			{
				continue;
			}
			item.CenterPoint();
			Vector3 vector = item.ClosestPoint(info.HitPositionWorld);
			float num = Vector3.Distance(vector, info.HitPositionWorld) / radius;
			if (num > 1f)
			{
				continue;
			}
			float num2 = 1f - num;
			if (item.IsVisibleAndCanSeeLegacy(info.HitPositionWorld - info.ProjectileVelocity.normalized * 0.1f) && item.IsVisibleAndCanSeeLegacy(info.HitPositionWorld - (vector - info.HitPositionWorld).normalized * 0.1f))
			{
				obj.Add(item);
				BasePlayer component = item.GetComponent<BasePlayer>();
				if (component != null && component.GetActiveShield(out var foundShield) && info.Initiator != null && foundShield.SphereCastAgainstColliders(info.HitPositionWorld, radius))
				{
					foundShield.OnAttacked(new HitInfo(info.Initiator, item, damage.type, damage.amount * num2));
				}
				else
				{
					item.OnAttacked(new HitInfo(info.Initiator, item, damage.type, damage.amount * num2));
				}
			}
		}
		Pool.FreeUnmanaged(ref obj);
		Pool.FreeUnmanaged(ref obj2);
	}
}
