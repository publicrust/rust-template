using System.Collections.Generic;

public class LimitList<T> : List<T>
{
	public int maxCapacity;

	private Queue<T> entries;

	public LimitList(int maxCapacity = 4096)
	{
		this.maxCapacity = maxCapacity;
		entries = new Queue<T>(this.maxCapacity);
	}

	public new void Add(T item)
	{
		while (base.Count > maxCapacity)
		{
			T item2 = entries.Dequeue();
			Remove(item2);
		}
		base.Add(item);
		entries.Enqueue(item);
	}

	public new void AddRange(IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			Add(item);
		}
	}
}
