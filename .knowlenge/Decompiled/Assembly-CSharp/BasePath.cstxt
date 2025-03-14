using System;
using System.Collections.Generic;
using UnityEngine;

public class BasePath : MonoBehaviour, IAIPath
{
	public List<BasePathNode> nodes;

	public List<PathInterestNode> interestZones;

	public List<PathSpeedZone> speedZones;

	private float? cachedLength;

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
				if (!(node == node2) && (maxRange == -1f || !(Vector3.Distance(node.Position, node2.Position) > maxRange)) && GamePhysics.LineOfSight(node.Position, node2.Position, 1503731969) && GamePhysics.LineOfSight(node2.Position, node.Position, 1503731969))
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

	public float GetPathLength()
	{
		if (cachedLength.HasValue)
		{
			return cachedLength.Value;
		}
		if (nodes.Count < 2)
		{
			return 0f;
		}
		cachedLength = 0f;
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			cachedLength += Vector3.Distance(nodes[i].Position, nodes[i + 1].Position);
		}
		return cachedLength.Value;
	}

	public float GetPathProgress(Vector3 position)
	{
		float num = 0f;
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			Vector3 position2 = nodes[i].Position;
			Vector3 position3 = nodes[i + 1].Position;
			Vector3 normalized = (position2 - position3).normalized;
			Vector3 normalized2 = (position2 - position).normalized;
			Vector3 normalized3 = (position3 - position).normalized;
			float num2 = Vector3.Distance(position2, position3);
			float num3 = Vector3.Dot(normalized, normalized2);
			float num4 = Vector3.Dot(-normalized, normalized3);
			if (i == 0 && num3 < 0f)
			{
				return 0f;
			}
			if (num3 > -0.1f && num4 > -0.1f)
			{
				float num5 = Vector3.Distance(position2, position);
				return num + num5;
			}
			num += num2;
		}
		return GetPathLength();
	}

	public void GetPointInPath(float normalisedTime, out Vector3 pos, out Vector3 rotation)
	{
		normalisedTime = Mathf.Clamp01(normalisedTime);
		pos = Vector3.zero;
		rotation = Vector3.zero;
		if (normalisedTime >= 1f)
		{
			List<BasePathNode> list = nodes;
			pos = list[list.Count - 1].Position;
			return;
		}
		float num = GetPathLength() * normalisedTime;
		float num2 = 0f;
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			float num3 = Vector3.Distance(nodes[i].Position, nodes[i + 1].Position);
			if (num2 + num3 > num)
			{
				float t = (num - num2) / num3;
				pos = Vector3.Lerp(nodes[i].Position, nodes[i + 1].Position, t);
				rotation = (nodes[i + 1].Position - nodes[i].Position).normalized;
				break;
			}
			num2 += num3;
		}
	}
}
