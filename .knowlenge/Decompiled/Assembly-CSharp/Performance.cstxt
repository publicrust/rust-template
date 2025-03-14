using System;
using Rust.Workshop;
using UnityEngine;

public class Performance : SingletonComponent<Performance>
{
	public struct Tick
	{
		public int frameID;

		public int frameRate;

		public float frameTime;

		public float frameRateAverage;

		public float frameTimeAverage;

		public long memoryUsageSystem;

		public long memoryAllocations;

		public long memoryCollections;

		public long loadBalancerTasks;

		public long invokeHandlerTasks;

		public long workshopSkinsQueued;

		public int ping;

		public bool gcTriggered;
	}

	public static Tick current;

	public static Tick report;

	private static long cycles = 0L;

	private static int[] frameRateHistory = new int[60];

	private static float[] frameTimeHistory = new float[60];

	private int frames;

	private float time;

	private void Update()
	{
		using (TimeWarning.New("FPSTimer"))
		{
			FPSTimer();
		}
	}

	private void FPSTimer()
	{
		frames++;
		time += Time.unscaledDeltaTime;
		if (!(time < 1f))
		{
			long memoryCollections = current.memoryCollections;
			current.frameID = Time.frameCount;
			current.frameRate = frames;
			current.frameTime = time / (float)frames * 1000f;
			frameRateHistory[cycles % frameRateHistory.Length] = current.frameRate;
			frameTimeHistory[cycles % frameTimeHistory.Length] = current.frameTime;
			current.frameRateAverage = AverageFrameRate();
			current.frameTimeAverage = AverageFrameTime();
			current.memoryUsageSystem = SystemInfoEx.systemMemoryUsed;
			current.memoryAllocations = GC.GetTotalMemory(forceFullCollection: false) / 1048576;
			current.memoryCollections = GC.CollectionCount(0);
			current.loadBalancerTasks = LoadBalancer.Count();
			current.invokeHandlerTasks = InvokeHandler.Count();
			current.workshopSkinsQueued = Rust.Workshop.WorkshopSkin.QueuedCount;
			current.gcTriggered = memoryCollections != current.memoryCollections;
			frames = 0;
			time = 0f;
			cycles++;
			report = current;
		}
	}

	private float AverageFrameRate()
	{
		float num = 0f;
		for (int i = 0; i < frameRateHistory.Length; i++)
		{
			num += (float)frameRateHistory[i];
		}
		return num / (float)frameRateHistory.Length;
	}

	private float AverageFrameTime()
	{
		float num = 0f;
		for (int i = 0; i < frameTimeHistory.Length; i++)
		{
			num += frameTimeHistory[i];
		}
		return num / (float)frameTimeHistory.Length;
	}
}
