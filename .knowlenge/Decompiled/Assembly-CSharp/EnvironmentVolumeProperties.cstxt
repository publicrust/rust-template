using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Environment Volume Properties")]
public class EnvironmentVolumeProperties : ScriptableObject
{
	public int ReflectionQuality;

	public LayerMask ReflectionCullingFlags;

	[Horizontal(1, 0)]
	public EnvironmentMultiplier[] ReflectionMultipliers;

	[Horizontal(1, 0)]
	public EnvironmentMultiplier[] AmbientMultipliers;

	public float FindReflectionMultiplier(EnvironmentType type)
	{
		EnvironmentMultiplier[] reflectionMultipliers = ReflectionMultipliers;
		foreach (EnvironmentMultiplier environmentMultiplier in reflectionMultipliers)
		{
			if ((type & environmentMultiplier.Type) != 0)
			{
				return environmentMultiplier.Multiplier;
			}
		}
		return 1f;
	}

	public float FindAmbientMultiplier(EnvironmentType type)
	{
		EnvironmentMultiplier[] ambientMultipliers = AmbientMultipliers;
		foreach (EnvironmentMultiplier environmentMultiplier in ambientMultipliers)
		{
			if ((type & environmentMultiplier.Type) != 0)
			{
				return environmentMultiplier.Multiplier;
			}
		}
		return 1f;
	}
}
