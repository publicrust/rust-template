using UnityEngine;

public class TOD_AudioAtTime : TOD_Audio
{
	public AnimationCurve Volume = new AnimationCurve
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
		SetVolume(Volume.Evaluate(TOD_Sky.Instance.Cycle.Hour));
	}
}
