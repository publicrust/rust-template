using UnityEngine;

public struct Half4
{
	public ushort x;

	public ushort y;

	public ushort z;

	public ushort w;

	public Half4(Vector4 vec)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		x = Mathf.FloatToHalf(vec.x);
		y = Mathf.FloatToHalf(vec.y);
		z = Mathf.FloatToHalf(vec.z);
		w = Mathf.FloatToHalf(vec.w);
	}

	public static explicit operator Vector4(Half4 vec)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		return new Vector4(Mathf.HalfToFloat(vec.x), Mathf.HalfToFloat(vec.y), Mathf.HalfToFloat(vec.z), Mathf.HalfToFloat(vec.w));
	}
}
