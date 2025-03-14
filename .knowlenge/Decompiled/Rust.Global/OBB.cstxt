using UnityEngine;

public struct OBB
{
	public Quaternion rotation;

	public Vector3 position;

	public Vector3 extents;

	public Vector3 forward;

	public Vector3 right;

	public Vector3 up;

	public float reject;

	public OBB(Bounds bounds)
		: this(Vector3.zero, Vector3.one, Quaternion.identity, bounds)
	{
	}

	public OBB(Transform transform, Bounds bounds)
		: this(transform.position, transform.lossyScale, transform.rotation, bounds)
	{
	}

	public OBB(Vector3 position, Vector3 scale, Quaternion rotation, Bounds bounds)
	{
		this.rotation = rotation;
		this.position = position + rotation * Vector3.Scale(scale, bounds.center);
		extents = Vector3.Scale(scale, bounds.extents);
		forward = rotation * Vector3.forward;
		right = rotation * Vector3.right;
		up = rotation * Vector3.up;
		reject = extents.sqrMagnitude;
	}

	public OBB(Vector3 position, Quaternion rotation, Bounds bounds)
	{
		this.rotation = rotation;
		this.position = position + rotation * bounds.center;
		extents = bounds.extents;
		forward = rotation * Vector3.forward;
		right = rotation * Vector3.right;
		up = rotation * Vector3.up;
		reject = extents.sqrMagnitude;
	}

	public OBB(Vector3 position, Vector3 size, Quaternion rotation)
	{
		this.rotation = rotation;
		this.position = position;
		extents = size * 0.5f;
		forward = rotation * Vector3.forward;
		right = rotation * Vector3.right;
		up = rotation * Vector3.up;
		reject = extents.sqrMagnitude;
	}

	public void Transform(Vector3 position, Vector3 scale, Quaternion rotation)
	{
		this.rotation *= rotation;
		this.position = position + rotation * Vector3.Scale(scale, this.position);
		extents = Vector3.Scale(scale, extents);
	}

	public Vector3 GetPoint(float x, float y, float z)
	{
		return position + x * extents.x * right + y * extents.y * up + z * extents.z * forward;
	}

	public Bounds ToBounds()
	{
		Vector3 vector = extents.x * right;
		Vector3 vector2 = extents.y * up;
		Vector3 vector3 = extents.z * forward;
		Bounds result = new Bounds(position, Vector3.zero);
		result.Encapsulate(position + vector2 + vector + vector3);
		result.Encapsulate(position + vector2 + vector - vector3);
		result.Encapsulate(position + vector2 - vector + vector3);
		result.Encapsulate(position + vector2 - vector - vector3);
		result.Encapsulate(position - vector2 + vector + vector3);
		result.Encapsulate(position - vector2 + vector - vector3);
		result.Encapsulate(position - vector2 - vector + vector3);
		result.Encapsulate(position - vector2 - vector - vector3);
		return result;
	}

	public bool Contains(Vector3 target)
	{
		if ((target - position).sqrMagnitude > reject)
		{
			return false;
		}
		return ClosestPoint(target) == target;
	}

	public bool Intersects(OBB target)
	{
		Matrix4x4 matrix4x = Matrix4x4.Rotate(rotation);
		Matrix4x4 matrix4x2 = Matrix4x4.Rotate(target.rotation);
		Vector3 vector = matrix4x.inverse.MultiplyPoint3x4(target.position - position);
		Matrix4x4 matrix4x3 = matrix4x.transpose * matrix4x2;
		Matrix4x4 identity = Matrix4x4.identity;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				identity[i, j] = Mathf.Abs(matrix4x3[i, j]) + Mathf.Epsilon;
			}
		}
		if (Mathf.Abs(vector.x) > extents.x + target.extents.x * identity[0, 0] + target.extents.y * identity[0, 1] + target.extents.z * identity[0, 2])
		{
			return false;
		}
		if (Mathf.Abs(vector.y) > extents.y + target.extents.x * identity[1, 0] + target.extents.y * identity[1, 1] + target.extents.z * identity[1, 2])
		{
			return false;
		}
		if (Mathf.Abs(vector.z) > extents.z + target.extents.x * identity[2, 0] + target.extents.y * identity[2, 1] + target.extents.z * identity[2, 2])
		{
			return false;
		}
		if (Mathf.Abs(vector.x * matrix4x3[0, 0] + vector.y * matrix4x3[1, 0] + vector.z * matrix4x3[2, 0]) > extents.x * identity[0, 0] + extents.y * identity[1, 0] + extents.z * identity[2, 0] + target.extents.x)
		{
			return false;
		}
		if (Mathf.Abs(vector.x * matrix4x3[0, 1] + vector.y * matrix4x3[1, 1] + vector.z * matrix4x3[2, 1]) > extents.x * identity[0, 1] + extents.y * identity[1, 1] + extents.z * identity[2, 1] + target.extents.y)
		{
			return false;
		}
		if (Mathf.Abs(vector.x * matrix4x3[0, 2] + vector.y * matrix4x3[1, 2] + vector.z * matrix4x3[2, 2]) > extents.x * identity[0, 2] + extents.y * identity[1, 2] + extents.z * identity[2, 2] + target.extents.z)
		{
			return false;
		}
		if (Mathf.Abs(vector.z * matrix4x3[1, 0] - vector.y * matrix4x3[2, 0]) > extents.y * identity[2, 0] + extents.z * identity[1, 0] + target.extents.y * identity[0, 2] + target.extents.z * identity[0, 1])
		{
			return false;
		}
		if (Mathf.Abs(vector.z * matrix4x3[1, 1] - vector.y * matrix4x3[2, 1]) > extents.y * identity[2, 1] + extents.z * identity[1, 1] + target.extents.x * identity[0, 2] + target.extents.z * identity[0, 0])
		{
			return false;
		}
		if (Mathf.Abs(vector.z * matrix4x3[1, 2] - vector.y * matrix4x3[2, 2]) > extents.y * identity[2, 2] + extents.z * identity[1, 2] + target.extents.x * identity[0, 1] + target.extents.y * identity[0, 0])
		{
			return false;
		}
		if (Mathf.Abs(vector.x * matrix4x3[2, 0] - vector.z * matrix4x3[0, 0]) > extents.x * identity[2, 0] + extents.z * identity[0, 0] + target.extents.y * identity[1, 2] + target.extents.z * identity[1, 1])
		{
			return false;
		}
		if (Mathf.Abs(vector.x * matrix4x3[2, 1] - vector.z * matrix4x3[0, 1]) > extents.x * identity[2, 1] + extents.z * identity[0, 1] + target.extents.x * identity[1, 2] + target.extents.z * identity[1, 0])
		{
			return false;
		}
		if (Mathf.Abs(vector.x * matrix4x3[2, 2] - vector.z * matrix4x3[0, 2]) > extents.x * identity[2, 2] + extents.z * identity[0, 2] + target.extents.x * identity[1, 1] + target.extents.y * identity[1, 0])
		{
			return false;
		}
		if (Mathf.Abs(vector.y * matrix4x3[0, 0] - vector.x * matrix4x3[1, 0]) > extents.x * identity[1, 0] + extents.y * identity[0, 0] + target.extents.y * identity[2, 2] + target.extents.z * identity[2, 1])
		{
			return false;
		}
		if (Mathf.Abs(vector.y * matrix4x3[0, 1] - vector.x * matrix4x3[1, 1]) > extents.x * identity[1, 1] + extents.y * identity[0, 1] + target.extents.x * identity[2, 2] + target.extents.z * identity[2, 0])
		{
			return false;
		}
		if (Mathf.Abs(vector.y * matrix4x3[0, 2] - vector.x * matrix4x3[1, 2]) > extents.x * identity[1, 2] + extents.y * identity[0, 2] + target.extents.x * identity[2, 1] + target.extents.y * identity[2, 0])
		{
			return false;
		}
		return true;
	}

	public bool Intersects2D(OBB target)
	{
		target.position.y = position.y;
		return Intersects(target);
	}

	public bool Intersects(Ray ray)
	{
		RaycastHit hit;
		return Trace(ray, out hit);
	}

	public bool Trace(Ray ray, out RaycastHit hit, float maxDistance = float.PositiveInfinity)
	{
		hit = default(RaycastHit);
		Vector3 rhs = right;
		Vector3 rhs2 = up;
		Vector3 rhs3 = forward;
		float x = extents.x;
		float y = extents.y;
		float z = extents.z;
		Vector3 lhs = ray.origin - position;
		Vector3 direction = ray.direction;
		float num = Vector3.Dot(direction, rhs);
		float num2 = Vector3.Dot(direction, rhs2);
		float num3 = Vector3.Dot(direction, rhs3);
		float num4 = Vector3.Dot(lhs, rhs);
		float num5 = Vector3.Dot(lhs, rhs2);
		float num6 = Vector3.Dot(lhs, rhs3);
		float f;
		float f2;
		if (num > 0f)
		{
			f = (0f - x - num4) / num;
			f2 = (x - num4) / num;
		}
		else if (num < 0f)
		{
			f = (x - num4) / num;
			f2 = (0f - x - num4) / num;
		}
		else
		{
			f = float.MinValue;
			f2 = float.MaxValue;
		}
		float f3;
		float f4;
		if (num2 > 0f)
		{
			f3 = (0f - y - num5) / num2;
			f4 = (y - num5) / num2;
		}
		else if (num2 < 0f)
		{
			f3 = (y - num5) / num2;
			f4 = (0f - y - num5) / num2;
		}
		else
		{
			f3 = float.MinValue;
			f4 = float.MaxValue;
		}
		float f5;
		float f6;
		if (num3 > 0f)
		{
			f5 = (0f - z - num6) / num3;
			f6 = (z - num6) / num3;
		}
		else if (num3 < 0f)
		{
			f5 = (z - num6) / num3;
			f6 = (0f - z - num6) / num3;
		}
		else
		{
			f5 = float.MinValue;
			f6 = float.MaxValue;
		}
		float num7 = Mathx.Min(f2, f4, f6);
		if (num7 < 0f)
		{
			return false;
		}
		float num8 = Mathx.Max(f, f3, f5);
		if (num8 > num7)
		{
			return false;
		}
		float num9 = Mathf.Clamp(0f, num8, num7);
		if (num9 > maxDistance)
		{
			return false;
		}
		hit.point = ray.origin + ray.direction * num9;
		hit.distance = num9;
		return true;
	}

	public Vector3 ClosestPoint(Vector3 target)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		Vector3 result = position;
		Vector3 lhs = target - position;
		float num = Vector3.Dot(lhs, right);
		if (num > extents.x)
		{
			result += right * extents.x;
		}
		else if (num < 0f - extents.x)
		{
			result -= right * extents.x;
		}
		else
		{
			flag = true;
			result += right * num;
		}
		float num2 = Vector3.Dot(lhs, up);
		if (num2 > extents.y)
		{
			result += up * extents.y;
		}
		else if (num2 < 0f - extents.y)
		{
			result -= up * extents.y;
		}
		else
		{
			flag2 = true;
			result += up * num2;
		}
		float num3 = Vector3.Dot(lhs, forward);
		if (num3 > extents.z)
		{
			result += forward * extents.z;
		}
		else if (num3 < 0f - extents.z)
		{
			result -= forward * extents.z;
		}
		else
		{
			flag3 = true;
			result += forward * num3;
		}
		if (flag && flag2 && flag3)
		{
			return target;
		}
		return result;
	}

	public float Distance(OBB other)
	{
		return GJK.Distance(this, other);
	}

	public float Distance(Vector3 position)
	{
		return Vector3.Distance(position, ClosestPoint(position));
	}

	public float SqrDistance(OBB other)
	{
		return GJK.Distance2(this, other);
	}

	public float SqrDistance(Vector3 position)
	{
		return (position - ClosestPoint(position)).sqrMagnitude;
	}

	public void DebugDraw(Color colour, float duration)
	{
		Debug.DrawLine(GetPoint(-1f, -1f, -1f), GetPoint(1f, -1f, -1f), colour, duration);
		Debug.DrawLine(GetPoint(-1f, -1f, 1f), GetPoint(1f, -1f, 1f), colour, duration);
		Debug.DrawLine(GetPoint(-1f, -1f, -1f), GetPoint(-1f, -1f, 1f), colour, duration);
		Debug.DrawLine(GetPoint(1f, -1f, -1f), GetPoint(1f, -1f, 1f), colour, duration);
		Debug.DrawLine(GetPoint(-1f, -1f, -1f), GetPoint(-1f, 1f, -1f), colour, duration);
		Debug.DrawLine(GetPoint(-1f, -1f, 1f), GetPoint(-1f, 1f, 1f), colour, duration);
		Debug.DrawLine(GetPoint(1f, -1f, -1f), GetPoint(1f, 1f, -1f), colour, duration);
		Debug.DrawLine(GetPoint(1f, -1f, 1f), GetPoint(1f, 1f, 1f), colour, duration);
		Debug.DrawLine(GetPoint(-1f, 1f, -1f), GetPoint(1f, 1f, -1f), colour, duration);
		Debug.DrawLine(GetPoint(-1f, 1f, 1f), GetPoint(1f, 1f, 1f), colour, duration);
		Debug.DrawLine(GetPoint(-1f, 1f, -1f), GetPoint(-1f, 1f, 1f), colour, duration);
		Debug.DrawLine(GetPoint(1f, -1f, -1f), GetPoint(1f, 1f, 1f), colour, duration);
	}
}
