using System;
using System.Collections.Generic;

public class InvokeProfiler
{
	public static InvokeProfiler update = new InvokeProfiler("Update");

	public static InvokeProfiler fixedUpdate = new InvokeProfiler("FixedUpdate");

	public int mode;

	public TimeSpan elapsedTime;

	public int executedCount;

	public int tickCount;

	public int addCount;

	public int deletedCount;

	public List<InvokeTrackingData> trackingDataList = new List<InvokeTrackingData>();

	private readonly Dictionary<InvokeTrackingKey, InvokeTrackingData> trackingDataLookup = new Dictionary<InvokeTrackingKey, InvokeTrackingData>();

	public string Name { get; private set; }

	public InvokeProfiler(string name)
	{
		Name = name;
	}

	public void Reset()
	{
		executedCount = 0;
		tickCount = 0;
		elapsedTime = default(TimeSpan);
		addCount = 0;
		deletedCount = 0;
	}

	public InvokeTrackingData GetTrackingData(InvokeTrackingKey key)
	{
		if (trackingDataLookup.TryGetValue(key, out var value))
		{
			return value;
		}
		value = new InvokeTrackingData(key);
		trackingDataLookup.Add(key, value);
		trackingDataList.Add(value);
		return value;
	}
}
