using System;
using UnityEngine;

[Serializable]
public class SpawnFilter
{
	[InspectorFlags]
	public Enum SplatType = (Enum)(-1);

	[InspectorFlags]
	public Enum BiomeType = (Enum)(-1);

	[InspectorFlags]
	public Enum TopologyAny = (Enum)(-1);

	[InspectorFlags]
	public Enum TopologyAll;

	[InspectorFlags]
	public Enum TopologyNot;

	public bool Test(Vector3 worldPos)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return GetFactor(worldPos) > 0.5f;
	}

	public bool Test(float normX, float normZ)
	{
		return GetFactor(normX, normZ) > 0.5f;
	}

	public float GetFactor(Vector3 worldPos, bool checkPlacementMap = true, float checkTopologyRadius = 0f)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetFactor(normX, normZ, checkPlacementMap, checkTopologyRadius);
	}

	public float GetFactor(float normX, float normZ, bool checkPlacementMap = true, float checkTopologyRadius = 0f)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected I4, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected I4, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected I4, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected I4, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected I4, but got Unknown
		if ((Object)(object)TerrainMeta.TopologyMap == (Object)null)
		{
			return 0f;
		}
		if (checkPlacementMap && (Object)(object)TerrainMeta.PlacementMap != (Object)null && TerrainMeta.PlacementMap.GetBlocked(normX, normZ))
		{
			return 0f;
		}
		int num = (int)SplatType;
		int num2 = (int)BiomeType;
		int num3 = (int)TopologyAny;
		int num4 = (int)TopologyAll;
		int num5 = (int)TopologyNot;
		if (num3 == 0)
		{
			Debug.LogError((object)"Empty topology filter is invalid.");
		}
		else if (num3 != -1 || num4 != 0 || num5 != 0)
		{
			int num6 = ((checkTopologyRadius > 0f) ? TerrainMeta.TopologyMap.GetTopology(normX, normZ, checkTopologyRadius) : TerrainMeta.TopologyMap.GetTopology(normX, normZ));
			if (num3 != -1 && (num6 & num3) == 0)
			{
				return 0f;
			}
			if (num5 != 0 && (num6 & num5) != 0)
			{
				return 0f;
			}
			if (num4 != 0 && (num6 & num4) != num4)
			{
				return 0f;
			}
		}
		switch (num2)
		{
		case 0:
			Debug.LogError((object)"Empty biome filter is invalid.");
			break;
		default:
			if ((TerrainMeta.BiomeMap.GetBiomeMaxType(normX, normZ) & num2) == 0)
			{
				return 0f;
			}
			break;
		case -1:
			break;
		}
		switch (num)
		{
		case 0:
			Debug.LogError((object)"Empty splat filter is invalid.");
			break;
		default:
			return TerrainMeta.SplatMap.GetSplat(normX, normZ, num);
		case -1:
			break;
		}
		return 1f;
	}
}
