using System.Linq;
using Rust;
using UnityEngine;

public class TeslaCoil : IOEntity
{
	public TargetTrigger targetTrigger;

	public TriggerMovement movementTrigger;

	public float powerToDamageRatio = 2f;

	public float dischargeTickRate = 0.25f;

	public float maxDischargeSelfDamageSeconds = 120f;

	public float maxDamageOutput = 35f;

	public Transform damageEyes;

	public const Flags Flag_WeakShorting = Flags.Reserved1;

	public const Flags Flag_StrongShorting = Flags.Reserved2;

	public int powerForHeavyShorting = 10;

	private float lastDischargeTime;

	public override int ConsumptionAmount()
	{
		return Mathf.CeilToInt(maxDamageOutput / powerToDamageRatio);
	}

	public override int DesiredPower(int inputIndex = 0)
	{
		if (!CanDischarge())
		{
			return 0;
		}
		return Mathf.Clamp(currentEnergy, 0, ConsumptionAmount());
	}

	public bool CanDischarge()
	{
		return base.healthFraction >= 0.1f;
	}

	public override void UpdateFromInput(int inputAmount, int inputSlot)
	{
		base.UpdateFromInput(inputAmount, inputSlot);
		if (inputAmount > 0 && CanDischarge())
		{
			float num = Time.time - lastDischargeTime;
			if (num < 0f)
			{
				num = 0f;
			}
			float time = Mathf.Min(dischargeTickRate - num, dischargeTickRate);
			InvokeRepeating(Discharge, time, dischargeTickRate);
			SetFlag(Flags.Reserved1, inputAmount < powerForHeavyShorting, recursive: false, networkupdate: false);
			SetFlag(Flags.Reserved2, inputAmount >= powerForHeavyShorting, recursive: false, networkupdate: false);
			SetFlag(Flags.On, b: true);
		}
		else
		{
			CancelInvoke(Discharge);
			SetFlag(Flags.Reserved1, b: false, recursive: false, networkupdate: false);
			SetFlag(Flags.Reserved2, b: false, recursive: false, networkupdate: false);
			SetFlag(Flags.On, b: false);
		}
	}

	public void Discharge()
	{
		float damageAmount = Mathf.Clamp((float)currentEnergy * powerToDamageRatio, 0f, maxDamageOutput) * dischargeTickRate;
		lastDischargeTime = Time.time;
		if (targetTrigger.entityContents != null)
		{
			BaseEntity[] array = targetTrigger.entityContents.ToArray();
			if (array != null)
			{
				BaseEntity[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BaseCombatEntity component = array2[i].GetComponent<BaseCombatEntity>();
					if ((bool)component && component.IsVisible(damageEyes.transform.position, component.CenterPoint()))
					{
						component.OnAttacked(new HitInfo(this, component, DamageType.ElectricShock, damageAmount));
					}
				}
			}
		}
		float amount = dischargeTickRate / maxDischargeSelfDamageSeconds * MaxHealth();
		Hurt(amount, DamageType.ElectricShock, this, useProtection: false);
		if (!CanDischarge())
		{
			SendChangedToRoot(forceUpdate: true);
		}
	}

	public override void OnRepair()
	{
		base.OnRepair();
		if (CanDischarge())
		{
			SendChangedToRoot(forceUpdate: true);
		}
	}
}
