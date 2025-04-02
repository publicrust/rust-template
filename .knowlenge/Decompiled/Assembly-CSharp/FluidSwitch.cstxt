using UnityEngine;

public class FluidSwitch : ElectricSwitch
{
	private Flags Flag_PumpPowered = Flags.Reserved6;

	public Animator PumpAnimator;

	private bool pumpEnabled;

	private int lastToggleInput;

	public override bool IsGravitySource => true;

	protected override bool DisregardGravityRestrictionsOnLiquid => HasFlag(Flag_PumpPowered);

	public override void ResetState()
	{
		base.ResetState();
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		if (inputSlot == 1 && lastToggleInput != inputAmount)
		{
			lastToggleInput = inputAmount;
			SetSwitch(inputAmount > 0);
		}
		if (inputSlot == 2)
		{
			bool num = pumpEnabled;
			pumpEnabled = inputAmount > 0;
			if (num != pumpEnabled)
			{
				lastPassthroughEnergy = -1;
				SetFlag(Flag_PumpPowered, pumpEnabled);
				SendChangedToRoot(forceUpdate: true);
			}
		}
	}

	public override void SetSwitch(bool wantsOn)
	{
		base.SetSwitch(wantsOn);
		Invoke(DelayedSendChanged, IOEntity.responsetime * 2f);
	}

	private void DelayedSendChanged()
	{
		SendChangedToRoot(forceUpdate: true);
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (outputSlot == 0)
		{
			if (!IsOn())
			{
				return 0;
			}
			return GetCurrentEnergy();
		}
		return 0;
	}

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override bool AllowLiquidPassthrough(IOEntity fromSource, Vector3 sourceWorldPosition, bool forPlacement = false)
	{
		if (!forPlacement && !IsOn())
		{
			return false;
		}
		return base.AllowLiquidPassthrough(fromSource, sourceWorldPosition);
	}
}
