using UnityEngine;

public abstract class TOD_Particle : MonoBehaviour
{
	private ParticleSystem particleComponent;

	protected float GetEmission()
	{
		if ((bool)particleComponent)
		{
			return particleComponent.emission.rateOverTimeMultiplier;
		}
		return 0f;
	}

	protected void SetEmission(float value)
	{
		if ((bool)particleComponent)
		{
			ParticleSystem.EmissionModule emission = particleComponent.emission;
			emission.rateOverTimeMultiplier = value;
		}
	}

	protected void Awake()
	{
		particleComponent = GetComponent<ParticleSystem>();
	}
}
