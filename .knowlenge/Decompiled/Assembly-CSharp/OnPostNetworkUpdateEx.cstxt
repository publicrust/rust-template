using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class OnPostNetworkUpdateEx
{
	public static void BroadcastOnPostNetworkUpdate(this GameObject go, BaseEntity entity)
	{
		List<IOnPostNetworkUpdate> list = Pool.Get<List<IOnPostNetworkUpdate>>();
		go.GetComponentsInChildren<IOnPostNetworkUpdate>(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].OnPostNetworkUpdate(entity);
		}
		Pool.FreeUnmanaged<IOnPostNetworkUpdate>(ref list);
	}

	public static void SendOnPostNetworkUpdate(this GameObject go, BaseEntity entity)
	{
		List<IOnPostNetworkUpdate> list = Pool.Get<List<IOnPostNetworkUpdate>>();
		go.GetComponents<IOnPostNetworkUpdate>(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].OnPostNetworkUpdate(entity);
		}
		Pool.FreeUnmanaged<IOnPostNetworkUpdate>(ref list);
	}
}
