using System;
using UnityEngine;

[Serializable]
public class TOD_CycleParameters
{
	[Tooltip("Current hour of the day.")]
	public float Hour = 12f;

	[Tooltip("Current day of the month.")]
	public int Day = 15;

	[Tooltip("Current month of the year.")]
	public int Month = 6;

	[Tooltip("Current year.")]
	[TOD_Range(1f, 9999f)]
	public int Year = 2000;

	public float RedMoonLerp;

	public DateTime DateTime
	{
		get
		{
			DateTime result = new DateTime(0L, DateTimeKind.Utc);
			if (Year > 0)
			{
				result = result.AddYears(Year - 1);
			}
			if (Month > 0)
			{
				result = result.AddMonths(Month - 1);
			}
			if (Day > 0)
			{
				result = result.AddDays(Day - 1);
			}
			if (Hour > 0f)
			{
				result = result.AddHours(Hour);
			}
			return result;
		}
		set
		{
			Year = value.Year;
			Month = value.Month;
			Day = value.Day;
			Hour = (float)value.Hour + (float)value.Minute / 60f + (float)value.Second / 3600f + (float)value.Millisecond / 3600000f;
		}
	}

	public long Ticks
	{
		get
		{
			return DateTime.Ticks;
		}
		set
		{
			DateTime = new DateTime(value, DateTimeKind.Utc);
		}
	}
}
