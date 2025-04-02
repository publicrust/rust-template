using UnityEngine;

public class ScreenFov : BaseScreenShake
{
	public AnimationCurve FovAdjustment;

	public override void Setup()
	{
	}

	public override void Run(float delta, ref CachedTransform<Camera> cam, ref CachedTransform<BaseViewModel> vm)
	{
		if ((bool)cam)
		{
			Camera component = cam.component;
			component.fieldOfView += FovAdjustment.Evaluate(delta);
		}
	}
}
