using System.Linq;
using UnityEngine;

public class GenerateRiverTerrain : ProceduralComponent
{
	public const int SmoothenLoops = 1;

	public const int SmoothenIterations = 8;

	public const int SmoothenY = 8;

	public const int SmoothenXZ = 4;

	public override void Process(uint seed)
	{
		TerrainHeightMap heightMap = TerrainMeta.HeightMap;
		for (int i = 0; i < 1; i++)
		{
			foreach (PathList item in TerrainMeta.Path.Rivers.AsEnumerable().Reverse())
			{
				if (!World.Networked)
				{
					PathInterpolator path = item.Path;
					path.Smoothen(8, Vector3.up);
					path.RecalculateTangents();
				}
			}
			foreach (PathList item2 in TerrainMeta.Path.Rivers.AsEnumerable().Reverse())
			{
				heightMap.Push();
				float intensity = 1f;
				float fade = Mathf.InverseLerp(1f, 0f, i);
				item2.AdjustTerrainHeight(intensity, fade, scaleWidthWithLength: true);
				heightMap.Pop();
			}
		}
	}
}
