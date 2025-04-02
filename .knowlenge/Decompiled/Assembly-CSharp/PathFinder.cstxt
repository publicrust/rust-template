using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
	public struct Point : IEquatable<Point>
	{
		public int x;

		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static Point operator +(Point a, Point b)
		{
			return new Point(a.x + b.x, a.y + b.y);
		}

		public static Point operator -(Point a, Point b)
		{
			return new Point(a.x - b.x, a.y - b.y);
		}

		public static Point operator *(Point p, int i)
		{
			return new Point(p.x * i, p.y * i);
		}

		public static Point operator /(Point p, int i)
		{
			return new Point(p.x / i, p.y / i);
		}

		public static bool operator ==(Point a, Point b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Point a, Point b)
		{
			return !a.Equals(b);
		}

		public override int GetHashCode()
		{
			return x.GetHashCode() ^ y.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (!(other is Point))
			{
				return false;
			}
			return Equals((Point)other);
		}

		public bool Equals(Point other)
		{
			if (x == other.x)
			{
				return y == other.y;
			}
			return false;
		}
	}

	public class Node : IMinHeapNode<Node>, ILinkedListNode<Node>
	{
		public Point point;

		public int cost;

		public int heuristic;

		public Node next { get; set; }

		public Node child { get; set; }

		public int order => cost + heuristic;

		public Node(Point point, int cost, int heuristic, Node next = null)
		{
			this.point = point;
			this.cost = cost;
			this.heuristic = heuristic;
			this.next = next;
		}
	}

	private int[,] costmap;

	private int[,] visited;

	private Point[] neighbors;

	private bool diagonals;

	private bool directional;

	public Point PushPoint;

	public int PushRadius;

	public int PushDistance;

	public int PushMultiplier;

	public List<Point> PushPointsAdditional = new List<Point>();

	public HashSet<Point> BlockedPointsAdditional = new HashSet<Point>();

	private static Point[] mooreNeighbors = new Point[8]
	{
		new Point(0, 1),
		new Point(-1, 0),
		new Point(1, 0),
		new Point(0, -1),
		new Point(-1, 1),
		new Point(1, 1),
		new Point(-1, -1),
		new Point(1, -1)
	};

	private static Point[] neumannNeighbors = new Point[4]
	{
		new Point(0, 1),
		new Point(-1, 0),
		new Point(1, 0),
		new Point(0, -1)
	};

	public PathFinder(int[,] costmap, bool diagonals = true, bool directional = true)
	{
		this.costmap = costmap;
		neighbors = (diagonals ? mooreNeighbors : neumannNeighbors);
		this.diagonals = diagonals;
		this.directional = directional;
	}

	public int GetResolution(int index)
	{
		return costmap.GetLength(index);
	}

	public Node FindPath(Point start, Point end, int depth = int.MaxValue)
	{
		return FindPathReversed(end, start, depth);
	}

	private Node FindPathReversed(Point start, Point end, int depth = int.MaxValue)
	{
		if (visited == null)
		{
			visited = new int[costmap.GetLength(0), costmap.GetLength(1)];
		}
		else
		{
			Array.Clear(visited, 0, visited.Length);
		}
		int num = 0;
		int num2 = costmap.GetLength(0) - 1;
		int num3 = 0;
		int num4 = costmap.GetLength(1) - 1;
		IntrusiveMinHeap<Node> intrusiveMinHeap = default(IntrusiveMinHeap<Node>);
		int num5 = Cost(start);
		if (num5 != int.MaxValue)
		{
			int heuristic = Heuristic(start, end);
			intrusiveMinHeap.Add(new Node(start, num5, heuristic));
		}
		visited[start.x, start.y] = num5;
		while (!intrusiveMinHeap.Empty && depth-- > 0)
		{
			Node node = intrusiveMinHeap.Pop();
			if (node.heuristic == 0)
			{
				return node;
			}
			for (int i = 0; i < neighbors.Length; i++)
			{
				Point point = node.point + neighbors[i];
				if (point.x < num || point.x > num2 || point.y < num3 || point.y > num4)
				{
					continue;
				}
				int num6 = Cost(point, node);
				if (num6 != int.MaxValue)
				{
					int num7 = visited[point.x, point.y];
					if (num7 == 0 || num6 < num7)
					{
						int cost = node.cost + num6;
						int heuristic2 = Heuristic(point, end);
						intrusiveMinHeap.Add(new Node(point, cost, heuristic2, node));
						visited[point.x, point.y] = num6;
					}
				}
				else
				{
					visited[point.x, point.y] = -1;
				}
			}
		}
		return null;
	}

	public Node FindPathDirected(List<Point> startList, List<Point> endList, int depth = int.MaxValue)
	{
		if (startList.Count == 0 || endList.Count == 0)
		{
			return null;
		}
		return FindPathReversed(endList, startList, depth);
	}

	public Node FindPathUndirected(List<Point> startList, List<Point> endList, int depth = int.MaxValue)
	{
		if (startList.Count == 0 || endList.Count == 0)
		{
			return null;
		}
		if (startList.Count > endList.Count)
		{
			return FindPathReversed(endList, startList, depth);
		}
		return FindPathReversed(startList, endList, depth);
	}

	private Node FindPathReversed(List<Point> startList, List<Point> endList, int depth = int.MaxValue)
	{
		if (visited == null)
		{
			visited = new int[costmap.GetLength(0), costmap.GetLength(1)];
		}
		else
		{
			Array.Clear(visited, 0, visited.Length);
		}
		int num = 0;
		int num2 = costmap.GetLength(0) - 1;
		int num3 = 0;
		int num4 = costmap.GetLength(1) - 1;
		IntrusiveMinHeap<Node> intrusiveMinHeap = default(IntrusiveMinHeap<Node>);
		foreach (Point start in startList)
		{
			int num5 = Cost(start);
			if (num5 != int.MaxValue)
			{
				int heuristic = Heuristic(start, endList);
				intrusiveMinHeap.Add(new Node(start, num5, heuristic));
			}
			visited[start.x, start.y] = num5;
		}
		while (!intrusiveMinHeap.Empty && depth-- > 0)
		{
			Node node = intrusiveMinHeap.Pop();
			if (node.heuristic == 0)
			{
				return node;
			}
			for (int i = 0; i < neighbors.Length; i++)
			{
				Point point = node.point + neighbors[i];
				if (point.x < num || point.x > num2 || point.y < num3 || point.y > num4)
				{
					continue;
				}
				int num6 = Cost(point, node);
				if (num6 != int.MaxValue)
				{
					int num7 = visited[point.x, point.y];
					if (num7 == 0 || num6 < num7)
					{
						int cost = node.cost + num6;
						int heuristic2 = Heuristic(point, endList);
						intrusiveMinHeap.Add(new Node(point, cost, heuristic2, node));
						visited[point.x, point.y] = num6;
					}
				}
				else
				{
					visited[point.x, point.y] = -1;
				}
			}
		}
		return null;
	}

	public Node FindClosestWalkable(Point start, int depth = int.MaxValue)
	{
		if (visited == null)
		{
			visited = new int[costmap.GetLength(0), costmap.GetLength(1)];
		}
		else
		{
			Array.Clear(visited, 0, visited.Length);
		}
		int num = 0;
		int num2 = costmap.GetLength(0) - 1;
		int num3 = 0;
		int num4 = costmap.GetLength(1) - 1;
		if (start.x < num)
		{
			return null;
		}
		if (start.x > num2)
		{
			return null;
		}
		if (start.y < num3)
		{
			return null;
		}
		if (start.y > num4)
		{
			return null;
		}
		IntrusiveMinHeap<Node> intrusiveMinHeap = default(IntrusiveMinHeap<Node>);
		int num5 = 1;
		int heuristic = Heuristic(start);
		intrusiveMinHeap.Add(new Node(start, num5, heuristic));
		visited[start.x, start.y] = num5;
		while (!intrusiveMinHeap.Empty && depth-- > 0)
		{
			Node node = intrusiveMinHeap.Pop();
			if (node.heuristic == 0)
			{
				return node;
			}
			for (int i = 0; i < neighbors.Length; i++)
			{
				Point point = node.point + neighbors[i];
				if (point.x >= num && point.x <= num2 && point.y >= num3 && point.y <= num4)
				{
					int num6 = 1;
					if (visited[point.x, point.y] == 0)
					{
						int cost = node.cost + num6;
						int heuristic2 = Heuristic(point);
						intrusiveMinHeap.Add(new Node(point, cost, heuristic2, node));
						visited[point.x, point.y] = num6;
					}
				}
			}
		}
		return null;
	}

	public bool IsWalkable(Point point)
	{
		return costmap[point.x, point.y] != int.MaxValue;
	}

	public bool IsWalkableWithNeighbours(Point point)
	{
		if (costmap[point.x, point.y] == int.MaxValue)
		{
			return false;
		}
		for (int i = 0; i < neighbors.Length; i++)
		{
			Point point2 = point + neighbors[i];
			if (costmap[point2.x, point2.y] == int.MaxValue)
			{
				return false;
			}
		}
		return true;
	}

	public Node Reverse(Node start)
	{
		Node node = null;
		Node next = null;
		for (Node node2 = start; node2 != null; node2 = node2.next)
		{
			if (node != null)
			{
				node.next = next;
			}
			next = node;
			node = node2;
		}
		if (node != null)
		{
			node.next = next;
		}
		return node;
	}

	public Node FindEnd(Node start)
	{
		for (Node node = start; node != null; node = node.next)
		{
			if (node.next == null)
			{
				return node;
			}
		}
		return start;
	}

	public int Cost(Point a)
	{
		int num = costmap[a.x, a.y];
		int num2 = 0;
		if (BlockedPointsAdditional.Contains(a))
		{
			num = int.MaxValue;
		}
		if (num == int.MaxValue)
		{
			return num;
		}
		if (PushMultiplier > 0)
		{
			int num3 = ((PushRadius > 0) ? Mathf.Max(0, Heuristic(a, PushPoint) - PushRadius) : (PushDistance * 2));
			for (int i = 0; i < PushPointsAdditional.Count; i++)
			{
				num3 = Mathf.Min(num3, Heuristic(a, PushPointsAdditional[i]));
			}
			float num4 = Mathf.Max(0f, PushDistance - num3) / (float)PushDistance;
			num2 = ((PushMultiplier != int.MaxValue) ? Mathf.CeilToInt((float)PushMultiplier * num4) : ((num4 > 0f) ? int.MaxValue : 0));
		}
		if (num2 == int.MaxValue)
		{
			return num2;
		}
		return num + num2;
	}

	public int Cost(Point a, Node prev)
	{
		int num = Cost(a);
		int num2 = 0;
		if (num != int.MaxValue && directional && prev != null && prev.next != null && Heuristic(a, prev.next.point) <= 1)
		{
			num2 = 10000;
		}
		return num + num2;
	}

	public int Heuristic(Point a)
	{
		if (costmap[a.x, a.y] != int.MaxValue)
		{
			return 0;
		}
		return 1;
	}

	public int Heuristic(Point a, Point b)
	{
		int num = Mathf.Abs(a.x - b.x);
		int num2 = Mathf.Abs(a.y - b.y);
		if (diagonals)
		{
			return Mathf.Max(num, num2);
		}
		return num + num2;
	}

	public int Heuristic(Point a, List<Point> b)
	{
		int num = int.MaxValue;
		for (int i = 0; i < b.Count; i++)
		{
			num = Mathf.Min(num, Heuristic(a, b[i]));
		}
		return num;
	}

	public float Distance(Point a, Point b)
	{
		int num = a.x - b.x;
		int num2 = a.y - b.y;
		return Mathf.Sqrt(num * num + num2 * num2);
	}

	public static Point GetPoint(Vector3 worldPos, int res)
	{
		float num = TerrainMeta.NormalizeX(worldPos.x);
		float num2 = TerrainMeta.NormalizeZ(worldPos.z);
		Point result = default(Point);
		result.x = Mathf.Clamp((int)(num * (float)res), 0, res - 1);
		result.y = Mathf.Clamp((int)(num2 * (float)res), 0, res - 1);
		return result;
	}
}
