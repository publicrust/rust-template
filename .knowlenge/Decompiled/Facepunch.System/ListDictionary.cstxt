using System.Collections;
using System.Collections.Generic;

public class ListDictionary<TKey, TVal> : IEnumerable<KeyValuePair<TKey, TVal>>, IEnumerable
{
	private Dictionary<TKey, int> key2idx;

	private Dictionary<int, TKey> idx2key;

	private BufferList<TKey> keys;

	private BufferList<TVal> vals;

	public TVal this[TKey key]
	{
		get
		{
			return vals[key2idx[key]];
		}
		set
		{
			vals[key2idx[key]] = value;
		}
	}

	public BufferList<TKey> Keys => keys;

	public BufferList<TVal> Values => vals;

	public int Count => vals.Count;

	public ListDictionary()
		: this(8)
	{
	}

	public ListDictionary(int capacity = 8)
	{
		key2idx = new Dictionary<TKey, int>(capacity);
		idx2key = new Dictionary<int, TKey>(capacity);
		keys = new BufferList<TKey>(capacity);
		vals = new BufferList<TVal>(capacity);
	}

	public void Add(TKey key, TVal val)
	{
		int count = keys.Count;
		key2idx.Add(key, count);
		idx2key.Add(count, key);
		keys.Add(key);
		vals.Add(val);
	}

	public bool Contains(TKey key)
	{
		return key2idx.ContainsKey(key);
	}

	public bool ContainsKey(TKey key)
	{
		return key2idx.ContainsKey(key);
	}

	public bool Remove(TKey key)
	{
		if (!key2idx.TryGetValue(key, out var value))
		{
			return false;
		}
		Remove(value, key);
		return true;
	}

	public bool RemoveAt(int idx)
	{
		if (!idx2key.TryGetValue(idx, out var value))
		{
			return false;
		}
		Remove(idx, value);
		return true;
	}

	private void Remove(int idx_remove, TKey key_remove)
	{
		int key = keys.Count - 1;
		TKey val = idx2key[key];
		keys.RemoveUnordered(idx_remove);
		vals.RemoveUnordered(idx_remove);
		key2idx[val] = idx_remove;
		idx2key[idx_remove] = val;
		key2idx.Remove(key_remove);
		idx2key.Remove(key);
	}

	public bool TryGetValue(TKey key, out TVal val)
	{
		if (key2idx.TryGetValue(key, out var value))
		{
			val = vals[value];
			return true;
		}
		val = default(TVal);
		return false;
	}

	public KeyValuePair<TKey, TVal> GetByIndex(int idx)
	{
		return new KeyValuePair<TKey, TVal>(idx2key[idx], vals[idx]);
	}

	public void Clear()
	{
		if (Count != 0)
		{
			key2idx.Clear();
			idx2key.Clear();
			keys.Clear();
			vals.Clear();
		}
	}

	public IEnumerator<KeyValuePair<TKey, TVal>> GetEnumerator()
	{
		for (int i = 0; i < vals.Count; i++)
		{
			yield return GetByIndex(i);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
