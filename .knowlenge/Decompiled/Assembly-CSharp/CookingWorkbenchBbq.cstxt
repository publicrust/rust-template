public class CookingWorkbenchBbq : BaseOven
{
	private CookingWorkbench ParentBench
	{
		get
		{
			if (!parentEntity.IsValid(base.isServer))
			{
				return null;
			}
			return parentEntity.Get(base.isServer) as CookingWorkbench;
		}
	}

	public override void OnAttacked(HitInfo info)
	{
		if (ParentBench != null && base.isServer)
		{
			ParentBench.Hurt(info);
		}
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (base.isServer && next.HasFlag(Flags.On) != old.HasFlag(Flags.On))
		{
			CookingWorkbench parentBench = ParentBench;
			if (parentBench != null)
			{
				bool b = (parentBench.IsOn() ? parentBench.IsOn() : next.HasFlag(Flags.On));
				parentBench.SetFlag(Flags.Reserved9, b);
			}
		}
	}

	public override void AdminKill()
	{
		BaseEntity baseEntity = GetParentEntity();
		if (baseEntity != null)
		{
			baseEntity.AdminKill();
		}
	}
}
