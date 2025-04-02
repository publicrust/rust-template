using UnityEngine;

public class TOD_LightAtTime : TOD_Light
{
	public AnimationCurve Intensity = new AnimationCurve
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
		SetIntensity(Intensity.Evaluate(TOD_Sky.Instance.Cycle.Hour));
	}
}
