public class MicrophoneStandIOEntity : IOEntity, IAudioConnectionSource
{
	public int PowerCost = 5;

	public TriggerBase InstrumentTrigger;

	public bool IsStatic;

	public override int ConsumptionAmount()
	{
		return PowerCost;
	}

	public override int DesiredPower(int inputIndex = 0)
	{
		return PowerCost;
	}

	public override int MaximalPowerOutput()
	{
		if (IsStatic)
		{
			return 100;
		}
		return base.MaximalPowerOutput();
	}

	public override int CalculateCurrentEnergy(int inputAmount, int inputSlot)
	{
		if (IsStatic)
		{
			return 100;
		}
		return base.CalculateCurrentEnergy(inputAmount, inputSlot);
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (IsStatic)
		{
			return 100;
		}
		return base.GetPassthroughAmount(outputSlot);
	}

	public override bool IsRootEntity()
	{
		if (IsStatic)
		{
			return true;
		}
		return base.IsRootEntity();
	}

	public IOEntity ToEntity()
	{
		return this;
	}
}
