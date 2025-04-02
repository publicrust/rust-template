using System;
using System.Collections.Generic;
using UnityEngine;

public class InvokeHandlerFixedTime : InvokeHandlerBase<InvokeHandlerFixedTime>
{
	protected override float GetTime()
	{
		return Time.fixedTime;
	}

	public static void FindInvokes(Behaviour sender, List<InvokeAction> list)
	{
		if (!SingletonComponent<InvokeHandlerFixedTime>.Instance)
		{
			return;
		}
		InvokeAction[] buffer = SingletonComponent<InvokeHandlerFixedTime>.Instance.curList.Keys.Buffer;
		int count = SingletonComponent<InvokeHandlerFixedTime>.Instance.curList.Count;
		for (int i = 0; i < count; i++)
		{
			InvokeAction item = buffer[i];
			if (item.sender == sender)
			{
				list.Add(item);
			}
		}
	}

	public static int Count()
	{
		if (!SingletonComponent<InvokeHandlerFixedTime>.Instance)
		{
			return 0;
		}
		return SingletonComponent<InvokeHandlerFixedTime>.Instance.curList.Count;
	}

	public static bool IsInvoking(Behaviour sender, Action action)
	{
		if (!SingletonComponent<InvokeHandlerFixedTime>.Instance)
		{
			return false;
		}
		return SingletonComponent<InvokeHandlerFixedTime>.Instance.Contains(new InvokeAction(sender, action, null));
	}

	public static void Invoke(Behaviour sender, Action action, float time)
	{
		if (!SingletonComponent<InvokeHandlerFixedTime>.Instance)
		{
			CreateInstance();
		}
		InvokeTrackingData trackingData = SingletonComponent<InvokeHandlerFixedTime>.Instance.profiler.GetTrackingData(new InvokeTrackingKey(action));
		SingletonComponent<InvokeHandlerFixedTime>.Instance.QueueAdd(new InvokeAction(sender, action, trackingData, time));
	}

	public static void InvokeRepeating(Behaviour sender, Action action, float time, float repeat)
	{
		if (!SingletonComponent<InvokeHandlerFixedTime>.Instance)
		{
			CreateInstance();
		}
		InvokeTrackingData trackingData = SingletonComponent<InvokeHandlerFixedTime>.Instance.profiler.GetTrackingData(new InvokeTrackingKey(action));
		SingletonComponent<InvokeHandlerFixedTime>.Instance.QueueAdd(new InvokeAction(sender, action, trackingData, time, repeat));
	}

	public static void InvokeRandomized(Behaviour sender, Action action, float time, float repeat, float random)
	{
		if (!SingletonComponent<InvokeHandlerFixedTime>.Instance)
		{
			CreateInstance();
		}
		InvokeTrackingData trackingData = SingletonComponent<InvokeHandlerFixedTime>.Instance.profiler.GetTrackingData(new InvokeTrackingKey(action));
		SingletonComponent<InvokeHandlerFixedTime>.Instance.QueueAdd(new InvokeAction(sender, action, trackingData, time, repeat, random));
	}

	public static void CancelInvoke(Behaviour sender, Action action)
	{
		if (!(SingletonComponent<InvokeHandlerFixedTime>.Instance == null))
		{
			InvokeTrackingData trackingData = SingletonComponent<InvokeHandlerFixedTime>.Instance.profiler.GetTrackingData(new InvokeTrackingKey(action));
			SingletonComponent<InvokeHandlerFixedTime>.Instance.QueueRemove(new InvokeAction(sender, action, trackingData));
		}
	}

	private static void CreateInstance()
	{
		GameObject obj = new GameObject();
		obj.name = "InvokeHandlerFixedTime";
		obj.AddComponent<InvokeHandlerFixedTime>().profiler = InvokeProfiler.fixedUpdate;
		UnityEngine.Object.DontDestroyOnLoad(obj);
	}
}
