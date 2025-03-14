using System;
using UnityEngine;

public class BasePathFinder
{
	private static Vector3[] preferedTopologySamples = new Vector3[4];

	private static Vector3[] topologySamples = new Vector3[4];

	private Vector3 chosenPosition;

	private const float halfPI = MathF.PI / 180f;

	public virtual Vector3 GetRandomPatrolPoint()
	{
		return Vector3.zero;
	}

	public virtual AIMovePoint GetBestRoamPoint(Vector3 anchorPos, Vector3 currentPos, Vector3 currentDirection, float anchorClampDistance, float lookupMaxRange = 20f)
	{
		return null;
	}

	public void DebugDraw()
	{
		Color color = Gizmos.color;
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(chosenPosition, 5f);
		Gizmos.color = Color.blue;
		Vector3[] array = topologySamples;
		for (int i = 0; i < array.Length; i++)
		{
			Gizmos.DrawSphere(array[i], 2.5f);
		}
		Gizmos.color = color;
	}

	public virtual Vector3 GetRandomPositionAround(Vector3 position, float minDistFrom = 0f, float maxDistFrom = 2f)
	{
		if (maxDistFrom < 0f)
		{
			maxDistFrom = 0f;
		}
		Vector2 vector = UnityEngine.Random.insideUnitCircle * maxDistFrom;
		float x = Mathf.Clamp(Mathf.Max(Mathf.Abs(vector.x), minDistFrom), minDistFrom, maxDistFrom) * Mathf.Sign(vector.x);
		float z = Mathf.Clamp(Mathf.Max(Mathf.Abs(vector.y), minDistFrom), minDistFrom, maxDistFrom) * Mathf.Sign(vector.y);
		return position + new Vector3(x, 0f, z);
	}

	public virtual Vector3 GetBestRoamPosition(BaseNavigator navigator, Vector3 anchorPos, Vector3 fallbackPos, float minRange, float maxRange)
	{
		float radius = UnityEngine.Random.Range(minRange, maxRange);
		int num = 0;
		int num2 = 0;
		float num3 = UnityEngine.Random.Range(0f, 90f);
		for (float num4 = 0f; num4 < 360f; num4 += 90f)
		{
			Vector3 pointOnCircle = GetPointOnCircle(anchorPos, radius, num4 + num3);
			if (navigator.GetNearestNavmeshPosition(pointOnCircle, out var position, 10f) && navigator.IsPositionABiomeRequirement(position) && navigator.IsAcceptableWaterDepth(position) && !navigator.IsPositionPreventTopology(position))
			{
				topologySamples[num] = position;
				num++;
				if (navigator.IsPositionABiomePreference(position) && navigator.IsPositionATopologyPreference(position))
				{
					preferedTopologySamples[num2] = position;
					num2++;
				}
			}
		}
		if (num2 > 0)
		{
			chosenPosition = preferedTopologySamples[UnityEngine.Random.Range(0, num2)];
		}
		else if (num > 0)
		{
			chosenPosition = topologySamples[UnityEngine.Random.Range(0, num)];
		}
		else
		{
			chosenPosition = fallbackPos;
		}
		return chosenPosition;
	}

	public virtual Vector3 GetBestRoamPositionFromAnchor(BaseNavigator navigator, Vector3 anchorPos, Vector3 fallbackPos, float minRange, float maxRange)
	{
		float radius = UnityEngine.Random.Range(minRange, maxRange);
		int num = 0;
		int num2 = 0;
		float num3 = UnityEngine.Random.Range(0f, 90f);
		for (float num4 = 0f; num4 < 360f; num4 += 90f)
		{
			Vector3 pointOnCircle = GetPointOnCircle(anchorPos, radius, num4 + num3);
			if (navigator.GetNearestNavmeshPosition(pointOnCircle, out var position, 10f) && navigator.IsAcceptableWaterDepth(position))
			{
				topologySamples[num] = position;
				num++;
				if (navigator.IsPositionABiomePreference(position) && navigator.IsPositionATopologyPreference(position))
				{
					preferedTopologySamples[num2] = position;
					num2++;
				}
			}
		}
		if (UnityEngine.Random.Range(0f, 1f) <= 0.9f && num2 > 0)
		{
			chosenPosition = preferedTopologySamples[UnityEngine.Random.Range(0, num2)];
		}
		else if (num > 0)
		{
			chosenPosition = topologySamples[UnityEngine.Random.Range(0, num)];
		}
		else
		{
			chosenPosition = fallbackPos;
		}
		return chosenPosition;
	}

	public virtual bool GetBestFleePosition(BaseNavigator navigator, AIBrainSenses senses, BaseEntity fleeFrom, Vector3 fallbackPos, float minRange, float maxRange, out Vector3 result)
	{
		if (fleeFrom == null)
		{
			result = navigator.transform.position;
			return false;
		}
		Vector3 dirFromThreat = Vector3Ex.Direction2D(navigator.transform.position, fleeFrom.transform.position);
		if (TestFleeDirection(navigator, dirFromThreat, 0f, minRange, maxRange, out result))
		{
			return true;
		}
		bool flag = UnityEngine.Random.Range(0, 2) == 1;
		if (TestFleeDirection(navigator, dirFromThreat, flag ? 45f : 315f, minRange, maxRange, out result))
		{
			return true;
		}
		if (TestFleeDirection(navigator, dirFromThreat, flag ? 315f : 45f, minRange, maxRange, out result))
		{
			return true;
		}
		if (TestFleeDirection(navigator, dirFromThreat, flag ? 90f : 270f, minRange, maxRange, out result))
		{
			return true;
		}
		if (TestFleeDirection(navigator, dirFromThreat, flag ? 270f : 90f, minRange, maxRange, out result))
		{
			return true;
		}
		if (TestFleeDirection(navigator, dirFromThreat, 135f + UnityEngine.Random.Range(0f, 90f), minRange, maxRange, out result))
		{
			return true;
		}
		return false;
	}

	private bool TestFleeDirection(BaseNavigator navigator, Vector3 dirFromThreat, float offsetDegrees, float minRange, float maxRange, out Vector3 result)
	{
		result = navigator.transform.position;
		Vector3 vector = Quaternion.Euler(0f, offsetDegrees, 0f) * dirFromThreat;
		Vector3 target = navigator.transform.position + vector * UnityEngine.Random.Range(minRange, maxRange);
		if (!navigator.GetNearestNavmeshPosition(target, out var position, 20f))
		{
			return false;
		}
		if (!navigator.IsAcceptableWaterDepth(position))
		{
			return false;
		}
		result = position;
		return true;
	}

	public static Vector3 GetPointOnCircle(Vector3 center, float radius, float degrees)
	{
		return new Vector3(center.x + radius * Mathf.Cos(degrees * (MathF.PI / 180f)), z: center.z + radius * Mathf.Sin(degrees * (MathF.PI / 180f)), y: center.y);
	}
}
