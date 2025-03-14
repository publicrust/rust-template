using System;

public static class CollectionUtil
{
	public static void SortInplace<T>(Span<T> values, Span<int> indices)
	{
		for (int i = 0; i < indices.Length; i++)
		{
			int num = i;
			int num2 = indices[i];
			if (num2 != -1 && num != num2)
			{
				while (num2 != -1 && num != num2)
				{
					T val = values[num2];
					values[num2] = values[i];
					values[i] = val;
					indices[num] = -1;
					num = num2;
					num2 = indices[num2];
				}
			}
		}
	}

	public static void ScatterOutInplace<T>(Span<T> values, ReadOnlySpan<int> indices, T defValue = default(T))
	{
		int num = indices.Length;
		while (num > 0)
		{
			num--;
			int num2 = indices[num];
			if (num != num2)
			{
				values[num2] = values[num];
				values[num] = defValue;
			}
		}
	}

	public static void ScatterTo<T>(ReadOnlySpan<T> from, Span<T> to, ReadOnlySpan<int> indicesTo)
	{
		for (int i = 0; i < indicesTo.Length; i++)
		{
			to[indicesTo[i]] = from[i];
		}
	}
}
