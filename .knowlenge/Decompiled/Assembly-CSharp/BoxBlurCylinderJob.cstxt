using Facepunch.MarchingCubes;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
public struct BoxBlurCylinderJob : IJob
{
	public Point3DGrid Grid;

	public float3 P0;

	public float3 P1;

	public float R;

	public void Execute()
	{
		float3 @float = math.float3(R);
		float3 float2 = math.min(P0, P1) - @float;
		float3 float3 = math.max(P0, P1) + @float;
		float3 float4 = P1 - P0;
		float v = math.dot(float4, float4);
		float r = R * R;
		for (float num = float2.x; num <= float3.x; num += 1f)
		{
			for (float num2 = float2.y; num2 <= float3.y; num2 += 1f)
			{
				for (float num3 = float2.z; num3 <= float3.z; num3 += 1f)
				{
					float3 float5 = math.float3(num, num2, num3);
					int3 @int = math.int3(float5);
					if (!Grid.InBoundsNotTouching(@int) || !SculptMathUtil.InFlatEndedCapsule(P0, float4, v, r, float5))
					{
						continue;
					}
					float num4 = 0f;
					int num5 = 0;
					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							for (int k = -1; k <= 1; k++)
							{
								if (i != 0 || j != 0 || k != 0)
								{
									int3 int2 = @int + new int3(i, j, k);
									if (Grid.InBounds(int2))
									{
										num4 += Grid.Sample(int2);
										num5++;
									}
								}
							}
						}
					}
					Grid[@int] = num4 / (float)num5 > 0.5f;
				}
			}
		}
	}
}
