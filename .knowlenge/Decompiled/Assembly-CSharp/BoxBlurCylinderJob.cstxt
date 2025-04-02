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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		float3 val = math.float3(R);
		float3 val2 = math.min(P0, P1) - val;
		float3 val3 = math.max(P0, P1) + val;
		float3 val4 = P1 - P0;
		float v = math.dot(val4, val4);
		float r = R * R;
		for (float num = val2.x; num <= val3.x; num += 1f)
		{
			for (float num2 = val2.y; num2 <= val3.y; num2 += 1f)
			{
				for (float num3 = val2.z; num3 <= val3.z; num3 += 1f)
				{
					float3 val5 = math.float3(num, num2, num3);
					int3 val6 = math.int3(val5);
					if (!Grid.InBoundsNotTouching(val6) || !SculptMathUtil.InFlatEndedCapsule(P0, val4, v, r, val5))
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
									int3 val7 = val6 + new int3(i, j, k);
									if (Grid.InBounds(val7))
									{
										num4 += Grid.Sample(val7);
										num5++;
									}
								}
							}
						}
					}
					Grid[val6] = num4 / (float)num5 > 0.5f;
				}
			}
		}
	}
}
