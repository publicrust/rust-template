using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class WorldSplineData
{
	[Serializable]
	public class LUTEntry
	{
		[Serializable]
		public struct LUTPoint
		{
			public float distance;

			public Vector3 pos;

			public LUTPoint(float distance, Vector3 pos)
			{
				this.distance = distance;
				this.pos = pos;
			}
		}

		public List<LUTPoint> points = new List<LUTPoint>();
	}

	public Vector3[] inputPoints;

	public Vector3[] inputTangents;

	public float inputLUTInterval;

	public List<LUTEntry> LUTValues;

	public float Length;

	[SerializeField]
	private int maxPointsIndex;

	public WorldSplineData(WorldSpline worldSpline)
	{
		worldSpline.CheckValidity();
		LUTValues = new List<LUTEntry>();
		inputPoints = new Vector3[worldSpline.points.Length];
		worldSpline.points.CopyTo(inputPoints, 0);
		inputTangents = new Vector3[worldSpline.tangents.Length];
		worldSpline.tangents.CopyTo(inputTangents, 0);
		inputLUTInterval = worldSpline.lutInterval;
		maxPointsIndex = inputPoints.Length - 1;
		CreateLookupTable(worldSpline);
	}

	public bool IsSameAs(WorldSpline worldSpline)
	{
		if (inputPoints.SequenceEqual(worldSpline.points) && inputTangents.SequenceEqual(worldSpline.tangents))
		{
			return inputLUTInterval == worldSpline.lutInterval;
		}
		return false;
	}

	public bool IsDifferentTo(WorldSpline worldSpline)
	{
		return !IsSameAs(worldSpline);
	}

	public Vector3 GetStartPoint()
	{
		return inputPoints[0];
	}

	public Vector3 GetEndPoint()
	{
		return inputPoints[maxPointsIndex];
	}

	public Vector3 GetStartTangent()
	{
		return inputTangents[0];
	}

	public Vector3 GetEndTangent()
	{
		return inputTangents[maxPointsIndex];
	}

	public Vector3 GetPointCubicHermite(float distance)
	{
		Vector3 tangent;
		return GetPointAndTangentCubicHermite(distance, out tangent);
	}

	public Vector3 GetTangentCubicHermite(float distance)
	{
		GetPointAndTangentCubicHermite(distance, out var tangent);
		return tangent;
	}

	public Vector3 GetPointAndTangentCubicHermite(float distance, out Vector3 tangent)
	{
		if (distance <= 0f)
		{
			tangent = GetStartTangent();
			return GetStartPoint();
		}
		if (distance >= Length)
		{
			tangent = GetEndTangent();
			return GetEndPoint();
		}
		int num = Mathf.FloorToInt(distance);
		if (LUTValues.Count > num)
		{
			int num2 = -1;
			while (num2 < 0 && (float)num > 0f)
			{
				LUTEntry lUTEntry = LUTValues[num];
				for (int i = 0; i < lUTEntry.points.Count && !(lUTEntry.points[i].distance > distance); i++)
				{
					num2 = i;
				}
				if (num2 < 0)
				{
					num--;
				}
			}
			float a;
			Vector3 vector;
			if (num2 < 0)
			{
				a = 0f;
				vector = GetStartPoint();
			}
			else
			{
				LUTEntry.LUTPoint lUTPoint = LUTValues[num].points[num2];
				a = lUTPoint.distance;
				vector = lUTPoint.pos;
			}
			num2 = -1;
			while (num2 < 0 && num < LUTValues.Count)
			{
				LUTEntry lUTEntry2 = LUTValues[num];
				for (int j = 0; j < lUTEntry2.points.Count; j++)
				{
					if (lUTEntry2.points[j].distance > distance)
					{
						num2 = j;
						break;
					}
				}
				if (num2 < 0)
				{
					num++;
				}
			}
			float b;
			Vector3 vector2;
			if (num2 < 0)
			{
				b = Length;
				vector2 = GetEndPoint();
			}
			else
			{
				LUTEntry.LUTPoint lUTPoint2 = LUTValues[num].points[num2];
				b = lUTPoint2.distance;
				vector2 = lUTPoint2.pos;
			}
			float t = Mathf.InverseLerp(a, b, distance);
			tangent = (vector2 - vector).normalized;
			return Vector3.Lerp(vector, vector2, t);
		}
		tangent = GetEndTangent();
		return GetEndPoint();
	}

	public void SetDefaultTangents(WorldSpline worldSpline)
	{
		PathInterpolator pathInterpolator = new PathInterpolator(worldSpline.points, worldSpline.tangents);
		pathInterpolator.RecalculateTangents();
		worldSpline.tangents = pathInterpolator.Tangents;
	}

	public bool DetectSplineProblems(WorldSpline worldSpline)
	{
		bool result = false;
		Vector3 to = GetTangentCubicHermite(0f);
		for (float num = 0.05f; num <= Length; num += 0.05f)
		{
			Vector3 tangentCubicHermite = GetTangentCubicHermite(num);
			float num2 = Vector3.Angle(tangentCubicHermite, to);
			if (num2 > 5f)
			{
				if (worldSpline != null)
				{
					Vector3 tangent;
					Vector3 pointAndTangentCubicHermiteWorld = worldSpline.GetPointAndTangentCubicHermiteWorld(num, out tangent);
					Debug.DrawRay(pointAndTangentCubicHermiteWorld, tangent, Color.red, 30f);
					Debug.DrawRay(pointAndTangentCubicHermiteWorld, Vector3.up, Color.red, 30f);
				}
				Debug.Log($"Spline may have a too-sharp bend at {num / Length:P0}. Angle change: " + num2);
				result = true;
			}
			to = tangentCubicHermite;
		}
		return result;
	}

	private void CreateLookupTable(WorldSpline worldSpline)
	{
		PathInterpolator pathInterpolator = new PathInterpolator(worldSpline.points, worldSpline.tangents);
		Vector3 b = pathInterpolator.GetPointCubicHermite(0f);
		Length = 0f;
		AddEntry(0f, GetStartPoint());
		Vector3 pointCubicHermite;
		for (float num = worldSpline.lutInterval; num < pathInterpolator.Length; num += worldSpline.lutInterval)
		{
			pointCubicHermite = pathInterpolator.GetPointCubicHermite(num);
			Length += Vector3.Distance(pointCubicHermite, b);
			AddEntry(Length, pathInterpolator.GetPointCubicHermite(num));
			b = pointCubicHermite;
		}
		pointCubicHermite = GetEndPoint();
		Length += Vector3.Distance(pointCubicHermite, b);
		AddEntry(Length, pointCubicHermite);
	}

	private void AddEntry(float distance, Vector3 pos)
	{
		int num = Mathf.FloorToInt(distance);
		if (LUTValues.Count < num + 1)
		{
			for (int i = LUTValues.Count; i < num + 1; i++)
			{
				LUTValues.Add(new LUTEntry());
			}
		}
		LUTValues[num].points.Add(new LUTEntry.LUTPoint(distance, pos));
	}
}
