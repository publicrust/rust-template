using Unity.Mathematics;

public static class SculptMathUtil
{
	public static bool InFlatEndedCapsule(float3 p0, float3 v, float v2, float r2, float3 check)
	{
		float3 x = check - p0;
		if (math.dot(x, v) > v2)
		{
			return false;
		}
		return math.lengthsq(math.cross(x, v)) * math.rcp(v2) <= r2;
	}
}
