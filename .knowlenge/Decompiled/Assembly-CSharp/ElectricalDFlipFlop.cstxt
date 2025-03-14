using System;
using UnityEngine;

public class ElectricalDFlipFlop : IOEntity
{
	[NonSerialized]
	private int setAmount;

	[NonSerialized]
	private int resetAmount;

	[NonSerialized]
	private int toggleAmount;

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		if (inputSlot == 0)
		{
			base.UpdateHasPower(inputAmount, inputSlot);
		}
	}

	public bool GetDesiredState()
	{
		if (setAmount > 0 && resetAmount == 0)
		{
			return true;
		}
		if (setAmount > 0 && resetAmount > 0)
		{
			return true;
		}
		if (setAmount == 0 && resetAmount > 0)
		{
			return false;
		}
		if (toggleAmount > 0)
		{
			return !IsOn();
		}
		if (setAmount == 0 && resetAmount == 0)
		{
			return IsOn();
		}
		return false;
	}

	public void UpdateState()
	{
		if (IsPowered())
		{
			bool num = IsOn();
			bool desiredState = GetDesiredState();
			SetFlag(Flags.On, desiredState);
			if (num != IsOn())
			{
				MarkDirtyForceUpdateOutputs();
			}
		}
	}

	public override void UpdateFromInput(int inputAmount, int inputSlot)
	{
		bool flag = false;
		switch (inputSlot)
		{
		case 1:
			flag = inputAmount != setAmount;
			setAmount = inputAmount;
			break;
		case 2:
			flag = inputAmount != resetAmount;
			resetAmount = inputAmount;
			break;
		case 3:
			flag = inputAmount != toggleAmount;
			toggleAmount = inputAmount;
			break;
		case 0:
			base.UpdateFromInput(inputAmount, inputSlot);
			UpdateState();
			break;
		}
		if (flag)
		{
			UpdateState();
		}
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		int result = Mathf.Max(0, currentEnergy);
		if (outputSlot == -1)
		{
			return result;
		}
		if (!AllowDrainFrom(outputSlot))
		{
			return 0;
		}
		return result;
	}

	public override void UpdateOutputs()
	{
		if (ShouldUpdateOutputs() && ensureOutputsUpdated)
		{
			int passthroughAmount = GetPassthroughAmount(-1);
			if (outputs[0].connectedTo.Get() != null)
			{
				outputs[0].connectedTo.Get().UpdateFromInput(IsOn() ? passthroughAmount : 0, outputs[0].connectedToSlot);
			}
			if (outputs[1].connectedTo.Get() != null)
			{
				outputs[1].connectedTo.Get().UpdateFromInput((!IsOn()) ? passthroughAmount : 0, outputs[1].connectedToSlot);
			}
		}
	}

	public override bool AllowDrainFrom(int outputSlot)
	{
		if (outputSlot == -1)
		{
			return true;
		}
		if (!IsOn())
		{
			return outputSlot == 1;
		}
		return outputSlot == 0;
	}

	public override bool WantsPower(int inputIndex)
	{
		return inputIndex == 0;
	}
}
