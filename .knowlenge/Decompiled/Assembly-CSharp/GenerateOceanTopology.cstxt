using UnityEngine;

public class GenerateOceanTopology : ProceduralComponent
{
	public override void Process(uint seed)
	{
		TerrainTopologyMap topologymap = TerrainMeta.TopologyMap;
		TerrainHeightMap heightmap = TerrainMeta.HeightMap;
		int[] dst = TerrainMeta.TopologyMap.dst;
		int res = TerrainMeta.TopologyMap.res;
		Parallel.For(0, res, delegate(int z)
		{
			for (int i = 0; i < res; i++)
			{
				float normX = topologymap.Coordinate(i);
				float normZ = topologymap.Coordinate(z);
				int num = dst[z * res + i];
				if (heightmap.GetHeight01(normX, normZ) <= 0.5f)
				{
					if ((num & 0x810000) == 0)
					{
						dst[z * res + i] = num | 0x80;
					}
				}
				else
				{
					dst[z * res + i] = num & -129;
				}
			}
		});
	}
}
