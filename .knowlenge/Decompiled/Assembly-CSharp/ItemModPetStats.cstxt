using UnityEngine;

public class ItemModPetStats : ItemMod
{
	[Tooltip("Speed modifier. Value, not percentage.")]
	public float SpeedModifier;

	[Tooltip("HP amount to modify max health by. Value, not percentage.")]
	public float MaxHealthModifier;

	[Tooltip("Damage amount to modify base attack damage by. Value, not percentage.")]
	public float AttackDamageModifier;

	[Tooltip("Attack rate (seconds) to modify base attack rate by. Value, not percentage.")]
	public float AttackRateModifier;

	public void Apply(BasePet pet)
	{
		if (!((Object)(object)pet == (Object)null))
		{
			pet.SetMaxHealth(pet.MaxHealth() + MaxHealthModifier);
			if ((Object)(object)pet.Brain != (Object)null && (Object)(object)pet.Brain.Navigator != (Object)null)
			{
				pet.Brain.Navigator.Speed += SpeedModifier;
			}
			pet.BaseAttackRate += AttackRateModifier;
			pet.BaseAttackDamge += AttackDamageModifier;
		}
	}
}
