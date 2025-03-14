using System.Runtime.InteropServices;
using UnityEngine;

public class GenerateTopology : ProceduralComponent
{
	[DllImport("RustNative", EntryPoint = "generate_topology")]
	public static extern void Native_GenerateTopology(int[] map, int res, Vector3 pos, Vector3 size, uint seed, float lootAngle, float biomeAngle, short[] heightmap, int heightres, byte[] biomemap, int biomeres);

	public override void Process(uint seed)
	{
		int[] dst = TerrainMeta.TopologyMap.dst;
		int res = TerrainMeta.TopologyMap.res;
		Vector3 position = TerrainMeta.Position;
		Vector3 size = TerrainMeta.Size;
		float lootAxisAngle = TerrainMeta.LootAxisAngle;
		float biomeAxisAngle = TerrainMeta.BiomeAxisAngle;
		short[] src = TerrainMeta.HeightMap.src;
		int res2 = TerrainMeta.HeightMap.res;
		byte[] src2 = TerrainMeta.BiomeMap.src;
		int res3 = TerrainMeta.BiomeMap.res;
		Native_GenerateTopology(dst, res, position, size, seed, lootAxisAngle, biomeAxisAngle, src, res2, src2, res3);
	}
}
