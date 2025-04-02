using Facepunch.MarchingCubes;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
public struct CarveAndBlurCylinderJob : IJob
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
		float num = R * R;
		NativeList<int3> nativeList = new NativeList<int3>((int)num, Allocator.Temp);
		for (float num2 = float2.x; num2 <= float3.x; num2 += 1f)
		{
			for (float num3 = float2.y; num3 <= float3.y; num3 += 1f)
			{
				for (float num4 = float2.z; num4 <= float3.z; num4 += 1f)
				{
					float3 float5 = math.float3(num2, num3, num4);
					int3 value = math.int3(float5);
					if (Grid.InBounds(value) && SculptMathUtil.InFlatEndedCapsule(P0, float4, v, num, float5))
					{
						Grid[value] = false;
						nativeList.Add(in value);
					}
				}
			}
		}
		NativeArray<int3> nativeArray = nativeList.AsArray();
		int length = nativeList.Length;
		for (int i = 0; i < length; i++)
		{
			int3 @int = nativeArray[i];
			if (!Grid.InBoundsNotTouching(@int))
			{
				continue;
			}
			float num5 = 0f;
			int num6 = 0;
			for (int j = -1; j <= 1; j++)
			{
				for (int k = -1; k <= 1; k++)
				{
					for (int l = -1; l <= 1; l++)
					{
						if (j != 0 || k != 0 || l != 0)
						{
							int3 int2 = @int + new int3(j, k, l);
							if (Grid.InBounds(int2))
							{
								num5 += Grid.Sample(int2);
								num6++;
							}
						}
					}
				}
			}
			Grid[@int] = num5 / (float)num6 > 0.5f;
		}
	}
}
