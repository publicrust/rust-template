using UnityEngine;

public class CrushTrigger : TriggerHurt
{
	public bool includeNPCs = true;

	public bool requireCentreBelowPosition;

	internal override GameObject InterestedInObject(GameObject obj)
	{
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
		if (!includeNPCs && baseEntity.IsNpc)
		{
			return null;
		}
		return ((Component)baseEntity).gameObject;
	}

	protected override bool CanHurt(BaseCombatEntity ent)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (requireCentreBelowPosition && ent.CenterPoint().y > ((Component)this).transform.position.y)
		{
			return false;
		}
		return base.CanHurt(ent);
	}
}
