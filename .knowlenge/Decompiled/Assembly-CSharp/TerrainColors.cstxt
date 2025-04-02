using UnityEngine;

public class TerrainColors : TerrainExtension
{
	private TerrainSplatMap splatMap;

	private TerrainBiomeMap biomeMap;

	public override void Setup()
	{
		splatMap = ((Component)terrain).GetComponent<TerrainSplatMap>();
		biomeMap = ((Component)terrain).GetComponent<TerrainBiomeMap>();
	}

	public Color GetColor(Vector3 worldPos, int mask = -1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetColor(normX, normZ, mask);
	}

	public Color GetColor(float normX, float normZ, int mask = -1)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		float biome = biomeMap.GetBiome(normX, normZ, 1);
		float biome2 = biomeMap.GetBiome(normX, normZ, 2);
		float biome3 = biomeMap.GetBiome(normX, normZ, 4);
		float biome4 = biomeMap.GetBiome(normX, normZ, 8);
		int num = TerrainSplat.TypeToIndex(splatMap.GetSplatMaxType(normX, normZ, mask));
		TerrainConfig.SplatType splatType = config.Splats[num];
		return biome * splatType.AridColor + biome2 * splatType.TemperateColor + biome3 * splatType.TundraColor + biome4 * splatType.ArcticColor;
	}
}
