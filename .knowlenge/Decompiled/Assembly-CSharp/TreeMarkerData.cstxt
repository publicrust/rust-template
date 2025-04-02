using System;
using UnityEngine;

public class TreeMarkerData : PrefabAttribute, IServerComponent
{
	[Serializable]
	public struct MarkerLocation
	{
		public Vector3 LocalPosition;

		public Vector3 LocalNormal;
	}

	[Serializable]
	public struct GenerationArc
	{
		public Vector3 CentrePoint;

		public float Radius;

		public Vector3 Rotation;

		public int OverrideCount;
	}

	public GenerationArc[] GenerationArcs;

	public MarkerLocation[] Markers;

	public Vector3 GenerationStartPoint = Vector3.up * 2f;

	public float GenerationRadius = 2f;

	public float MaxY = 1.7f;

	public float MinY = 0.2f;

	public bool ProcessAngleChecks;

	protected override Type GetIndexedType()
	{
		return typeof(TreeMarkerData);
	}

	public Vector3 GetNearbyPoint(Vector3 point, ref int ignoreIndex, out Vector3 normal)
	{
		int num = Markers.Length;
		if (ignoreIndex != -1 && ProcessAngleChecks)
		{
			ignoreIndex++;
			if (ignoreIndex >= num)
			{
				ignoreIndex = 0;
			}
			normal = Markers[ignoreIndex].LocalNormal;
			return Markers[ignoreIndex].LocalPosition;
		}
		int num2 = UnityEngine.Random.Range(0, num);
		float num3 = float.MaxValue;
		int num4 = -1;
		for (int i = 0; i < num; i++)
		{
			if (ignoreIndex == num2)
			{
				continue;
			}
			MarkerLocation markerLocation = Markers[num2];
			if (!(markerLocation.LocalPosition.y < MinY))
			{
				Vector3 vector = markerLocation.LocalPosition;
				vector.y = Mathf.Lerp(vector.y, point.y, 0.5f);
				float sqrMagnitude = (vector - point).sqrMagnitude;
				sqrMagnitude *= UnityEngine.Random.Range(0.95f, 1.05f);
				if (sqrMagnitude < num3)
				{
					num3 = sqrMagnitude;
					num4 = num2;
				}
				num2++;
				if (num2 >= num)
				{
					num2 = 0;
				}
			}
		}
		if (num4 > -1)
		{
			normal = Markers[num4].LocalNormal;
			ignoreIndex = num4;
			return Markers[num4].LocalPosition;
		}
		normal = Markers[0].LocalNormal;
		return Markers[0].LocalPosition;
	}
}
