public class Horse : BaseAnimalNPC
{
	[ServerVar(Help = "Population active on the server, per square km")]
	public static float Population;

	public override float RealisticMass => 500f;

	public override TraitFlag Traits => TraitFlag.Alive | TraitFlag.Animal | TraitFlag.Food | TraitFlag.Meat;

	public override void ServerInit()
	{
		base.ServerInit();
	}

	public override bool WantsToEat(BaseEntity best)
	{
		if (best.HasTrait(TraitFlag.Alive))
		{
			return false;
		}
		if (best.HasTrait(TraitFlag.Meat))
		{
			return false;
		}
		CollectibleEntity collectibleEntity = best as CollectibleEntity;
		if (collectibleEntity != null)
		{
			ItemAmount[] itemList = collectibleEntity.itemList;
			for (int i = 0; i < itemList.Length; i++)
			{
				if (itemList[i].itemDef.category == ItemCategory.Food)
				{
					return true;
				}
			}
		}
		return base.WantsToEat(best);
	}

	public override string Categorize()
	{
		return "Horse";
	}
}
