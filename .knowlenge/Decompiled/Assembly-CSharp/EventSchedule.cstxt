using System;
using ConVar;
using Rust;
using UnityEngine;

public class EventSchedule : BaseMonoBehaviour
{
	[Tooltip("The minimum amount of hours between events")]
	public float minimumHoursBetween = 12f;

	[Tooltip("The maximum amount of hours between events")]
	public float maxmumHoursBetween = 24f;

	private float hoursRemaining;

	private long lastRun;

	private void OnEnable()
	{
		hoursRemaining = UnityEngine.Random.Range(minimumHoursBetween, maxmumHoursBetween);
		InvokeRepeating(RunSchedule, 1f, 1f);
	}

	private void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			CancelInvoke(RunSchedule);
		}
	}

	private void RunSchedule()
	{
		if (!Rust.Application.isLoading && ConVar.Server.events)
		{
			CountHours();
			if (!(hoursRemaining > 0f))
			{
				Trigger();
			}
		}
	}

	private void Trigger()
	{
		hoursRemaining = UnityEngine.Random.Range(minimumHoursBetween, maxmumHoursBetween);
		TriggeredEvent[] components = GetComponents<TriggeredEvent>();
		if (components.Length != 0)
		{
			TriggeredEvent triggeredEvent = components[UnityEngine.Random.Range(0, components.Length)];
			if (!(triggeredEvent == null))
			{
				triggeredEvent.SendMessage("RunEvent", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	private void CountHours()
	{
		if ((bool)TOD_Sky.Instance)
		{
			if (lastRun != 0L)
			{
				hoursRemaining -= (float)TOD_Sky.Instance.Cycle.DateTime.Subtract(DateTime.FromBinary(lastRun)).TotalSeconds / 60f / 60f;
			}
			lastRun = TOD_Sky.Instance.Cycle.DateTime.ToBinary();
		}
	}
}
