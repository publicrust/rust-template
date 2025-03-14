using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public static class PerformanceMetrics
{
	private static PerformanceSamplePoint current;

	private static Action OnBeforeRender;

	private static int _mainThreadId;

	public static PerformanceSamplePoint GetCurrent(bool reset = false)
	{
		PerformanceSamplePoint result = current;
		if (reset)
		{
			current = default(PerformanceSamplePoint);
		}
		return result;
	}

	public static void Setup()
	{
		Application.onBeforeRender += delegate
		{
			OnBeforeRender?.Invoke();
		};
		_mainThreadId = Thread.CurrentThread.ManagedThreadId;
		AddStopwatch(PerformanceSample.PreCull, ref OnBeforeRender, ref CameraUpdateHook.RustCamera_PreRender);
		AddStopwatch(PerformanceSample.Update, ref PreUpdateHook.OnUpdate, ref PostUpdateHook.OnUpdate);
		AddStopwatch(PerformanceSample.LateUpdate, ref PreUpdateHook.OnLateUpdate, ref PostUpdateHook.OnLateUpdate);
		AddStopwatch(PerformanceSample.Render, ref CameraUpdateHook.PreRender, ref CameraUpdateHook.PostRender);
		AddStopwatch(PerformanceSample.FixedUpdate, ref PreUpdateHook.OnFixedUpdate, ref PostUpdateHook.OnFixedUpdate);
		AddCPUTimeStopwatch();
	}

	private static void AddCPUTimeStopwatch()
	{
		Stopwatch watch = new Stopwatch();
		int lastFrame = 0;
		TimeSpan lastTime = default(TimeSpan);
		StartOfFrameHook.OnStartOfFrame = (Action)Delegate.Combine(StartOfFrameHook.OnStartOfFrame, (Action)delegate
		{
			current.TotalCPU += lastTime;
			current.CpuUpdateCount++;
			lastTime = default(TimeSpan);
			if (Time.frameCount != lastFrame)
			{
				lastFrame = Time.frameCount;
				watch.Restart();
			}
		});
		CameraUpdateHook.PostRender = (Action)Delegate.Combine(CameraUpdateHook.PostRender, (Action)delegate
		{
			lastTime = watch.Elapsed;
		});
	}

	private static void AddStopwatch(PerformanceSample sample, ref Action pre, ref Action post)
	{
		Stopwatch watch = new Stopwatch();
		bool active = false;
		pre = (Action)Delegate.Combine(pre, (Action)delegate
		{
			if (!active)
			{
				active = true;
				watch.Restart();
			}
		});
		post = (Action)Delegate.Combine(post, (Action)delegate
		{
			if (active)
			{
				active = false;
				watch.Stop();
				switch (sample)
				{
				case PerformanceSample.Update:
					current.UpdateCount++;
					current.Update += watch.Elapsed;
					break;
				case PerformanceSample.LateUpdate:
					current.LateUpdate += watch.Elapsed;
					break;
				case PerformanceSample.FixedUpdate:
					current.FixedUpdate += watch.Elapsed;
					current.FixedUpdateCount++;
					break;
				case PerformanceSample.PreCull:
					current.PreCull += watch.Elapsed;
					break;
				case PerformanceSample.Render:
					current.Render += watch.Elapsed;
					current.RenderCount++;
					break;
				case PerformanceSample.TotalCPU:
					current.TotalCPU += watch.Elapsed;
					break;
				case PerformanceSample.NetworkMessage:
					break;
				}
			}
		});
	}
}
