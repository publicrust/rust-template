using System;
using UnityEngine;

public class TOD_Time : MonoBehaviour
{
	[Tooltip("Length of one day in minutes.")]
	[TOD_Min(0f)]
	public float DayLengthInMinutes = 30f;

	[Tooltip("Progress time at runtime.")]
	public bool ProgressTime = true;

	[Tooltip("Set the date to the current device date on start.")]
	public bool UseDeviceDate;

	[Tooltip("Set the time to the current device time on start.")]
	public bool UseDeviceTime;

	[Tooltip("Apply the time curve when progressing time.")]
	public bool UseTimeCurve;

	[Tooltip("Time progression curve.")]
	public AnimationCurve TimeCurve = AnimationCurve.Linear(0f, 0f, 24f, 24f);

	private TOD_Sky sky;

	private AnimationCurve timeCurve;

	private AnimationCurve timeCurveInverse;

	private float timeFraction;

	public event Action OnSecond;

	public event Action OnMinute;

	public event Action OnHour;

	public event Action OnDay;

	public event Action OnMonth;

	public event Action OnYear;

	public event Action OnSunrise;

	public event Action OnSunset;

	public void RefreshTimeCurve()
	{
		TimeCurve.preWrapMode = WrapMode.Once;
		TimeCurve.postWrapMode = WrapMode.Once;
		ApproximateCurve(TimeCurve, out timeCurve, out timeCurveInverse);
		timeCurve.preWrapMode = WrapMode.Loop;
		timeCurve.postWrapMode = WrapMode.Loop;
		timeCurveInverse.preWrapMode = WrapMode.Loop;
		timeCurveInverse.postWrapMode = WrapMode.Loop;
	}

	public float ApplyTimeCurve(float deltaTime)
	{
		float num = timeCurveInverse.Evaluate(sky.Cycle.Hour) + deltaTime;
		deltaTime = timeCurve.Evaluate(num) - sky.Cycle.Hour;
		if (num >= 24f)
		{
			deltaTime += (float)((int)num / 24 * 24);
		}
		else if (num < 0f)
		{
			deltaTime += (float)(((int)num / 24 - 1) * 24);
		}
		return deltaTime;
	}

	public float EvaulateTimeCurve(float hour)
	{
		return timeCurve.Evaluate(hour);
	}

	public void AddHours(float hours, bool adjust = true)
	{
		if (UseTimeCurve && adjust)
		{
			hours = ApplyTimeCurve(hours);
		}
		DateTime dateTime = sky.Cycle.DateTime;
		DateTime dateTime2 = dateTime.AddHours(hours);
		sky.Cycle.DateTime = dateTime2;
		if (dateTime2.Year > dateTime.Year)
		{
			if (this.OnYear != null)
			{
				this.OnYear();
			}
			if (this.OnMonth != null)
			{
				this.OnMonth();
			}
			if (this.OnDay != null)
			{
				this.OnDay();
			}
			if (this.OnHour != null)
			{
				this.OnHour();
			}
			if (this.OnMinute != null)
			{
				this.OnMinute();
			}
			if (this.OnSecond != null)
			{
				this.OnSecond();
			}
		}
		else if (dateTime2.Month > dateTime.Month)
		{
			if (this.OnMonth != null)
			{
				this.OnMonth();
			}
			if (this.OnDay != null)
			{
				this.OnDay();
			}
			if (this.OnHour != null)
			{
				this.OnHour();
			}
			if (this.OnMinute != null)
			{
				this.OnMinute();
			}
			if (this.OnSecond != null)
			{
				this.OnSecond();
			}
		}
		else if (dateTime2.Day > dateTime.Day)
		{
			if (this.OnDay != null)
			{
				this.OnDay();
			}
			if (this.OnHour != null)
			{
				this.OnHour();
			}
			if (this.OnMinute != null)
			{
				this.OnMinute();
			}
			if (this.OnSecond != null)
			{
				this.OnSecond();
			}
		}
		else if (dateTime2.Hour > dateTime.Hour)
		{
			if (this.OnHour != null)
			{
				this.OnHour();
			}
			if (this.OnMinute != null)
			{
				this.OnMinute();
			}
			if (this.OnSecond != null)
			{
				this.OnSecond();
			}
		}
		else if (dateTime2.Minute > dateTime.Minute)
		{
			if (this.OnMinute != null)
			{
				this.OnMinute();
			}
			if (this.OnSecond != null)
			{
				this.OnSecond();
			}
		}
		else if (dateTime2.Second > dateTime.Second && this.OnSecond != null)
		{
			this.OnSecond();
		}
		double totalHours = dateTime.TimeOfDay.TotalHours;
		double totalHours2 = dateTime2.TimeOfDay.TotalHours;
		if (totalHours < (double)sky.SunriseTime && totalHours2 >= (double)sky.SunriseTime && this.OnSunrise != null)
		{
			this.OnSunrise();
		}
		if (totalHours < (double)sky.SunsetTime && totalHours2 >= (double)sky.SunsetTime && this.OnSunset != null)
		{
			this.OnSunset();
		}
	}

	public void AddSeconds(float seconds, bool adjust = true)
	{
		AddHours(seconds / 3600f);
	}

	private void CalculateLinearTangents(Keyframe[] keys)
	{
		for (int i = 0; i < keys.Length; i++)
		{
			Keyframe keyframe = keys[i];
			if (i > 0)
			{
				Keyframe keyframe2 = keys[i - 1];
				keyframe.inTangent = (keyframe.value - keyframe2.value) / (keyframe.time - keyframe2.time);
			}
			if (i < keys.Length - 1)
			{
				Keyframe keyframe3 = keys[i + 1];
				keyframe.outTangent = (keyframe3.value - keyframe.value) / (keyframe3.time - keyframe.time);
			}
			keys[i] = keyframe;
		}
	}

	private void ApproximateCurve(AnimationCurve source, out AnimationCurve approxCurve, out AnimationCurve approxInverse)
	{
		Keyframe[] array = new Keyframe[25];
		Keyframe[] array2 = new Keyframe[25];
		float num = -0.01f;
		for (int i = 0; i < 25; i++)
		{
			num = Mathf.Max(num + 0.01f, source.Evaluate(i));
			array[i] = new Keyframe(i, num);
			array2[i] = new Keyframe(num, i);
		}
		CalculateLinearTangents(array);
		CalculateLinearTangents(array2);
		approxCurve = new AnimationCurve(array);
		approxInverse = new AnimationCurve(array2);
	}

	protected void Awake()
	{
		sky = GetComponent<TOD_Sky>();
		if (UseDeviceDate)
		{
			sky.Cycle.Year = DateTime.Now.Year;
			sky.Cycle.Month = DateTime.Now.Month;
			sky.Cycle.Day = DateTime.Now.Day;
		}
		if (UseDeviceTime)
		{
			sky.Cycle.Hour = (float)DateTime.Now.TimeOfDay.TotalHours;
		}
		RefreshTimeCurve();
	}

	protected void Update()
	{
		if (ProgressTime && DayLengthInMinutes > 0f)
		{
			float num = 1440f / DayLengthInMinutes;
			float num2 = timeFraction + Time.deltaTime;
			int num3 = Mathf.FloorToInt(num2 / (1f / 30f)) + 1;
			for (int i = 0; i < num3; i++)
			{
				float num4 = ((num2 >= 1f / 30f) ? (1f / 30f) : 0f);
				AddSeconds(num4 * num);
				num2 -= num4;
			}
			timeFraction = num2;
		}
	}
}
