using UnityEngine;

public class TriggerSubmarineMoonpool : TriggerBase, IServerComponent
{
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
		if (baseEntity.isServer && baseEntity is BaseSubmarine baseSubmarine)
		{
			return ((Component)baseSubmarine).gameObject;
		}
		return null;
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if (ent is BaseSubmarine baseSubmarine)
		{
			baseSubmarine.OnSurfacedInMoonpool();
		}
	}
}
