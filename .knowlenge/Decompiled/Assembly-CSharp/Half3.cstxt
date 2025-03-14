using UnityEngine;

public struct Half3
{
	public ushort x;

	public ushort y;

	public ushort z;

	public Half3(Vector3 vec)
	{
		x = Mathf.FloatToHalf(vec.x);
		y = Mathf.FloatToHalf(vec.y);
		z = Mathf.FloatToHalf(vec.z);
	}

	public static explicit operator Vector3(Half3 vec)
	{
		return new Vector3(Mathf.HalfToFloat(vec.x), Mathf.HalfToFloat(vec.y), Mathf.HalfToFloat(vec.z));
	}
}
