using UnityEngine;

public static class WaterLevel
{
	public struct WaterInfo
	{
		public bool isValid;

		public float currentDepth;

		public float overallDepth;

		public float surfaceLevel;
	}

	public static float Factor(Bounds bounds, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.Factor"))
		{
			if (bounds.size == Vector3.zero)
			{
				bounds.size = new Vector3(0.1f, 0.1f, 0.1f);
			}
			WaterInfo waterInfo = GetWaterInfo(bounds, forEntity);
			return waterInfo.isValid ? Mathf.InverseLerp(bounds.min.y, bounds.max.y, waterInfo.surfaceLevel) : 0f;
		}
	}

	public static bool Test(Vector3 pos, float radius, bool waves = true, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.Test"))
		{
			WaterInfo waterInfo = GetWaterInfo(pos, waves, forEntity);
			return waterInfo.isValid && Mathf.Abs(waterInfo.surfaceLevel - pos.y) <= radius;
		}
	}

	public static bool Test(Vector3 pos, bool waves = true, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.Test"))
		{
			return GetWaterInfo(pos, waves, forEntity).isValid;
		}
	}

	public static float GetWaterDepth(Vector3 pos, bool waves = true, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterDepth"))
		{
			return GetWaterInfo(pos, waves, forEntity).currentDepth;
		}
	}

	public static float GetOverallWaterDepth(Vector3 pos, bool waves = true, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetOverallWaterDepth"))
		{
			return GetWaterInfo(pos, waves, forEntity).overallDepth;
		}
	}

	public static WaterInfo GetBuoyancyWaterInfo(Vector3 pos, Vector2 posUV, float terrainHeight, float waterHeight, BaseEntity forEntity = null)
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
				waterHeight = 0f;
				if (pos.y > waterHeight)
				{
					return result;
				}
			}
			int num = (TerrainMeta.TopologyMap ? TerrainMeta.TopologyMap.GetTopologyFast(posUV) : 0);
			if ((flag || (num & 0x3C180) == 0) && (bool)WaterSystem.Collision && WaterSystem.Collision.GetIgnore(pos))
			{
				return result;
			}
			result.isValid = true;
			result.currentDepth = Mathf.Max(0f, waterHeight - pos.y);
			result.overallDepth = Mathf.Max(0f, waterHeight - terrainHeight);
			result.surfaceLevel = waterHeight;
			return result;
		}
	}

	public static WaterInfo GetWaterInfo(Vector3 pos, bool waves = true, BaseEntity forEntity = null)
	{
		using (TimeWarning.New("WaterLevel.GetWaterInfo"))
		{
			WaterInfo result = default(WaterInfo);
			float num = 0f;
			if (waves)
			{
				num = WaterSystem.GetHeight(pos);
			}
			else if ((bool)TerrainMeta.WaterMap)
			{
				num = TerrainMeta.WaterMap.GetHeight(pos);
			}
			if (pos.y > num)
			{
				return GetWaterInfoFromVolumes(pos, forEntity);
			}
			float num2 = (TerrainMeta.HeightMap ? TerrainMeta.HeightMap.GetHeight(pos) : 0f);
			if (pos.y < num2 - 1f)
			{
				num = 0f;
				if (pos.y > num)
				{
					return result;
				}
			}
			if ((bool)WaterSystem.Collision && WaterSystem.Collision.GetIgnore(pos))
			{
				return result;
			}
			result.isValid = true;
			result.currentDepth = Mathf.Max(0f, num - pos.y);
			result.overallDepth = Mathf.Max(0f, num - num2);
			result.surfaceLevel = num;
			return result;
		}
	}

	public static WaterInfo GetWaterInfo(Bounds bounds, BaseEntity forEntity = null, bool waves = true)
	{
		using (TimeWarning.New("WaterLevel.GetWaterInfo"))
		{
			WaterInfo result = default(WaterInfo);
			float num = 0f;
			if (waves)
			{
				num = WaterSystem.GetHeight(bounds.center);
			}
			else if ((bool)TerrainMeta.WaterMap)
			{
				num = TerrainMeta.WaterMap.GetHeight(bounds.center);
			}
			if (bounds.min.y > num)
			{
				return GetWaterInfoFromVolumes(bounds, forEntity);
			}
			float num2 = (TerrainMeta.HeightMap ? TerrainMeta.HeightMap.GetHeight(bounds.center) : 0f);
			if (bounds.max.y < num2 - 1f)
			{
				num = 0f;
				if (bounds.min.y > num)
				{
					return result;
				}
			}
			if ((bool)WaterSystem.Collision && WaterSystem.Collision.GetIgnore(bounds))
			{
				return result;
			}
			result.isValid = true;
			result.currentDepth = Mathf.Max(0f, num - bounds.min.y);
			result.overallDepth = Mathf.Max(0f, num - num2);
			result.surfaceLevel = num;
			return result;
		}
	}

	private static WaterInfo GetWaterInfoFromVolumes(Bounds bounds, BaseEntity forEntity)
	{
		WaterInfo info = default(WaterInfo);
		if (forEntity == null)
		{
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
			return info;
		}
		forEntity.WaterTestFromVolumes(pos, out info);
		return info;
	}
}
