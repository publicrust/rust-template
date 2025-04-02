using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Plant Properties")]
public class PlantProperties : ScriptableObject
{
	public enum State
	{
		Seed,
		Seedling,
		Sapling,
		Crossbreed,
		Mature,
		Fruiting,
		Ripe,
		Dying
	}

	[Serializable]
	public struct Stage
	{
		public State nextState;

		public float lifeLength;

		public float health;

		public float resources;

		public float yield;

		public GameObjectRef skinObject;

		public bool IgnoreConditions;

		public float lifeLengthSeconds => lifeLength * 60f;
	}

	public Translate.Phrase Description;

	public GrowableGeneProperties Genes;

	[ArrayIndexIsEnum(enumType = typeof(State))]
	public Stage[] stages = new Stage[8];

	[Header("Metabolism")]
	public AnimationCurve timeOfDayHappiness = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(12f, 1f), new Keyframe(24f, 0f));

	public AnimationCurve temperatureHappiness = new AnimationCurve(new Keyframe(-10f, -1f), new Keyframe(1f, 0f), new Keyframe(30f, 1f), new Keyframe(50f, 0f), new Keyframe(80f, -1f));

	public AnimationCurve temperatureWaterRequirementMultiplier = new AnimationCurve(new Keyframe(-10f, 1f), new Keyframe(0f, 1f), new Keyframe(30f, 1f), new Keyframe(50f, 1f), new Keyframe(80f, 1f));

	public AnimationCurve fruitVisualScaleCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.75f, 1f), new Keyframe(1f, 0f));

	public int MaxSeasons = 1;

	public float WaterIntake = 20f;

	public float OptimalLightQuality = 1f;

	public float OptimalWaterQuality = 1f;

	public float OptimalGroundQuality = 1f;

	public float OptimalTemperatureQuality = 1f;

	[Header("Harvesting")]
	public BaseEntity.Menu.Option pickOption;

	public BaseEntity.Menu.Option pickAllOption;

	public BaseEntity.Menu.Option eatOption;

	public ItemDefinition pickupItem;

	public BaseEntity.Menu.Option cloneOption;

	public BaseEntity.Menu.Option cloneAllOption;

	public BaseEntity.Menu.Option removeDyingOption;

	public BaseEntity.Menu.Option removeDyingAllOption;

	public ItemDefinition removeDyingItem;

	public GameObjectRef removeDyingEffect;

	public int pickupMultiplier = 1;

	public GameObjectRef pickEffect;

	public int maxHarvests = 1;

	public bool disappearAfterHarvest;

	[Header("Seeds")]
	public GameObjectRef CrossBreedEffect;

	public ItemDefinition SeedItem;

	public ItemDefinition CloneItem;

	public int BaseCloneCount = 1;

	[Header("Market")]
	public int BaseMarketValue = 10;
}
