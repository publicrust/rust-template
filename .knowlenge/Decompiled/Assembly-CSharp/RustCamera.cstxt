using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public abstract class RustCamera<T> : SingletonComponent<T> where T : RustCamera<T>
{
	[SerializeField]
	private AmplifyOcclusionEffect ssao;

	[SerializeField]
	private SEScreenSpaceShadows contactShadows;

	[SerializeField]
	private VisualizeTexelDensity visualizeTexelDensity;

	[SerializeField]
	private EnvironmentVolumePropertiesCollection environmentVolumeProperties;

	[SerializeField]
	private PostProcessLayer post;

	[SerializeField]
	private PostProcessVolume baseEffectVolume;
}
