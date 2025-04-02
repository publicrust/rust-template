using UnityEngine;

public class ORSwitch : IOEntity
{
	private int input1Amount;

	private int input2Amount;

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override bool WantsPower(int inputIndex)
	{
		if (IsFlickering())
		{
			return true;
		}
		if (input1Amount == 0 && input2Amount == 0)
		{
			return false;
		}
		if (input1Amount == input2Amount)
		{
			return inputIndex == 0;
		}
		int num = ((input1Amount <= input2Amount) ? 1 : 0);
		return inputIndex == num;
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		int b = Mathf.Max(input1Amount, input2Amount);
		return Mathf.Max(0, b);
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		SetFlag(Flags.Reserved8, input1Amount > 0 || input2Amount > 0, recursive: false, networkupdate: false);
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
	}

	public override void UpdateFromInput(int inputAmount, int slot)
	{
		if (IsConnectedTo(this, slot, IOEntity.backtracking))
		{
			inputAmount = 0;
		}
		switch (slot)
		{
		case 0:
			input1Amount = inputAmount;
			break;
		case 1:
			input2Amount = inputAmount;
			break;
		}
		int num = input1Amount + input2Amount;
		bool b = num > 0;
		Flags num2 = flags;
		SetFlag(Flags.Reserved1, input1Amount > 0, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved2, input2Amount > 0, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved3, b, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved4, input1Amount > 0 || input2Amount > 0, recursive: false, networkupdate: false);
		SetFlag(Flags.On, num > 0, recursive: false, networkupdate: false);
		if (num2 != flags)
		{
			SendNetworkUpdate_Flags();
		}
		base.UpdateFromInput(inputAmount, slot);
	}
}
