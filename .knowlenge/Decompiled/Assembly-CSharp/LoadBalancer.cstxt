using System.Collections.Generic;
using System.Diagnostics;
using Rust;
using UnityEngine;

public class LoadBalancer : SingletonComponent<LoadBalancer>
{
	public static bool Paused;

	private const float MinMilliseconds = 1f;

	private const float MaxMilliseconds = 100f;

	private const int MinBacklog = 1000;

	private const int MaxBacklog = 100000;

	private Queue<DeferredAction>[] queues = new Queue<DeferredAction>[5]
	{
		new Queue<DeferredAction>(),
		new Queue<DeferredAction>(),
		new Queue<DeferredAction>(),
		new Queue<DeferredAction>(),
		new Queue<DeferredAction>()
	};

	private Stopwatch watch = Stopwatch.StartNew();

	protected void LateUpdate()
	{
		if (Rust.Application.isReceiving || Rust.Application.isLoading || Paused)
		{
			return;
		}
		int num = Count();
		float t = Mathf.InverseLerp(1000f, 100000f, num);
		float num2 = Mathf.SmoothStep(1f, 100f, t);
		watch.Reset();
		watch.Start();
		for (int i = 0; i < queues.Length; i++)
		{
			Queue<DeferredAction> queue = queues[i];
			while (queue.Count > 0)
			{
				queue.Dequeue().Action();
				if (watch.Elapsed.TotalMilliseconds > (double)num2)
				{
					return;
				}
			}
		}
	}

	public static int Count()
	{
		if (!SingletonComponent<LoadBalancer>.Instance)
		{
			return 0;
		}
		Queue<DeferredAction>[] array = SingletonComponent<LoadBalancer>.Instance.queues;
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			num += array[i].Count;
		}
		return num;
	}

	public static void ProcessAll()
	{
		if (!SingletonComponent<LoadBalancer>.Instance)
		{
			CreateInstance();
		}
		Queue<DeferredAction>[] array = SingletonComponent<LoadBalancer>.Instance.queues;
		foreach (Queue<DeferredAction> queue in array)
		{
			while (queue.Count > 0)
			{
				queue.Dequeue().Action();
			}
		}
	}

	public static void Enqueue(DeferredAction action)
	{
		if (!SingletonComponent<LoadBalancer>.Instance)
		{
			CreateInstance();
		}
		SingletonComponent<LoadBalancer>.Instance.queues[action.Index].Enqueue(action);
	}

	private static void CreateInstance()
	{
		GameObject obj = new GameObject();
		obj.name = "LoadBalancer";
		obj.AddComponent<LoadBalancer>();
		Object.DontDestroyOnLoad(obj);
	}
}
