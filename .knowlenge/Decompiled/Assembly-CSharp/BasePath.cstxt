using System;
using System.Collections.Generic;
using UnityEngine;

public class BasePath : MonoBehaviour, IAIPath
{
	public List<BasePathNode> nodes;

	public List<PathInterestNode> interestZones;

	public List<PathSpeedZone> speedZones;

	public IEnumerable<IAIPathInterestNode> InterestNodes => interestZones;

	public IEnumerable<IAIPathSpeedZone> SpeedZones => speedZones;

	private void AddChildren()
	{
		if (nodes != null)
		{
			nodes.Clear();
			nodes.AddRange(GetComponentsInChildren<BasePathNode>());
			foreach (BasePathNode node in nodes)
			{
				node.Path = this;
			}
		}
		if (interestZones != null)
		{
			interestZones.Clear();
			interestZones.AddRange(GetComponentsInChildren<PathInterestNode>());
		}
		if (speedZones != null)
		{
			speedZones.Clear();
			speedZones.AddRange(GetComponentsInChildren<PathSpeedZone>());
		}
	}

	private void ClearChildren()
	{
		if (nodes != null)
		{
			foreach (BasePathNode node in nodes)
			{
				node.linked.Clear();
			}
		}
		nodes.Clear();
	}

	public static void AutoGenerateLinks(BasePath path, float maxRange = -1f)
	{
		path.AddChildren();
		foreach (BasePathNode node in path.nodes)
		{
			if (node.linked == null)
			{
				node.linked = new List<BasePathNode>();
			}
			else
			{
				node.linked.Clear();
			}
			foreach (BasePathNode node2 in path.nodes)
			{
				if (!(node == node2) && (maxRange == -1f || !(Vector3.Distance(node.Position, node2.Position) > maxRange)) && GamePhysics.LineOfSight(node.Position, node2.Position, 429990145) && GamePhysics.LineOfSight(node2.Position, node.Position, 429990145))
				{
					node.linked.Add(node2);
				}
			}
		}
	}

	public void GetNodesNear(Vector3 point, ref List<IAIPathNode> nearNodes, float dist = 10f)
	{
		foreach (BasePathNode node in nodes)
		{
			if ((Vector3Ex.XZ(point) - Vector3Ex.XZ(node.Position)).sqrMagnitude <= dist * dist)
			{
				nearNodes.Add(node);
			}
		}
	}

	public IAIPathNode GetClosestToPoint(Vector3 point)
	{
		IAIPathNode result = nodes[0];
		float num = float.PositiveInfinity;
		foreach (BasePathNode node in nodes)
		{
			if (!(node == null) && !(node.transform == null))
			{
				float sqrMagnitude = (point - node.Position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = node;
				}
			}
		}
		return result;
	}

	public IAIPathInterestNode GetRandomInterestNodeAwayFrom(Vector3 from, float dist = 10f)
	{
		PathInterestNode pathInterestNode = null;
		int num = 0;
		while (pathInterestNode == null && num < 20)
		{
			pathInterestNode = interestZones[UnityEngine.Random.Range(0, interestZones.Count)];
			if (!((pathInterestNode.transform.position - from).sqrMagnitude < dist * dist))
			{
				break;
			}
			pathInterestNode = null;
			num++;
		}
		if (pathInterestNode == null)
		{
			Debug.LogError("REturning default interest zone");
			pathInterestNode = interestZones[0];
		}
		return pathInterestNode;
	}

	public void AddInterestNode(IAIPathInterestNode interestZone)
	{
		throw new NotImplementedException();
	}

	public void AddSpeedZone(IAIPathSpeedZone speedZone)
	{
		throw new NotImplementedException();
	}
}
