public class BaseAnimalNPC : BaseNpc
{
	public string deathStatName = "";

	public override void OnKilled(HitInfo hitInfo = null)
	{
		if (hitInfo != null)
		{
			BasePlayer initiatorPlayer = hitInfo.InitiatorPlayer;
			if (initiatorPlayer != null)
			{
				initiatorPlayer.GiveAchievement("KILL_ANIMAL");
				if (!string.IsNullOrEmpty(deathStatName))
				{
					initiatorPlayer.stats.Add(deathStatName, 1, (Stats)5);
					initiatorPlayer.stats.Save();
				}
				initiatorPlayer.LifeStoryKill(this);
			}
		}
		base.OnKilled((HitInfo)null);
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		if (base.isServer && (bool)info.InitiatorPlayer && !info.damageTypes.IsMeleeType())
		{
			info.InitiatorPlayer.LifeStoryShotHit(info.Weapon);
		}
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		Kill();
	}
}
