using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Ambience Definition")]
public class AmbienceDefinition : ScriptableObject
{
	[Serializable]
	public class ValueRange
	{
		public float min;

		public float max;

		public ValueRange(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}

	[Header("Sound")]
	public List<SoundDefinition> sounds;

	[Horizontal(2, -1)]
	public ValueRange stingFrequency = new ValueRange(15f, 30f);

	[InspectorFlags]
	[Header("Environment")]
	public TerrainBiome.Enum biomes = (TerrainBiome.Enum)(-1);

	[InspectorFlags]
	public TerrainTopology.Enum topologies = (TerrainTopology.Enum)(-1);

	public EnvironmentType environmentType = EnvironmentType.Underground;

	public bool useEnvironmentType;

	public AnimationCurve time = AnimationCurve.Linear(0f, 0f, 24f, 0f);

	[Horizontal(2, -1)]
	public ValueRange rain = new ValueRange(0f, 1f);

	[Horizontal(2, -1)]
	public ValueRange wind = new ValueRange(0f, 1f);

	[Horizontal(2, -1)]
	public ValueRange snow = new ValueRange(0f, 1f);

	[Horizontal(2, -1)]
	public ValueRange waves = new ValueRange(0f, 10f);
}
