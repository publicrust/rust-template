using UnityEngine;

public class WaterResource
{
	public static ItemDefinition SV_GetAtPoint(Vector3 pos)
	{
		if (IsRadioactive(pos))
		{
			return WaterTypes.RadioactiveWaterItemDef;
		}
		if (!IsFreshWater(pos))
		{
			return WaterTypes.SaltWaterItemDef;
		}
		return WaterTypes.WaterItemDef;
	}

	public static WaterBody FindWaterBodyAtPos(Vector3 pos)
	{
		float num = 1.5f;
		RaycastHit hitInfo;
		bool num2 = GamePhysics.Trace(new Ray(pos + Vector3.up * num, Vector3.down), 0f, out hitInfo, 3f, 16);
		WaterBody result = null;
		if (num2)
		{
			result = RaycastHitEx.GetWaterBody(hitInfo);
		}
		return result;
	}

	public static bool IsRadioactive(WaterBody body)
	{
		return body.Type == WaterBodyType.Radioactive;
	}

	public static bool IsRadioactive(Vector3 pos)
	{
		WaterBody waterBody = FindWaterBodyAtPos(pos);
		if ((bool)waterBody)
		{
			return waterBody.Type == WaterBodyType.Radioactive;
		}
		return false;
	}

	public static bool IsFreshWater(Vector3 pos)
	{
		if (TerrainMeta.TopologyMap == null)
		{
			return false;
		}
		return TerrainMeta.TopologyMap.GetTopology(pos, 245760);
	}

	public static ItemDefinition Merge(ItemDefinition first, ItemDefinition second)
	{
		if (first == second)
		{
			return first;
		}
		if (first == WaterTypes.RadioactiveWaterItemDef || second == WaterTypes.RadioactiveWaterItemDef)
		{
			return WaterTypes.RadioactiveWaterItemDef;
		}
		if (first == WaterTypes.SaltWaterItemDef || second == WaterTypes.SaltWaterItemDef)
		{
			return WaterTypes.SaltWaterItemDef;
		}
		return WaterTypes.WaterItemDef;
	}
}
