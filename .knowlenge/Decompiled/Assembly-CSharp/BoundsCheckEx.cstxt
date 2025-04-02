using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class BoundsCheckEx
{
	public static bool ApplyBoundsChecks(this BaseEntity entity, BoundsCheck[] bounds, Vector3 pos, Quaternion rot, Vector3 scale, LayerMask rejectOnLayer)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (bounds.Length == 0 && LayerMask.op_Implicit(rejectOnLayer) == 0)
		{
			return true;
		}
		OBB obb = new OBB(pos + rot * Vector3.Scale(((Bounds)(ref entity.bounds)).center, scale), Vector3.Scale(((Bounds)(ref entity.bounds)).extents, scale), rot);
		List<Collider> list = Pool.Get<List<Collider>>();
		GamePhysics.OverlapOBB(obb, list, 0x40000 | LayerMask.op_Implicit(rejectOnLayer), (QueryTriggerInteraction)2);
		SpawnableBoundsBlocker spawnableBoundsBlocker = default(SpawnableBoundsBlocker);
		foreach (Collider item in list)
		{
			if (!item.isTrigger && (((Component)item).gameObject.layer & LayerMask.op_Implicit(rejectOnLayer)) != 0)
			{
				Pool.FreeUnmanaged<Collider>(ref list);
				return false;
			}
			if (!((Component)item).TryGetComponent<SpawnableBoundsBlocker>(ref spawnableBoundsBlocker))
			{
				continue;
			}
			foreach (BoundsCheck boundsCheck in bounds)
			{
				if (spawnableBoundsBlocker.BlockType == boundsCheck.IsType)
				{
					Pool.FreeUnmanaged<Collider>(ref list);
					return false;
				}
			}
		}
		Pool.FreeUnmanaged<Collider>(ref list);
		return true;
	}
}
