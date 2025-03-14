using System;

public class Deque<T>
{
	private T[] buffer;

	private int offset;

	private int count;

	public T this[int index]
	{
		get
		{
			return buffer[(offset + index) % buffer.Length];
		}
		set
		{
			buffer[(offset + index) % buffer.Length] = value;
		}
	}

	public int Count => count;

	public bool IsEmpty => Count == 0;

	public bool IsFull => Count == Capacity;

	public bool IsSplit => offset > Capacity - Count;

	public int Capacity => buffer.Length;

	public T Front
	{
		get
		{
			if (IsEmpty)
			{
				return default(T);
			}
			return buffer[offset];
		}
	}

	public T Back
	{
		get
		{
			if (IsEmpty)
			{
				return default(T);
			}
			return buffer[(count + offset - 1) % Capacity];
		}
	}

	public Deque(int capacity = 8)
	{
		buffer = new T[capacity];
	}

	public void Clear()
	{
		offset = (count = 0);
	}

	public void Resize(int capacity)
	{
		if (capacity > Capacity)
		{
			T[] destinationArray = new T[capacity];
			if (IsSplit)
			{
				int num = Capacity - offset;
				Array.Copy(buffer, offset, destinationArray, 0, num);
				Array.Copy(buffer, 0, destinationArray, num, Count - num);
			}
			else
			{
				Array.Copy(buffer, offset, destinationArray, 0, Count);
			}
			buffer = destinationArray;
			offset = 0;
		}
	}

	public T PeekBack()
	{
		if (IsEmpty)
		{
			return default(T);
		}
		return buffer[(count + offset) % Capacity];
	}

	public T PeekFront()
	{
		if (IsEmpty)
		{
			return default(T);
		}
		return buffer[offset];
	}

	public void PushBack(T value)
	{
		if (IsFull)
		{
			Resize(Capacity * 2);
		}
		buffer[(count + offset) % Capacity] = value;
		count++;
	}

	public void PushFront(T value)
	{
		if (IsFull)
		{
			Resize(Capacity * 2);
		}
		if (--offset < 0)
		{
			offset += Capacity;
		}
		buffer[offset] = value;
		count++;
	}

	public T PopBack()
	{
		if (IsEmpty)
		{
			return default(T);
		}
		T result = buffer[(count + offset - 1) % Capacity];
		count--;
		return result;
	}

	public T PopFront()
	{
		if (IsEmpty)
		{
			return default(T);
		}
		T result = buffer[offset];
		offset = (offset + 1) % Capacity;
		count--;
		return result;
	}
}
