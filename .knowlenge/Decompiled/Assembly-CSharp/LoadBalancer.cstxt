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
		if (Application.isReceiving || Application.isLoading || Paused)
		{
			return;
		}
		int num = Count();
		float num2 = Mathf.InverseLerp(1000f, 100000f, (float)num);
		float num3 = Mathf.SmoothStep(1f, 100f, num2);
		watch.Reset();
		watch.Start();
		for (int i = 0; i < queues.Length; i++)
		{
			Queue<DeferredAction> queue = queues[i];
			while (queue.Count > 0)
			{
				queue.Dequeue().Action();
				if (watch.Elapsed.TotalMilliseconds > (double)num3)
				{
					return;
				}
			}
		}
	}

	public static int Count()
	{
		if (!Object.op_Implicit((Object)(object)SingletonComponent<LoadBalancer>.Instance))
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
		if (!Object.op_Implicit((Object)(object)SingletonComponent<LoadBalancer>.Instance))
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
		if (!Object.op_Implicit((Object)(object)SingletonComponent<LoadBalancer>.Instance))
		{
			CreateInstance();
		}
		SingletonComponent<LoadBalancer>.Instance.queues[action.Index].Enqueue(action);
	}

	private static void CreateInstance()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		GameObject val = new GameObject
		{
			name = "LoadBalancer"
		};
		val.AddComponent<LoadBalancer>();
		Object.DontDestroyOnLoad((Object)val);
	}
}
