using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Environment Volume Properties Collection")]
public class EnvironmentVolumePropertiesCollection : ScriptableObject
{
	public float TransitionSpeed = 1f;

	public EnvironmentVolumeProperties[] Properties;

	public EnvironmentVolumeProperties FindQuality(int quality)
	{
		EnvironmentVolumeProperties[] properties = Properties;
		foreach (EnvironmentVolumeProperties environmentVolumeProperties in properties)
		{
			if (environmentVolumeProperties.ReflectionQuality == quality)
			{
				return environmentVolumeProperties;
			}
		}
		return null;
	}
}
