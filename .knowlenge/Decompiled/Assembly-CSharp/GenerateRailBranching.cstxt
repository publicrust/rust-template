using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateRailBranching : ProceduralComponent
{
	public const float Width = 4f;

	public const float InnerPadding = 1f;

	public const float OuterPadding = 1f;

	public const float InnerFade = 1f;

	public const float OuterFade = 32f;

	public const float RandomScale = 1f;

	public const float MeshOffset = 0f;

	public const float TerrainOffset = -0.125f;

	private static Quaternion rot90 = Quaternion.Euler(0f, 90f, 0f);

	private const int MaxDepth = 250000;

	private PathList CreateSegment(int number, Vector3[] points)
	{
		return new PathList("Rail " + number, points)
		{
			Spline = true,
			Width = 4f,
			InnerPadding = 1f,
			OuterPadding = 1f,
			InnerFade = 1f,
			OuterFade = 32f,
			RandomScale = 1f,
			MeshOffset = 0f,
			TerrainOffset = -0.125f,
			Topology = 524288,
			Splat = 128,
			Hierarchy = 1
		};
	}

	public override void Process(uint seed)
	{
		if (World.Networked)
		{
			return;
		}
		int min = Mathf.RoundToInt(40f);
		int max = Mathf.RoundToInt(53.333332f);
		int min2 = Mathf.RoundToInt(40f);
		int max2 = Mathf.RoundToInt(120f);
		float num = 120f * 120f;
		List<PathList> list = new List<PathList>();
		int[,] array = TerrainPath.CreateRailCostmap(ref seed);
		PathFinder pathFinder = new PathFinder(array);
		int length = array.GetLength(0);
		foreach (MonumentInfo monument in TerrainMeta.Path.Monuments)
		{
			TerrainPathConnect[] array2 = (from target in monument.GetComponentsInChildren<TerrainPathConnect>(includeInactive: true)
				where target.Type == InfrastructureType.Rail
				select target).ToArray();
			foreach (TerrainPathConnect terrainPathConnect in array2)
			{
				pathFinder.PushPointsAdditional.Add(PathFinder.GetPoint(terrainPathConnect.transform.position, length));
			}
		}
		if (pathFinder.PushPointsAdditional.Count > 0)
		{
			pathFinder.PushDistance = 10;
			pathFinder.PushMultiplier = int.MaxValue;
		}
		List<Vector3> list2 = new List<Vector3>();
		List<Vector3> list3 = new List<Vector3>();
		List<Vector3> list4 = new List<Vector3>();
		HashSet<Vector3> hashSet = new HashSet<Vector3>();
		foreach (PathList rail2 in TerrainMeta.Path.Rails)
		{
			foreach (PathList rail3 in TerrainMeta.Path.Rails)
			{
				if (rail2 == rail3)
				{
					continue;
				}
				Vector3[] points = rail2.Path.Points;
				foreach (Vector3 vector in points)
				{
					Vector3[] points2 = rail3.Path.Points;
					foreach (Vector3 vector2 in points2)
					{
						if ((vector - vector2).sqrMagnitude < num)
						{
							hashSet.Add(vector);
							break;
						}
					}
				}
			}
		}
		foreach (PathList rail4 in TerrainMeta.Path.Rails)
		{
			PathInterpolator path = rail4.Path;
			Vector3[] points3 = path.Points;
			Vector3[] tangents = path.Tangents;
			int num2 = path.MinIndex + 1 + 8;
			int num3 = path.MaxIndex - 1 - 8;
			for (int l = num2; l <= num3; l++)
			{
				list2.Clear();
				list3.Clear();
				list4.Clear();
				int num4 = SeedRandom.Range(ref seed, min2, max2);
				int num5 = SeedRandom.Range(ref seed, min, max);
				int num6 = l;
				int num7 = l + num4;
				if (num7 >= num3)
				{
					continue;
				}
				Vector3 from = tangents[num6];
				Vector3 to = tangents[num7];
				if (Vector3.Angle(from, to) > 30f)
				{
					continue;
				}
				Vector3 vector3 = points3[num6];
				Vector3 vector4 = points3[num7];
				if (hashSet.Contains(vector3) || hashSet.Contains(vector4))
				{
					continue;
				}
				PathFinder.Point point = PathFinder.GetPoint(vector3, length);
				PathFinder.Point point2 = PathFinder.GetPoint(vector4, length);
				l += num5;
				PathFinder.Node node = pathFinder.FindPath(point, point2, 250000);
				if (node == null)
				{
					continue;
				}
				PathFinder.Node node2 = null;
				PathFinder.Node node3 = null;
				PathFinder.Node node4 = node;
				while (node4 != null && node4.next != null)
				{
					if (node4 == node.next)
					{
						node2 = node4;
					}
					if (node4.next.next == null)
					{
						node3 = node4;
					}
					node4 = node4.next;
				}
				if (node2 == null || node3 == null)
				{
					continue;
				}
				node = node2;
				node3.next = null;
				for (int m = 0; m < 8; m++)
				{
					int num8 = num6 + (m + 1 - 8);
					int num9 = num7 + m;
					list2.Add(points3[num8]);
					list3.Add(points3[num9]);
				}
				list4.AddRange(list2);
				for (PathFinder.Node node5 = node2; node5 != null; node5 = node5.next)
				{
					float normX = ((float)node5.point.x + 0.5f) / (float)length;
					float normZ = ((float)node5.point.y + 0.5f) / (float)length;
					float x = TerrainMeta.DenormalizeX(normX);
					float z = TerrainMeta.DenormalizeZ(normZ);
					float y = Mathf.Max(TerrainMeta.HeightMap.GetHeight(normX, normZ), 1f);
					list4.Add(new Vector3(x, y, z));
				}
				list4.AddRange(list3);
				int num10 = 8;
				int num11 = list4.Count - 1 - 8;
				Vector3 to2 = Vector3.Normalize(list4[num10 + 16] - list4[num10]);
				Vector3 to3 = Vector3.Normalize(list4[num11] - list4[num11 - 16]);
				Vector3 vector5 = Vector3.Normalize(points3[num6 + 16] - points3[num6]);
				Vector3 vector6 = Vector3.Normalize(points3[num7] - points3[(num7 - 16 + points3.Length) % points3.Length]);
				float num12 = Vector3.SignedAngle(vector5, to2, Vector3.up);
				float num13 = 0f - Vector3.SignedAngle(vector6, to3, Vector3.up);
				if (Mathf.Sign(num12) != Mathf.Sign(num13) || Mathf.Abs(num12) > 60f || Mathf.Abs(num13) > 60f)
				{
					continue;
				}
				Vector3 vector7 = rot90 * vector5;
				Vector3 vector8 = rot90 * vector6;
				if (num12 < 0f)
				{
					vector7 = -vector7;
				}
				if (num13 < 0f)
				{
					vector8 = -vector8;
				}
				for (int n = 0; n < 16; n++)
				{
					int index = n;
					int index2 = list4.Count - n - 1;
					float t = Mathf.InverseLerp(0f, 8f, n);
					float num14 = Mathf.SmoothStep(0f, 2f, t) * 4f;
					list4[index] += vector7 * num14;
					list4[index2] += vector8 * num14;
				}
				bool flag = false;
				bool flag2 = false;
				foreach (Vector3 item in list4)
				{
					bool blocked = TerrainMeta.PlacementMap.GetBlocked(item);
					if (!flag2 && !flag && !blocked)
					{
						flag = true;
					}
					if (flag && !flag2 && blocked)
					{
						flag2 = true;
					}
					if (flag && flag2 && !blocked)
					{
						list4.Clear();
						break;
					}
				}
				if (list4.Count != 0)
				{
					if (list4.Count >= 2)
					{
						int number = TerrainMeta.Path.Rails.Count + list.Count;
						PathList pathList = CreateSegment(number, list4.ToArray());
						pathList.Start = false;
						pathList.End = false;
						pathList.ProcgenStartNode = node2;
						pathList.ProcgenEndNode = node3;
						list.Add(pathList);
					}
					l += num4;
				}
			}
		}
		foreach (PathList rail in list)
		{
			Func<int, float> filter = delegate(int i)
			{
				float a = Mathf.InverseLerp(0f, 8f, i);
				float b = Mathf.InverseLerp(rail.Path.DefaultMaxIndex, rail.Path.DefaultMaxIndex - 8, i);
				return Mathf.SmoothStep(0f, 1f, Mathf.Min(a, b));
			};
			rail.Path.Smoothen(32, new Vector3(1f, 0f, 1f), filter);
			rail.Path.Smoothen(64, new Vector3(0f, 1f, 0f), filter);
			rail.Path.Resample(7.5f);
			rail.Path.RecalculateTangents();
			rail.AdjustPlacementMap(20f);
		}
		TerrainMeta.Path.Rails.AddRange(list);
	}
}
