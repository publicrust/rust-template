using System;
using UnityEngine;

public class SeedRandom
{
	public uint Seed;

	public SeedRandom(uint seed = 0u)
	{
		if (seed != 0)
		{
			Seed = seed;
		}
		else
		{
			Seed = (uint)UnityEngine.Random.Range(1, int.MaxValue);
		}
	}

	public int Range(int min, int max)
	{
		return Range(ref Seed, min, max);
	}

	public static int Range(uint seed, int min, int max)
	{
		return Range(ref seed, min, max);
	}

	public static int Range(ref uint seed, int min, int max)
	{
		uint num = (uint)(max - min);
		return min + (int)(Xorshift(ref seed) % num);
	}

	public float Range(float min, float max)
	{
		return Range(ref Seed, min, max);
	}

	public static float Range(uint seed, float min, float max)
	{
		return Range(ref seed, min, max);
	}

	public static float Range(ref uint seed, float min, float max)
	{
		return min + Xorshift01(ref seed) * (max - min);
	}

	public int Sign()
	{
		if (Xorshift(ref Seed) % 2 != 0)
		{
			return -1;
		}
		return 1;
	}

	public static int Sign(uint seed)
	{
		if (Xorshift(ref seed) % 2 != 0)
		{
			return -1;
		}
		return 1;
	}

	public static int Sign(ref uint seed)
	{
		if (Xorshift(ref seed) % 2 != 0)
		{
			return -1;
		}
		return 1;
	}

	public float Value()
	{
		return Xorshift01(ref Seed);
	}

	public static float Value(uint seed)
	{
		return Xorshift01(ref seed);
	}

	public static float Value(ref uint seed)
	{
		return Xorshift01(ref seed);
	}

	public Vector2 Value2D()
	{
		return Value2D(ref Seed);
	}

	public static Vector2 Value2D(uint seed)
	{
		return Value2D(ref seed);
	}

	public static Vector2 Value2D(ref uint seed)
	{
		float f = Value(ref seed) * MathF.PI * 2f;
		return new Vector2(Mathf.Cos(f), Mathf.Sin(f));
	}

	public static uint Wanghash(ref uint x)
	{
		x = x ^ 0x3D ^ (x >> 16);
		x *= 9u;
		x ^= x >> 4;
		x *= 668265261u;
		x ^= x >> 15;
		return x;
	}

	public static ulong Wanghash(ref ulong x)
	{
		x ^= x >> 30;
		x *= 13787848793156543929uL;
		x ^= x >> 27;
		x *= 10723151780598845931uL;
		x ^= x >> 31;
		return x;
	}

	public static float Wanghash01(ref uint x)
	{
		return (float)Wanghash(ref x) * 2.3283064E-10f;
	}

	public static uint Xorshift(ref uint x)
	{
		x ^= x << 13;
		x ^= x >> 17;
		x ^= x << 5;
		return x;
	}

	public static ulong Xorshift(ref ulong x)
	{
		x ^= x << 13;
		x ^= x >> 7;
		x ^= x << 17;
		return x;
	}

	public static float Xorshift01(ref uint x)
	{
		return (float)Xorshift(ref x) * 2.3283064E-10f;
	}
}
