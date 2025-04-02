using UnityEngine;

public class TriggerVehicleDrag : TriggerBase, IServerComponent
{
	[Tooltip("If set, the entering object must have line of sight to this transform to be added, note this is only checked on entry")]
	public Transform losEyes;

	public float vehicleDrag;

	internal override GameObject InterestedInObject(GameObject obj)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		obj = base.InterestedInObject(obj);
		if ((Object)(object)obj == (Object)null)
		{
			return null;
		}
		BaseEntity baseEntity = obj.ToBaseEntity();
		if ((Object)(object)baseEntity == (Object)null)
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		if ((Object)(object)losEyes != (Object)null)
		{
			if (entityContents != null && entityContents.Contains(baseEntity))
			{
				return ((Component)baseEntity).gameObject;
			}
			if (!baseEntity.IsVisible(((Component)losEyes).transform.position, baseEntity.CenterPoint()))
			{
				return null;
			}
		}
		return ((Component)baseEntity).gameObject;
	}
}
