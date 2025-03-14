using UnityEngine;

public struct Cylinder
{
	public Vector3 position;

	public float radius;

	public float extent;

	public Cylinder(Vector3 position, float radius, float extent)
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
}
