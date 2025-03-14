public class TriggerParentElevator : TriggerParentEnclosed
{
	public bool AllowHorsesToBypassClippingChecks = true;

	protected override bool IsClipping(BaseEntity ent)
	{
		if (AllowHorsesToBypassClippingChecks && ent is BaseRidableAnimal)
		{
			return false;
		}
		return base.IsClipping(ent);
	}
}
