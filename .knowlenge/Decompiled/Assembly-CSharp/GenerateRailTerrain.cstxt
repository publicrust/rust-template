using System;
using System.Linq;
using UnityEngine;

public class GenerateRailTerrain : ProceduralComponent
{
	public const int SmoothenLoops = 8;

	public const int SmoothenIterations = 8;

	public const int SmoothenY = 64;

	public const int SmoothenXZ = 32;

	public const int TransitionSteps = 8;

	public override void Process(uint seed)
	{
		TerrainHeightMap heightMap = TerrainMeta.HeightMap;
		Func<int, float> func = (int i) => Mathf.SmoothStep(0f, 1f, Mathf.InverseLerp(0f, 8f, i));
		for (int j = 0; j < 8; j++)
		{
			foreach (PathList item in TerrainMeta.Path.Rails.AsEnumerable().Reverse())
			{
				PathInterpolator path = item.Path;
				Vector3[] points = path.Points;
				for (int k = 0; k < points.Length; k++)
				{
					Vector3 vector = points[k];
					float t = (item.Start ? func(k) : 1f);
					vector.y = Mathf.SmoothStep(vector.y, heightMap.GetHeight(vector), t);
					points[k] = vector;
				}
				path.Smoothen(8, Vector3.up, item.Start ? func : null);
				path.RecalculateTangents();
				heightMap.Push();
				float intensity = 1f;
				float fade = Mathf.InverseLerp(8f, 0f, j);
				item.AdjustTerrainHeight(intensity, fade);
				heightMap.Pop();
			}
		}
		foreach (PathList rail in TerrainMeta.Path.Rails)
		{
			PathInterpolator path2 = rail.Path;
			Vector3[] points2 = path2.Points;
			for (int l = 0; l < points2.Length; l++)
			{
				Vector3 vector2 = points2[l];
				float t2 = (rail.Start ? func(l) : 1f);
				vector2.y = Mathf.SmoothStep(vector2.y, heightMap.GetHeight(vector2), t2);
				points2[l] = vector2;
			}
			path2.RecalculateTangents();
		}
	}
}
