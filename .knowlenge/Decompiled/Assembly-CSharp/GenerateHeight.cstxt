using System.Runtime.InteropServices;
using UnityEngine;

public class GenerateHeight : ProceduralComponent
{
	[DllImport("RustNative", EntryPoint = "generate_height")]
	public static extern void Native_GenerateHeight(short[] map, int res, Vector3 pos, Vector3 size, uint seed, float lootAngle, float biomeAngle);

	public override void Process(uint seed)
	{
		short[] dst = TerrainMeta.HeightMap.dst;
		int res = TerrainMeta.HeightMap.res;
		Vector3 position = TerrainMeta.Position;
		Vector3 size = TerrainMeta.Size;
		float lootAxisAngle = TerrainMeta.LootAxisAngle;
		float biomeAxisAngle = TerrainMeta.BiomeAxisAngle;
		Native_GenerateHeight(dst, res, position, size, seed, lootAxisAngle, biomeAxisAngle);
	}
}
