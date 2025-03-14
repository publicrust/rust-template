using System.Collections.Generic;
using UnityEngine;

public class PrefabPool
{
	public Stack<Poolable> stack = new Stack<Poolable>();

	public int Count => stack.Count;

	public void Push(Poolable info)
	{
		stack.Push(info);
		info.EnterPool();
	}

	public void Push(GameObject instance)
	{
		Poolable component = instance.GetComponent<Poolable>();
		Push(component);
	}

	public GameObject Pop(Vector3 pos = default(Vector3), Quaternion rot = default(Quaternion))
	{
		while (stack.Count > 0)
		{
			Poolable poolable = stack.Pop();
			if ((bool)poolable)
			{
				poolable.transform.position = pos;
				poolable.transform.rotation = rot;
				poolable.LeavePool();
				return poolable.gameObject;
			}
		}
		return null;
	}

	public void Clear()
	{
		foreach (Poolable item in stack)
		{
			if ((bool)item)
			{
				Object.Destroy(item.gameObject);
			}
		}
		stack.Clear();
	}
}
