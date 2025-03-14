using UnityEngine;

public struct Sphere
{
	public Vector3 position;

	public float radius;

	public Sphere(Vector3 position, float radius)
	{
		this.position = position;
		this.radius = radius;
	}

	public bool Contains(Vector3 target)
	{
		return ClosestPoint(target) == target;
	}

	public Vector3 ClosestPoint(Vector3 target)
	{
		Vector3 result = target;
		Vector3 vector = target - position;
		float magnitude = vector.magnitude;
		if (magnitude <= radius)
		{
			return result;
		}
		float num = radius / magnitude;
		result.x = position.x + vector.x * num;
		result.y = position.y + vector.y * num;
		result.z = position.z + vector.z * num;
		return result;
	}

	public void Move(Vector3 direction, float distance, int layerMask = 0)
	{
		RaycastHit hitInfo;
		bool flag = Physics.SphereCast(position, radius, direction, out hitInfo, distance, layerMask);
		if ((!(hitInfo.collider != null) || ((int)hitInfo.collider.excludeLayers & 0x1000) == 0) && layerMask != 0 && flag)
		{
			position += direction * hitInfo.distance;
		}
		else
		{
			position += direction * distance;
		}
	}

	public bool Trace(Ray ray, out RaycastHit hit, float maxDistance = float.PositiveInfinity)
	{
		hit = default(RaycastHit);
		if (radius <= 0f)
		{
			return false;
		}
		float num = 1f;
		float num2 = 2f * Vector3.Dot(ray.direction, ray.origin - position);
		float num3 = (ray.origin - position).sqrMagnitude - radius * radius;
		float num4 = num2 * num2 - 4f * num * num3;
		if (num4 < 0f)
		{
			return false;
		}
		float num5 = Mathf.Sqrt(num4);
		float num6 = 2f * num;
		float num7 = 0f - num2;
		float num8 = (num7 - num5) / num6;
		if (num8 >= 0f)
		{
			if (num8 <= maxDistance)
			{
				hit.point = ray.origin + num8 * ray.direction;
				hit.normal = (hit.point - position) / radius;
				hit.distance = num8;
				return true;
			}
			return false;
		}
		if ((num7 + num5) / num6 >= 0f)
		{
			hit.point = ray.origin;
			hit.normal = (hit.point - position).normalized;
			hit.distance = 0f;
			return true;
		}
		return false;
	}
}
