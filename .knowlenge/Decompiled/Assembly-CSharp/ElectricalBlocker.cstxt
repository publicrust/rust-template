public class ElectricalBlocker : IOEntity
{
	protected int input1Amount;

	protected int input2Amount;

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		return base.GetPassthroughAmount(outputSlot) * ((!IsOn()) ? 1 : 0);
	}

	public override bool WantsPower(int inputIndex)
	{
		if (inputIndex != 0 || !IsFlickering())
		{
			return !IsOn();
		}
		return true;
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		SetFlag(Flags.Reserved8, input2Amount > 0, recursive: false, networkupdate: false);
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
	}

	public virtual void UpdateBlocked()
	{
		bool num = IsOn();
		SetFlag(Flags.On, input1Amount > 0, recursive: false, networkupdate: false);
		if (num != IsOn())
		{
			MarkDirty();
		}
	}

	public override void UpdateFromInput(int inputAmount, int inputSlot)
	{
		switch (inputSlot)
		{
		case 1:
			input1Amount = inputAmount;
			UpdateBlocked();
			break;
		case 0:
			input2Amount = inputAmount;
			base.UpdateFromInput(inputAmount, inputSlot);
			break;
		}
	}
}
