using Facepunch.MarchingCubes;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
internal struct BoxBlurSphereJob : IJob
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
					if (math.distancesq(int2, Origin) > (float)num || !Grid.InBoundsNotTouching(int2))
					{
						continue;
					}
					float num2 = 0f;
					int num3 = 0;
					for (int l = -1; l <= 1; l++)
					{
						for (int m = -1; m <= 1; m++)
						{
							for (int n = -1; n <= 1; n++)
							{
								if (l != 0 || m != 0 || n != 0)
								{
									int3 int3 = int2 + new int3(l, m, n);
									if (Grid.InBounds(int3))
									{
										num2 += Grid.Sample(int3);
										num3++;
									}
								}
							}
						}
					}
					Grid[int2] = num2 / (float)num3 > 0.5f;
				}
			}
		}
	}
}
