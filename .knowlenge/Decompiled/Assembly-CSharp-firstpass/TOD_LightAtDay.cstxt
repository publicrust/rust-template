using UnityEngine;

public class TOD_LightAtDay : TOD_Light
{
	public float fadeTime = 1f;

	private float lerpTime;

	private float maxIntensity;

	protected void Start()
	{
		maxIntensity = GetIntensity();
		SetIntensity(TOD_Sky.Instance.IsDay ? maxIntensity : 0f);
	}

	protected void Update()
	{
		int num = (TOD_Sky.Instance.IsDay ? 1 : (-1));
		lerpTime = Mathf.Clamp01(lerpTime + (float)num * Time.deltaTime / fadeTime);
		SetIntensity(Mathf.Lerp(0f, maxIntensity, lerpTime));
	}
}
