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
		if (!(pet == null))
		{
			pet.SetMaxHealth(pet.MaxHealth() + MaxHealthModifier);
			if (pet.Brain != null && pet.Brain.Navigator != null)
			{
				pet.Brain.Navigator.Speed += SpeedModifier;
			}
			pet.BaseAttackRate += AttackRateModifier;
			pet.BaseAttackDamge += AttackDamageModifier;
		}
	}
}
