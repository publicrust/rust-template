using UnityEngine;

public struct Capsule
{
	public Vector3 position;

	public float radius;

	public float extent;

	public Capsule(Vector3 position, float radius, float extent)
	{
		this.position = position;
		this.radius = radius;
		this.extent = extent;
	}

	public bool Contains(Vector3 target)
	{
		return ClosestPoint(target) == target;
	}

	public Vector3 ClosestPoint(Vector3 target)
	{
		Vector3 result = target;
		Vector3 v = target - position;
		float num = v.Magnitude2D();
		if (num > radius)
		{
			float num2 = radius / num;
			result.x = position.x + v.x * num2;
			result.z = position.z + v.z * num2;
		}
		result.y = Mathf.Clamp(target.y, position.y - extent, position.y + extent);
		return result;
	}

	public void Move(Vector3 direction, float distance, int layerMask = 0)
	{
		Vector3 point = position + Vector3.up * (extent - radius);
		Vector3 point2 = position - Vector3.up * (extent - radius);
		if (layerMask != 0 && Physics.CapsuleCast(point, point2, radius, direction, out var hitInfo, distance, layerMask))
		{
			position += direction * hitInfo.distance;
		}
		else
		{
			position += direction * distance;
		}
	}

	public bool Trace(Ray ray, out RaycastHit hit, float rayRadius = 0f, float maxDistance = float.PositiveInfinity)
	{
		hit = default(RaycastHit);
		float num = radius + rayRadius;
		float num2 = extent + rayRadius - num;
		Vector3 vector = position + Vector3.down * num2;
		Vector3 vector2 = position + Vector3.up * num2;
		if (num2 < Mathf.Epsilon * 2f)
		{
			return new Sphere(position, radius).Trace(ray, out hit, maxDistance);
		}
		Vector3 vector3 = vector2 - vector;
		Vector3 vector4 = ray.origin - vector;
		float num3 = Vector3.Dot(vector3, vector3);
		float num4 = Vector3.Dot(vector3, ray.direction);
		float num5 = Vector3.Dot(vector3, vector4);
		float num6 = Vector3.Dot(ray.direction, vector4);
		float num7 = Vector3.Dot(vector4, vector4);
		float num8 = num3 - num4 * num4;
		float num9 = num3 * num6 - num5 * num4;
		float num10 = num3 * num7 - num5 * num5 - num * num * num3;
		float num11 = num9 * num9 - num8 * num10;
		if ((double)num11 >= 0.0)
		{
			float num12 = (0f - num9 - Mathf.Sqrt(num11)) / num8;
			float num13 = num5 + num12 * num4;
			if ((double)num13 > 0.0 && num13 < num3)
			{
				hit.distance = num12;
				if (hit.distance < 0f || hit.distance > maxDistance)
				{
					return false;
				}
				hit.point = ray.origin + ray.direction * num12;
				Vector3 vector5 = hit.point - vector;
				float num14 = Mathf.Clamp(Vector3.Dot(vector5, vector3) / Vector3.Dot(vector3, vector3), 0f, 1f);
				hit.normal = (vector5 - num14 * vector3) / num;
				hit.point -= hit.normal * rayRadius;
				return true;
			}
			Vector3 vector6 = (((double)num13 <= 0.0) ? vector4 : (ray.origin - vector2));
			num9 = Vector3.Dot(ray.direction, vector6);
			num10 = Vector3.Dot(vector6, vector6) - num * num;
			num11 = num9 * num9 - num10;
			if ((double)num11 > 0.0)
			{
				hit.distance = 0f - num9 - Mathf.Sqrt(num11);
				if (hit.distance < 0f || hit.distance > maxDistance)
				{
					return false;
				}
				hit.point = ray.origin + ray.direction * hit.distance;
				Vector3 vector7 = hit.point - vector;
				float num15 = Mathf.Clamp(Vector3.Dot(vector7, vector3) / Vector3.Dot(vector3, vector3), 0f, 1f);
				hit.normal = (vector7 - num15 * vector3) / num;
				hit.point -= hit.normal * rayRadius;
				hit.distance = hit.distance;
				return true;
			}
		}
		return false;
	}
}
