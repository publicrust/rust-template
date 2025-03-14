using System.Collections.Generic;
using System.Linq;

public class GenerateRiverTopology : ProceduralComponent
{
	public override void Process(uint seed)
	{
		List<PathList> rivers = TerrainMeta.Path.Rivers;
		TerrainHeightMap heightMap = TerrainMeta.HeightMap;
		heightMap.Push();
		foreach (PathList item in rivers)
		{
			item.AdjustTerrainHeight();
		}
		heightMap.Pop();
		foreach (PathList item2 in rivers.AsEnumerable().Reverse())
		{
			item2.AdjustTerrainTexture();
			item2.AdjustTerrainTopology();
		}
		MarkRiverside();
	}

	public void MarkRiverside()
	{
		TerrainHeightMap heightmap = TerrainMeta.HeightMap;
		TerrainTopologyMap topomap = TerrainMeta.TopologyMap;
		int[] map = topomap.dst;
		int res = topomap.res;
		ImageProcessing.Dilate2D(map, res, res, 49152, 6, delegate(int x, int y)
		{
			if ((map[x * res + y] & 0x31) != 0)
			{
				map[x * res + y] |= 32768;
			}
			float normX = topomap.Coordinate(x);
			float normZ = topomap.Coordinate(y);
			if (heightmap.GetSlope(normX, normZ) > 40f)
			{
				map[x * res + y] |= 2;
			}
		});
	}
}
