using Unity.Mathematics;

public static class SculptMathUtil
{
	public static bool InFlatEndedCapsule(float3 p0, float3 v, float v2, float r2, float3 check)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		float3 val = check - p0;
		if (math.dot(val, v) > v2)
		{
			return false;
		}
		return math.lengthsq(math.cross(val, v)) * math.rcp(v2) <= r2;
	}
}
