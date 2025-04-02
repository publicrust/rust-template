using UnityEngine;

public struct AABB
{
	public Vector3 position;

	public Vector3 extents;

	public AABB(Vector3 position, Vector3 size)
	{
		this.position = position;
		extents = size * 0.5f;
	}

	public bool Contains(Vector3 target)
	{
		return ClosestPoint(target) == target;
	}

	public Vector3 ClosestPoint(Vector3 target)
	{
		Vector3 result = target;
		float num = position.x - extents.x;
		float num2 = position.x + extents.x;
		if (target.x < num)
		{
			result.x = num;
		}
		else if (target.x > num2)
		{
			result.x = num2;
		}
		float num3 = position.y - extents.y;
		float num4 = position.y + extents.y;
		if (target.y < num3)
		{
			result.y = num3;
		}
		else if (target.y > num4)
		{
			result.y = num4;
		}
		float num5 = position.z - extents.z;
		float num6 = position.z + extents.z;
		if (target.z < num5)
		{
			result.z = num5;
		}
		else if (target.z > num6)
		{
			result.z = num6;
		}
		return result;
	}

	public bool Trace(Ray ray, out RaycastHit hit, float radius = 0f, float maxDistance = float.PositiveInfinity)
	{
		Vector3 vector = position - (extents + Vector3.one * radius);
		Vector3 vector2 = position + (extents + Vector3.one * radius);
		hit = default(RaycastHit);
		float num = (vector.x - ray.origin.x) / ray.direction.x;
		float num2 = (vector2.x - ray.origin.x) / ray.direction.x;
		float num3 = (vector.y - ray.origin.y) / ray.direction.y;
		float num4 = (vector2.y - ray.origin.y) / ray.direction.y;
		float num5 = (vector.z - ray.origin.z) / ray.direction.z;
		float num6 = (vector2.z - ray.origin.z) / ray.direction.z;
		float num7 = ((num < num2) ? num : num2);
		float num8 = ((num3 < num4) ? num3 : num4);
		float num9 = ((num5 < num6) ? num5 : num6);
		float num10 = ((num > num2) ? num : num2);
		float num11 = ((num3 > num4) ? num3 : num4);
		float num12 = ((num5 > num6) ? num5 : num6);
		float num13 = ((num7 > num8) ? num7 : num8);
		float num14 = ((num10 < num11) ? num10 : num11);
		float num15 = ((num13 > num9) ? num13 : num9);
		float num16 = ((num14 < num12) ? num14 : num12);
		float num17 = ((num16 < 0f || num15 > num16) ? (-1f) : num15);
		if (num17 < 0f)
		{
			return false;
		}
		if (num17 == num)
		{
			hit.normal = new Vector3(-1f, 0f, 0f);
		}
		else if (num17 == num2)
		{
			hit.normal = new Vector3(1f, 0f, 0f);
		}
		else if (num17 == num3)
		{
			hit.normal = new Vector3(0f, -1f, 0f);
		}
		else if (num17 == num4)
		{
			hit.normal = new Vector3(0f, 1f, 0f);
		}
		else if (num17 == num5)
		{
			hit.normal = new Vector3(0f, 0f, -1f);
		}
		else
		{
			hit.normal = new Vector3(0f, 0f, 1f);
		}
		hit.point = ray.origin + ray.direction * num17 - hit.normal * radius;
		Vector3 vector3 = hit.point - position;
		vector3.x = Mathf.Clamp(vector3.x, 0f - extents.x, extents.x);
		vector3.y = Mathf.Clamp(vector3.y, 0f - extents.y, extents.y);
		vector3.z = Mathf.Clamp(vector3.z, 0f - extents.z, extents.z);
		hit.point = position + vector3;
		hit.distance = Vector3.Distance(ray.origin, hit.point);
		return hit.distance < maxDistance;
	}
}
