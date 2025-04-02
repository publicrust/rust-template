using System.Runtime.CompilerServices;

public struct EncryptedValue<TInner> where TInner : unmanaged
{
	private TInner _value;

	private int _padding;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TInner Get()
	{
		return _value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Set(TInner value)
	{
		_value = value;
	}

	public override string ToString()
	{
		return Get().ToString();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator EncryptedValue<TInner>(TInner value)
	{
		EncryptedValue<TInner> result = default(EncryptedValue<TInner>);
		result.Set(value);
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator TInner(EncryptedValue<TInner> encrypted)
	{
		return encrypted.Get();
	}
}
