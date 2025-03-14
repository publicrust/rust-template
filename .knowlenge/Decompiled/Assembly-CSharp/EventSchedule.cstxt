using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ConVar;
using Rust;
using UnityEngine;

public class EventSchedule : BaseMonoBehaviour
{
	[Tooltip("The minimum amount of hours between events")]
	public float minimumHoursBetween = 12f;

	[Tooltip("The maximum amount of hours between events")]
	public float maxmumHoursBetween = 24f;

	[Tooltip("ID to reference this event via convars")]
	public string Key;

	public static HashSet<EventSchedule> allEvents = new HashSet<EventSchedule>();

	public static HashSet<EventSchedule> enabledEvents = new HashSet<EventSchedule>();

	public float hoursRemaining;

	public long lastRun;

	[ServerVar(Name = "triggerevent")]
	public static void TriggerEvent(ConsoleSystem.Arg arg)
	{
		string eventName = arg.GetString(0);
		string[] source = enabledEvents.Select((EventSchedule x) => x.GetName().ToLower()).ToArray();
		string[] array = (from x in source
			where x.Contains(eventName, CompareOptions.IgnoreCase)
			select x.ToLower()).ToArray();
		if (string.IsNullOrEmpty(eventName) || array.Length == 0)
		{
			arg.ReplyWith("Unknown event - event list:\n\n" + string.Join("\n", source.Select(Path.GetFileNameWithoutExtension).ToArray()));
			return;
		}
		if (array.Length > 1)
		{
			string text = array.FirstOrDefault((string x) => string.Compare(x, eventName, StringComparison.OrdinalIgnoreCase) == 0);
			if (text != null)
			{
				array[0] = text;
			}
		}
		foreach (EventSchedule enabledEvent in enabledEvents)
		{
			if (enabledEvent.GetName() == array[0])
			{
				enabledEvent.Trigger();
				arg.ReplyWith("Triggered " + enabledEvent.GetName());
			}
		}
	}

	[ServerVar(Name = "killallevents")]
	public static void KillAllEvents()
	{
		foreach (EventSchedule enabledEvent in enabledEvents)
		{
			TriggeredEvent[] components = enabledEvent.GetComponents<TriggeredEvent>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].Kill();
			}
		}
	}

	public string GetName()
	{
		return Path.GetFileNameWithoutExtension(base.name);
	}

	private void Awake()
	{
		allEvents.Add(this);
		Events.UpdateScheduleFromConVars(this);
	}

	private void OnDestroy()
	{
		allEvents.Remove(this);
	}

	private void OnEnable()
	{
		hoursRemaining = UnityEngine.Random.Range(minimumHoursBetween, maxmumHoursBetween);
		InvokeRepeating(RunSchedule, 1f, 1f);
		enabledEvents.Add(this);
	}

	private void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			enabledEvents.Remove(this);
			CancelInvoke(RunSchedule);
		}
	}

	public virtual void RunSchedule()
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
				triggeredEvent.RunEvent();
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
