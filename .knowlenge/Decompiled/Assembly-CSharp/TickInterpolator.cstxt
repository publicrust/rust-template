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
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		index = 0;
		CurrentPoint = StartPoint;
	}

	public void Reset(Vector3 point)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		points.Clear();
		index = 0;
		Length = 0f;
		CurrentPoint = (StartPoint = (EndPoint = point));
	}

	public void AddPoint(Vector3 point)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		Segment item = new Segment(EndPoint, point);
		points.Add(item);
		Length += item.length;
		EndPoint = item.point;
	}

	public bool MoveNext(float distance)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < points.Count; i++)
		{
			Segment value = points[i];
			value.point = ((Matrix4x4)(ref matrix)).MultiplyPoint3x4(value.point);
			points[i] = value;
		}
		CurrentPoint = ((Matrix4x4)(ref matrix)).MultiplyPoint3x4(CurrentPoint);
		StartPoint = ((Matrix4x4)(ref matrix)).MultiplyPoint3x4(StartPoint);
		EndPoint = ((Matrix4x4)(ref matrix)).MultiplyPoint3x4(EndPoint);
	}
}
