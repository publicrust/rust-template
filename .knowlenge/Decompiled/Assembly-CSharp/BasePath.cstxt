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
			nodes.AddRange(((Component)this).GetComponentsInChildren<BasePathNode>());
			foreach (BasePathNode node in nodes)
			{
				node.Path = this;
			}
		}
		if (interestZones != null)
		{
			interestZones.Clear();
			interestZones.AddRange(((Component)this).GetComponentsInChildren<PathInterestNode>());
		}
		if (speedZones != null)
		{
			speedZones.Clear();
			speedZones.AddRange(((Component)this).GetComponentsInChildren<PathSpeedZone>());
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
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
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
				if (!((Object)(object)node == (Object)(object)node2) && (maxRange == -1f || !(Vector3.Distance(node.Position, node2.Position) > maxRange)) && GamePhysics.LineOfSight(node.Position, node2.Position, 1503731969) && GamePhysics.LineOfSight(node2.Position, node.Position, 1503731969))
				{
					node.linked.Add(node2);
				}
			}
		}
	}

	public void GetNodesNear(Vector3 point, ref List<IAIPathNode> nearNodes, float dist = 10f)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		foreach (BasePathNode node in nodes)
		{
			Vector3 val = Vector3Ex.XZ(point) - Vector3Ex.XZ(node.Position);
			if (((Vector3)(ref val)).sqrMagnitude <= dist * dist)
			{
				nearNodes.Add(node);
			}
		}
	}

	public IAIPathNode GetClosestToPoint(Vector3 point)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		IAIPathNode result = nodes[0];
		float num = float.PositiveInfinity;
		foreach (BasePathNode node in nodes)
		{
			if (!((Object)(object)node == (Object)null) && !((Object)(object)((Component)node).transform == (Object)null))
			{
				Vector3 val = point - node.Position;
				float sqrMagnitude = ((Vector3)(ref val)).sqrMagnitude;
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
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		PathInterestNode pathInterestNode = null;
		int num = 0;
		while ((Object)(object)pathInterestNode == (Object)null && num < 20)
		{
			pathInterestNode = interestZones[Random.Range(0, interestZones.Count)];
			Vector3 val = ((Component)pathInterestNode).transform.position - from;
			if (!(((Vector3)(ref val)).sqrMagnitude < dist * dist))
			{
				break;
			}
			pathInterestNode = null;
			num++;
		}
		if ((Object)(object)pathInterestNode == (Object)null)
		{
			Debug.LogError((object)"REturning default interest zone");
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
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f;
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			Vector3 position2 = nodes[i].Position;
			Vector3 position3 = nodes[i + 1].Position;
			Vector3 val = position2 - position3;
			Vector3 normalized = ((Vector3)(ref val)).normalized;
			val = position2 - position;
			Vector3 normalized2 = ((Vector3)(ref val)).normalized;
			val = position3 - position;
			Vector3 normalized3 = ((Vector3)(ref val)).normalized;
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
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
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
				float num4 = (num - num2) / num3;
				pos = Vector3.Lerp(nodes[i].Position, nodes[i + 1].Position, num4);
				Vector3 val = nodes[i + 1].Position - nodes[i].Position;
				rotation = ((Vector3)(ref val)).normalized;
				break;
			}
			num2 += num3;
		}
	}
}
