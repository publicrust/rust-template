using System;
using Facepunch.MarchingCubes;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;

[BurstCompile]
internal struct CleanFloatingIslandsJob : IJob
{
	private struct NativeStack : IDisposable
	{
		public NativeList<int3> arr;

		public NativeStack(Allocator allocator)
		{
			arr = new NativeList<int3>(allocator);
		}

		public void Dispose()
		{
			arr.Dispose();
		}

		public void Push(int3 v)
		{
			arr.Add(in v);
		}

		public bool TryPop(out int3 v)
		{
			v = default(int3);
			if (arr.Length == 0)
			{
				return false;
			}
			v = arr[arr.Length - 1];
			arr.RemoveAtSwapBack(arr.Length - 1);
			return true;
		}
	}

	public Point3DGrid Sampler;

	public static readonly ProfilerMarker k_Init = new ProfilerMarker("Init");

	public static readonly ProfilerMarker k_Flood = new ProfilerMarker("Flood");

	public static readonly ProfilerMarker k_Copy = new ProfilerMarker("CopyBack");

	public void Execute()
	{
		NativeBitArray other = new NativeBitArray(Sampler.Length, Allocator.Temp);
		NativeStack nativeStack = new NativeStack(Allocator.Temp);
		int width = Sampler.Width;
		int depth = Sampler.Depth;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < depth; j++)
			{
				int3 @int = new int3(i, 1, j);
				int num = Sampler.ToIndex(@int);
				if (Sampler[num])
				{
					nativeStack.Push(@int);
					other.Set(num, value: true);
				}
			}
		}
		int3 v;
		while (nativeStack.TryPop(out v))
		{
			int num2 = v.x - 1;
			int3 p = new int3(num2, v.yz);
			int num3 = 0;
			while (Sampler.InBounds(p) && Sampler[num3 = Sampler.ToIndex(p)] && !other.IsSet(num3))
			{
				other.Set(num3, value: true);
				p = new int3(--num2, v.yz);
			}
			int num4 = v.x + 1;
			p = new int3(num4, v.yz);
			while (Sampler.InBounds(p) && Sampler[num3 = Sampler.ToIndex(p)] && !other.IsSet(num3))
			{
				other.Set(num3, value: true);
				p = new int3(++num4, v.yz);
			}
			int num5 = v.z - 1;
			p = new int3(v.xy, num5);
			while (Sampler.InBounds(p) && Sampler[num3 = Sampler.ToIndex(p)] && !other.IsSet(num3))
			{
				other.Set(num3, value: true);
				p = new int3(v.xy, --num5);
			}
			int num6 = v.z + 1;
			p = new int3(v.xy, num6);
			while (Sampler.InBounds(p) && Sampler[num3 = Sampler.ToIndex(p)] && !other.IsSet(num3))
			{
				other.Set(num3, value: true);
				p = new int3(v.xy, ++num6);
			}
			for (int k = num2; k < num4; k++)
			{
				for (int l = num5; l < num6; l++)
				{
					for (int m = -1; m <= 1; m += 2)
					{
						p = new int3(k, v.y + m, l);
						if (Sampler.InBounds(p) && Sampler[num3 = Sampler.ToIndex(p)] && !other.IsSet(num3))
						{
							nativeStack.Push(p);
							other.Set(num3, value: true);
						}
					}
				}
			}
		}
		Sampler.CopyFromNativeBitArray(ref other);
	}
}
