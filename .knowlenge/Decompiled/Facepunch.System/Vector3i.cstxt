using System;
using UnityEngine;

[Serializable]
public struct Vector3i : IEquatable<Vector3i>
{
	public static readonly Vector3i zero = new Vector3i(0, 0, 0);

	public static readonly Vector3i one = new Vector3i(1, 1, 1);

	public static readonly Vector3i forward = new Vector3i(0, 0, 1);

	public static readonly Vector3i back = new Vector3i(0, 0, -1);

	public static readonly Vector3i up = new Vector3i(0, 1, 0);

	public static readonly Vector3i down = new Vector3i(0, -1, 0);

	public static readonly Vector3i right = new Vector3i(1, 0, 0);

	public static readonly Vector3i left = new Vector3i(-1, 0, 0);

	public int x;

	public int y;

	public int z;

	public Vector3i(int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public static Vector3i operator >>(Vector3i v, int shift)
	{
		return new Vector3i(v.x >> shift, v.y >> shift, v.z >> shift);
	}

	public static Vector3i operator <<(Vector3i v, int shift)
	{
		return new Vector3i(v.x << shift, v.y << shift, v.z << shift);
	}

	public static Vector3i operator +(Vector3i v)
	{
		return new Vector3i(v.x, v.y, v.z);
	}

	public static Vector3i operator -(Vector3i v)
	{
		return new Vector3i(-v.x, -v.y, -v.z);
	}

	public static Vector3i operator +(Vector3i a, Vector3i b)
	{
		return new Vector3i(a.x + b.x, a.y + b.y, a.z + b.z);
	}

	public static Vector3i operator -(Vector3i a, Vector3i b)
	{
		return new Vector3i(a.x - b.x, a.y - b.y, a.z - b.z);
	}

	public static Vector3i operator *(Vector3i v, int multiplier)
	{
		return new Vector3i(v.x * multiplier, v.y * multiplier, v.z * multiplier);
	}

	public static Vector3i operator /(Vector3i v, int divisor)
	{
		return new Vector3i(v.x / divisor, v.y / divisor, v.z / divisor);
	}

	public static Vector3 operator *(Vector3i v, float multiplier)
	{
		return new Vector3((float)v.x * multiplier, (float)v.y * multiplier, (float)v.z * multiplier);
	}

	public static Vector3 operator /(Vector3i v, float divisor)
	{
		return new Vector3((float)v.x / divisor, (float)v.y / divisor, (float)v.z / divisor);
	}

	public static Vector3i operator %(Vector3i v, int mod)
	{
		int num = v.x % mod;
		int num2 = v.y % mod;
		int num3 = v.z % mod;
		return new Vector3i(num, num2, num3);
	}

	public static implicit operator Vector3(Vector3i other)
	{
		return new Vector3(other.x, other.y, other.z);
	}

	public static explicit operator Vector3i(Vector3 other)
	{
		return new Vector3i((int)other.x, (int)other.y, (int)other.z);
	}

	public static bool operator ==(Vector3i a, Vector3i b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Vector3i a, Vector3i b)
	{
		return !a.Equals(b);
	}

	public bool Equals(Vector3i o)
	{
		if (x == o.x && y == o.y)
		{
			return z == o.z;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
	}

	public override bool Equals(object o)
	{
		if (o != null && o is Vector3i)
		{
			return Equals((Vector3i)o);
		}
		return false;
	}

	public override string ToString()
	{
		return $"[{x},{y},{z}]";
	}
}
