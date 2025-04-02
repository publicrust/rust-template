using UnityEngine;

public struct Triangle
{
	public Vector3 point0;

	public Vector3 point1;

	public Vector3 point2;

	public Vector3 Normal
	{
		get
		{
			Vector3 lhs = point1 - point0;
			Vector3 rhs = point2 - point0;
			return Vector3.Cross(lhs, rhs).normalized;
		}
	}

	public Vector3 Center => (point0 + point1 + point2) / 3f;

	public Triangle(Vector3 point0, Vector3 point1, Vector3 point2)
	{
		this.point0 = point0;
		this.point1 = point1;
		this.point2 = point2;
	}

	public bool Trace(Ray ray, float radius, out RaycastHit hit, float maxDistance = float.PositiveInfinity)
	{
		hit = default(RaycastHit);
		Vector3 vector = point1 - point0;
		Vector3 vector2 = point2 - point0;
		Vector3 rhs = Vector3.Cross(ray.direction, vector2);
		float num = Vector3.Dot(vector, rhs);
		if (num > 0f - Mathf.Epsilon && num < Mathf.Epsilon)
		{
			return false;
		}
		float num2 = 1f / num;
		Vector3 lhs = ray.origin - point0;
		float num3 = Vector3.Dot(lhs, rhs) * num2;
		if (num3 < 0f)
		{
			return LineTest(point0, point2, ray, radius, out hit, maxDistance);
		}
		if (num3 > 1f)
		{
			return LineTest(point1, point2, ray, radius, out hit, maxDistance);
		}
		Vector3 rhs2 = Vector3.Cross(lhs, vector);
		float num4 = Vector3.Dot(ray.direction, rhs2) * num2;
		if (num4 < 0f)
		{
			return LineTest(point0, point1, ray, radius, out hit, maxDistance);
		}
		if (num3 + num4 > 1f)
		{
			return LineTest(point1, point2, ray, radius, out hit, maxDistance);
		}
		float num5 = Vector3.Dot(vector2, rhs2) * num2;
		if (num5 < 0f || num5 > maxDistance)
		{
			return false;
		}
		Vector3 point = ray.origin + num5 * ray.direction;
		hit.point = point;
		hit.distance = num5;
		hit.normal = Vector3.Cross(vector, vector2).normalized;
		return true;
	}

	private bool LineTest(Vector3 a, Vector3 b, Ray ray, float radius, out RaycastHit hit, float maxDistance)
	{
		if (new Line(point0, point2).Trace(ray, radius, out hit, maxDistance))
		{
			hit.normal = Normal;
			return true;
		}
		return false;
	}

	public Vector3 ClosestPoint(Vector3 pos)
	{
		Vector3 rhs = point0 - pos;
		Vector3 vector = point1 - point0;
		Vector3 vector2 = point2 - point0;
		float num = Vector3.Dot(vector, vector);
		float num2 = Vector3.Dot(vector, vector2);
		float num3 = Vector3.Dot(vector2, vector2);
		float num4 = Vector3.Dot(vector, rhs);
		float num5 = Vector3.Dot(vector2, rhs);
		float num6 = num * num3 - num2 * num2;
		float num7 = num2 * num5 - num3 * num4;
		float num8 = num2 * num4 - num * num5;
		if (num7 + num8 < num6)
		{
			if (num7 < 0f)
			{
				if (num8 < 0f)
				{
					if (num4 < 0f)
					{
						num7 = Mathf.Clamp01((0f - num4) / num);
						num8 = 0f;
					}
					else
					{
						num7 = 0f;
						num8 = Mathf.Clamp01((0f - num5) / num3);
					}
				}
				else
				{
					num7 = 0f;
					num8 = Mathf.Clamp01((0f - num5) / num3);
				}
			}
			else if (num8 < 0f)
			{
				num7 = Mathf.Clamp01((0f - num4) / num);
				num8 = 0f;
			}
			else
			{
				float num9 = 1f / num6;
				num7 *= num9;
				num8 *= num9;
			}
		}
		else if (num7 < 0f)
		{
			float num10 = num2 + num4;
			float num11 = num3 + num5;
			if (num11 > num10)
			{
				float num12 = num11 - num10;
				float num13 = num - 2f * num2 + num3;
				num7 = Mathf.Clamp01(num12 / num13);
				num8 = 1f - num7;
			}
			else
			{
				num8 = Mathf.Clamp01((0f - num5) / num3);
				num7 = 0f;
			}
		}
		else if (num8 < 0f)
		{
			if (num + num4 > num2 + num5)
			{
				float num14 = num3 + num5 - num2 - num4;
				float num15 = num - 2f * num2 + num3;
				num7 = Mathf.Clamp01(num14 / num15);
				num8 = 1f - num7;
			}
			else
			{
				num7 = Mathf.Clamp01((0f - num5) / num3);
				num8 = 0f;
			}
		}
		else
		{
			float num16 = num3 + num5 - num2 - num4;
			float num17 = num - 2f * num2 + num3;
			num7 = Mathf.Clamp01(num16 / num17);
			num8 = 1f - num7;
		}
		return point0 + num7 * vector + num8 * vector2;
	}

	public float Distance(Vector3 pos)
	{
		return (pos - ClosestPoint(pos)).magnitude;
	}

	public float SqrDistance(Vector3 pos)
	{
		return (pos - ClosestPoint(pos)).sqrMagnitude;
	}

	public float Area()
	{
		float num = Vector3.Distance(point0, point1);
		float num2 = Vector3.Distance(point1, point2);
		float num3 = Vector3.Distance(point2, point0);
		return 0.25f * Mathf.Sqrt((num + num2 + num3) * (0f - num + num2 + num3) * (num - num2 + num3) * (num + num2 - num3));
	}
}
