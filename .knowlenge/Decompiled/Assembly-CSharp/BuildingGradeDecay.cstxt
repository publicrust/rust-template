using ConVar;

public class BuildingGradeDecay : Decay
{
	public BuildingGrade.Enum decayGrade;

	public override float GetDecayDelay(BaseEntity entity)
	{
		return GetDecayDelay(decayGrade);
	}

	public override float GetDecayDuration(BaseEntity entity)
	{
		return GetDecayDuration(decayGrade);
	}

	public override bool ShouldDecay(BaseEntity entity)
	{
		if (ConVar.Decay.upkeep)
		{
			return true;
		}
		return entity.IsOutside();
	}
}
