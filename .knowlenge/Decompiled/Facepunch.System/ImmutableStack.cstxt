using System;
using System.Collections;
using System.Collections.Generic;

public class ImmutableStack<T> : IImmutableStack<T>, IEnumerable<T>, IEnumerable
{
	private sealed class EmptyStack : IImmutableStack<T>, IEnumerable<T>, IEnumerable
	{
		public int Count => 0;

		public IImmutableStack<T> Push(T value)
		{
			return new ImmutableStack<T>(value, this);
		}

		public IImmutableStack<T> Pop()
		{
			throw new InvalidOperationException("The stack is empty.");
		}

		public T Peek()
		{
			throw new InvalidOperationException("The stack is empty.");
		}

		public IEnumerator<T> GetEnumerator()
		{
			yield break;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private readonly T _head;

	private readonly IImmutableStack<T> _tail;

	public static IImmutableStack<T> Empty { get; } = new EmptyStack();

	public int Count { get; }

	private ImmutableStack(T head, IImmutableStack<T> tail)
	{
		if (tail == null)
		{
			throw new ArgumentNullException("tail");
		}
		_head = head;
		_tail = tail;
		Count = tail.Count + 1;
	}

	public T Peek()
	{
		return _head;
	}

	public IImmutableStack<T> Pop()
	{
		return _tail;
	}

	public IImmutableStack<T> Push(T value)
	{
		return new ImmutableStack<T>(value, this);
	}

	public IEnumerator<T> GetEnumerator()
	{
		IImmutableStack<T> stack = this;
		while (stack.Count > 0)
		{
			yield return stack.Peek();
			stack = stack.Pop();
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
