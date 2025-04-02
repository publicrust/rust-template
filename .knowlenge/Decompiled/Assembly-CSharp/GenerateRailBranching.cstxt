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
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		if (World.Networked)
		{
			return;
		}
		int num = Mathf.RoundToInt(40f);
		int num2 = Mathf.RoundToInt(53.333332f);
		int num3 = Mathf.RoundToInt(40f);
		int num4 = Mathf.RoundToInt(120f);
		float num5 = 120f * 120f;
		List<PathList> list = new List<PathList>();
		int[,] array = TerrainPath.CreateRailCostmap(ref seed);
		PathFinder pathFinder = new PathFinder(array);
		int length = array.GetLength(0);
		foreach (MonumentInfo monument in TerrainMeta.Path.Monuments)
		{
			TerrainPathConnect[] array2 = (from target in ((Component)monument).GetComponentsInChildren<TerrainPathConnect>(true)
				where target.Type == InfrastructureType.Rail
				select target).ToArray();
			foreach (TerrainPathConnect terrainPathConnect in array2)
			{
				pathFinder.PushPointsAdditional.Add(PathFinder.GetPoint(((Component)terrainPathConnect).transform.position, length));
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
				foreach (Vector3 val in points)
				{
					Vector3[] points2 = rail3.Path.Points;
					foreach (Vector3 val2 in points2)
					{
						Vector3 val3 = val - val2;
						if (((Vector3)(ref val3)).sqrMagnitude < num5)
						{
							hashSet.Add(val);
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
			int num6 = path.MinIndex + 1 + 8;
			int num7 = path.MaxIndex - 1 - 8;
			for (int l = num6; l <= num7; l++)
			{
				list2.Clear();
				list3.Clear();
				list4.Clear();
				int num8 = SeedRandom.Range(ref seed, num3, num4);
				int num9 = SeedRandom.Range(ref seed, num, num2);
				int num10 = l;
				int num11 = l + num8;
				if (num11 >= num7)
				{
					continue;
				}
				Vector3 val4 = tangents[num10];
				Vector3 val5 = tangents[num11];
				if (Vector3.Angle(val4, val5) > 30f)
				{
					continue;
				}
				Vector3 val6 = points3[num10];
				Vector3 val7 = points3[num11];
				if (hashSet.Contains(val6) || hashSet.Contains(val7))
				{
					continue;
				}
				PathFinder.Point point = PathFinder.GetPoint(val6, length);
				PathFinder.Point point2 = PathFinder.GetPoint(val7, length);
				l += num9;
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
					int num12 = num10 + (m + 1 - 8);
					int num13 = num11 + m;
					list2.Add(points3[num12]);
					list3.Add(points3[num13]);
				}
				list4.AddRange(list2);
				for (PathFinder.Node node5 = node2; node5 != null; node5 = node5.next)
				{
					float normX = ((float)node5.point.x + 0.5f) / (float)length;
					float normZ = ((float)node5.point.y + 0.5f) / (float)length;
					float num14 = TerrainMeta.DenormalizeX(normX);
					float num15 = TerrainMeta.DenormalizeZ(normZ);
					float num16 = Mathf.Max(TerrainMeta.HeightMap.GetHeight(normX, normZ), 1f);
					list4.Add(new Vector3(num14, num16, num15));
				}
				list4.AddRange(list3);
				int num17 = 8;
				int num18 = list4.Count - 1 - 8;
				Vector3 val8 = Vector3.Normalize(list4[num17 + 16] - list4[num17]);
				Vector3 val9 = Vector3.Normalize(list4[num18] - list4[num18 - 16]);
				Vector3 val10 = Vector3.Normalize(points3[num10 + 16] - points3[num10]);
				Vector3 val11 = Vector3.Normalize(points3[num11] - points3[(num11 - 16 + points3.Length) % points3.Length]);
				float num19 = Vector3.SignedAngle(val10, val8, Vector3.up);
				float num20 = 0f - Vector3.SignedAngle(val11, val9, Vector3.up);
				if (Mathf.Sign(num19) != Mathf.Sign(num20) || Mathf.Abs(num19) > 60f || Mathf.Abs(num20) > 60f)
				{
					continue;
				}
				Vector3 val12 = rot90 * val10;
				Vector3 val13 = rot90 * val11;
				if (num19 < 0f)
				{
					val12 = -val12;
				}
				if (num20 < 0f)
				{
					val13 = -val13;
				}
				for (int n = 0; n < 16; n++)
				{
					int num21 = n;
					int num22 = list4.Count - n - 1;
					float num23 = Mathf.InverseLerp(0f, 8f, (float)n);
					float num24 = Mathf.SmoothStep(0f, 2f, num23) * 4f;
					List<Vector3> list5 = list4;
					int j = num21;
					list5[j] += val12 * num24;
					list5 = list4;
					j = num22;
					list5[j] += val13 * num24;
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
					l += num8;
				}
			}
		}
		foreach (PathList rail in list)
		{
			Func<int, float> filter = delegate(int i)
			{
				float num25 = Mathf.InverseLerp(0f, 8f, (float)i);
				float num26 = Mathf.InverseLerp((float)rail.Path.DefaultMaxIndex, (float)(rail.Path.DefaultMaxIndex - 8), (float)i);
				return Mathf.SmoothStep(0f, 1f, Mathf.Min(num25, num26));
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
