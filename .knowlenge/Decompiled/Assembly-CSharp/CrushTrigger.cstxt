using UnityEngine;

public class CrushTrigger : TriggerHurt
{
	public bool includeNPCs = true;

	public bool requireCentreBelowPosition;

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
		if (!includeNPCs && baseEntity.IsNpc)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	protected override bool CanHurt(BaseCombatEntity ent)
	{
		if (requireCentreBelowPosition && ent.CenterPoint().y > base.transform.position.y)
		{
			return false;
		}
		return base.CanHurt(ent);
	}
}
