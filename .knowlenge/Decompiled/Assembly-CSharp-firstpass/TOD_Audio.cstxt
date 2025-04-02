using UnityEngine;

public abstract class TOD_Audio : MonoBehaviour
{
	private AudioSource audioComponent;

	protected float GetVolume()
	{
		if ((bool)audioComponent)
		{
			return audioComponent.volume;
		}
		return 0f;
	}

	protected void SetVolume(float value)
	{
		if ((bool)audioComponent)
		{
			audioComponent.volume = value;
			audioComponent.enabled = value > 0f;
		}
	}

	protected void Awake()
	{
		audioComponent = GetComponent<AudioSource>();
	}
}
