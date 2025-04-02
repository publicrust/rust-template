using System;
using System.Collections.Generic;
using Facepunch;
using Facepunch.Extend;
using Facepunch.Nexus.Models;
using ProtoBuf;
using Rust.UI;
using UnityEngine;

public class NexusDockTerminal : BaseEntity
{
	public static readonly Translate.Phrase ScheduleSoonPhrase = new Translate.Phrase("nexus.dock.schedule.soon", "{0} - Now");

	public static readonly Translate.Phrase ScheduleMinutesPhrase = new Translate.Phrase("nexus.dock.schedule.minutes", "{0} - {1} min");

	public static readonly Translate.Phrase ScheduleUnknownPhrase = new Translate.Phrase("nexus.dock.schedule.unknown", "{0} - Unknown");

	public float TravelTime = 90f;

	public RustText[] ScheduleLabels;

	private List<ProtoBuf.NexusDockTerminal.ScheduleEntry> _scheduleEntries;

	private static readonly HashSet<string> SeenFerries = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

	public override void InitShared()
	{
		base.InitShared();
		if (base.isServer)
		{
			InvokeRandomized(UpdateFerrySchedule, 0f, 10f, 5f);
		}
	}

	public override void AdminKill()
	{
		if (!HasFlag(Flags.Debugging))
		{
			Debug.LogWarning("Prevented killing NexusDock, set debugging flag to override");
		}
	}

	private void UpdateFerrySchedule()
	{
		if (_scheduleEntries == null)
		{
			_scheduleEntries = Pool.Get<List<ProtoBuf.NexusDockTerminal.ScheduleEntry>>();
		}
		foreach (ProtoBuf.NexusDockTerminal.ScheduleEntry scheduleEntry2 in _scheduleEntries)
		{
			ProtoBuf.NexusDockTerminal.ScheduleEntry obj = scheduleEntry2;
			Pool.Free(ref obj);
		}
		_scheduleEntries.Clear();
		List<(string, float?)> list = Pool.Get<List<(string, float?)>>();
		CalculateFerryEstimates(list);
		foreach (var item in list)
		{
			NexusZoneDetails nexusZoneDetails = NexusServer.FindZone(item.Item1);
			if (nexusZoneDetails != null)
			{
				ProtoBuf.NexusDockTerminal.ScheduleEntry scheduleEntry = Pool.Get<ProtoBuf.NexusDockTerminal.ScheduleEntry>();
				scheduleEntry.nextZoneId = nexusZoneDetails.Id;
				scheduleEntry.estimate = (int)Mathf.Round(item.Item2 ?? (-1f));
				_scheduleEntries.Add(scheduleEntry);
			}
		}
		SendNetworkUpdate();
	}

	private void CalculateFerryEstimates(List<(string NextZone, float? Estimate)> estimates)
	{
		if (estimates == null)
		{
			throw new ArgumentNullException("estimates");
		}
		estimates.Clear();
		SeenFerries.Clear();
		NexusDock instance = SingletonComponent<NexusDock>.Instance;
		if (instance == null || !NexusServer.Started || NexusServer.Zones == null)
		{
			return;
		}
		instance.CleanupQueuedFerries();
		float num = 0f;
		if (instance.CurrentFerry != null && !instance.CurrentFerry.IsRetiring)
		{
			estimates.Add((instance.CurrentFerry.NextZone, num));
			SeenFerries.Add(instance.CurrentFerry.OwnerZone);
		}
		NexusFerry[] queuedFerries = instance.QueuedFerries;
		foreach (NexusFerry nexusFerry in queuedFerries)
		{
			if (!(nexusFerry == null) && !nexusFerry.IsRetiring)
			{
				estimates.Add((nexusFerry.NextZone, num));
				num += instance.WaitTime;
				SeenFerries.Add(nexusFerry.OwnerZone);
			}
		}
		string zoneKey = NexusServer.ZoneKey;
		foreach (NexusZoneDetails zone in NexusServer.Zones)
		{
			if (SeenFerries.Contains(zone.Key) || !zone.Variables.TryGetValue("ferry", out var value) || value.Type != VariableType.String || string.IsNullOrWhiteSpace(value.Value) || !value.Value.Contains(zoneKey, StringComparison.InvariantCultureIgnoreCase) || !NexusUtil.TryParseFerrySchedule(zone.Key, value.Value, out var schedule))
			{
				continue;
			}
			int num2 = schedule.FindIndex(zoneKey, StringComparer.InvariantCultureIgnoreCase);
			if (num2 < 0)
			{
				continue;
			}
			string item = ((num2 < schedule.Length - 1) ? schedule[num2 + 1] : schedule[0]);
			if (!NexusServer.TryGetFerryStatus(zone.Key, out var currentZone, out var status))
			{
				estimates.Add((item, null));
				SeenFerries.Add(zone.Key);
				continue;
			}
			int num3 = schedule.FindIndex(currentZone, StringComparer.InvariantCultureIgnoreCase);
			if (num3 < 0)
			{
				estimates.Add((item, null));
				SeenFerries.Add(zone.Key);
				continue;
			}
			float num4 = 0f;
			int idx = num3;
			NexusFerry.State state = (NexusFerry.State)status.state;
			if (idx == num3)
			{
				if (state == NexusFerry.State.SailingIn)
				{
					num4 += num + TravelTime;
				}
				else if (state <= NexusFerry.State.Waiting)
				{
					num4 += num;
				}
				else
				{
					num4 += instance.WaitTime + TravelTime;
					NextIdx();
				}
			}
			else
			{
				if (state <= NexusFerry.State.Stopping)
				{
					num4 += TravelTime;
				}
				if (state <= NexusFerry.State.Waiting)
				{
					num4 += instance.WaitTime;
				}
				if (state <= NexusFerry.State.SailingOut)
				{
					num4 += TravelTime;
				}
			}
			while (idx != num2)
			{
				num4 += TravelTime + instance.WaitTime + TravelTime;
				NextIdx();
			}
			estimates.Add((item, num4));
			SeenFerries.Add(zone.Key);
			void NextIdx()
			{
				idx++;
				if (idx >= schedule.Length)
				{
					idx = 0;
				}
			}
		}
		SeenFerries.Clear();
		estimates.Sort(delegate((string NextZone, float? Estimate) a, (string NextZone, float? Estimate) b)
		{
			int num5 = StringComparer.InvariantCultureIgnoreCase.Compare(a.NextZone, b.NextZone);
			if (num5 != 0)
			{
				return num5;
			}
			if (!a.Estimate.HasValue && !b.Estimate.HasValue)
			{
				return 0;
			}
			if (!a.Estimate.HasValue)
			{
				return 1;
			}
			return (!b.Estimate.HasValue) ? (-1) : a.Estimate.Value.CompareTo(b.Estimate.Value);
		});
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.nexusDockTerminal = Pool.Get<ProtoBuf.NexusDockTerminal>();
		info.msg.nexusDockTerminal.schedule = Pool.Get<List<ProtoBuf.NexusDockTerminal.ScheduleEntry>>();
		if (_scheduleEntries == null)
		{
			return;
		}
		foreach (ProtoBuf.NexusDockTerminal.ScheduleEntry scheduleEntry in _scheduleEntries)
		{
			info.msg.nexusDockTerminal.schedule.Add(scheduleEntry.Copy());
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.nexusDockTerminal?.schedule == null)
		{
			return;
		}
		if (_scheduleEntries != null)
		{
			foreach (ProtoBuf.NexusDockTerminal.ScheduleEntry scheduleEntry in _scheduleEntries)
			{
				ProtoBuf.NexusDockTerminal.ScheduleEntry obj = scheduleEntry;
				Pool.Free(ref obj);
			}
			Pool.Free(ref _scheduleEntries, freeElements: false);
		}
		_scheduleEntries = info.msg.nexusDockTerminal.schedule;
		info.msg.nexusDockTerminal.schedule = null;
	}
}
