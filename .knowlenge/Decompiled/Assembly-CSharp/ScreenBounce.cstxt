using UnityEngine;

public class ScreenBounce : BaseScreenShake
{
	public AnimationCurve bounceScale;

	public AnimationCurve bounceSpeed;

	public AnimationCurve bounceViewmodel;

	private float bounceTime;

	private Vector3 bounceVelocity = Vector3.zero;

	public override void Setup()
	{
		bounceTime = Random.Range(0f, 1000f);
	}

	public override void Run(float delta, ref CachedTransform<Camera> cam, ref CachedTransform<BaseViewModel> vm)
	{
		bounceTime += Time.deltaTime * bounceSpeed.Evaluate(delta);
		float num = bounceScale.Evaluate(delta) * 0.1f;
		bounceVelocity.x = Mathf.Sin(bounceTime * 20f) * num;
		bounceVelocity.y = Mathf.Cos(bounceTime * 25f) * num;
		bounceVelocity.z = 0f;
		Vector3 zero = Vector3.zero;
		zero += bounceVelocity.x * cam.right;
		zero += bounceVelocity.y * cam.up;
		if ((bool)cam)
		{
			cam.position += zero;
		}
		if ((bool)vm)
		{
			vm.position += zero * -1f * bounceViewmodel.Evaluate(delta);
		}
	}
}
