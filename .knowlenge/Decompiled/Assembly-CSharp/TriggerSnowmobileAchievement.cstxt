using UnityEngine;

public class TriggerSnowmobileAchievement : TriggerBase
{
	internal override GameObject InterestedInObject(GameObject obj)
	{
		BaseEntity baseEntity = obj.ToBaseEntity();
		if ((Object)(object)baseEntity != (Object)null && baseEntity.isServer && (Object)(object)baseEntity.ToPlayer() != (Object)null)
		{
			return ((Component)baseEntity).gameObject;
		}
		return null;
	}
}
