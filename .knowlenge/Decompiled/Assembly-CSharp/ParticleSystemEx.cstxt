using UnityEngine;

public static class ParticleSystemEx
{
	public static void SetPlayingState(this ParticleSystem ps, bool play)
	{
		if (!((Object)(object)ps == (Object)null))
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
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		EmissionModule emission = ps.emission;
		if (enable != ((EmissionModule)(ref emission)).enabled)
		{
			EmissionModule emission2 = ps.emission;
			((EmissionModule)(ref emission2)).enabled = enable;
		}
	}
}
