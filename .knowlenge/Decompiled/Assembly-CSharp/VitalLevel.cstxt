using System;
using UnityEngine;

[Serializable]
public struct VitalLevel
{
	public float Level;

	private float lastUsedTime;

	public float TimeSinceUsed => Time.time - lastUsedTime;

	internal void Add(float f)
	{
		Level += f;
		if (Level > 1f)
		{
			Level = 1f;
		}
		if (Level < 0f)
		{
			Level = 0f;
		}
	}

	internal void Use(float f)
	{
		if (!Mathf.Approximately(f, 0f))
		{
			Level -= Mathf.Abs(f);
			if (Level < 0f)
			{
				Level = 0f;
			}
			lastUsedTime = Time.time;
		}
	}
}
