using UnityEngine;

public class flamethrowerFire : MonoBehaviour
{
	public ParticleSystem pilotLightFX;

	public ParticleSystem[] flameFX;

	public FlameJet jet;

	public AudioSource oneShotSound;

	public AudioSource loopSound;

	public AudioClip pilotlightIdle;

	public AudioClip flameLoop;

	public AudioClip flameStart;

	public flamethrowerState flameState;

	private flamethrowerState previousflameState;

	public void PilotLightOn()
	{
		pilotLightFX.enableEmission = true;
		SetFlameStatus(status: false);
	}

	public void SetFlameStatus(bool status)
	{
		ParticleSystem[] array = flameFX;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enableEmission = status;
		}
	}

	public void ShutOff()
	{
		pilotLightFX.enableEmission = false;
		SetFlameStatus(status: false);
	}

	public void FlameOn()
	{
		pilotLightFX.enableEmission = false;
		SetFlameStatus(status: true);
	}

	private void Start()
	{
		previousflameState = (flameState = flamethrowerState.OFF);
		ShutOff();
	}

	private void Update()
	{
		if (previousflameState != flameState)
		{
			switch (flameState)
			{
			case flamethrowerState.OFF:
				ShutOff();
				break;
			case flamethrowerState.PILOT_LIGHT:
				PilotLightOn();
				break;
			case flamethrowerState.FLAME_ON:
				FlameOn();
				break;
			}
			previousflameState = flameState;
			jet.SetOn(flameState == flamethrowerState.FLAME_ON);
		}
	}
}
