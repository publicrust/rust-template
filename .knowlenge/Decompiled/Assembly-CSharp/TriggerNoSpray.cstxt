using UnityEngine;

public class TriggerNoSpray : TriggerBase
{
	public BoxCollider TriggerCollider;

	private OBB cachedBounds;

	private Transform cachedTransform;

	private void OnEnable()
	{
		cachedTransform = base.transform;
		cachedBounds = new OBB(cachedTransform, new Bounds(TriggerCollider.center, TriggerCollider.size));
	}

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
		if (baseEntity.ToPlayer() == null)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	public bool IsPositionValid(Vector3 worldPosition)
	{
		return !cachedBounds.Contains(worldPosition);
	}
}
