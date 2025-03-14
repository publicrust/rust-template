using System.Collections.Generic;
using UnityEngine;

public class GenerateRoadRing : ProceduralComponent
{
	private class RingNode
	{
		public int attempts;

		public PathFinder.Point position;

		public PathFinder.Point direction;

		public RingNode next;

		public RingNode prev;

		public PathFinder.Node path;

		public RingNode(int pos_x, int pos_y, int dir_x, int dir_y, int stepcount)
		{
			position = new PathFinder.Point(pos_x, pos_y);
			direction = new PathFinder.Point(dir_x, dir_y);
			attempts = stepcount;
		}
	}

	public const float Width = 12f;

	public const float InnerPadding = 1f;

	public const float OuterPadding = 1f;

	public const float InnerFade = 1f;

	public const float OuterFade = 8f;

	public const float RandomScale = 0.75f;

	public const float MeshOffset = 0f;

	public const float TerrainOffset = -0.125f;

	private const int MaxDepth = 250000;

	public int MinWorldSize;

	public override void Process(uint seed)
	{
		if (World.Networked || World.Size < MinWorldSize || !World.Config.MainRoads)
		{
			return;
		}
		int[,] array = TerrainPath.CreateRoadCostmap(ref seed);
		PathFinder pathFinder = new PathFinder(array);
		int length = array.GetLength(0);
		int num = length / 4;
		int num2 = 1;
		int stepcount = num / num2;
		int num3 = length / 2;
		int pos_x = num;
		int pos_x2 = length - num;
		int pos_y = num;
		int pos_y2 = length - num;
		int num4 = 0;
		int dir_x = -num2;
		int dir_x2 = num2;
		int dir_y = -num2;
		int dir_y2 = num2;
		List<RingNode> list = ((World.Size >= 5000) ? new List<RingNode>
		{
			new RingNode(num3, pos_y2, num4, dir_y, stepcount),
			new RingNode(pos_x2, pos_y2, dir_x, dir_y, stepcount),
			new RingNode(pos_x2, num3, dir_x, num4, stepcount),
			new RingNode(pos_x2, pos_y, dir_x, dir_y2, stepcount),
			new RingNode(num3, pos_y, num4, dir_y2, stepcount),
			new RingNode(pos_x, pos_y, dir_x2, dir_y2, stepcount),
			new RingNode(pos_x, num3, dir_x2, num4, stepcount),
			new RingNode(pos_x, pos_y2, dir_x2, dir_y, stepcount)
		} : new List<RingNode>
		{
			new RingNode(pos_x2, pos_y2, dir_x, dir_y, stepcount),
			new RingNode(pos_x2, pos_y, dir_x, dir_y2, stepcount),
			new RingNode(pos_x, pos_y, dir_x2, dir_y2, stepcount),
			new RingNode(pos_x, pos_y2, dir_x2, dir_y, stepcount)
		});
		for (int i = 0; i < list.Count; i++)
		{
			RingNode ringNode = list[i];
			RingNode next = list[(i + 1) % list.Count];
			RingNode prev = list[(i - 1 + list.Count) % list.Count];
			ringNode.next = next;
			ringNode.prev = prev;
			while (!pathFinder.IsWalkable(ringNode.position))
			{
				if (ringNode.attempts <= 0)
				{
					return;
				}
				ringNode.position += ringNode.direction;
				ringNode.attempts--;
			}
		}
		foreach (RingNode item in list)
		{
			item.path = pathFinder.FindPath(item.position, item.next.position, 250000);
		}
		bool flag = false;
		while (!flag)
		{
			flag = true;
			PathFinder.Point point = new PathFinder.Point(0, 0);
			foreach (RingNode item2 in list)
			{
				point += item2.position;
			}
			point /= list.Count;
			float num5 = float.MinValue;
			RingNode ringNode2 = null;
			foreach (RingNode item3 in list)
			{
				if (item3.path == null)
				{
					float num6 = new Vector2(item3.position.x - point.x, item3.position.y - point.y).magnitude;
					if (item3.prev.path == null)
					{
						num6 *= 1.5f;
					}
					if (num6 > num5)
					{
						num5 = num6;
						ringNode2 = item3;
					}
				}
			}
			if (ringNode2 == null)
			{
				continue;
			}
			do
			{
				if (ringNode2.attempts <= 0)
				{
					return;
				}
				ringNode2.position += ringNode2.direction;
				ringNode2.attempts--;
			}
			while (!pathFinder.IsWalkable(ringNode2.position));
			ringNode2.path = pathFinder.FindPath(ringNode2.position, ringNode2.next.position, 250000);
			ringNode2.prev.path = pathFinder.FindPath(ringNode2.prev.position, ringNode2.position, 250000);
			flag = false;
		}
		if (!flag)
		{
			return;
		}
		for (int j = 0; j < list.Count; j++)
		{
			RingNode ringNode3 = list[j];
			RingNode ringNode4 = list[(j + 1) % list.Count];
			PathFinder.Node node = null;
			PathFinder.Node node2 = null;
			for (PathFinder.Node node3 = ringNode3.path; node3 != null; node3 = node3.next)
			{
				for (PathFinder.Node node4 = ringNode4.path; node4 != null; node4 = node4.next)
				{
					int num7 = Mathf.Abs(node3.point.x - node4.point.x);
					int num8 = Mathf.Abs(node3.point.y - node4.point.y);
					if (num7 <= 15 && num8 <= 15)
					{
						if (node == null || node3.cost > node.cost)
						{
							node = node3;
						}
						if (node2 == null || node4.cost < node2.cost)
						{
							node2 = node4;
						}
					}
				}
			}
			if (node != null && node2 != null)
			{
				PathFinder.Node node5 = pathFinder.FindPath(node.point, node2.point, 250000);
				if (node5 != null && node5.next != null)
				{
					node.next = node5.next;
					ringNode4.path = node2;
				}
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			RingNode ringNode5 = list[k];
			RingNode ringNode6 = list[(k + 1) % list.Count];
			PathFinder.Node node6 = null;
			PathFinder.Node node7 = null;
			for (PathFinder.Node node8 = ringNode5.path; node8 != null; node8 = node8.next)
			{
				for (PathFinder.Node node9 = ringNode6.path; node9 != null; node9 = node9.next)
				{
					int num9 = Mathf.Abs(node8.point.x - node9.point.x);
					int num10 = Mathf.Abs(node8.point.y - node9.point.y);
					if (num9 <= 1 && num10 <= 1)
					{
						if (node6 == null || node8.cost > node6.cost)
						{
							node6 = node8;
						}
						if (node7 == null || node9.cost < node7.cost)
						{
							node7 = node9;
						}
					}
				}
			}
			if (node6 != null && node7 != null)
			{
				node6.next = null;
				ringNode6.path = node7;
			}
		}
		PathFinder.Node node10 = null;
		PathFinder.Node node11 = null;
		foreach (RingNode item4 in list)
		{
			if (node10 == null)
			{
				node10 = item4.path;
				node11 = item4.path;
			}
			else
			{
				node11.next = item4.path;
			}
			while (node11.next != null)
			{
				node11 = node11.next;
			}
		}
		node11.next = new PathFinder.Node(node10.point, node10.cost, node10.heuristic);
		List<Vector3> list2 = new List<Vector3>();
		for (PathFinder.Node node12 = node10; node12 != null; node12 = node12.next)
		{
			float normX = ((float)node12.point.x + 0.5f) / (float)length;
			float normZ = ((float)node12.point.y + 0.5f) / (float)length;
			float x = TerrainMeta.DenormalizeX(normX);
			float z = TerrainMeta.DenormalizeZ(normZ);
			float y = Mathf.Max(TerrainMeta.HeightMap.GetHeight(normX, normZ), 1f);
			list2.Add(new Vector3(x, y, z));
		}
		if (list2.Count >= 2)
		{
			PathList pathList = new PathList("Road " + TerrainMeta.Path.Roads.Count, list2.ToArray());
			pathList.Spline = true;
			pathList.Width = 12f;
			pathList.InnerPadding = 1f;
			pathList.OuterPadding = 1f;
			pathList.InnerFade = 1f;
			pathList.OuterFade = 8f;
			pathList.RandomScale = 0.75f;
			pathList.MeshOffset = 0f;
			pathList.TerrainOffset = -0.125f;
			pathList.Topology = 2048;
			pathList.Splat = 128;
			pathList.Start = false;
			pathList.End = false;
			pathList.ProcgenStartNode = node10;
			pathList.ProcgenEndNode = node11;
			pathList.Path.Smoothen(4, new Vector3(1f, 0f, 1f));
			pathList.Path.Smoothen(16, new Vector3(0f, 1f, 0f));
			pathList.Path.Resample(7.5f);
			pathList.Path.RecalculateTangents();
			pathList.AdjustPlacementMap(24f);
			TerrainMeta.Path.AddRoad(pathList);
		}
	}
}
