using System.Collections.Generic;
using UnityEngine;

public class TickInterpolator
{
	private struct Segment
	{
		public Vector3 point;

		public readonly float length;

		public Segment(Vector3 a, Vector3 b)
		{
			point = b;
			length = Vector3.Distance(a, b);
		}
	}

	private readonly List<Segment> points = new List<Segment>();

	private int index;

	public float Length;

	public Vector3 CurrentPoint;

	public Vector3 StartPoint;

	public Vector3 EndPoint;

	public int Count => points.Count;

	public void Reset()
	{
		index = 0;
		CurrentPoint = StartPoint;
	}

	public void Reset(Vector3 point)
	{
		points.Clear();
		index = 0;
		Length = 0f;
		CurrentPoint = (StartPoint = (EndPoint = point));
	}

	public void AddPoint(Vector3 point)
	{
		Segment item = new Segment(EndPoint, point);
		points.Add(item);
		Length += item.length;
		EndPoint = item.point;
	}

	public bool MoveNext(float distance)
	{
		float num = 0f;
		while (num < distance && index < points.Count)
		{
			Segment segment = points[index];
			CurrentPoint = segment.point;
			num += segment.length;
			index++;
		}
		return num > 0f;
	}

	public bool HasNext()
	{
		return index < points.Count;
	}

	public void TransformEntries(Matrix4x4 matrix)
	{
		for (int i = 0; i < points.Count; i++)
		{
			Segment value = points[i];
			value.point = matrix.MultiplyPoint3x4(value.point);
			points[i] = value;
		}
		CurrentPoint = matrix.MultiplyPoint3x4(CurrentPoint);
		StartPoint = matrix.MultiplyPoint3x4(StartPoint);
		EndPoint = matrix.MultiplyPoint3x4(EndPoint);
	}
}
