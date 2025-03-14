using Facepunch.MarchingCubes;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
internal struct BoxBlur3DJob : IJobFor
{
	[Unity.Collections.ReadOnly]
	public Point3DGrid InputGrid;

	public NativeBitArray OutputGrid;

	public int Width;

	public int WidthHeight;

	public void Execute(int index)
	{
		int3 @int = new int3(index % Width, index % WidthHeight / Width, index / WidthHeight);
		bool flag = InputGrid[index];
		if (!InputGrid.InBoundsNotTouching(@int))
		{
			OutputGrid.Set(index, value: false);
			return;
		}
		float num = 0f;
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				for (int k = -1; k <= 1; k++)
				{
					if (i != 0 || j != 0 || k != 0)
					{
						num += InputGrid.Sample(@int + new int3(i, j, k));
					}
				}
			}
		}
		bool flag2 = num / 26f >= (flag ? 0.33f : 0.66f);
		if (flag2 != flag)
		{
			flag2 = flag2 || flag2;
		}
		OutputGrid.Set(index, flag2);
	}
}
