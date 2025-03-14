using System.Collections.Generic;
using UnityEngine;

public class TransformInterpolator
{
	public struct Segment
	{
		public Entry tick;

		public Entry prev;

		public Entry next;
	}

	public struct Entry
	{
		public float time;

		public Vector3 pos;

		public Quaternion rot;
	}

	public List<Entry> list = new List<Entry>(32);

	public Entry last;

	public void Add(Entry tick)
	{
		last = tick;
		list.Add(tick);
	}

	public void Cull(float beforeTime)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].time < beforeTime)
			{
				list.RemoveAt(i);
				i--;
			}
		}
	}

	public void Clear()
	{
		list.Clear();
	}

	public Segment Query(float time, float interpolation, float extrapolation, float smoothing)
	{
		Segment result = default(Segment);
		if (list.Count == 0)
		{
			result.prev = last;
			result.next = last;
			result.tick = last;
			return result;
		}
		float num = time - interpolation - smoothing * 0.5f;
		float num2 = Mathf.Min(time - interpolation, last.time);
		float num3 = num2 - smoothing;
		Entry entry = list[0];
		Entry entry2 = last;
		Entry entry3 = list[0];
		Entry entry4 = last;
		foreach (Entry item in list)
		{
			if (item.time < num3)
			{
				entry = item;
			}
			else if (entry2.time >= item.time)
			{
				entry2 = item;
			}
			if (item.time < num2)
			{
				entry3 = item;
			}
			else if (entry4.time >= item.time)
			{
				entry4 = item;
			}
		}
		Entry prev = default(Entry);
		if (entry2.time - entry.time <= Mathf.Epsilon)
		{
			prev.time = num3;
			prev.pos = entry2.pos;
			prev.rot = entry2.rot;
		}
		else
		{
			float t = (num3 - entry.time) / (entry2.time - entry.time);
			prev.time = num3;
			prev.pos = Vector3.LerpUnclamped(entry.pos, entry2.pos, t);
			prev.rot = Quaternion.SlerpUnclamped(entry.rot, entry2.rot, t);
		}
		result.prev = prev;
		Entry entry5 = default(Entry);
		if (entry4.time - entry3.time <= Mathf.Epsilon)
		{
			entry5.time = num2;
			entry5.pos = entry4.pos;
			entry5.rot = entry4.rot;
		}
		else
		{
			float t2 = (num2 - entry3.time) / (entry4.time - entry3.time);
			entry5.time = num2;
			entry5.pos = Vector3.LerpUnclamped(entry3.pos, entry4.pos, t2);
			entry5.rot = Quaternion.SlerpUnclamped(entry3.rot, entry4.rot, t2);
		}
		result.next = entry5;
		if (entry5.time - prev.time <= Mathf.Epsilon)
		{
			result.prev = entry5;
			result.tick = entry5;
			return result;
		}
		if (num - entry5.time > extrapolation)
		{
			result.prev = entry5;
			result.tick = entry5;
			return result;
		}
		Entry tick = default(Entry);
		float t3 = Mathf.Min(num - prev.time, entry5.time + extrapolation - prev.time) / (entry5.time - prev.time);
		tick.time = num;
		tick.pos = Vector3.LerpUnclamped(prev.pos, entry5.pos, t3);
		tick.rot = Quaternion.SlerpUnclamped(prev.rot, entry5.rot, t3);
		result.tick = tick;
		return result;
	}
}
