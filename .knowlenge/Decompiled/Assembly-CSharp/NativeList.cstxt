using System;
using Facepunch;
using Unity.Collections;

public class NativeList<T> : Pool.IPooled where T : unmanaged
{
	private NativeArray<T> _array;

	private int _length;

	public NativeArray<T> Array => _array;

	public int Count => _length;

	public T this[int index]
	{
		get
		{
			return _array[index];
		}
		set
		{
			_array[index] = value;
		}
	}

	public void Add(T item)
	{
		EnsureCapacity(_length + 1);
		_array[_length++] = item;
	}

	public void Clear()
	{
		for (int i = 0; i < _array.Length; i++)
		{
			_array[i] = default(T);
		}
		_length = 0;
	}

	public void Resize(int count)
	{
		if (_array.IsCreated)
		{
			_array.Dispose();
		}
		_array = new NativeArray<T>(count, Allocator.Persistent);
		_length = count;
	}

	public void EnsureCapacity(int requiredCapacity)
	{
		if (!_array.IsCreated || _array.Length < requiredCapacity)
		{
			int length = Math.Max(_array.Length * 2, requiredCapacity);
			NativeArray<T> array = new NativeArray<T>(length, Allocator.Persistent);
			if (_array.IsCreated)
			{
				_array.CopyTo(array.GetSubArray(0, _array.Length));
				_array.Dispose();
			}
			_array = array;
		}
	}

	public void EnterPool()
	{
		if (_array.IsCreated)
		{
			_array.Dispose();
		}
		_array = default(NativeArray<T>);
		_length = 0;
	}

	public void LeavePool()
	{
	}
}
