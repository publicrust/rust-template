public class CableTunnel : IOEntity
{
	private const int numChannels = 4;

	private int[] inputAmounts = new int[4];

	public override bool WantsPower(int inputIndex)
	{
		return true;
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		int num = inputAmounts[inputSlot];
		inputAmounts[inputSlot] = inputAmount;
		if (inputAmount != num)
		{
			ensureOutputsUpdated = true;
		}
		base.IOStateChanged(inputAmount, inputSlot);
	}

	public override void UpdateOutputs()
	{
		if (!ShouldUpdateOutputs() || !ensureOutputsUpdated)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			IOSlot iOSlot = outputs[i];
			if (iOSlot.connectedTo.Get() != null)
			{
				iOSlot.connectedTo.Get().UpdateFromInput(inputAmounts[i], iOSlot.connectedToSlot);
			}
		}
	}
}
