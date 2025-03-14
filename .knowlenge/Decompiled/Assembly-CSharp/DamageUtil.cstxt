using System.Collections.Generic;
using Facepunch;
using Rust;
using UnityEngine;

public static class DamageUtil
{
	public static void RadiusDamage(BaseEntity attackingPlayer, BaseEntity weaponPrefab, Vector3 pos, float minradius, float radius, List<DamageTypeEntry> damage, int layers, bool useLineOfSight, bool ignoreAI = false, bool ignoreAttackingPlayer = false, bool extendedLineOfSight = false)
	{
		using (TimeWarning.New("DamageUtil.RadiusDamage"))
		{
			List<HitInfo> obj = Pool.Get<List<HitInfo>>();
			List<BaseEntity> obj2 = Pool.Get<List<BaseEntity>>();
			List<BaseEntity> obj3 = Pool.Get<List<BaseEntity>>();
			Vis.Entities(pos, radius, obj3, layers);
			for (int i = 0; i < obj3.Count; i++)
			{
				BaseEntity baseEntity = obj3[i];
				if (!baseEntity.isServer || obj2.Contains(baseEntity) || (ignoreAI && IsIgnoredAI(baseEntity)))
				{
					continue;
				}
				Vector3 vector = baseEntity.ClosestPoint(pos);
				float num = Mathf.Clamp01((Vector3.Distance(vector, pos) - minradius) / (radius - minradius));
				if (!(num > 1f))
				{
					float amount = 1f - num;
					if ((!extendedLineOfSight || GamePhysics.LineOfSight(baseEntity.CenterPoint(), pos, 1218519041, baseEntity)) && (!useLineOfSight || baseEntity.IsVisible(pos)))
					{
						HitInfo hitInfo = new HitInfo();
						hitInfo.Initiator = attackingPlayer;
						hitInfo.WeaponPrefab = weaponPrefab;
						hitInfo.damageTypes.Add(damage);
						hitInfo.damageTypes.ScaleAll(amount);
						hitInfo.HitPositionWorld = vector;
						hitInfo.HitNormalWorld = (pos - vector).normalized;
						hitInfo.PointStart = pos;
						hitInfo.PointEnd = hitInfo.HitPositionWorld;
						obj.Add(hitInfo);
						obj2.Add(baseEntity);
					}
				}
			}
			for (int j = 0; j < obj2.Count; j++)
			{
				BaseEntity baseEntity2 = obj2[j];
				HitInfo info = obj[j];
				if (!ignoreAttackingPlayer || !(attackingPlayer != null) || !baseEntity2.EqualNetID(attackingPlayer))
				{
					baseEntity2.OnAttacked(info);
				}
			}
			Pool.FreeUnmanaged(ref obj);
			Pool.FreeUnmanaged(ref obj2);
			Pool.FreeUnmanaged(ref obj3);
		}
	}

	private static bool IsIgnoredAI(BaseEntity ent)
	{
		return ent is ScientistNPC;
	}
}
