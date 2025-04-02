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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		x = (sbyte)(vec.x * 128f);
		y = (sbyte)(vec.y * 128f);
		z = (sbyte)(vec.z * 128f);
		w = (sbyte)(vec.w * 128f);
	}

	public static explicit operator Vector4(FixedSByteNorm4 vec)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		return new Vector4((float)vec.x * (1f / 128f), (float)vec.y * (1f / 128f), (float)vec.z * (1f / 128f), (float)vec.w * (1f / 128f));
	}
}
