using System.Collections.Generic;
using Facepunch;

public class PooledList<T>
{
	public List<T> data;

	public void Alloc()
	{
		if (data == null)
		{
			data = Pool.GetList<T>();
		}
	}

	public void Free()
	{
		if (data != null)
		{
			Pool.FreeList(ref data);
		}
	}

	public void Clear()
	{
		if (data != null)
		{
			data.Clear();
		}
	}
}
