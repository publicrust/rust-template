using System;
using UnityEngine;

[Serializable]
public class SpawnFilter
{
	[InspectorFlags]
	public TerrainSplat.Enum SplatType = (TerrainSplat.Enum)(-1);

	[InspectorFlags]
	public TerrainBiome.Enum BiomeType = (TerrainBiome.Enum)(-1);

	[InspectorFlags]
	public TerrainTopology.Enum TopologyAny = (TerrainTopology.Enum)(-1);

	[InspectorFlags]
	public TerrainTopology.Enum TopologyAll;

	[InspectorFlags]
	public TerrainTopology.Enum TopologyNot;

	public bool Test(Vector3 worldPos)
	{
		return GetFactor(worldPos) > 0.5f;
	}

	public bool Test(float normX, float normZ)
	{
		return GetFactor(normX, normZ) > 0.5f;
	}

	public float GetFactor(Vector3 worldPos, bool checkPlacementMap = true, float checkTopologyRadius = 0f)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetFactor(normX, normZ, checkPlacementMap, checkTopologyRadius);
	}

	public float GetFactor(float normX, float normZ, bool checkPlacementMap = true, float checkTopologyRadius = 0f)
	{
		if (TerrainMeta.TopologyMap == null)
		{
			return 0f;
		}
		if (checkPlacementMap && TerrainMeta.PlacementMap != null && TerrainMeta.PlacementMap.GetBlocked(normX, normZ))
		{
			return 0f;
		}
		int splatType = (int)SplatType;
		int biomeType = (int)BiomeType;
		int topologyAny = (int)TopologyAny;
		int topologyAll = (int)TopologyAll;
		int topologyNot = (int)TopologyNot;
		if (topologyAny == 0)
		{
			Debug.LogError("Empty topology filter is invalid.");
		}
		else if (topologyAny != -1 || topologyAll != 0 || topologyNot != 0)
		{
			int num = ((checkTopologyRadius > 0f) ? TerrainMeta.TopologyMap.GetTopology(normX, normZ, checkTopologyRadius) : TerrainMeta.TopologyMap.GetTopology(normX, normZ));
			if (topologyAny != -1 && (num & topologyAny) == 0)
			{
				return 0f;
			}
			if (topologyNot != 0 && (num & topologyNot) != 0)
			{
				return 0f;
			}
			if (topologyAll != 0 && (num & topologyAll) != topologyAll)
			{
				return 0f;
			}
		}
		switch (biomeType)
		{
		case 0:
			Debug.LogError("Empty biome filter is invalid.");
			break;
		default:
			if ((TerrainMeta.BiomeMap.GetBiomeMaxType(normX, normZ) & biomeType) == 0)
			{
				return 0f;
			}
			break;
		case -1:
			break;
		}
		switch (splatType)
		{
		case 0:
			Debug.LogError("Empty splat filter is invalid.");
			break;
		default:
			return TerrainMeta.SplatMap.GetSplat(normX, normZ, splatType);
		case -1:
			break;
		}
		return 1f;
	}
}
