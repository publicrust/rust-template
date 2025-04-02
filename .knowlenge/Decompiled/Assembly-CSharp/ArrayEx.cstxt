using System;
using UnityEngine;

public static class ArrayEx
{
	public static T[] New<T>(int length)
	{
		if (length == 0)
		{
			return Array.Empty<T>();
		}
		return new T[length];
	}

	public static T GetRandom<T>(this T[] array)
	{
		if (array == null || array.Length == 0)
		{
			return default(T);
		}
		return array[UnityEngine.Random.Range(0, array.Length)];
	}

	public static T GetRandom<T>(this T[] array, uint seed)
	{
		if (array == null || array.Length == 0)
		{
			return default(T);
		}
		return array[SeedRandom.Range(ref seed, 0, array.Length)];
	}

	public static T GetRandom<T>(this T[] array, ref uint seed)
	{
		if (array == null || array.Length == 0)
		{
			return default(T);
		}
		return array[SeedRandom.Range(ref seed, 0, array.Length)];
	}

	public static void Shuffle<T>(this T[] array, uint seed)
	{
		Shuffle(array, ref seed);
	}

	public static void Shuffle<T>(this T[] array, ref uint seed)
	{
		for (int i = 0; i < array.Length; i++)
		{
			int num = SeedRandom.Range(ref seed, 0, array.Length);
			int num2 = SeedRandom.Range(ref seed, 0, array.Length);
			T val = array[num];
			array[num] = array[num2];
			array[num2] = val;
		}
	}

	public static void BubbleSort<T>(this T[] array) where T : IComparable<T>
	{
		for (int i = 1; i < array.Length; i++)
		{
			T val = array[i];
			for (int num = i - 1; num >= 0; num--)
			{
				T val2 = array[num];
				if (val.CompareTo(val2) >= 0)
				{
					break;
				}
				array[num + 1] = val2;
				array[num] = val;
			}
		}
	}
}
