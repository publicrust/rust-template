using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Rust/Foliage Placement")]
public class FoliagePlacement : ScriptableObject
{
	[Header("Placement")]
	public float Density = 2f;

	[Header("Filter")]
	public SpawnFilter Filter;

	[FormerlySerializedAs("Cutoff")]
	public float FilterCutoff = 0.5f;

	public float FilterFade = 0.1f;

	[FormerlySerializedAs("Scaling")]
	public float FilterScaling = 1f;

	[Header("Randomization")]
	public float RandomScaling = 0.2f;

	[MinMax(0f, 1f)]
	[Header("Placement Range")]
	public MinMax Range = new MinMax(0f, 1f);

	public float RangeFade = 0.1f;

	[Range(0f, 1f)]
	[Header("LOD")]
	public float DistanceDensity;

	[Range(1f, 2f)]
	public float DistanceScaling = 2f;

	[Header("Visuals")]
	public Material material;

	[FormerlySerializedAs("mesh")]
	public Mesh mesh0;

	[FormerlySerializedAs("mesh")]
	public Mesh mesh1;

	[FormerlySerializedAs("mesh")]
	public Mesh mesh2;

	public const int lods = 5;

	public const int octaves = 1;

	public const float frequency = 0.05f;

	public const float amplitude = 0.5f;

	public const float offset = 0.5f;
}
