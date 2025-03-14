using UnityEngine;

public class TickHistory
{
	private Deque<Vector3> points = new Deque<Vector3>();

	public int Count => points.Count;

	public void Reset()
	{
		points.Clear();
	}

	public void Reset(Vector3 point)
	{
		Reset();
		AddPoint(point);
	}

	public float Distance(BasePlayer player, Vector3 point)
	{
		if (points.Count == 0)
		{
			return player.Distance(point);
		}
		Vector3 position = player.transform.position;
		Quaternion rotation = player.transform.rotation;
		Bounds bounds = player.bounds;
		Matrix4x4 tickHistoryMatrix = player.tickHistoryMatrix;
		float num = float.MaxValue;
		for (int i = 0; i < points.Count; i++)
		{
			Vector3 point2 = tickHistoryMatrix.MultiplyPoint3x4(points[i]);
			Vector3 point3 = ((i == points.Count - 1) ? position : tickHistoryMatrix.MultiplyPoint3x4(points[i + 1]));
			Vector3 position2 = new Line(point2, point3).ClosestPoint(point);
			num = Mathf.Min(num, new OBB(position2, rotation, bounds).Distance(point));
		}
		return num;
	}

	public void AddPoint(Vector3 point, int limit = -1)
	{
		while (limit > 0 && points.Count >= limit)
		{
			points.PopFront();
		}
		points.PushBack(point);
	}

	public void TransformEntries(Matrix4x4 matrix)
	{
		for (int i = 0; i < points.Count; i++)
		{
			Vector3 point = points[i];
			point = matrix.MultiplyPoint3x4(point);
			points[i] = point;
		}
	}
}
