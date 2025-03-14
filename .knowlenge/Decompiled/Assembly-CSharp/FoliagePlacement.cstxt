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

	[Header("Placement Range")]
	[MinMax(0f, 1f)]
	public MinMax Range = new MinMax(0f, 1f);

	public float RangeFade = 0.1f;

	[Header("LOD")]
	[Range(0f, 1f)]
	public float DistanceDensity;

	[Range(1f, 2f)]
	public float DistanceScaling = 2f;

	[Header("Visuals")]
	public Material material;

	public Mesh mesh;

	public const int octaves = 1;

	public const float frequency = 0.05f;

	public const float amplitude = 0.5f;

	public const float offset = 0.5f;
}
