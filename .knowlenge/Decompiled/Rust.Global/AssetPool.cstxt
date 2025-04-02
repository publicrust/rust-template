using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class AssetPool
{
	public class Pool
	{
		public Stack<UnityEngine.Object> stack = new Stack<UnityEngine.Object>();

		public int allocated;

		public int available;

		public string name;

		public Pool(string name)
		{
			this.name = name;
		}

		public T Pop<T>() where T : UnityEngine.Object, new()
		{
			if (stack.Count > 0)
			{
				available--;
				return stack.Pop() as T;
			}
			allocated++;
			return new T
			{
				name = name
			};
		}

		public void Push<T>(ref T instance) where T : UnityEngine.Object, new()
		{
			available++;
			stack.Push(instance);
			instance = null;
		}

		public void Clear()
		{
			foreach (UnityEngine.Object item in stack)
			{
				UnityEngine.Object.Destroy(item);
			}
			available -= stack.Count;
			allocated -= stack.Count;
			stack.Clear();
		}
	}

	public static Dictionary<Type, Pool> storage = new Dictionary<Type, Pool>();

	public static T Get<T>() where T : UnityEngine.Object, new()
	{
		return GetPool<T>().Pop<T>();
	}

	public static void Free(ref Mesh mesh)
	{
		mesh.Clear();
		GetPool<Mesh>().Push(ref mesh);
	}

	private static Pool GetPool<T>() where T : UnityEngine.Object, new()
	{
		if (!storage.TryGetValue(typeof(T), out var value))
		{
			value = new Pool("Pooled " + typeof(T).Name);
			storage.Add(typeof(T), value);
		}
		return value;
	}

	public static void Clear(string filter = null)
	{
		if (string.IsNullOrEmpty(filter))
		{
			foreach (KeyValuePair<Type, Pool> item in storage)
			{
				item.Value.Clear();
			}
			return;
		}
		foreach (KeyValuePair<Type, Pool> item2 in storage)
		{
			if (item2.Key.FullName.Contains(filter, CompareOptions.IgnoreCase))
			{
				item2.Value.Clear();
			}
		}
	}
}
