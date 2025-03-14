using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class BoundsCheckEx
{
	public static bool ApplyBoundsChecks(this BaseEntity entity, BoundsCheck[] bounds, Vector3 pos, Quaternion rot, Vector3 scale, LayerMask rejectOnLayer)
	{
		if (bounds.Length == 0 && (int)rejectOnLayer == 0)
		{
			return true;
		}
		OBB obb = new OBB(pos + rot * Vector3.Scale(entity.bounds.center, scale), Vector3.Scale(entity.bounds.extents, scale), rot);
		List<Collider> obj = Pool.GetList<Collider>();
		GamePhysics.OverlapOBB(obb, obj, 0x40000 | (int)rejectOnLayer, QueryTriggerInteraction.Collide);
		foreach (Collider item in obj)
		{
			if (!item.isTrigger && (item.gameObject.layer & (int)rejectOnLayer) != 0)
			{
				return false;
			}
			if (!item.TryGetComponent<SpawnableBoundsBlocker>(out var component))
			{
				continue;
			}
			foreach (BoundsCheck boundsCheck in bounds)
			{
				if (component.BlockType == boundsCheck.IsType)
				{
					Pool.FreeList(ref obj);
					return false;
				}
			}
		}
		Pool.FreeList(ref obj);
		return true;
	}
}
