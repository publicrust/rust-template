using UnityEngine;

public class ItemModFishable : ItemMod
{
	public bool CanBeFished = true;

	[Header("Catching Behaviour")]
	public float StrainModifier = 1f;

	public float MoveMultiplier = 1f;

	public float ReelInSpeedMultiplier = 1f;

	public float CatchWaitTimeMultiplier = 1f;

	[Header("Catch Criteria")]
	public float MinimumBaitLevel;

	public float MaximumBaitLevel;

	public float MinimumWaterDepth;

	public float MaximumWaterDepth;

	[InspectorFlags]
	public WaterBody.FishingTag RequiredTag;

	[Range(0f, 1f)]
	public float Chance;

	public string SteamStatName;

	[Header("Mounting")]
	public bool CanBeMounted;

	public int FishMountIndex;
}
