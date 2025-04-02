using UnityEngine;

public static class Radiation
{
	public enum Tier
	{
		MINIMAL,
		LOW,
		MEDIUM,
		HIGH,
		NONE
	}

	[ServerVar]
	public static bool water_loot_damage = true;

	[ServerVar]
	public static bool water_inventory_damage = true;

	public static float MaterialToRadsRatio = 0.0044f;

	[ServerVar]
	public static float materialToRadsRatio
	{
		get
		{
			return MaterialToRadsRatio;
		}
		set
		{
			MaterialToRadsRatio = value;
		}
	}

	public static float MaxExposureProtection => 0.5f;

	public static float GetRadiation(Tier tier)
	{
		return tier switch
		{
			Tier.NONE => 0f, 
			Tier.MINIMAL => 2f, 
			Tier.LOW => 10f, 
			Tier.MEDIUM => 25f, 
			Tier.HIGH => 51f, 
			_ => 1f, 
		};
	}

	public static float GetRadiationAfterProtection(float radiationAmount, float radiationProtection)
	{
		return Mathf.Clamp(radiationAmount - radiationProtection, 0f, radiationAmount);
	}
}
