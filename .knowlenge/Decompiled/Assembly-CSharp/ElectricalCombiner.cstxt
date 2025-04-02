using UnityEngine;

public class ElectricalCombiner : IOEntity
{
	public int input1Amount;

	public int input2Amount;

	public int input3Amount;

	public override bool BlockFluidDraining => true;

	public override bool IsRootEntity()
	{
		return true;
	}

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		int num = input1Amount + input2Amount + input3Amount;
		Mathf.Clamp(num, 0, num);
		return num;
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		SetFlag(Flags.Reserved8, input1Amount > 0 || input2Amount > 0, recursive: false, networkupdate: false);
	}

	public override void UpdateFromInput(int inputAmount, int slot)
	{
		if (inputAmount > 0 && IsConnectedTo(this, slot, IOEntity.backtracking * 2, defaultReturn: true))
		{
			inputAmount = 0;
			SetFlag(Flags.Reserved7, b: true);
		}
		else
		{
			SetFlag(Flags.Reserved7, b: false);
		}
		switch (slot)
		{
		case 0:
			input1Amount = inputAmount;
			break;
		case 1:
			input2Amount = inputAmount;
			break;
		case 2:
			input3Amount = inputAmount;
			break;
		}
		int num = input1Amount + input2Amount + input3Amount;
		bool b = num > 0;
		Flags num2 = flags;
		SetFlag(Flags.Reserved1, input1Amount > 0, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved2, input2Amount > 0, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved3, b, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved4, input1Amount > 0 || input2Amount > 0 || input3Amount > 0, recursive: false, networkupdate: false);
		SetFlag(Flags.On, num > 0, recursive: false, networkupdate: false);
		if (num2 != flags)
		{
			SendNetworkUpdate_Flags();
		}
		base.UpdateFromInput(num, slot);
	}
}
