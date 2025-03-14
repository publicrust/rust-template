using System;

public static class GenericsUtil
{
	private static class CastImpl<TSrc, TDst>
	{
		[ThreadStatic]
		public static TSrc Value;

		static CastImpl()
		{
			if (typeof(TSrc) != typeof(TDst))
			{
				throw new InvalidCastException();
			}
		}
	}

	public static TDst Cast<TSrc, TDst>(TSrc obj)
	{
		CastImpl<TSrc, TDst>.Value = obj;
		return CastImpl<TDst, TSrc>.Value;
	}

	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		a = b;
		b = val;
	}
}
