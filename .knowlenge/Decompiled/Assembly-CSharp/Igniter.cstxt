using System.Collections.Generic;
using Facepunch;
using Rust;
using UnityEngine;

public class Igniter : IOEntity
{
	public float IgniteRange = 5f;

	public float IgniteFrequency = 1f;

	public float IgniteStartDelay;

	public Transform LineOfSightEyes;

	public float SelfDamagePerIgnite = 0.5f;

	public int PowerConsumption = 2;

	public override int ConsumptionAmount()
	{
		return PowerConsumption;
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		base.UpdateHasPower(inputAmount, inputSlot);
		if (inputAmount > 0)
		{
			InvokeRepeating(IgniteInRange, IgniteStartDelay, IgniteFrequency);
		}
		else if (IsInvoking(IgniteInRange))
		{
			CancelInvoke(IgniteInRange);
		}
	}

	private void IgniteInRange()
	{
		List<BaseEntity> obj = Pool.GetList<BaseEntity>();
		Vis.Entities(LineOfSightEyes.position, IgniteRange, obj, 1236495121);
		int num = 0;
		foreach (BaseEntity item in obj)
		{
			if (item.HasFlag(Flags.On) || !item.IsVisible(LineOfSightEyes.position))
			{
				continue;
			}
			if (item.isServer && item is BaseOven)
			{
				(item as BaseOven).StartCooking();
				if (item.HasFlag(Flags.On))
				{
					num++;
				}
			}
			else if (item.isServer && item is IIgniteable igniteable && igniteable.CanIgnite())
			{
				igniteable.Ignite(base.transform.position);
				num++;
			}
		}
		Pool.FreeList(ref obj);
		Hurt(SelfDamagePerIgnite, DamageType.ElectricShock, this, useProtection: false);
	}
}
