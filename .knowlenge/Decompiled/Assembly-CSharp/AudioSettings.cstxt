using ConVar;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
	public static float duckingFactor = 1f;

	public AudioMixer mixer;

	private void Update()
	{
		if (!(mixer == null))
		{
			mixer.SetFloat("MasterVol", LinearToDecibel(Audio.master * duckingFactor));
			mixer.GetFloat("MusicVol", out var value);
			if (!LevelManager.isLoaded || !MainCamera.isValid)
			{
				mixer.SetFloat("MusicVol", Mathf.Lerp(value, LinearToDecibel(Audio.musicvolumemenu), UnityEngine.Time.deltaTime));
			}
			else
			{
				mixer.SetFloat("MusicVol", Mathf.Lerp(value, LinearToDecibel(Audio.musicvolume), UnityEngine.Time.deltaTime));
			}
			float num = 1f - ((SingletonComponent<MixerSnapshotManager>.Instance == null) ? 0f : SingletonComponent<MixerSnapshotManager>.Instance.deafness);
			mixer.SetFloat("WorldVol", LinearToDecibel(Audio.game * num));
			mixer.SetFloat("WorldVolFlashbang", LinearToDecibel(Audio.game));
			mixer.SetFloat("VoiceVol", LinearToDecibel(Audio.voices * num));
			mixer.SetFloat("InstrumentVol", LinearToDecibel(Audio.instruments * num));
			float num2 = LinearToDecibel(Audio.voiceProps * num) - 28.7f;
			mixer.SetFloat("VoicePropsVol", num2 * num);
			mixer.SetFloat("SeasonalEventsVol", LinearToDecibel(Audio.eventAudio * num));
		}
	}

	private float LinearToDecibel(float linear)
	{
		if (linear > 0f)
		{
			return 20f * Mathf.Log10(linear);
		}
		return -144f;
	}
}
