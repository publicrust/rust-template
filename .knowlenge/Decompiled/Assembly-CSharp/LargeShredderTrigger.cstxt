using UnityEngine;

public class LargeShredderTrigger : TriggerBase
{
	public LargeShredder shredder;

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
		if (!baseEntity.syncPosition)
		{
			return null;
		}
		if (!Object.op_Implicit((Object)(object)((Component)baseEntity).GetComponent<MagnetLiftable>()))
		{
			return null;
		}
		return ((Component)baseEntity).gameObject;
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		shredder.OnEntityEnteredTrigger(ent);
	}
}
