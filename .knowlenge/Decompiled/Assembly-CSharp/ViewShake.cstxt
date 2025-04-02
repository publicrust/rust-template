using System.Collections.Generic;
using UnityEngine;

public class ViewShake
{
	protected class ShakeParameters
	{
		public float endTime;

		public float duration;

		public float amplitude;

		public float frequency;

		public float nextShake;

		public float angle;

		public Vector3 offset;

		public bool infinite;
	}

	protected List<ShakeParameters> Entries = new List<ShakeParameters>();

	public Vector3 PositionOffset { get; protected set; }

	public Vector3 AnglesOffset { get; protected set; }

	public void AddShake(float amplitude, float frequency, float duration)
	{
		Entries.Add(new ShakeParameters
		{
			amplitude = amplitude,
			frequency = Mathf.Max(frequency, 0.01f),
			duration = duration,
			endTime = Time.time + duration,
			nextShake = 0f,
			angle = 0f,
			infinite = (duration <= 0f)
		});
	}

	public void Update()
	{
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		Entries.RemoveAll((ShakeParameters i) => !i.infinite && Time.time > i.endTime);
		foreach (ShakeParameters entry in Entries)
		{
			if (Time.time > entry.nextShake)
			{
				entry.nextShake = Time.time + 1f / entry.frequency;
				entry.offset = new Vector3(Random.Range(0f - entry.amplitude, entry.amplitude), Random.Range(0f - entry.amplitude, entry.amplitude), Random.Range(0f - entry.amplitude, entry.amplitude));
				entry.angle = Random.Range((0f - entry.amplitude) * 0.25f, entry.amplitude * 0.25f);
			}
			float num = 0f;
			float num2 = (entry.infinite ? 1f : ((entry.endTime - Time.time) / entry.duration));
			if (num2 != 0f)
			{
				num = entry.frequency / num2;
			}
			num2 *= num2;
			float f = Time.time * num;
			num2 *= Mathf.Sin(f);
			zero += entry.offset * num2;
			zero2.z += entry.angle * num2;
			if (!entry.infinite)
			{
				entry.amplitude -= entry.amplitude * Time.deltaTime / (entry.duration * entry.frequency);
			}
		}
		PositionOffset = zero * 0.01f;
		AnglesOffset = zero2;
	}

	public void Stop()
	{
		Entries.Clear();
		PositionOffset = Vector3.zero;
		AnglesOffset = Vector3.zero;
	}
}
