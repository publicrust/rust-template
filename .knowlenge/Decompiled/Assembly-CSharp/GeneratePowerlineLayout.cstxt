using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratePowerlineLayout : ProceduralComponent
{
	private class PathNode
	{
		public MonumentInfo monument;

		public PathFinder.Node node;
	}

	private class PathSegment
	{
		public PathFinder.Node start;

		public PathFinder.Node end;
	}

	private const int MaxDepth = 100000;

	public override void Process(uint seed)
	{
		if (World.Networked)
		{
			TerrainMeta.Path.Powerlines.Clear();
			TerrainMeta.Path.Powerlines.AddRange(World.GetPaths("Powerline"));
		}
		else
		{
			if (!World.Config.Powerlines)
			{
				return;
			}
			List<PathList> list = new List<PathList>();
			List<MonumentInfo> monuments = TerrainMeta.Path.Monuments;
			int[,] array = TerrainPath.CreatePowerlineCostmap(ref seed);
			PathFinder pathFinder = new PathFinder(array);
			int length = array.GetLength(0);
			List<PathSegment> list2 = new List<PathSegment>();
			List<PathNode> list3 = new List<PathNode>();
			List<PathNode> list4 = new List<PathNode>();
			List<PathFinder.Point> list5 = new List<PathFinder.Point>();
			List<PathFinder.Point> list6 = new List<PathFinder.Point>();
			List<PathFinder.Point> list7 = new List<PathFinder.Point>();
			foreach (PathList road in TerrainMeta.Path.Roads)
			{
				if (road.ProcgenStartNode == null || road.ProcgenEndNode == null || road.Hierarchy != 0)
				{
					continue;
				}
				int num = 1;
				for (PathFinder.Node node = road.ProcgenStartNode; node != null; node = node.next)
				{
					if (num % 8 == 0)
					{
						list5.Add(node.point);
					}
					num++;
				}
			}
			foreach (MonumentInfo item in monuments)
			{
				TerrainPathConnect[] componentsInChildren = item.GetComponentsInChildren<TerrainPathConnect>(includeInactive: true);
				foreach (TerrainPathConnect terrainPathConnect in componentsInChildren)
				{
					if (terrainPathConnect.Type == InfrastructureType.Power)
					{
						PathFinder.Point pathFinderPoint = terrainPathConnect.GetPathFinderPoint(length);
						PathFinder.Node node2 = pathFinder.FindClosestWalkable(pathFinderPoint, 100000);
						if (node2 != null)
						{
							PathNode pathNode = new PathNode();
							pathNode.monument = item;
							pathNode.node = node2;
							list4.Add(pathNode);
						}
					}
				}
			}
			while (list4.Count != 0)
			{
				list7.Clear();
				list7.AddRange(list4.Select((PathNode x) => x.node.point));
				list6.Clear();
				list6.AddRange(list3.Select((PathNode x) => x.node.point));
				list6.AddRange(list5);
				PathFinder.Node node3 = pathFinder.FindPathUndirected(list6, list7, 100000);
				if (node3 == null)
				{
					PathNode copy = list4[0];
					list3.AddRange(list4.Where((PathNode x) => x.monument == copy.monument));
					list4.RemoveAll((PathNode x) => x.monument == copy.monument);
					continue;
				}
				PathSegment segment = new PathSegment();
				for (PathFinder.Node node4 = node3; node4 != null; node4 = node4.next)
				{
					if (node4 == node3)
					{
						segment.start = node4;
					}
					if (node4.next == null)
					{
						segment.end = node4;
					}
				}
				list2.Add(segment);
				PathNode copy2 = list4.Find((PathNode x) => x.node.point == segment.start.point || x.node.point == segment.end.point);
				list3.AddRange(list4.Where((PathNode x) => x.monument == copy2.monument));
				list4.RemoveAll((PathNode x) => x.monument == copy2.monument);
				int num2 = 1;
				for (PathFinder.Node node5 = node3; node5 != null; node5 = node5.next)
				{
					if (num2 % 8 == 0)
					{
						list5.Add(node5.point);
					}
					num2++;
				}
			}
			List<Vector3> list8 = new List<Vector3>();
			foreach (PathSegment item2 in list2)
			{
				for (PathFinder.Node node6 = item2.start; node6 != null; node6 = node6.next)
				{
					float num3 = ((float)node6.point.x + 0.5f) / (float)length;
					float num4 = ((float)node6.point.y + 0.5f) / (float)length;
					float height = TerrainMeta.HeightMap.GetHeight01(num3, num4);
					list8.Add(TerrainMeta.Denormalize(new Vector3(num3, height, num4)));
				}
				if (list8.Count != 0)
				{
					if (list8.Count >= 8)
					{
						PathList pathList = new PathList("Powerline " + (TerrainMeta.Path.Powerlines.Count + list.Count), list8.ToArray());
						pathList.Start = true;
						pathList.End = true;
						pathList.ProcgenStartNode = item2.start;
						pathList.ProcgenEndNode = item2.end;
						list.Add(pathList);
					}
					list8.Clear();
				}
			}
			foreach (PathList item3 in list)
			{
				item3.Path.RecalculateTangents();
			}
			TerrainMeta.Path.Powerlines.AddRange(list);
		}
	}
}
