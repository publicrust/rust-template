using System;
using System.Runtime.CompilerServices;
using Facepunch;

public sealed class HiddenValue<T> : IDisposable where T : class
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

	public void Dispose()
	{
		_value = null;
		HiddenValue<T> obj = this;
		Pool.FreeUnsafe(ref obj);
	}
}
