using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class OnSendNetworkUpdateEx
{
	public static void BroadcastOnSendNetworkUpdate(this GameObject go, BaseEntity entity)
	{
		List<IOnSendNetworkUpdate> list = Pool.Get<List<IOnSendNetworkUpdate>>();
		go.GetComponentsInChildren<IOnSendNetworkUpdate>(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].OnSendNetworkUpdate(entity);
		}
		Pool.FreeUnmanaged<IOnSendNetworkUpdate>(ref list);
	}

	public static void SendOnSendNetworkUpdate(this GameObject go, BaseEntity entity)
	{
		List<IOnSendNetworkUpdate> list = Pool.Get<List<IOnSendNetworkUpdate>>();
		go.GetComponents<IOnSendNetworkUpdate>(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].OnSendNetworkUpdate(entity);
		}
		Pool.FreeUnmanaged<IOnSendNetworkUpdate>(ref list);
	}
}
