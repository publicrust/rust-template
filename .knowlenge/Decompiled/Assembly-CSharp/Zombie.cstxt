public class Zombie : BaseAnimalNPC
{
	[ServerVar(Help = "Population active on the server, per square km", ShowInAdminUI = true)]
	public static float Population;

	public override TraitFlag Traits => TraitFlag.Alive | TraitFlag.Animal | TraitFlag.Food | TraitFlag.Meat;

	public override bool WantsToEat(BaseEntity best)
	{
		if (best.HasTrait(TraitFlag.Alive))
		{
			return false;
		}
		return base.WantsToEat(best);
	}

	protected override void TickSleep()
	{
		Sleep = 100f;
	}

	public override string Categorize()
	{
		return "Zombie";
	}
}
