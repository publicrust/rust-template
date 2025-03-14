using System;

public class ElectricalDFlipFlop : IOEntity
{
	[NonSerialized]
	private int setAmount;

	[NonSerialized]
	private int resetAmount;

	[NonSerialized]
	private int toggleAmount;

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
		switch (inputSlot)
		{
		case 1:
			setAmount = inputAmount;
			UpdateState();
			break;
		case 2:
			resetAmount = inputAmount;
			UpdateState();
			break;
		case 3:
			toggleAmount = inputAmount;
			UpdateState();
			break;
		case 0:
			base.UpdateFromInput(inputAmount, inputSlot);
			UpdateState();
			break;
		}
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		return base.GetPassthroughAmount(outputSlot);
	}

	public override void UpdateOutputs()
	{
		if (ShouldUpdateOutputs() && ensureOutputsUpdated)
		{
			if (outputs[0].connectedTo.Get() != null)
			{
				outputs[0].connectedTo.Get().UpdateFromInput(IsOn() ? currentEnergy : 0, outputs[0].connectedToSlot);
			}
			if (outputs[1].connectedTo.Get() != null)
			{
				outputs[1].connectedTo.Get().UpdateFromInput((!IsOn()) ? currentEnergy : 0, outputs[1].connectedToSlot);
			}
		}
	}
}
