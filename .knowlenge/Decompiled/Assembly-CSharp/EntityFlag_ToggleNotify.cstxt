public class EntityFlag_ToggleNotify : EntityFlag_Toggle
{
	public bool UseEntityParent;

	protected override void OnStateToggled(bool state)
	{
		base.OnStateToggled(state);
		if (!UseEntityParent && base.baseEntity != null && base.baseEntity is IFlagNotify flagNotify)
		{
			flagNotify.OnFlagToggled(state);
		}
		if (UseEntityParent && base.baseEntity != null && base.baseEntity.GetParentEntity() != null && base.baseEntity.GetParentEntity() is IFlagNotify flagNotify2)
		{
			flagNotify2.OnFlagToggled(state);
		}
	}
}
