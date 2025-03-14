using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class WaterLevel
{
	public struct WaterInfo
	{
		public bool isValid;

		public float currentDepth;

		public float overallDepth;

		public float surfaceLevel;

		public float terrainHeight;

		public bool artificalWater;

		public int topology;
	}

	public static float Factor(Vector3 start, Vector3 end, float radius, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.Factor"))
		{
			WaterInfo waterInfo = GetWaterInfo(start, end, radius, waves, volumes, forEntity);
			return waterInfo.isValid ? Mathf.InverseLerp(Mathf.Min(start.y, end.y) - radius, Mathf.Max(start.y, end.y) + radius, waterInfo.surfaceLevel) : 0f;
		}
	}

	public static float Factor(Bounds bounds, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.Factor"))
		{
			if (bounds.size == Vector3.zero)
			{
				bounds.size = new Vector3(0.1f, 0.1f, 0.1f);
			}
			WaterInfo waterInfo = GetWaterInfo(bounds, waves, volumes, forEntity);
			return waterInfo.isValid ? Mathf.InverseLerp(bounds.min.y, bounds.max.y, waterInfo.surfaceLevel) : 0f;
		}
	}

	public static bool Test(Vector3 pos, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.Test"))
		{
			return GetWaterInfo(pos, waves, volumes, forEntity).isValid;
		}
	}

	public static (float, float) GetWaterAndTerrainSurface(Vector3 pos, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterDepth"))
		{
			WaterInfo waterInfo = GetWaterInfo(pos, waves, volumes, forEntity);
			return (waterInfo.surfaceLevel, waterInfo.terrainHeight);
		}
	}

	public static float GetWaterOrTerrainSurface(Vector3 pos, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterDepth"))
		{
			WaterInfo waterInfo = GetWaterInfo(pos, waves, volumes, forEntity);
			return Mathf.Max(waterInfo.surfaceLevel, waterInfo.terrainHeight);
		}
	}

	public static float GetWaterSurface(Vector3 pos, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterDepth"))
		{
			return GetWaterInfo(pos, waves, volumes, forEntity).surfaceLevel;
		}
	}

	public static float GetWaterDepth(Vector3 pos, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterDepth"))
		{
			return GetWaterInfo(pos, waves, volumes, forEntity).currentDepth;
		}
	}

	public static float GetOverallWaterDepth(Vector3 pos, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetOverallWaterDepth"))
		{
			return GetWaterInfo(pos, waves, volumes, forEntity).overallDepth;
		}
	}

	public static Vector3 GetWaterFlowDirection(Vector3 worldPosition)
	{
		if (TerrainMeta.WaterFlowMap == null)
		{
			return Vector3.zero;
		}
		return TerrainMeta.WaterFlowMap.GetFlowDirection(worldPosition);
	}

	public static Vector3 GetWaterNormal(Vector3 pos)
	{
		return Vector3.up;
	}

	public static WaterInfo GetBuoyancyWaterInfo(Vector3 pos, Vector2 posUV, float terrainHeight, float waterHeight, bool doDeepwaterChecks, BaseEntity forEntity)
	{
		using (TimeWarning.New("WaterLevel.GetWaterInfo"))
		{
			WaterInfo result = default(WaterInfo);
			if (pos.y > waterHeight)
			{
				return GetWaterInfoFromVolumes(pos, forEntity);
			}
			bool flag = pos.y < terrainHeight - 1f;
			if (flag)
			{
				return GetWaterInfoFromVolumes(pos, forEntity);
			}
			bool flag2 = doDeepwaterChecks && (pos.y < waterHeight - 10f || TerrainMeta.OutOfBounds(pos));
			int num = (TerrainMeta.TopologyMap ? TerrainMeta.TopologyMap.GetTopologyFast(posUV) : 0);
			if ((flag || flag2 || (num & 0x3C180) == 0) && (bool)WaterSystem.Collision && WaterSystem.Collision.GetIgnore(pos))
			{
				return result;
			}
			if (flag2 && Physics.Raycast(pos, Vector3.up, out var hitInfo, 5f, 16, QueryTriggerInteraction.Collide))
			{
				waterHeight = Mathf.Min(waterHeight, hitInfo.collider.bounds.max.y);
			}
			result.isValid = true;
			result.currentDepth = Mathf.Max(0f, waterHeight - pos.y);
			result.overallDepth = Mathf.Max(0f, waterHeight - terrainHeight);
			result.surfaceLevel = waterHeight;
			result.terrainHeight = terrainHeight;
			result.topology = num;
			return result;
		}
	}

	public static WaterInfo GetWaterInfo(Vector3 pos, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterInfo"))
		{
			WaterInfo result = default(WaterInfo);
			float num = GetWaterLevel(pos, waves);
			float num2 = (((bool)TerrainMeta.HeightMap && TerrainMeta.HeightMap.isInitialized) ? TerrainMeta.HeightMap.GetHeight(pos) : 0f);
			result.isValid = true;
			if (pos.y > num)
			{
				result.isValid = false;
			}
			else if (pos.y < num2 - 1f)
			{
				result.isValid = false;
			}
			bool flag = false;
			if (!result.isValid && volumes)
			{
				result = GetWaterInfoFromVolumes(pos, forEntity);
				if (result.isValid)
				{
					flag = true;
					num = result.surfaceLevel;
				}
			}
			if (result.isValid && (bool)WaterSystem.Collision && WaterSystem.Collision.GetIgnore(pos))
			{
				result.isValid = false;
				num = -1000f;
			}
			result.currentDepth = Mathf.Max(0f, num - pos.y);
			if (!flag)
			{
				result.overallDepth = Mathf.Max(0f, num - num2);
			}
			result.surfaceLevel = num;
			result.terrainHeight = num2;
			return result;
		}
	}

	public static WaterInfo GetWaterInfo(Bounds bounds, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterInfo"))
		{
			WaterInfo result = default(WaterInfo);
			float num = GetWaterLevel(bounds.center, waves);
			float num2 = (TerrainMeta.HeightMap ? TerrainMeta.HeightMap.GetHeight(bounds.center) : 0f);
			result.isValid = true;
			if (bounds.min.y > num)
			{
				result.isValid = false;
			}
			else if (bounds.max.y < num2 - 1f)
			{
				result.isValid = false;
			}
			if (!result.isValid && volumes)
			{
				result = GetWaterInfoFromVolumes(bounds, forEntity);
				if (result.isValid)
				{
					num = result.surfaceLevel;
				}
			}
			if (result.isValid && (bool)WaterSystem.Collision && WaterSystem.Collision.GetIgnore(bounds))
			{
				result.isValid = false;
				num = -1000f;
			}
			result.currentDepth = Mathf.Max(0f, num - bounds.min.y);
			result.overallDepth = Mathf.Max(0f, num - num2);
			result.surfaceLevel = num;
			result.terrainHeight = num2;
			return result;
		}
	}

	public static WaterInfo GetWaterInfo(Vector3 start, Vector3 end, float radius, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterInfo"))
		{
			WaterInfo result = default(WaterInfo);
			Vector3 vector = (start + end) * 0.5f;
			float num = Mathf.Min(start.y, end.y) - radius;
			float num2 = Mathf.Max(start.y, end.y) + radius;
			float num3 = GetWaterLevel(vector, waves);
			float num4 = (TerrainMeta.HeightMap ? TerrainMeta.HeightMap.GetHeight(vector) : 0f);
			result.isValid = true;
			if (num > num3)
			{
				result.isValid = false;
			}
			else if (num2 < num4 - 1f)
			{
				result.isValid = false;
			}
			if (!result.isValid && volumes)
			{
				result = GetWaterInfoFromVolumes(start, end, radius, forEntity);
				if (result.isValid)
				{
					num3 = result.surfaceLevel;
				}
			}
			if (result.isValid && (bool)WaterSystem.Collision && WaterSystem.Collision.GetIgnore(start, end, radius))
			{
				Vector3 pos = vector.WithY(Mathf.Lerp(num, num2, 0.75f));
				if (!WaterSystem.Collision.GetIgnore(pos))
				{
					num3 = Mathf.Min(num3, pos.y);
				}
				else
				{
					result.isValid = false;
					num3 = -1000f;
				}
			}
			result.currentDepth = Mathf.Max(0f, num3 - num);
			result.overallDepth = Mathf.Max(0f, num3 - num4);
			result.surfaceLevel = num3;
			result.terrainHeight = num4;
			return result;
		}
	}

	public static WaterInfo GetWaterInfo(Camera cam, bool waves, bool volumes, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterInfo"))
		{
			waves = waves && WaterSystem.Instance != null;
			float num = WaterSystem.OceanLevel;
			if (waves)
			{
				num += WaterSystem.Instance.oceanSimulation.MinLevel();
			}
			if (cam.transform.position.y < num - 1f)
			{
				return GetWaterInfo(cam.transform.position, waves, volumes, forEntity);
			}
			return GetWaterInfo(cam.transform.position - Vector3.up, waves, volumes, forEntity);
		}
	}

	private static float GetWaterLevel(Vector3 pos, bool waves)
	{
		if (!UnityEngine.Application.isPlaying)
		{
			return WaterSystem.OceanLevel;
		}
		waves = waves && WaterSystem.Instance != null;
		float normX = TerrainMeta.NormalizeX(pos.x);
		float normZ = TerrainMeta.NormalizeZ(pos.z);
		float num = (TerrainMeta.WaterMap ? TerrainMeta.WaterMap.GetHeight(normX, normZ) : TerrainMeta.Position.y);
		float num2 = WaterSystem.OceanLevel;
		if (waves)
		{
			num2 += WaterSystem.Instance.oceanSimulation.MaxLevel();
		}
		if (num < num2 && (!TerrainMeta.TopologyMap || TerrainMeta.TopologyMap.GetTopology(normX, normZ, 384)))
		{
			float num3 = WaterSystem.OceanLevel;
			if (waves)
			{
				num3 += WaterSystem.Instance.oceanSimulation.GetHeight(pos);
			}
			return Mathf.Max(num, num3);
		}
		return num;
	}

	private static WaterInfo GetWaterInfoFromVolumes(Bounds bounds, BaseEntity forEntity)
	{
		WaterInfo info = default(WaterInfo);
		if (forEntity == null)
		{
			List<WaterVolume> obj = Pool.Get<List<WaterVolume>>();
			Vis.Components(new OBB(bounds), obj, 262144);
			using (List<WaterVolume>.Enumerator enumerator = obj.GetEnumerator())
			{
				while (enumerator.MoveNext() && !enumerator.Current.Test(bounds, out info))
				{
				}
			}
			Pool.FreeUnmanaged(ref obj);
			return info;
		}
		forEntity.WaterTestFromVolumes(bounds, out info);
		return info;
	}

	private static WaterInfo GetWaterInfoFromVolumes(Vector3 pos, BaseEntity forEntity)
	{
		WaterInfo info = default(WaterInfo);
		if (forEntity == null)
		{
			List<WaterVolume> obj = Pool.Get<List<WaterVolume>>();
			Vis.Components(pos, 0.1f, obj, 262144);
			foreach (WaterVolume item in obj)
			{
				if (item.Test(pos, out info))
				{
					info.artificalWater = !item.naturalSource;
					break;
				}
			}
			Pool.FreeUnmanaged(ref obj);
			return info;
		}
		forEntity.WaterTestFromVolumes(pos, out info);
		return info;
	}

	private static WaterInfo GetWaterInfoFromVolumes(Vector3 start, Vector3 end, float radius, BaseEntity forEntity)
	{
		WaterInfo info = default(WaterInfo);
		if (forEntity == null)
		{
			List<WaterVolume> obj = Pool.Get<List<WaterVolume>>();
			Vis.Components(start, end, radius, obj, 262144);
			using (List<WaterVolume>.Enumerator enumerator = obj.GetEnumerator())
			{
				while (enumerator.MoveNext() && !enumerator.Current.Test(start, end, radius, out info))
				{
				}
			}
			Pool.FreeUnmanaged(ref obj);
			return info;
		}
		forEntity.WaterTestFromVolumes(start, end, radius, out info);
		return info;
	}
}
