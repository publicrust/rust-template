using System;
using System.Collections.Generic;
using Facepunch;

public class PooledHashSet<T> : HashSet<T>, IDisposable, Pool.IPooled
{
	void IDisposable.Dispose()
	{
		PooledHashSet<T> obj = this;
		Pool.Free(ref obj);
	}

	void Pool.IPooled.EnterPool()
	{
		Clear();
	}

	void Pool.IPooled.LeavePool()
	{
	}
}
