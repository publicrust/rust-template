using UnityEngine;

public class PatternFireworkStar : MonoBehaviour, IClientComponent
{
	public GameObject Pixel;

	public GameObject Explosion;

	public ParticleSystem[] ParticleSystems;

	public void Initialize(Color color)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Pixel != (Object)null)
		{
			Pixel.SetActive(true);
		}
		if ((Object)(object)Explosion != (Object)null)
		{
			Explosion.SetActive(false);
		}
		if (ParticleSystems == null)
		{
			return;
		}
		ParticleSystem[] particleSystems = ParticleSystems;
		foreach (ParticleSystem val in particleSystems)
		{
			if (!((Object)(object)val == (Object)null))
			{
				MainModule main = val.main;
				((MainModule)(ref main)).startColor = new MinMaxGradient(color);
			}
		}
	}

	public void Explode()
	{
		if ((Object)(object)Pixel != (Object)null)
		{
			Pixel.SetActive(false);
		}
		if ((Object)(object)Explosion != (Object)null)
		{
			Explosion.SetActive(true);
		}
	}
}
