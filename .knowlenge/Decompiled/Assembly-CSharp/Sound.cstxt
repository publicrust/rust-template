using UnityEngine;

public class Sound : MonoBehaviour, IClientComponent
{
	public static float volumeExponent = Mathf.Log(Mathf.Sqrt(10f), 2f);

	public SoundDefinition definition;

	public SoundModifier[] modifiers;

	public SoundSource soundSource;

	public AudioSource[] audioSources = new AudioSource[2];

	[SerializeField]
	private SoundFade _fade;

	[SerializeField]
	private SoundModulation _modulation;

	[SerializeField]
	private SoundOcclusion _occlusion;

	public SoundFade fade => _fade;

	public SoundModulation modulation => _modulation;

	public SoundOcclusion occlusion => _occlusion;
}
