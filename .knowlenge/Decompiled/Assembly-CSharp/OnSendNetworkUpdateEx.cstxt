using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class OnSendNetworkUpdateEx
{
	public static void BroadcastOnSendNetworkUpdate(this GameObject go, BaseEntity entity)
	{
		List<IOnSendNetworkUpdate> obj = Pool.Get<List<IOnSendNetworkUpdate>>();
		go.GetComponentsInChildren(obj);
		for (int i = 0; i < obj.Count; i++)
		{
			obj[i].OnSendNetworkUpdate(entity);
		}
		Pool.FreeUnmanaged(ref obj);
	}

	public static void SendOnSendNetworkUpdate(this GameObject go, BaseEntity entity)
	{
		List<IOnSendNetworkUpdate> obj = Pool.Get<List<IOnSendNetworkUpdate>>();
		go.GetComponents(obj);
		for (int i = 0; i < obj.Count; i++)
		{
			obj[i].OnSendNetworkUpdate(entity);
		}
		Pool.FreeUnmanaged(ref obj);
	}
}
