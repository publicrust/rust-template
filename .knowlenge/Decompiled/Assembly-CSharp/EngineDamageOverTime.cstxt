using System;
using System.Collections.Generic;
using UnityEngine;

public class EngineDamageOverTime
{
	private struct RecentDamage
	{
		public readonly float time;

		public readonly float amount;

		public RecentDamage(float time, float amount)
		{
			this.time = time;
			this.amount = amount;
		}
	}

	private readonly List<RecentDamage> recentDamage = new List<RecentDamage>();

	private readonly float maxSeconds;

	private readonly float triggerDamage;

	private readonly Action trigger;

	public EngineDamageOverTime(float triggerDamage, float maxSeconds, Action trigger)
	{
		this.triggerDamage = triggerDamage;
		this.maxSeconds = maxSeconds;
		this.trigger = trigger;
	}

	public void TakeDamage(float amount)
	{
		recentDamage.Add(new RecentDamage(Time.time, amount));
		if (GetRecentDamage() > triggerDamage)
		{
			trigger();
			recentDamage.Clear();
		}
	}

	private float GetRecentDamage()
	{
		float num = 0f;
		int num2;
		for (num2 = this.recentDamage.Count - 1; num2 >= 0; num2--)
		{
			RecentDamage recentDamage = this.recentDamage[num2];
			if (Time.time > recentDamage.time + maxSeconds)
			{
				break;
			}
			num += recentDamage.amount;
		}
		if (num2 > 0)
		{
			this.recentDamage.RemoveRange(0, num2 + 1);
		}
		return num;
	}
}
