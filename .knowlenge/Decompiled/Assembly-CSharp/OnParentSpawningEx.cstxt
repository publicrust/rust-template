using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class OnParentSpawningEx
{
	public static void BroadcastOnParentSpawning(this GameObject go)
	{
		List<IOnParentSpawning> obj = Pool.GetList<IOnParentSpawning>();
		go.GetComponentsInChildren(obj);
		for (int i = 0; i < obj.Count; i++)
		{
			obj[i].OnParentSpawning();
		}
		Pool.FreeList(ref obj);
	}

	public static void SendOnParentSpawning(this GameObject go)
	{
		List<IOnParentSpawning> obj = Pool.GetList<IOnParentSpawning>();
		go.GetComponents(obj);
		for (int i = 0; i < obj.Count; i++)
		{
			obj[i].OnParentSpawning();
		}
		Pool.FreeList(ref obj);
	}
}
