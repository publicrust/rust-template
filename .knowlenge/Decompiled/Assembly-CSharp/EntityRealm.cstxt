using System;
using System.Runtime.CompilerServices;
using Facepunch;

internal class EntityRealm
{
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

	public struct HiddenValue_Internal_EncryptedValue<TInner> where TInner : unmanaged
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
		public static implicit operator HiddenValue_Internal_EncryptedValue<TInner>(TInner value)
		{
			HiddenValue_Internal_EncryptedValue<TInner> result = default(HiddenValue_Internal_EncryptedValue<TInner>);
			result.Set(value);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator TInner(HiddenValue_Internal_EncryptedValue<TInner> encrypted)
		{
			return encrypted.Get();
		}
	}
}
