using System;
using UnityEngine;

public static class DigitalClockEx
{
	public static TimeSpan ToTimeSpan(this float value)
	{
		int num = Mathf.RoundToInt(value * 60f);
		int hours = num / 60;
		int minutes = num % 60;
		return new TimeSpan(hours, minutes, 0);
	}

	public static float ToFloat(this TimeSpan timeSpan)
	{
		int hours = timeSpan.Hours;
		float num = (float)timeSpan.Minutes / 60f;
		return (float)hours + num;
	}
}
