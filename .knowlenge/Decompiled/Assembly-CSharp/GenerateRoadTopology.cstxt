using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateRoadTopology : ProceduralComponent
{
	private const int Smoothen = 8;

	public override void Process(uint seed)
	{
		List<PathList> roads = TerrainMeta.Path.Roads;
		TerrainHeightMap heightMap = TerrainMeta.HeightMap;
		foreach (PathList item in roads)
		{
			PathInterpolator path = item.Path;
			Vector3[] points = path.Points;
			for (int i = 0; i < points.Length; i++)
			{
				Vector3 vector = points[i];
				vector.y = heightMap.GetHeight(vector);
				points[i] = vector;
			}
			item.TrimTopology(2048);
			path.Smoothen(8, Vector3.up);
			path.RecalculateTangents();
			item.ResetTrims();
			heightMap.Push();
			item.AdjustTerrainHeight();
			heightMap.Pop();
		}
		foreach (PathList item2 in roads.AsEnumerable().Reverse())
		{
			item2.AdjustTerrainTexture();
			item2.AdjustTerrainTopology();
		}
		MarkRoadside();
		TerrainMeta.PlacementMap.Reset();
	}

	private void MarkRoadside()
	{
		TerrainHeightMap heightmap = TerrainMeta.HeightMap;
		TerrainTopologyMap topomap = TerrainMeta.TopologyMap;
		int[] map = topomap.dst;
		int res = topomap.res;
		ImageProcessing.Dilate2D(map, res, res, 6144, 6, delegate(int x, int y)
		{
			if ((map[x * res + y] & 0x31) != 0)
			{
				map[x * res + y] |= 4096;
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
