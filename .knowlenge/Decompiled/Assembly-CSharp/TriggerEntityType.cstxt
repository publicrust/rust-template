using UnityEngine;

public class TriggerEntityType<TEntity> : TriggerBase where TEntity : BaseEntity
{
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
		if (!(baseEntity is TEntity))
		{
			return null;
		}
		return baseEntity.gameObject;
	}
}
