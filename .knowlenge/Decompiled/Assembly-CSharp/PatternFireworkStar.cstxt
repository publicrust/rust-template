using UnityEngine;

public class PatternFireworkStar : MonoBehaviour, IClientComponent
{
	public GameObject Pixel;

	public GameObject Explosion;

	public ParticleSystem[] ParticleSystems;

	public void Initialize(Color color)
	{
		if (Pixel != null)
		{
			Pixel.SetActive(value: true);
		}
		if (Explosion != null)
		{
			Explosion.SetActive(value: false);
		}
		if (ParticleSystems == null)
		{
			return;
		}
		ParticleSystem[] particleSystems = ParticleSystems;
		foreach (ParticleSystem particleSystem in particleSystems)
		{
			if (!(particleSystem == null))
			{
				ParticleSystem.MainModule main = particleSystem.main;
				main.startColor = new ParticleSystem.MinMaxGradient(color);
			}
		}
	}

	public void Explode()
	{
		if (Pixel != null)
		{
			Pixel.SetActive(value: false);
		}
		if (Explosion != null)
		{
			Explosion.SetActive(value: true);
		}
	}
}
