public class Splitter : IOEntity
{
	public override bool BlockFluidDraining => true;

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (outputSlot < 0 || outputSlot >= outputs.Length)
		{
			return 0;
		}
		IOEntity iOEntity = outputs[outputSlot].connectedTo.Get();
		if (iOEntity == null || iOEntity.IsDestroyed)
		{
			return 0;
		}
		int num = ((cachedOutputsUsed == 0) ? 1 : cachedOutputsUsed);
		int num2 = GetCurrentEnergy();
		int num3 = num2 / num;
		int num4 = 0;
		for (int i = 0; i < outputs.Length; i++)
		{
			if (!(outputs[i].connectedTo.Get() != null) || outputs[i].connectedTo.Get().IsDestroyed)
			{
				continue;
			}
			if (outputSlot == i)
			{
				if (num4 < num2 % num)
				{
					return num3 + 1;
				}
				return num3;
			}
			num4++;
		}
		return 0;
	}

	public override bool IsRootEntity()
	{
		return true;
	}

	public override void OnCircuitChanged(bool forceUpdate)
	{
		MarkDirtyForceUpdateOutputs();
	}
}
