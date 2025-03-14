using System.Runtime.InteropServices;
using UnityEngine;

public class GenerateBiome : ProceduralComponent
{
	[DllImport("RustNative", EntryPoint = "generate_biome")]
	public static extern void Native_GenerateBiome(byte[] map, int res, Vector3 pos, Vector3 size, uint seed, float lootAngle, float lootTier0, float lootTier1, float lootTier2, float biomeAngle, float biomeArid, float biomeTemperate, float biomeTundra, float biomeArctic, short[] heightmap, int heightres);

	public override void Process(uint seed)
	{
		Native_GenerateBiome(TerrainMeta.BiomeMap.dst, TerrainMeta.BiomeMap.res, TerrainMeta.Position, TerrainMeta.Size, lootAngle: TerrainMeta.LootAxisAngle, biomeAngle: TerrainMeta.BiomeAxisAngle, heightmap: TerrainMeta.HeightMap.src, heightres: TerrainMeta.HeightMap.res, seed: seed, lootTier0: World.Config.PercentageTier0, lootTier1: World.Config.PercentageTier1, lootTier2: World.Config.PercentageTier2, biomeArid: World.Config.PercentageBiomeArid, biomeTemperate: World.Config.PercentageBiomeTemperate, biomeTundra: World.Config.PercentageBiomeTundra, biomeArctic: World.Config.PercentageBiomeArctic);
	}
}
