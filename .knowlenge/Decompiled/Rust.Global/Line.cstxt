using UnityEngine;

public struct Line
{
	public Vector3 point0;

	public Vector3 point1;

	public float Length => Vector3.Distance(point0, point1);

	public float LengthSqr => Vector3.SqrMagnitude(point1 - point0);

	public Line(Vector3 point0, Vector3 point1)
	{
		this.point0 = point0;
		this.point1 = point1;
	}

	public Line(Vector3 origin, Vector3 direction, float length)
	{
		point0 = origin;
		point1 = origin + direction * length;
	}

	public bool Trace(Ray ray, float radius, out RaycastHit hit, float maxDistance = float.PositiveInfinity)
	{
		hit = default(RaycastHit);
		if (radius <= 0f)
		{
			return false;
		}
		Vector3 vector = point1 - point0;
		Vector3 direction = ray.direction;
		Vector3 rhs = point0 - ray.origin;
		float num = Vector3.Dot(vector, vector);
		float num2 = Vector3.Dot(vector, direction);
		float num3 = Vector3.Dot(direction, rhs);
		float num4 = num - num2 * num2;
		float num5 = 0f;
		float num6 = num3;
		if (num4 >= Mathf.Epsilon)
		{
			float num7 = Vector3.Dot(vector, rhs);
			float num8 = 1f / num4;
			num5 = num8 * (num2 * num3 - num7);
			num6 = num8 * (num * num3 - num2 * num7);
			num5 = Mathf.Clamp01(num5);
		}
		if (num6 < 0f || num6 > maxDistance)
		{
			return false;
		}
		Vector3 vector2 = point0 + num5 * vector;
		Vector3 vector3 = ray.origin + num6 * direction - vector2;
		float magnitude = vector3.magnitude;
		if (magnitude > radius)
		{
			return false;
		}
		hit.point = vector2;
		hit.normal = vector3 / magnitude;
		hit.distance = Vector3.Distance(ray.origin, hit.point);
		return true;
	}

	public Vector3 ClosestPoint(Vector3 pos)
	{
		Vector3 vector = point1 - point0;
		float magnitude = vector.magnitude;
		if (magnitude < 0.001f)
		{
			return point0;
		}
		Vector3 vector2 = vector / magnitude;
		return point0 + Mathf.Clamp(Vector3.Dot(pos - point0, vector2), 0f, magnitude) * vector2;
	}

	public Vector3 ClosestPoint2D(Vector3 pos)
	{
		Vector3 vector = point1 - point0;
		float magnitude = vector.magnitude;
		if (magnitude < 0.001f)
		{
			return point0;
		}
		float num = vector.Magnitude2D();
		Vector3 vector2 = vector / magnitude;
		return point0 + Mathf.Clamp(Vector3.Dot(pos.XZ3D() - point0.XZ3D(), vector2.XZ3D()), 0f, num) * (magnitude / num) * vector2;
	}

	public float Distance(Vector3 pos)
	{
		return (pos - ClosestPoint(pos)).magnitude;
	}

	public float SqrDistance(Vector3 pos)
	{
		return (pos - ClosestPoint(pos)).sqrMagnitude;
	}

	public Vector3 ClosestPoint(in Line other)
	{
		ClosestPoints(in other, out var closestThis, out var _);
		return closestThis;
	}

	public void ClosestPoints(in Line other, out Vector3 closestThis, out Vector3 closestOther)
	{
		Vector3 vector = point1 - point0;
		Vector3 vector2 = other.point1 - other.point0;
		Vector3 rhs = point0 - other.point0;
		float sqrMagnitude = vector.sqrMagnitude;
		float sqrMagnitude2 = vector2.sqrMagnitude;
		float num = Vector3.Dot(vector2, rhs);
		if (sqrMagnitude <= Mathf.Epsilon && sqrMagnitude2 <= Mathf.Epsilon)
		{
			closestThis = point0;
			closestOther = other.point0;
			return;
		}
		float num2 = 0f;
		float num3 = 0f;
		if (sqrMagnitude <= Mathf.Epsilon)
		{
			num2 = 0f;
			num3 = Mathf.Clamp01(num / sqrMagnitude2);
		}
		else
		{
			float num4 = Vector3.Dot(vector, rhs);
			if (sqrMagnitude2 <= Mathf.Epsilon)
			{
				num3 = 0f;
				num2 = Mathf.Clamp01((0f - num4) / sqrMagnitude);
			}
			else
			{
				float num5 = Vector3.Dot(vector, vector2);
				float num6 = sqrMagnitude * sqrMagnitude2 - num5 * num5;
				num2 = ((num6 == 0f) ? 0f : Mathf.Clamp01((num5 * num - num4 * sqrMagnitude2) / num6));
				num3 = num5 * num2 + num;
				if (num3 < 0f)
				{
					num3 = 0f;
					num2 = Mathf.Clamp01((0f - num4) / sqrMagnitude);
				}
				else if (num3 > sqrMagnitude2)
				{
					num3 = 1f;
					num2 = Mathf.Clamp01((num5 - num4) / sqrMagnitude);
				}
				else
				{
					num3 /= sqrMagnitude2;
				}
			}
		}
		closestThis = point0 + vector * num2;
		closestOther = other.point0 + vector2 * num3;
	}

	public float Distance(Line other)
	{
		ClosestPoints(in other, out var closestThis, out var closestOther);
		return Vector3.Distance(closestThis, closestOther);
	}

	public float SqrDistance(Line other)
	{
		ClosestPoints(in other, out var closestThis, out var closestOther);
		return Vector3.SqrMagnitude(closestThis - closestOther);
	}
}
