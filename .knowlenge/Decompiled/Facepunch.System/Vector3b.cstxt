using System;

[Serializable]
public struct Vector3b : IEquatable<Vector3b>
{
	public static readonly Vector3b alltrue = new Vector3b(x: true, y: true, z: true);

	public static readonly Vector3b allfalse = new Vector3b(x: false, y: false, z: false);

	public bool x;

	public bool y;

	public bool z;

	public Vector3b(bool x, bool y, bool z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public static bool operator ==(Vector3b a, Vector3b b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Vector3b a, Vector3b b)
	{
		return !a.Equals(b);
	}

	public bool Equals(Vector3b o)
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
		if (o != null && o is Vector3b)
		{
			return Equals((Vector3b)o);
		}
		return false;
	}

	public override string ToString()
	{
		return $"[{x},{y},{z}]";
	}
}
