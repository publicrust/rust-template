using UnityEngine;

public class TOD_ParticleAtDay : TOD_Particle
{
	public float fadeTime = 1f;

	private float lerpTime;

	private float maxEmission;

	protected void Start()
	{
		maxEmission = GetEmission();
		SetEmission(TOD_Sky.Instance.IsDay ? maxEmission : 0f);
	}

	protected void Update()
	{
		int num = (TOD_Sky.Instance.IsDay ? 1 : (-1));
		lerpTime = Mathf.Clamp01(lerpTime + (float)num * Time.deltaTime / fadeTime);
		SetEmission(Mathf.Lerp(0f, maxEmission, lerpTime));
	}
}
