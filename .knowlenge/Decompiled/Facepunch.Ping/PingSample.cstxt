using System;
using System.Collections.Generic;
using System.Linq;
using Facepunch.Ping;
using UnityEngine;

internal class PingSample : IComparable<PingSample>
{
	private List<int> _samples = new List<int>();

	public PingAddress Region { get; }

	public IReadOnlyList<int> Samples => _samples;

	public int Value { get; set; }

	internal Ping PingInstance { get; set; }

	internal DateTime Timestamp { get; set; }

	internal bool IsDone()
	{
		if (PingInstance == null || !PingInstance.isDone)
		{
			return DateTime.UtcNow.Subtract(Timestamp) > TimeSpan.FromMilliseconds(Region.Timeout);
		}
		return true;
	}

	public PingSample(PingAddress region)
	{
		Region = region;
		Value = int.MaxValue;
	}

	public void AddSample(int sample)
	{
		_samples.Add(sample);
		Value = _samples.Min();
	}

	public int CompareTo(PingSample other)
	{
		return Value.CompareTo(other.Value);
	}
}
