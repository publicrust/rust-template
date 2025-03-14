using UnityEngine;

public class TargetTrigger : TriggerBase
{
	[Tooltip("If set, the entering object must have line of sight to this transform to be added, note this is only checked on entry")]
	public Transform losEyes;

	public override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity == null)
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		if (losEyes != null && !baseEntity.IsVisible(losEyes.transform.position, baseEntity.CenterPoint()))
		{
			return null;
		}
		return baseEntity.gameObject;
	}
}
