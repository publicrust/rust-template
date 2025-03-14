using UnityEngine;

public class PlayerDetectionTrigger : TriggerBase
{
	public BaseDetector myDetector;

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
		return baseEntity.gameObject;
	}

	public override void OnObjects()
	{
		base.OnObjects();
		myDetector.OnObjects();
	}

	public override void OnEmpty()
	{
		base.OnEmpty();
		myDetector.OnEmpty();
	}
}
