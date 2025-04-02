using UnityEngine;

public static class ParticleSystemEx
{
	public static void SetPlayingState(this ParticleSystem ps, bool play)
	{
		if (!(ps == null))
		{
			if (play && !ps.isPlaying)
			{
				ps.Play();
			}
			else if (!play && ps.isPlaying)
			{
				ps.Stop();
			}
		}
	}

	public static void SetEmitterState(this ParticleSystem ps, bool enable)
	{
		if (enable != ps.emission.enabled)
		{
			ParticleSystem.EmissionModule emission = ps.emission;
			emission.enabled = enable;
		}
	}
}
