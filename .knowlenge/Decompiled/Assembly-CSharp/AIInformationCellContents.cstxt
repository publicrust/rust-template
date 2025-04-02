using System.Collections.Generic;
using UnityEngine;

public class AIInformationCellContents<T> where T : AIPoint
{
	public HashSet<T> Items = new HashSet<T>();

	public int Count => Items.Count;

	public bool Empty => Items.Count == 0;

	public void Init(Bounds cellBounds, GameObject root)
	{
		Clear();
		T[] componentsInChildren = root.GetComponentsInChildren<T>(includeInactive: true);
		foreach (T val in componentsInChildren)
		{
			if (cellBounds.Contains(val.gameObject.transform.position))
			{
				Add(val);
			}
		}
	}

	public void Clear()
	{
		Items.Clear();
	}

	public void Add(T item)
	{
		Items.Add(item);
	}

	public void Remove(T item)
	{
		Items.Remove(item);
	}
}
