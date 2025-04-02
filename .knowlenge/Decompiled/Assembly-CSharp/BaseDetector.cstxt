using UnityEngine;

public class BaseDetector : IOEntity, IDetector
{
	public PlayerDetectionTrigger myTrigger;

	public const Flags Flag_HasContents = Flags.Reserved1;

	public override int ConsumptionAmount()
	{
		return base.ConsumptionAmount();
	}

	public virtual bool ShouldTrigger()
	{
		return IsPowered();
	}

	public virtual void OnObjects()
	{
		SetFlag(Flags.Reserved1, b: true);
		if (ShouldTrigger())
		{
			OnDetectorTriggered();
			MarkDirty();
		}
	}

	public void OnObjectAdded(GameObject obj, Collider col)
	{
	}

	public virtual void OnEmpty()
	{
		SetFlag(Flags.Reserved1, b: false);
		if (ShouldTrigger())
		{
			OnDetectorReleased();
			MarkDirty();
		}
	}

	public virtual void OnDetectorTriggered()
	{
	}

	public virtual void OnDetectorReleased()
	{
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (!HasFlag(Flags.Reserved1))
		{
			return 0;
		}
		return base.GetPassthroughAmount();
	}
}
