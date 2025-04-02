using ConVar;
using UnityEngine;

public static class UISound
{
	private static AudioSource source;

	private static AudioSource GetAudioSource()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)source != (Object)null)
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
		if (!((Object)(object)clip == (Object)null))
		{
			GetAudioSource().volume = volume * Audio.master * 0.4f;
			GetAudioSource().PlayOneShot(clip);
		}
	}
}
