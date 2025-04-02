using UnityEngine;

public class TOD_AudioAtDay : TOD_Audio
{
	public float fadeTime = 1f;

	private float lerpTime;

	private float maxVolume;

	protected void Start()
	{
		maxVolume = GetVolume();
		SetVolume(TOD_Sky.Instance.IsDay ? maxVolume : 0f);
	}

	protected void Update()
	{
		int num = (TOD_Sky.Instance.IsDay ? 1 : (-1));
		lerpTime = Mathf.Clamp01(lerpTime + (float)num * Time.deltaTime / fadeTime);
		SetVolume(Mathf.Lerp(0f, maxVolume, lerpTime));
	}
}
