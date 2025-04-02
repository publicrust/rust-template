using System.Runtime.InteropServices;
using UnityEngine;

public class GenerateSplat : ProceduralComponent
{
	[DllImport("RustNative", EntryPoint = "generate_splat")]
	public static extern void Native_GenerateSplat(byte[] map, int res, Vector3 pos, Vector3 size, uint seed, float lootAngle, float biomeAngle, short[] heightmap, int heightres, byte[] biomemap, int biomeres, int[] topologymap, int topologyres);

	public override void Process(uint seed)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		byte[] dst = TerrainMeta.SplatMap.dst;
		int res = TerrainMeta.SplatMap.res;
		Vector3 position = TerrainMeta.Position;
		Vector3 size = TerrainMeta.Size;
		float lootAxisAngle = TerrainMeta.LootAxisAngle;
		float biomeAxisAngle = TerrainMeta.BiomeAxisAngle;
		short[] src = TerrainMeta.HeightMap.src;
		int res2 = TerrainMeta.HeightMap.res;
		byte[] src2 = TerrainMeta.BiomeMap.src;
		int res3 = TerrainMeta.BiomeMap.res;
		int[] src3 = TerrainMeta.TopologyMap.src;
		int res4 = TerrainMeta.TopologyMap.res;
		Native_GenerateSplat(dst, res, position, size, seed, lootAxisAngle, biomeAxisAngle, src, res2, src2, res3, src3, res4);
	}
}
