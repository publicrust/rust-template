using System;
using System.Diagnostics;
using UnityEngine;

public static class PerformanceMetrics
{
	private static PerformanceSamplePoint current;

	private static Action OnBeforeRender;

	public static PerformanceSamplePoint LastFrame { get; private set; }

	public static PerformanceSamplePoint PerformancePerSecond { get; set; }

	public static void Setup()
	{
		Application.onBeforeRender += delegate
		{
			OnBeforeRender?.Invoke();
		};
		AddStopwatch(PerformanceSample.PreCull, ref OnBeforeRender, ref CameraUpdateHook.RustCamera_PreRender);
		AddStopwatch(PerformanceSample.Update, ref PreUpdateHook.OnUpdate, ref PostUpdateHook.OnUpdate);
		AddStopwatch(PerformanceSample.LateUpdate, ref PreUpdateHook.OnLateUpdate, ref PostUpdateHook.OnLateUpdate);
		AddStopwatch(PerformanceSample.Render, ref CameraUpdateHook.PreRender, ref CameraUpdateHook.PostRender);
		AddStopwatch(PerformanceSample.FixedUpdate, ref PreUpdateHook.OnFixedUpdate, ref PostUpdateHook.OnFixedUpdate);
		AddStopwatch(PerformanceSample.PhysicsUpdate, ref PostUpdateHook.OnFixedUpdate, ref PreUpdateHook.PostPhysicsUpdate);
		AddCPUTimeStopwatch();
	}

	private static void AddCPUTimeStopwatch()
	{
		Stopwatch watch = new Stopwatch();
		PreUpdateHook.StartOfFrame = (Action)Delegate.Combine(PreUpdateHook.StartOfFrame, (Action)delegate
		{
			PerformancePerSecond = PerformancePerSecond.Add(current);
			LastFrame = current;
			current = default(PerformanceSamplePoint);
			watch.Restart();
			current.CpuUpdateCount++;
		});
		PostUpdateHook.EndOfFrame = (Action)Delegate.Combine(PostUpdateHook.EndOfFrame, (Action)delegate
		{
			current.TotalCPU += watch.Elapsed;
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
				case PerformanceSample.PhysicsUpdate:
					current.PhysicsUpdate += watch.Elapsed;
					break;
				case PerformanceSample.NetworkMessage:
				case PerformanceSample.TotalCPU:
					break;
				}
			}
		});
	}
}
