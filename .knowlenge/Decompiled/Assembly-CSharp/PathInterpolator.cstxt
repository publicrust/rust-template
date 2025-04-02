using System;
using System.Collections.Generic;
using UnityEngine;

public class PathInterpolator
{
	public Vector3[] Points;

	public Vector3[] Tangents;

	protected bool initialized;

	public int MinIndex { get; set; }

	public int MaxIndex { get; set; }

	public virtual float Length { get; private set; }

	public virtual float StepSize { get; private set; }

	public bool Circular { get; private set; }

	public int DefaultMinIndex => 0;

	public int DefaultMaxIndex => Points.Length - 1;

	public float StartOffset => Length * (float)(MinIndex - DefaultMinIndex) / (float)(DefaultMaxIndex - DefaultMinIndex);

	public float EndOffset => Length * (float)(DefaultMaxIndex - MaxIndex) / (float)(DefaultMaxIndex - DefaultMinIndex);

	public PathInterpolator(Vector3[] points)
	{
		if (points.Length < 2)
		{
			throw new ArgumentException("Point list too short.");
		}
		Points = points;
		MinIndex = DefaultMinIndex;
		MaxIndex = DefaultMaxIndex;
		Circular = Vector3.Distance(points[0], points[^1]) < 0.1f;
	}

	public PathInterpolator(Vector3[] points, Vector3[] tangents)
		: this(points)
	{
		if (tangents.Length != points.Length)
		{
			throw new ArgumentException("Points and tangents lengths must match. Points: " + points.Length + " Tangents: " + tangents.Length);
		}
		Tangents = tangents;
		RecalculateLength();
		initialized = true;
	}

	public void RecalculateTangents()
	{
		if (Tangents == null || Tangents.Length != Points.Length)
		{
			Tangents = new Vector3[Points.Length];
		}
		for (int i = 0; i < Points.Length; i++)
		{
			int num = i - 1;
			int num2 = i + 1;
			if (num < 0)
			{
				num = (Circular ? (Points.Length - 2) : 0);
			}
			if (num2 > Points.Length - 1)
			{
				num2 = (Circular ? 1 : (Points.Length - 1));
			}
			Vector3 vector = Points[num];
			Vector3 vector2 = Points[num2];
			Tangents[i] = (vector2 - vector).normalized;
		}
		RecalculateLength();
		initialized = true;
	}

	public void RecalculateLength()
	{
		float num = 0f;
		for (int i = 0; i < Points.Length - 1; i++)
		{
			Vector3 vector = Points[i];
			Vector3 vector2 = Points[i + 1];
			num += (vector2 - vector).magnitude;
		}
		Length = num;
		StepSize = num / (float)Points.Length;
	}

	public void Resample(float distance)
	{
		float num = 0f;
		for (int i = 0; i < Points.Length - 1; i++)
		{
			Vector3 vector = Points[i];
			Vector3 vector2 = Points[i + 1];
			num += (vector2 - vector).magnitude;
		}
		int num2 = Mathf.RoundToInt(num / distance);
		if (num2 < 2)
		{
			return;
		}
		distance = num / (float)(num2 - 1);
		List<Vector3> list = new List<Vector3>(num2);
		float num3 = 0f;
		for (int j = 0; j < Points.Length - 1; j++)
		{
			int num4 = j;
			int num5 = j + 1;
			Vector3 vector3 = Points[num4];
			Vector3 vector4 = Points[num5];
			float num6 = (vector4 - vector3).magnitude;
			if (num4 == 0)
			{
				list.Add(vector3);
			}
			while (num3 + num6 > distance)
			{
				float num7 = distance - num3;
				float t = num7 / num6;
				Vector3 vector5 = Vector3.Lerp(vector3, vector4, t);
				list.Add(vector5);
				vector3 = vector5;
				num3 = 0f;
				num6 -= num7;
			}
			num3 += num6;
			if (num5 == Points.Length - 1 && num3 > distance * 0.5f)
			{
				list.Add(vector4);
			}
		}
		if (list.Count >= 2)
		{
			Points = list.ToArray();
			MinIndex = DefaultMinIndex;
			MaxIndex = DefaultMaxIndex;
			initialized = false;
		}
	}

	public void Smoothen(int iterations, Func<int, float> filter = null)
	{
		Smoothen(iterations, Vector3.one, filter);
	}

	public void Smoothen(int iterations, Vector3 multipliers, Func<int, float> filter = null)
	{
		for (int i = 0; i < iterations; i++)
		{
			for (int j = MinIndex + ((!Circular) ? 1 : 0); j <= MaxIndex - 1; j += 2)
			{
				SmoothenIndex(j, multipliers, filter);
			}
			for (int k = MinIndex + (Circular ? 1 : 2); k <= MaxIndex - 1; k += 2)
			{
				SmoothenIndex(k, multipliers, filter);
			}
		}
		initialized = false;
	}

	private void SmoothenIndex(int i, Vector3 multipliers, Func<int, float> filter = null)
	{
		int num = i - 1;
		int num2 = i + 1;
		if (i == 0)
		{
			num = Points.Length - 2;
		}
		Vector3 vector = Points[num];
		Vector3 vector2 = Points[i];
		Vector3 vector3 = Points[num2];
		Vector3 vector4 = (vector + vector2 + vector2 + vector3) * 0.25f;
		if (filter != null)
		{
			multipliers *= filter(i);
		}
		if (multipliers != Vector3.one)
		{
			vector4.x = Mathf.LerpUnclamped(vector2.x, vector4.x, multipliers.x);
			vector4.y = Mathf.LerpUnclamped(vector2.y, vector4.y, multipliers.y);
			vector4.z = Mathf.LerpUnclamped(vector2.z, vector4.z, multipliers.z);
		}
		Points[i] = vector4;
		if (i == 0)
		{
			Points[Points.Length - 1] = Points[0];
		}
	}

	public void Straighten(int diStart, int diEnd)
	{
		Vector3 a = Points[diStart];
		Vector3 b = Points[diEnd];
		Vector3 a2 = Tangents[diStart];
		Vector3 b2 = Tangents[diEnd];
		float num = 1f / (float)(diEnd - diStart);
		for (int i = diStart + 1; i <= diEnd - 1; i++)
		{
			float t = (float)(i - diStart) * num;
			Points[i] = Vector3.Lerp(a, b, t);
			Tangents[i] = Vector3.Slerp(a2, b2, t);
		}
	}

	public Vector3 GetStartPoint()
	{
		return Points[MinIndex];
	}

	public Vector3 GetEndPoint()
	{
		return Points[MaxIndex];
	}

	public Vector3 GetStartTangent()
	{
		if (!initialized)
		{
			throw new Exception("Tangents have not been calculated yet or are outdated.");
		}
		return Tangents[MinIndex];
	}

	public Vector3 GetEndTangent()
	{
		if (!initialized)
		{
			throw new Exception("Tangents have not been calculated yet or are outdated.");
		}
		return Tangents[MaxIndex];
	}

	public Vector3 GetPointByIndex(int i)
	{
		if (!Circular)
		{
			return Points[Mathf.Clamp(i, 0, Points.Length - 1)];
		}
		return Points[(i % Points.Length + Points.Length) % Points.Length];
	}

	public Vector3 GetTangentByIndex(int i)
	{
		return (GetPoint(i + 1) - GetPoint(i - 1)).normalized;
	}

	public int GetPrevIndex(float distance)
	{
		return Mathf.FloorToInt(distance / Length * (float)(Points.Length - 1));
	}

	public int GetNextIndex(float distance)
	{
		return Mathf.CeilToInt(distance / Length * (float)(Points.Length - 1));
	}

	public Vector3 GetPoint(int index)
	{
		if (Length == 0f)
		{
			return GetStartPoint();
		}
		if (index <= MinIndex)
		{
			return GetStartPoint();
		}
		if (index >= MaxIndex)
		{
			return GetEndPoint();
		}
		return Points[index];
	}

	public Vector3 GetPoint(float distance)
	{
		if (Length == 0f)
		{
			return GetStartPoint();
		}
		float num = distance / Length * (float)(Points.Length - 1);
		int num2 = (int)num;
		if (num <= (float)MinIndex)
		{
			return GetStartPoint();
		}
		if (num >= (float)MaxIndex)
		{
			return GetEndPoint();
		}
		Vector3 a = Points[num2];
		Vector3 b = Points[num2 + 1];
		float t = num - (float)num2;
		return Vector3.Lerp(a, b, t);
	}

	public virtual Vector3 GetTangent(float distance)
	{
		if (!initialized)
		{
			throw new Exception("Tangents have not been calculated yet or are outdated.");
		}
		if (Length == 0f)
		{
			return GetStartPoint();
		}
		float num = distance / Length * (float)(Tangents.Length - 1);
		int num2 = (int)num;
		if (num <= (float)MinIndex)
		{
			return GetStartTangent();
		}
		if (num >= (float)MaxIndex)
		{
			return GetEndTangent();
		}
		Vector3 a = Tangents[num2];
		Vector3 b = Tangents[num2 + 1];
		float t = num - (float)num2;
		return Vector3.Slerp(a, b, t);
	}

	public virtual Vector3 GetPointCubicHermite(float distance)
	{
		if (!initialized)
		{
			throw new Exception("Tangents have not been calculated yet or are outdated.");
		}
		if (Length == 0f)
		{
			return GetStartPoint();
		}
		float num = distance / Length * (float)(Points.Length - 1);
		int num2 = (int)num;
		if (num <= (float)MinIndex)
		{
			return GetStartPoint();
		}
		if (num >= (float)MaxIndex)
		{
			return GetEndPoint();
		}
		Vector3 vector = Points[num2];
		Vector3 vector2 = Points[num2 + 1];
		Vector3 vector3 = Tangents[num2] * StepSize;
		Vector3 vector4 = Tangents[num2 + 1] * StepSize;
		float num3 = num - (float)num2;
		float num4 = num3 * num3;
		float num5 = num3 * num4;
		return (2f * num5 - 3f * num4 + 1f) * vector + (num5 - 2f * num4 + num3) * vector3 + (-2f * num5 + 3f * num4) * vector2 + (num5 - num4) * vector4;
	}
}
