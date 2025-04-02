using UnityEngine;

public class EntityFlag_ToggleNotify : EntityFlag_Toggle
{
	public bool UseEntityParent;

	protected override void OnStateToggled(bool state)
	{
		base.OnStateToggled(state);
		if (!UseEntityParent && (Object)(object)base.baseEntity != (Object)null && base.baseEntity is IFlagNotify flagNotify)
		{
			flagNotify.OnFlagToggled(state);
		}
		if (UseEntityParent && (Object)(object)base.baseEntity != (Object)null && (Object)(object)base.baseEntity.GetParentEntity() != (Object)null && base.baseEntity.GetParentEntity() is IFlagNotify flagNotify2)
		{
			flagNotify2.OnFlagToggled(state);
		}
	}
}
