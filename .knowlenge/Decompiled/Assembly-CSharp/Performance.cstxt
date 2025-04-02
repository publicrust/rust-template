using System;
using System.Collections.Generic;
using Facepunch;
using Rust;
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

		public PerformanceSamplePoint performanceSample;
	}

	private struct LagSpike
	{
		public int Index;

		public int Time;
	}

	public static Tick current;

	public static Tick report;

	public const int FrameHistoryCount = 1000;

	private const int HistoryLength = 60;

	private static long cycles = 0L;

	private static int[] frameRateHistory = new int[60];

	private static float[] frameTimeHistory = new float[60];

	private static int[] frameTimes = new int[1000];

	private int frames;

	private float time;

	private void Update()
	{
		frameTimes[Time.frameCount % 1000] = (int)(1000f * Time.deltaTime);
		using (TimeWarning.New("FPSTimer"))
		{
			FPSTimer();
		}
	}

	public List<int> GetFrameTimes(int requestedStart, int maxCount, out int startIndex)
	{
		startIndex = Math.Max(requestedStart, Math.Max(Time.frameCount - 1000 - 1, 0));
		int num = Math.Min(Math.Min(1000, maxCount), Time.frameCount);
		List<int> list = Pool.Get<List<int>>();
		for (int i = 0; i < num; i++)
		{
			int num2 = (startIndex + i) % 1000;
			list.Add(frameTimes[num2]);
		}
		return list;
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
			current.memoryAllocations = Rust.GC.GetTotalMemory();
			current.memoryCollections = Rust.GC.CollectionCount();
			current.loadBalancerTasks = LoadBalancer.Count();
			current.invokeHandlerTasks = InvokeHandler.Count();
			current.workshopSkinsQueued = Rust.Workshop.WorkshopSkin.QueuedCount;
			current.performanceSample = PerformanceMetrics.PerformancePerSecond;
			PerformanceMetrics.PerformancePerSecond = default(PerformanceSamplePoint);
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
		int num2 = Math.Min(frameRateHistory.Length, (int)cycles);
		for (int i = 0; i < num2; i++)
		{
			num += (float)frameRateHistory[i];
		}
		return num / (float)num2;
	}

	private float AverageFrameTime()
	{
		float num = 0f;
		int num2 = Math.Min(frameTimeHistory.Length, (int)cycles);
		for (int i = 0; i < frameTimeHistory.Length; i++)
		{
			num += frameTimeHistory[i];
		}
		return num / (float)num2;
	}
}
