using System.Collections.Generic;
using Facepunch;
using Rust;
using UnityEngine;

public static class DamageUtil
{
	public static void RadiusDamage(BaseEntity attackingPlayer, BaseEntity weaponPrefab, Vector3 pos, float minradius, float radius, List<DamageTypeEntry> damage, int layers, bool useLineOfSight)
	{
		using (TimeWarning.New("DamageUtil.RadiusDamage"))
		{
			List<HitInfo> obj = Pool.GetList<HitInfo>();
			List<BaseEntity> obj2 = Pool.GetList<BaseEntity>();
			List<BaseEntity> obj3 = Pool.GetList<BaseEntity>();
			Vis.Entities(pos, radius, obj3, layers);
			for (int i = 0; i < obj3.Count; i++)
			{
				BaseEntity baseEntity = obj3[i];
				if (!baseEntity.isServer || obj2.Contains(baseEntity))
				{
					continue;
				}
				Vector3 vector = baseEntity.ClosestPoint(pos);
				float num = Mathf.Clamp01((Vector3.Distance(vector, pos) - minradius) / (radius - minradius));
				if (!(num > 1f))
				{
					float amount = 1f - num;
					if (!useLineOfSight || baseEntity.IsVisible(pos))
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
				baseEntity2.OnAttacked(info);
			}
			Pool.FreeList(ref obj);
			Pool.FreeList(ref obj2);
			Pool.FreeList(ref obj3);
		}
	}
}
