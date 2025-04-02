using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class OnParentDestroyingEx
{
	public static void BroadcastOnParentDestroying(this GameObject go)
	{
		List<IOnParentDestroying> list = Pool.Get<List<IOnParentDestroying>>();
		go.GetComponentsInChildren<IOnParentDestroying>(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].OnParentDestroying();
		}
		Pool.FreeUnmanaged<IOnParentDestroying>(ref list);
	}

	public static void SendOnParentDestroying(this GameObject go)
	{
		List<IOnParentDestroying> list = Pool.Get<List<IOnParentDestroying>>();
		go.GetComponents<IOnParentDestroying>(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].OnParentDestroying();
		}
		Pool.FreeUnmanaged<IOnParentDestroying>(ref list);
	}
}
