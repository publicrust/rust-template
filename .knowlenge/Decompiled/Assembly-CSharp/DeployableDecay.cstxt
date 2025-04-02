using ConVar;

public class DeployableDecay : Decay
{
	public float decayDelay = 8f;

	public float decayDuration = 8f;

	public bool overrideHealRate;

	public float decayTickOverride;

	public bool decayIndoors;

	public float healRate = 1f;

	public override float GetDecayDelay(BaseEntity entity)
	{
		return decayDelay * 60f * 60f;
	}

	public override float GetDecayDuration(BaseEntity entity)
	{
		return decayDuration * 60f * 60f;
	}

	public override float GetHealScale(BaseEntity entity)
	{
		if (!overrideHealRate)
		{
			return base.GetHealScale(entity);
		}
		return healRate;
	}

	public override float GetDecayTickOverride()
	{
		return decayTickOverride;
	}

	public override bool ShouldDecay(BaseEntity entity)
	{
		if (ConVar.Decay.upkeep || decayIndoors)
		{
			return true;
		}
		return entity.IsOutside();
	}
}
