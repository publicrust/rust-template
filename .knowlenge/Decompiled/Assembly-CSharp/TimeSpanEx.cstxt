using System;

public static class TimeSpanEx
{
	public static string ToShortString(this TimeSpan timeSpan)
	{
		return $"{(int)timeSpan.TotalHours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
	}

	public static string ToShortStringNoHours(this TimeSpan timeSpan)
	{
		return $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
	}
}
