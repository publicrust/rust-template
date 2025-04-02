using Unity.Mathematics;
using UnityEngine;

public static class Float4x4Ex
{
	public static float3 ToPosition(this float4x4 m)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return ((float4)(ref m.c3)).xyz;
	}

	public static Quaternion ToRotation(this float4x4 m)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		return Quaternion.LookRotation(float3.op_Implicit(((float4)(ref m.c2)).xyz), float3.op_Implicit(((float4)(ref m.c1)).xyz));
	}
}
