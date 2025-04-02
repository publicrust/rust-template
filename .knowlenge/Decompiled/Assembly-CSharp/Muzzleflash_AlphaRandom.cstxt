using UnityEngine;

public class Muzzleflash_AlphaRandom : MonoBehaviour
{
	public ParticleSystem[] muzzleflashParticles;

	private Gradient grad = new Gradient();

	private GradientColorKey[] gck = new GradientColorKey[3];

	private GradientAlphaKey[] gak = new GradientAlphaKey[3];

	private void Start()
	{
	}

	private void OnEnable()
	{
		gck[0].color = Color.white;
		gck[0].time = 0f;
		gck[1].color = Color.white;
		gck[1].time = 0.6f;
		gck[2].color = Color.black;
		gck[2].time = 0.75f;
		float alpha = Random.Range(0.2f, 0.85f);
		gak[0].alpha = alpha;
		gak[0].time = 0f;
		gak[1].alpha = alpha;
		gak[1].time = 0.45f;
		gak[2].alpha = 0f;
		gak[2].time = 0.5f;
		grad.SetKeys(gck, gak);
		ParticleSystem[] array = muzzleflashParticles;
		foreach (ParticleSystem particleSystem in array)
		{
			if (particleSystem == null)
			{
				Debug.LogWarning("Muzzleflash_AlphaRandom : null particle system in " + base.gameObject.name);
				continue;
			}
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = particleSystem.colorOverLifetime;
			colorOverLifetime.color = grad;
		}
	}
}
