#define UNITY_ASSERTIONS
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class MruDictionary<Key, Value> : IEnumerable<KeyValuePair<Key, Value>>, IEnumerable
{
	private int capacity;

	private Queue<LinkedListNode<KeyValuePair<Key, Value>>> recycled;

	private LinkedList<KeyValuePair<Key, Value>> list;

	private Dictionary<Key, LinkedListNode<KeyValuePair<Key, Value>>> dict;

	private Action<Key, Value> valueRecycler;

	public int Capacity => capacity;

	public int Count => list.Count;

	public long EvictionCount { get; private set; }

	public MruDictionary(int capacity, Action<Key, Value> valueRecycler = null)
	{
		this.capacity = capacity;
		list = new LinkedList<KeyValuePair<Key, Value>>();
		dict = new Dictionary<Key, LinkedListNode<KeyValuePair<Key, Value>>>(capacity);
		recycled = new Queue<LinkedListNode<KeyValuePair<Key, Value>>>(capacity);
		this.valueRecycler = valueRecycler;
		for (int i = 0; i < capacity; i++)
		{
			recycled.Enqueue(new LinkedListNode<KeyValuePair<Key, Value>>(default(KeyValuePair<Key, Value>)));
		}
	}

	public void Add(Key key, Value value)
	{
		if (dict.ContainsKey(key))
		{
			throw new InvalidOperationException("An item with the same key has already been added.");
		}
		if (dict.Count >= capacity)
		{
			RemoveLast();
		}
		LinkedListNode<KeyValuePair<Key, Value>> linkedListNode = ((recycled.Count > 0) ? recycled.Dequeue() : new LinkedListNode<KeyValuePair<Key, Value>>(default(KeyValuePair<Key, Value>)));
		linkedListNode.Value = new KeyValuePair<Key, Value>(key, value);
		list.AddFirst(linkedListNode);
		dict.Add(key, linkedListNode);
	}

	public void Remove(Key key)
	{
		if (dict.TryGetValue(key, out var value))
		{
			Assert.AreEqual(key, value.Value.Key);
			Value value2 = value.Value.Value;
			list.Remove(value);
			dict.Remove(key);
			valueRecycler?.Invoke(key, value2);
			value.Value = default(KeyValuePair<Key, Value>);
			recycled.Enqueue(value);
		}
	}

	private void RemoveLast()
	{
		Assert.IsTrue(list.Count > 0);
		LinkedListNode<KeyValuePair<Key, Value>> last = list.Last;
		Assert.IsTrue(dict.Remove(last.Value.Key));
		list.RemoveLast();
		valueRecycler?.Invoke(last.Value.Key, last.Value.Value);
		last.Value = default(KeyValuePair<Key, Value>);
		recycled.Enqueue(last);
		EvictionCount++;
	}

	public bool TryGetValue(Key key, out Value value)
	{
		if (dict.TryGetValue(key, out var value2))
		{
			Assert.AreEqual(key, value2.Value.Key);
			value = value2.Value.Value;
			list.Remove(value2);
			list.AddFirst(value2);
			return true;
		}
		value = default(Value);
		return false;
	}

	public void Clear()
	{
		while (Count > 0)
		{
			RemoveLast();
		}
	}

	public void SetCapacity(int newCapacity)
	{
		int num = newCapacity - capacity;
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				recycled.Enqueue(new LinkedListNode<KeyValuePair<Key, Value>>(default(KeyValuePair<Key, Value>)));
			}
		}
		else
		{
			num *= -1;
			if (Count > newCapacity)
			{
				int num2 = Count - newCapacity;
				for (int j = 0; j < num2; j++)
				{
					RemoveLast();
				}
			}
			int num3 = newCapacity - Count;
			while (recycled.Count > num3)
			{
				recycled.Dequeue().Value = default(KeyValuePair<Key, Value>);
			}
		}
		capacity = newCapacity;
	}

	public LinkedList<KeyValuePair<Key, Value>>.Enumerator GetEnumerator()
	{
		return list.GetEnumerator();
	}

	IEnumerator<KeyValuePair<Key, Value>> IEnumerable<KeyValuePair<Key, Value>>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
