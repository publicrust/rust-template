using System;

[Serializable]
public struct Vector2b : IEquatable<Vector2b>
{
	public static readonly Vector2b alltrue = new Vector2b(x: true, y: true);

	public static readonly Vector2b allfalse = new Vector2b(x: false, y: false);

	public bool x;

	public bool y;

	public Vector2b(bool x, bool y)
	{
		this.x = x;
		this.y = y;
	}

	public static bool operator ==(Vector2b a, Vector2b b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Vector2b a, Vector2b b)
	{
		return !a.Equals(b);
	}

	public bool Equals(Vector2b o)
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
		if (o != null && o is Vector2b)
		{
			return Equals((Vector2b)o);
		}
		return false;
	}

	public override string ToString()
	{
		return $"[{x},{y}]";
	}
}
