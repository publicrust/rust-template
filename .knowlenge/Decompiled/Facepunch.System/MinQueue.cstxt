public class MinQueue
{
	private Deque<int> data;

	private Deque<int> min;

	public int Min => min.Front;

	public MinQueue(int capacity = 8)
	{
		data = new Deque<int>(capacity);
		min = new Deque<int>(capacity);
	}

	public void Push(int value)
	{
		data.PushBack(value);
		while (!min.IsEmpty && min.Back > value)
		{
			min.PopBack();
		}
		min.PushBack(value);
	}

	public int Pop()
	{
		if (min.Front == data.Front)
		{
			min.PopFront();
		}
		return data.PopFront();
	}
}
