using UnityEngine;

public class TriggerStashPlayer : TriggerBase
{
	public StashContainer Stash;

	internal override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if ((Object)(object)obj == (Object)null)
		{
			return null;
		}
		BasePlayer basePlayer = obj.ToBaseEntity() as BasePlayer;
		if ((Object)(object)basePlayer == (Object)null)
		{
			return null;
		}
		if (basePlayer.isClient)
		{
			return null;
		}
		return ((Component)basePlayer).gameObject;
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		if (entityContents == null || !entityContents.Contains(ent))
		{
			base.OnEntityEnter(ent);
			if (ent is BasePlayer basePlayer)
			{
				basePlayer.AddNeabyStash(Stash);
			}
		}
	}

	internal override void OnEntityLeave(BaseEntity ent)
	{
		base.OnEntityLeave(ent);
		if (ent is BasePlayer basePlayer)
		{
			basePlayer.RemoveNearbyStash(Stash);
		}
	}
}
