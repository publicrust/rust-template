using Unity.Mathematics;
using UnityEngine;

public static class Float4x4Ex
{
	public static float3 ToPosition(this float4x4 m)
	{
		return m.c3.xyz;
	}

	public static Quaternion ToRotation(this float4x4 m)
	{
		return Quaternion.LookRotation(m.c2.xyz, m.c1.xyz);
	}
}
