using System;
using UnityEngine;

[Serializable]
public struct Vector2i : IEquatable<Vector2i>
{
	public static readonly Vector2i zero = new Vector2i(0, 0);

	public static readonly Vector2i one = new Vector2i(1, 1);

	public static readonly Vector2i left = new Vector2i(-1, 0);

	public static readonly Vector2i right = new Vector2i(1, 0);

	public static readonly Vector2i forward = new Vector2i(0, 1);

	public static readonly Vector2i back = new Vector2i(0, -1);

	public int x;

	public int y;

	public Vector2i(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public static Vector2i operator >>(Vector2i v, int shift)
	{
		return new Vector2i(v.x >> shift, v.y >> shift);
	}

	public static Vector2i operator <<(Vector2i v, int shift)
	{
		return new Vector2i(v.x << shift, v.y << shift);
	}

	public static Vector2i operator +(Vector2i v)
	{
		return new Vector2i(v.x, v.y);
	}

	public static Vector2i operator -(Vector2i v)
	{
		return new Vector2i(-v.x, -v.y);
	}

	public static Vector2i operator +(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.x + b.x, a.y + b.y);
	}

	public static Vector2i operator -(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.x - b.x, a.y - b.y);
	}

	public static Vector2i operator *(Vector2i v, int multiplier)
	{
		return new Vector2i(Mathf.RoundToInt(v.x * multiplier), Mathf.RoundToInt(v.y * multiplier));
	}

	public static Vector2i operator /(Vector2i v, int divisor)
	{
		return new Vector2i(Mathf.RoundToInt(v.x / divisor), Mathf.RoundToInt(v.y / divisor));
	}

	public static Vector2 operator *(Vector2i v, float multiplier)
	{
		return new Vector2((float)v.x * multiplier, (float)v.y * multiplier);
	}

	public static Vector2 operator /(Vector2i v, float divisor)
	{
		return new Vector2((float)v.x / divisor, (float)v.y / divisor);
	}

	public static Vector2i operator %(Vector2i v, int mod)
	{
		int num = v.x % mod;
		int num2 = v.y % mod;
		return new Vector2i(num, num2);
	}

	public static implicit operator Vector2(Vector2i other)
	{
		return new Vector2(other.x, other.y);
	}

	public static explicit operator Vector2i(Vector2 other)
	{
		return new Vector2i((int)other.x, (int)other.y);
	}

	public static bool operator ==(Vector2i a, Vector2i b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Vector2i a, Vector2i b)
	{
		return !a.Equals(b);
	}

	public bool Equals(Vector2i o)
	{
		if (x == o.x)
		{
			return y == o.y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return x.GetHashCode() ^ y.GetHashCode();
	}

	public override bool Equals(object o)
	{
		if (o != null && o is Vector2i)
		{
			return Equals((Vector2i)o);
		}
		return false;
	}

	public override string ToString()
	{
		return $"[{x},{y}]";
	}
}
