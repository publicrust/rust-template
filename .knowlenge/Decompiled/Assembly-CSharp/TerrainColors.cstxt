using UnityEngine;

public class TerrainColors : TerrainExtension
{
	private TerrainSplatMap splatMap;

	private TerrainBiomeMap biomeMap;

	public override void Setup()
	{
		splatMap = terrain.GetComponent<TerrainSplatMap>();
		biomeMap = terrain.GetComponent<TerrainBiomeMap>();
	}

	public Color GetColor(Vector3 worldPos, int mask = -1)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetColor(normX, normZ, mask);
	}

	public Color GetColor(float normX, float normZ, int mask = -1)
	{
		float biome = biomeMap.GetBiome(normX, normZ, 1);
		float biome2 = biomeMap.GetBiome(normX, normZ, 2);
		float biome3 = biomeMap.GetBiome(normX, normZ, 4);
		float biome4 = biomeMap.GetBiome(normX, normZ, 8);
		int num = TerrainSplat.TypeToIndex(splatMap.GetSplatMaxType(normX, normZ, mask));
		TerrainConfig.SplatType splatType = config.Splats[num];
		return biome * splatType.AridColor + biome2 * splatType.TemperateColor + biome3 * splatType.TundraColor + biome4 * splatType.ArcticColor;
	}
}
