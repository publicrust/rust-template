using System.Collections.Generic;
using UnityEngine;

public class AIMovePoint : AIPoint
{
	public class DistTo
	{
		public float distance;

		public AIMovePoint target;
	}

	public ListDictionary<AIMovePoint, float> distances = new ListDictionary<AIMovePoint, float>();

	public ListDictionary<AICoverPoint, float> distancesToCover = new ListDictionary<AICoverPoint, float>();

	public float radius = 1f;

	public float WaitTime;

	public List<Transform> LookAtPoints;

	public void OnDrawGizmos()
	{
		Color color = Gizmos.color;
		Gizmos.color = Color.green;
		GizmosUtil.DrawWireCircleY(base.transform.position, radius);
		Gizmos.color = color;
	}

	public void DrawLookAtPoints()
	{
		Color color = Gizmos.color;
		Gizmos.color = Color.gray;
		if (LookAtPoints != null)
		{
			foreach (Transform lookAtPoint in LookAtPoints)
			{
				if (!(lookAtPoint == null))
				{
					Gizmos.DrawSphere(lookAtPoint.position, 0.2f);
					Gizmos.DrawLine(base.transform.position, lookAtPoint.position);
				}
			}
		}
		Gizmos.color = color;
	}

	public void Clear()
	{
		LookAtPoints = null;
	}

	public void AddLookAtPoint(Transform transform)
	{
		if (LookAtPoints == null)
		{
			LookAtPoints = new List<Transform>();
		}
		LookAtPoints.Add(transform);
	}

	public bool HasLookAtPoints()
	{
		if (LookAtPoints != null)
		{
			return LookAtPoints.Count > 0;
		}
		return false;
	}

	public Transform GetRandomLookAtPoint()
	{
		if (LookAtPoints == null || LookAtPoints.Count == 0)
		{
			return null;
		}
		return LookAtPoints[Random.Range(0, LookAtPoints.Count)];
	}
}
