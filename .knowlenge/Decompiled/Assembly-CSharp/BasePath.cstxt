using System.Collections.Generic;
using UnityEngine;

public class BasePath : MonoBehaviour
{
	public List<BasePathNode> nodes;

	public List<PathInterestNode> interestZones;

	public List<PathSpeedZone> speedZones;

	public void Start()
	{
	}

	public void GetNodesNear(Vector3 point, ref List<BasePathNode> nearNodes, float dist = 10f)
	{
		foreach (BasePathNode node in nodes)
		{
			if ((Vector3Ex.XZ(point) - Vector3Ex.XZ(node.transform.position)).sqrMagnitude <= dist * dist)
			{
				nearNodes.Add(node);
			}
		}
	}

	public BasePathNode GetClosestToPoint(Vector3 point)
	{
		BasePathNode result = nodes[0];
		float num = float.PositiveInfinity;
		foreach (BasePathNode node in nodes)
		{
			if (!(node == null) && !(node.transform == null))
			{
				float sqrMagnitude = (point - node.transform.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = node;
				}
			}
		}
		return result;
	}

	public PathInterestNode GetRandomInterestNodeAwayFrom(Vector3 from, float dist = 10f)
	{
		PathInterestNode pathInterestNode = null;
		int num = 0;
		while (pathInterestNode == null && num < 20)
		{
			pathInterestNode = interestZones[Random.Range(0, interestZones.Count)];
			if (!((pathInterestNode.transform.position - from).sqrMagnitude < 100f))
			{
				break;
			}
			pathInterestNode = null;
			num++;
		}
		if (pathInterestNode == null)
		{
			pathInterestNode = interestZones[0];
		}
		return pathInterestNode;
	}
}
