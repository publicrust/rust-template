public struct IntrusiveLinkedList<T> where T : ILinkedListNode<T>
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
		item.next = head;
		head = item;
	}

	public T Pop()
	{
		T result = head;
		head = head.next;
		result.next = default(T);
		return result;
	}
}
