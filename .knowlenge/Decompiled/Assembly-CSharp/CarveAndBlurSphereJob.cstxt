using Facepunch.MarchingCubes;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
internal struct CarveAndBlurSphereJob : IJob
{
	public Point3DGrid Grid;

	public int3 Origin;

	public int R;

	public void Execute()
	{
		int num = R * R;
		for (int i = -R; i <= R; i++)
		{
			for (int j = -R; j <= R; j++)
			{
				for (int k = -R; k <= R; k++)
				{
					int3 @int = new int3(i, j, k);
					int3 int2 = Origin + @int;
					if (!(math.distancesq(int2, Origin) > (float)num) && Grid.InBounds(int2))
					{
						Grid[int2] = false;
					}
				}
			}
		}
		for (int l = -R; l <= R; l++)
		{
			for (int m = -R; m <= R; m++)
			{
				for (int n = -R; n <= R; n++)
				{
					int3 int3 = new int3(l, m, n);
					int3 int4 = Origin + int3;
					if (math.distancesq(int4, Origin) > (float)num || !Grid.InBoundsNotTouching(int4))
					{
						continue;
					}
					float num2 = 0f;
					int num3 = 0;
					for (int num4 = -1; num4 <= 1; num4++)
					{
						for (int num5 = -1; num5 <= 1; num5++)
						{
							for (int num6 = -1; num6 <= 1; num6++)
							{
								if (num4 != 0 || num5 != 0 || num6 != 0)
								{
									int3 int5 = int4 + new int3(num4, num5, num6);
									if (Grid.InBounds(int5))
									{
										num2 += Grid.Sample(int5);
										num3++;
									}
								}
							}
						}
					}
					Grid[int4] = num2 / (float)num3 > 0.5f;
				}
			}
		}
	}
}
