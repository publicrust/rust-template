using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRailLayout : ProceduralComponent
{
	private class PathNode
	{
		public MonumentInfo monument;

		public TerrainPathConnect target;

		public PathFinder.Node node;
	}

	private class PathSegment
	{
		public PathFinder.Node start;

		public PathFinder.Node end;

		public TerrainPathConnect origin;

		public TerrainPathConnect target;
	}

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
			TerrainMeta.Path.Rails.Clear();
			TerrainMeta.Path.Rails.AddRange(World.GetPaths("Rail"));
			return;
		}
		List<PathList> list = new List<PathList>();
		int[,] array = TerrainPath.CreateRailCostmap(ref seed);
		PathFinder pathFinder = new PathFinder(array);
		int length = array.GetLength(0);
		new List<PathSegment>();
		List<PathFinder.Node> list2 = new List<PathFinder.Node>();
		List<PathFinder.Point> list3 = new List<PathFinder.Point>();
		List<PathFinder.Point> list4 = new List<PathFinder.Point>();
		List<Vector3> list5 = new List<Vector3>();
		List<Vector3> list6 = new List<Vector3>();
		List<Vector3> list7 = new List<Vector3>();
		List<Vector3> list8 = new List<Vector3>();
		foreach (PathList rail2 in TerrainMeta.Path.Rails)
		{
			if (rail2.ProcgenStartNode != null && rail2.ProcgenEndNode != null)
			{
				for (PathFinder.Node node = rail2.ProcgenStartNode; node != null; node = node.next)
				{
					list2.Add(node);
				}
			}
		}
		foreach (MonumentInfo monument in TerrainMeta.Path.Monuments)
		{
			pathFinder.PushPoint = monument.GetPathFinderPoint(length);
			pathFinder.PushRadius = monument.GetPathFinderRadius(length);
			pathFinder.PushDistance = 60;
			pathFinder.PushMultiplier = 1;
			TerrainPathConnect[] componentsInChildren = monument.GetComponentsInChildren<TerrainPathConnect>(includeInactive: true);
			foreach (TerrainPathConnect terrainPathConnect in componentsInChildren)
			{
				list5.Clear();
				list6.Clear();
				list7.Clear();
				list8.Clear();
				if (terrainPathConnect.Type != InfrastructureType.Rail)
				{
					continue;
				}
				Vector3 position = terrainPathConnect.transform.position;
				Vector3 vector = terrainPathConnect.transform.forward * 7.5f;
				PathFinder.Point pathFinderPoint = terrainPathConnect.GetPathFinderPoint(length, position);
				for (int k = 0; k < 8 || !pathFinder.IsWalkable(pathFinderPoint); k++)
				{
					list5.Add(position);
					position += vector;
					pathFinderPoint = terrainPathConnect.GetPathFinderPoint(length, position);
				}
				list3.Clear();
				list3.Add(pathFinderPoint);
				list4.Clear();
				foreach (PathFinder.Node item in list2)
				{
					if (!(pathFinder.Distance(item.point, pathFinder.PushPoint) < (float)(pathFinder.PushRadius + pathFinder.PushDistance / 2)))
					{
						list4.Add(item.point);
					}
				}
				PathFinder.Node node2 = pathFinder.FindPathDirected(list3, list4, 250000);
				if (node2 == null)
				{
					continue;
				}
				PathFinder.Node node3 = null;
				PathFinder.Node node4 = null;
				PathFinder.Node node5 = node2;
				while (node5 != null && node5.next != null)
				{
					if (node5 == node2.next)
					{
						node3 = node5;
					}
					if (node5.next.next == null)
					{
						node4 = node5;
					}
					node5 = node5.next;
				}
				if (node3 == null || node4 == null)
				{
					continue;
				}
				node2 = node3;
				node4.next = null;
				for (PathFinder.Node node6 = node3; node6 != null; node6 = node6.next)
				{
					float normX = ((float)node6.point.x + 0.5f) / (float)length;
					float normZ = ((float)node6.point.y + 0.5f) / (float)length;
					float x = TerrainMeta.DenormalizeX(normX);
					float z = TerrainMeta.DenormalizeZ(normZ);
					float y = Mathf.Max(TerrainMeta.HeightMap.GetHeight(normX, normZ), 1f);
					list6.Add(new Vector3(x, y, z));
				}
				if (list6.Count == 0)
				{
					continue;
				}
				Vector3 vector2 = list5[0];
				Vector3 vector3 = list6[list6.Count - 1];
				Vector3 normalized = (vector3 - vector2).normalized;
				PathList pathList = null;
				float num = float.MaxValue;
				int num2 = -1;
				foreach (PathList rail3 in TerrainMeta.Path.Rails)
				{
					Vector3[] points = rail3.Path.Points;
					for (int l = 0; l < points.Length; l++)
					{
						float num3 = Vector3.Distance(vector3, points[l]);
						if (num3 < num)
						{
							num = num3;
							pathList = rail3;
							num2 = l;
						}
					}
				}
				Vector3[] points2 = pathList.Path.Points;
				Vector3 vector4 = pathList.Path.Tangents[num2];
				int num4 = ((Vector3.Angle(vector4, normalized) < Vector3.Angle(-vector4, normalized)) ? 1 : (-1));
				Vector3 to = Vector3.Normalize(list6[list6.Count - 1] - list6[Mathf.Max(0, list6.Count - 1 - 16)]);
				Vector3 vector5 = Vector3.Normalize(points2[(num2 + num4 * 8 * 2 + points2.Length) % points2.Length] - points2[num2]);
				float num5 = 0f - Vector3.SignedAngle(vector5, to, Vector3.up);
				Vector3 vector6 = rot90 * vector5;
				if (num5 < 0f)
				{
					vector6 = -vector6;
				}
				for (int m = 0; m < 8; m++)
				{
					float t = Mathf.InverseLerp(7f, 0f, m);
					float num6 = Mathf.SmoothStep(0f, 2f, t) * 4f;
					list7.Add(points2[(num2 + num4 * m + points2.Length) % points2.Length] + vector6 * num6);
				}
				list8.AddRange(list5);
				list8.AddRange(list6);
				list8.AddRange(list7);
				if (list8.Count >= 2)
				{
					int number = TerrainMeta.Path.Rails.Count + list.Count;
					PathList pathList2 = CreateSegment(number, list8.ToArray());
					pathList2.Start = true;
					pathList2.End = false;
					pathList2.ProcgenStartNode = node3;
					pathList2.ProcgenEndNode = node4;
					list.Add(pathList2);
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
