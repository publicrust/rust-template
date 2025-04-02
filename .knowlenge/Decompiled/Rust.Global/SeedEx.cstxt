using UnityEngine;

public static class SeedEx
{
	public static uint Seed(this Vector2 v, uint baseSeed)
	{
		return baseSeed + (uint)(v.x * 10f + v.y * 100f);
	}

	public static uint Seed(this Vector3 v, uint baseSeed)
	{
		return baseSeed + (uint)(v.x * 10f + v.y * 100f + v.z * 1000f);
	}

	public static uint Seed(this Vector4 v, uint baseSeed)
	{
		return baseSeed + (uint)(v.x * 10f + v.y * 100f + v.z * 1000f + v.w * 10000f);
	}
}
