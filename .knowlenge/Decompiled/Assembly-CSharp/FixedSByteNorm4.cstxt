using UnityEngine;

public struct FixedSByteNorm4
{
	private const int FracBits = 7;

	private const float MaxFrac = 128f;

	private const float RcpMaxFrac = 1f / 128f;

	public sbyte x;

	public sbyte y;

	public sbyte z;

	public sbyte w;

	public FixedSByteNorm4(Vector4 vec)
	{
		x = (sbyte)(vec.x * 128f);
		y = (sbyte)(vec.y * 128f);
		z = (sbyte)(vec.z * 128f);
		w = (sbyte)(vec.w * 128f);
	}

	public static explicit operator Vector4(FixedSByteNorm4 vec)
	{
		return new Vector4((float)vec.x * (1f / 128f), (float)vec.y * (1f / 128f), (float)vec.z * (1f / 128f), (float)vec.w * (1f / 128f));
	}
}
