using UnityEngine;

public class TriggerEnsnare : TriggerBase
{
	public bool blockHands = true;

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
		return baseEntity.gameObject;
	}
}
