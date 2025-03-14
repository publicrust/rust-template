using UnityEngine;

public class TriggerStashPlayer : TriggerBase
{
	public StashContainer Stash;

	internal override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BasePlayer basePlayer = GameObjectEx.ToBaseEntity(obj) as BasePlayer;
		if (basePlayer == null)
		{
			return null;
		}
		if (basePlayer.isClient)
		{
			return null;
		}
		return basePlayer.gameObject;
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
