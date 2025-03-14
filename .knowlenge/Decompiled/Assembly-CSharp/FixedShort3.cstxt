using UnityEngine;

public struct FixedShort3
{
	private const int FracBits = 10;

	private const float MaxFrac = 1024f;

	private const float RcpMaxFrac = 0.0009765625f;

	public short x;

	public short y;

	public short z;

	public FixedShort3(Vector3 vec)
	{
		x = (short)(vec.x * 1024f);
		y = (short)(vec.y * 1024f);
		z = (short)(vec.z * 1024f);
	}

	public static explicit operator Vector3(FixedShort3 vec)
	{
		return new Vector3((float)vec.x * 0.0009765625f, (float)vec.y * 0.0009765625f, (float)vec.z * 0.0009765625f);
	}
}
