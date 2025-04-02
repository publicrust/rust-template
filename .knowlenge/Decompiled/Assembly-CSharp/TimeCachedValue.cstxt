using System;
using UnityEngine;

public class TimeCachedValue<T>
{
	public float refreshCooldown;

	public float refreshRandomRange;

	public Func<T> updateValue;

	private T cachedValue;

	private TimeSince cooldown;

	private bool hasRun;

	private bool forceNextRun;

	public T Get(bool force)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (TimeSince.op_Implicit(cooldown) < refreshCooldown && !force && hasRun && !forceNextRun)
		{
			return cachedValue;
		}
		hasRun = true;
		forceNextRun = false;
		cooldown = TimeSince.op_Implicit(0f - Random.Range(0f, refreshRandomRange));
		if (updateValue != null)
		{
			cachedValue = updateValue();
		}
		else
		{
			cachedValue = default(T);
		}
		return cachedValue;
	}

	public void ForceNextRun()
	{
		forceNextRun = true;
	}

	public void UpdateImmediately()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		hasRun = true;
		forceNextRun = false;
		cooldown = TimeSince.op_Implicit(0f - Random.Range(0f, refreshRandomRange));
		if (updateValue != null)
		{
			cachedValue = updateValue();
		}
		else
		{
			cachedValue = default(T);
		}
	}
}
