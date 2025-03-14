using UnityEngine;

public class GenerateCliffTopology : ProceduralComponent
{
	public bool KeepExisting = true;

	private const float slopeCutoff = 30f;

	private const float splatCutoff = 0.4f;

	private const int filter = 8389632;

	public static void Process(int x, int z)
	{
		TerrainTopologyMap topologyMap = TerrainMeta.TopologyMap;
		float normZ = topologyMap.Coordinate(z);
		float normX = topologyMap.Coordinate(x);
		if ((topologyMap.GetTopology(x, z) & 0x800400) == 0)
		{
			float slope = TerrainMeta.HeightMap.GetSlope(normX, normZ);
			float splat = TerrainMeta.SplatMap.GetSplat(normX, normZ, 8);
			if (slope > 30f || splat > 0.4f)
			{
				topologyMap.AddTopology(x, z, 2);
			}
			else
			{
				topologyMap.RemoveTopology(x, z, 2);
			}
		}
	}

	private static void Process(int x, int z, bool keepExisting)
	{
		TerrainTopologyMap topologyMap = TerrainMeta.TopologyMap;
		float normZ = topologyMap.Coordinate(z);
		float normX = topologyMap.Coordinate(x);
		int topology = topologyMap.GetTopology(x, z);
		if (!World.Procedural || (topology & 0x800400) == 0)
		{
			float slope = TerrainMeta.HeightMap.GetSlope(normX, normZ);
			float splat = TerrainMeta.SplatMap.GetSplat(normX, normZ, 8);
			if (slope > 30f || splat > 0.4f)
			{
				topologyMap.AddTopology(x, z, 2);
			}
			else if (!keepExisting)
			{
				topologyMap.RemoveTopology(x, z, 2);
			}
		}
	}

	public override void Process(uint seed)
	{
		int[] map = TerrainMeta.TopologyMap.dst;
		int res = TerrainMeta.TopologyMap.res;
		Parallel.For(0, res, delegate(int z)
		{
			for (int i = 0; i < res; i++)
			{
				Process(i, z, KeepExisting);
			}
		});
		ImageProcessing.Dilate2D(map, res, res, 4194306, 1, delegate(int x, int y)
		{
			if ((map[x * res + y] & 2) == 0)
			{
				map[x * res + y] |= 4194304;
			}
		});
	}
}
