using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class EnvironmentVolumeEx
{
	public static bool CheckEnvironmentVolumes(this Transform transform, Vector3 pos, Quaternion rot, Vector3 scale, EnvironmentType type)
	{
		List<EnvironmentVolume> obj = Pool.Get<List<EnvironmentVolume>>();
		transform.GetComponentsInChildren(includeInactive: true, obj);
		for (int i = 0; i < obj.Count; i++)
		{
			EnvironmentVolume environmentVolume = obj[i];
			OBB obb = new OBB(environmentVolume.transform, new Bounds(environmentVolume.Center, environmentVolume.Size));
			obb.Transform(pos, scale, rot);
			if (EnvironmentManager.Check(obb, type))
			{
				Pool.FreeUnmanaged(ref obj);
				return true;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return false;
	}

	public static bool CheckEnvironmentVolumes(this Transform transform, EnvironmentType type)
	{
		return transform.CheckEnvironmentVolumes(transform.position, transform.rotation, transform.lossyScale, type);
	}

	public static bool CheckEnvironmentVolumesInsideTerrain(this Transform transform, Vector3 pos, Quaternion rot, Vector3 scale, EnvironmentType type, float padding = 0f)
	{
		if (TerrainMeta.HeightMap == null)
		{
			return true;
		}
		List<EnvironmentVolume> obj = Pool.Get<List<EnvironmentVolume>>();
		transform.GetComponentsInChildren(includeInactive: true, obj);
		if (obj.Count == 0)
		{
			Pool.FreeUnmanaged(ref obj);
			return true;
		}
		for (int i = 0; i < obj.Count; i++)
		{
			EnvironmentVolume environmentVolume = obj[i];
			if ((environmentVolume.Type & type) == 0)
			{
				continue;
			}
			OBB oBB = new OBB(environmentVolume.transform, new Bounds(environmentVolume.Center, environmentVolume.Size));
			oBB.Transform(pos, scale, rot);
			Vector3 point = oBB.GetPoint(-1f, 0f, -1f);
			Vector3 point2 = oBB.GetPoint(1f, 0f, -1f);
			Vector3 point3 = oBB.GetPoint(-1f, 0f, 1f);
			Vector3 point4 = oBB.GetPoint(1f, 0f, 1f);
			float max = oBB.ToBounds().max.y + padding;
			bool fail = false;
			TerrainMeta.HeightMap.ForEachParallel(point, point2, point3, point4, delegate(int x, int z)
			{
				if (TerrainMeta.HeightMap.GetHeight(x, z) <= max)
				{
					fail = true;
				}
			});
			if (fail)
			{
				Pool.FreeUnmanaged(ref obj);
				return false;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return true;
	}

	public static bool CheckEnvironmentVolumesInsideTerrain(this Transform transform, EnvironmentType type)
	{
		return transform.CheckEnvironmentVolumesInsideTerrain(transform.position, transform.rotation, transform.lossyScale, type);
	}

	public static bool CheckEnvironmentVolumesOutsideTerrain(this Transform transform, Vector3 pos, Quaternion rot, Vector3 scale, EnvironmentType type, float padding = 0f)
	{
		if (TerrainMeta.HeightMap == null)
		{
			return true;
		}
		List<EnvironmentVolume> obj = Pool.Get<List<EnvironmentVolume>>();
		transform.GetComponentsInChildren(includeInactive: true, obj);
		if (obj.Count == 0)
		{
			Pool.FreeUnmanaged(ref obj);
			return true;
		}
		for (int i = 0; i < obj.Count; i++)
		{
			EnvironmentVolume environmentVolume = obj[i];
			if ((environmentVolume.Type & type) == 0)
			{
				continue;
			}
			OBB oBB = new OBB(environmentVolume.transform, new Bounds(environmentVolume.Center, environmentVolume.Size));
			oBB.Transform(pos, scale, rot);
			Vector3 point = oBB.GetPoint(-1f, 0f, -1f);
			Vector3 point2 = oBB.GetPoint(1f, 0f, -1f);
			Vector3 point3 = oBB.GetPoint(-1f, 0f, 1f);
			Vector3 point4 = oBB.GetPoint(1f, 0f, 1f);
			float min = oBB.ToBounds().min.y - padding;
			bool fail = false;
			TerrainMeta.HeightMap.ForEachParallel(point, point2, point3, point4, delegate(int x, int z)
			{
				if (TerrainMeta.HeightMap.GetHeight(x, z) >= min)
				{
					fail = true;
				}
			});
			if (fail)
			{
				Pool.FreeUnmanaged(ref obj);
				return false;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return true;
	}

	public static bool CheckEnvironmentVolumesOutsideTerrain(this Transform transform, EnvironmentType type)
	{
		return transform.CheckEnvironmentVolumesOutsideTerrain(transform.position, transform.rotation, transform.lossyScale, type);
	}
}
