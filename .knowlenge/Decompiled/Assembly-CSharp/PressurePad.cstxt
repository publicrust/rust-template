using UnityEngine;

public class PressurePad : BaseDetector
{
	public float pressPowerTime = 0.5f;

	public int pressPowerAmount = 2;

	public const Flags Flag_EmittingPower = Flags.Reserved3;

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public override bool IsRootEntity()
	{
		return true;
	}

	public override bool ShouldTrigger()
	{
		return true;
	}

	public override void OnDetectorTriggered()
	{
		base.OnDetectorTriggered();
		Invoke(UnpowerTime, pressPowerTime);
		SetFlag(Flags.Reserved3, b: true);
	}

	public override void OnDetectorReleased()
	{
		base.OnDetectorReleased();
		SetFlag(Flags.Reserved3, b: false);
	}

	public void UnpowerTime()
	{
		SetFlag(Flags.Reserved3, b: false);
		MarkDirty();
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (HasFlag(Flags.Reserved1))
		{
			int passthroughAmount = base.GetPassthroughAmount(0);
			if (HasFlag(Flags.Reserved3))
			{
				return Mathf.Max(pressPowerAmount, passthroughAmount);
			}
			if (IsPowered())
			{
				return passthroughAmount;
			}
		}
		return 0;
	}
}
