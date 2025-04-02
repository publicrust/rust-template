using UnityEngine;

public class GenerateCliffSplat : ProceduralComponent
{
	private const int filter = 8389632;

	public static void Process(int x, int z)
	{
		TerrainSplatMap splatMap = TerrainMeta.SplatMap;
		float normZ = splatMap.Coordinate(z);
		float normX = splatMap.Coordinate(x);
		if ((TerrainMeta.TopologyMap.GetTopology(normX, normZ) & 0x800400) == 0)
		{
			float slope = TerrainMeta.HeightMap.GetSlope(normX, normZ);
			if (slope > 30f)
			{
				splatMap.SetSplat(x, z, 8, Mathf.InverseLerp(30f, 50f, slope));
			}
		}
	}

	public override void Process(uint seed)
	{
		TerrainSplatMap splatMap = TerrainMeta.SplatMap;
		int splatres = splatMap.res;
		Parallel.For(0, splatres, delegate(int z)
		{
			for (int i = 0; i < splatres; i++)
			{
				Process(i, z);
			}
		});
	}
}
