using System.Runtime.InteropServices;
using UnityEngine;

public class GenerateHeight : ProceduralComponent
{
	[DllImport("RustNative", EntryPoint = "generate_height")]
	public static extern void Native_GenerateHeight(short[] map, int res, Vector3 pos, Vector3 size, uint seed, float lootAngle, float lootTier0, float lootTier1, float lootTier2, float biomeAngle, float biomeArid, float biomeTemperate, float biomeTundra, float biomeArctic);

	public override void Process(uint seed)
	{
		Native_GenerateHeight(TerrainMeta.HeightMap.dst, TerrainMeta.HeightMap.res, TerrainMeta.Position, TerrainMeta.Size, lootAngle: TerrainMeta.LootAxisAngle, biomeAngle: TerrainMeta.BiomeAxisAngle, seed: seed, lootTier0: World.Config.PercentageTier0, lootTier1: World.Config.PercentageTier1, lootTier2: World.Config.PercentageTier2, biomeArid: World.Config.PercentageBiomeArid, biomeTemperate: World.Config.PercentageBiomeTemperate, biomeTundra: World.Config.PercentageBiomeTundra, biomeArctic: World.Config.PercentageBiomeArctic);
	}
}
