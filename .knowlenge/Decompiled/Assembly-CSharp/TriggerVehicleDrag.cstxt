using UnityEngine;

public class TriggerVehicleDrag : TriggerBase, IServerComponent
{
	[Tooltip("If set, the entering object must have line of sight to this transform to be added, note this is only checked on entry")]
	public Transform losEyes;

	public float vehicleDrag;

	internal override GameObject InterestedInObject(GameObject obj)
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
		if (losEyes != null)
		{
			if (entityContents != null && entityContents.Contains(baseEntity))
			{
				return baseEntity.gameObject;
			}
			if (!baseEntity.IsVisible(losEyes.transform.position, baseEntity.CenterPoint()))
			{
				return null;
			}
		}
		return baseEntity.gameObject;
	}
}
