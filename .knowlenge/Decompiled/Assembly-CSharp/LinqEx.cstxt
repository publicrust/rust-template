using System;
using System.Collections.Generic;

public static class LinqEx
{
	public static int MaxIndex<T>(this IEnumerable<T> sequence) where T : IComparable<T>
	{
		int num = -1;
		T other = default(T);
		int num2 = 0;
		foreach (T item in sequence)
		{
			if (item.CompareTo(other) > 0 || num == -1)
			{
				num = num2;
				other = item;
			}
			num2++;
		}
		return num;
	}
}
