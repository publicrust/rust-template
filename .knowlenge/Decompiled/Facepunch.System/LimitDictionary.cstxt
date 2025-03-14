using System.Collections.Generic;

public class LimitDictionary<TKey, TValue> : Dictionary<TKey, TValue>
{
	public int MaxCapacity = 8192;

	private Queue<TKey> entries;

	public LimitDictionary(int maxCapacity = 8192)
	{
		MaxCapacity = maxCapacity;
		entries = new Queue<TKey>(MaxCapacity);
	}

	public new void TryAdd(TKey key, TValue item)
	{
		if (!ContainsKey(key))
		{
			if (base.Count == MaxCapacity)
			{
				TKey key2 = entries.Dequeue();
				Remove(key2);
			}
			Add(key, item);
			entries.Enqueue(key);
		}
	}
}
