using UnityEngine;

public class ScreenRotate : BaseScreenShake
{
	public AnimationCurve Pitch;

	public AnimationCurve Yaw;

	public AnimationCurve Roll;

	public AnimationCurve ViewmodelEffect;

	public float scale = 1f;

	public bool useViewModelEffect = true;

	public override void Setup()
	{
	}

	public override void Run(float delta, ref CachedTransform<Camera> cam, ref CachedTransform<BaseViewModel> vm)
	{
		Vector3 zero = Vector3.zero;
		zero.x = Pitch.Evaluate(delta);
		zero.y = Yaw.Evaluate(delta);
		zero.z = Roll.Evaluate(delta);
		if ((bool)cam)
		{
			cam.rotation *= Quaternion.Euler(zero * scale);
		}
		if ((bool)vm && useViewModelEffect)
		{
			vm.rotation *= Quaternion.Euler(zero * scale * -1f * (1f - ViewmodelEffect.Evaluate(delta)));
		}
	}
}
