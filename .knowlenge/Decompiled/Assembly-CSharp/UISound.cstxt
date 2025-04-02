using ConVar;
using UnityEngine;

public static class UISound
{
	private static AudioSource source;

	private static AudioSource GetAudioSource()
	{
		if (source != null)
		{
			return source;
		}
		source = new GameObject("UISound").AddComponent<AudioSource>();
		source.spatialBlend = 0f;
		source.volume = 1f;
		return source;
	}

	public static void Play(AudioClip clip, float volume = 1f)
	{
		if (!(clip == null))
		{
			GetAudioSource().volume = volume * Audio.master * 0.4f;
			GetAudioSource().PlayOneShot(clip);
		}
	}
}
