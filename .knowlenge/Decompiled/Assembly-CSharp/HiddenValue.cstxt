using System;
using System.Runtime.CompilerServices;
using Facepunch;

public sealed class HiddenValue<T> : Pool.IPooled, IDisposable where T : class
{
	private T _value;

	public HiddenValue()
		: this((T)null)
	{
	}

	public HiddenValue(T value)
	{
		_value = value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T Get()
	{
		return _value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HiddenValue<T> Set(T value)
	{
		_value = value;
		return this;
	}

	void Pool.IPooled.EnterPool()
	{
		Set(null);
	}

	void Pool.IPooled.LeavePool()
	{
	}

	public void Dispose()
	{
		Set(null);
		HiddenValue<T> obj = this;
		Pool.Free(ref obj);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator T(HiddenValue<T> hidden)
	{
		return hidden.Get();
	}
}
