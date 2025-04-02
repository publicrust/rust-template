using UnityEngine;

public class TOD_ParticleAtTime : TOD_Particle
{
	public AnimationCurve Emission = new AnimationCurve
	{
		keys = new Keyframe[3]
		{
			new Keyframe(0f, 0f),
			new Keyframe(12f, 1f),
			new Keyframe(24f, 0f)
		}
	};

	protected void Update()
	{
		SetEmission(Emission.Evaluate(TOD_Sky.Instance.Cycle.Hour));
	}
}
