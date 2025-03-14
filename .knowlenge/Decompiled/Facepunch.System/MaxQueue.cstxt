public class MaxQueue
{
	private Deque<int> data;

	private Deque<int> max;

	public int Max => max.Front;

	public MaxQueue(int capacity = 8)
	{
		data = new Deque<int>(capacity);
		max = new Deque<int>(capacity);
	}

	public void Push(int value)
	{
		data.PushBack(value);
		while (!max.IsEmpty && max.Back < value)
		{
			max.PopBack();
		}
		max.PushBack(value);
	}

	public int Pop()
	{
		if (max.Front == data.Front)
		{
			max.PopFront();
		}
		return data.PopFront();
	}
}
