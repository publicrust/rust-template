using System.Collections;
using System.Collections.Generic;

public interface IImmutableStack<T> : IEnumerable<T>, IEnumerable
{
	int Count { get; }

	IImmutableStack<T> Push(T value);

	IImmutableStack<T> Pop();

	T Peek();
}
