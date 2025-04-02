using System;
using System.Collections.Generic;

public class SpanningTree<T>
{
	private class Node
	{
		public List<Edge> edges;

		public bool connected;

		public Node()
		{
			edges = new List<Edge>();
			connected = false;
		}
	}

	private class Edge : IMinHeapNode<Edge>
	{
		public Node source;

		public Node target;

		public T value;

		public int order { get; private set; }

		public Edge child { get; set; }

		public Edge(Node source, Node target, int order, T value)
		{
			this.source = source;
			this.target = target;
			this.order = order;
			this.value = value;
		}
	}

	private List<Node> nodes = new List<Node>();

	private List<Edge> edges = new List<Edge>();

	public int AddNode()
	{
		nodes.Add(new Node());
		return nodes.Count - 1;
	}

	public void AddEdge(int a_idx, int b_idx, int cost, T value)
	{
		Node node = nodes[a_idx];
		Node target = nodes[b_idx];
		node.edges.Add(new Edge(node, target, cost, value));
	}

	public void Clear()
	{
		nodes.Clear();
		edges.Clear();
	}

	public void Reset()
	{
		foreach (Node node in nodes)
		{
			node.connected = false;
		}
		edges.Clear();
	}

	public void CalculateMin()
	{
		Reset();
		IntrusiveMinHeap<Edge> intrusiveMinHeap = default(IntrusiveMinHeap<Edge>);
		foreach (Node node in nodes)
		{
			if (node.connected)
			{
				continue;
			}
			foreach (Edge edge2 in node.edges)
			{
				if (!edge2.target.connected)
				{
					intrusiveMinHeap.Add(edge2);
				}
			}
			node.connected = true;
			while (!intrusiveMinHeap.Empty)
			{
				Edge edge = intrusiveMinHeap.Pop();
				Node target = edge.target;
				if (target.connected)
				{
					continue;
				}
				target.connected = true;
				foreach (Edge edge3 in target.edges)
				{
					if (edge3.target == edge.source)
					{
						edge = edge3;
					}
					if (!edge3.target.connected)
					{
						intrusiveMinHeap.Add(edge3);
					}
				}
				edges.Add(edge);
			}
		}
	}

	public void ForEach(Action<T> action)
	{
		foreach (Edge edge in edges)
		{
			action(edge.value);
		}
	}
}
