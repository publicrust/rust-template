public struct IntrusiveMinHeap<T> where T : IMinHeapNode<T>
{
	private T head;

	public bool Empty => head == null;

	public void Add(T item)
	{
		if (head == null)
		{
			head = item;
			return;
		}
		if (head.child == null && item.order <= head.order)
		{
			item.child = head;
			head = item;
			return;
		}
		T child = head;
		while (child.child != null && child.child.order < item.order)
		{
			child = child.child;
		}
		item.child = child.child;
		child.child = item;
	}

	public T Pop()
	{
		T result = head;
		head = head.child;
		result.child = default(T);
		return result;
	}
}
