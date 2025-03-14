using UnityEngine;

public class ScreenBounceFade : BaseScreenShake
{
	public AnimationCurve bounceScale;

	public AnimationCurve bounceSpeed;

	public AnimationCurve bounceViewmodel;

	public AnimationCurve distanceFalloff;

	public AnimationCurve timeFalloff;

	private float bounceTime;

	private Vector3 bounceVelocity = Vector3.zero;

	public float maxDistance = 10f;

	public float scale = 1f;

	public override void Setup()
	{
		bounceTime = Random.Range(0f, 1000f);
	}

	public override void Run(float delta, ref CachedTransform<Camera> cam, ref CachedTransform<BaseViewModel> vm)
	{
		float value = Vector3.Distance(cam.position, base.transform.position);
		float num = 1f - Mathf.InverseLerp(0f, maxDistance, value);
		bounceTime += Time.deltaTime * bounceSpeed.Evaluate(delta);
		float num2 = distanceFalloff.Evaluate(num);
		float num3 = bounceScale.Evaluate(delta) * 0.1f * num2 * scale * timeFalloff.Evaluate(delta);
		bounceVelocity.x = Mathf.Sin(bounceTime * 20f) * num3;
		bounceVelocity.y = Mathf.Cos(bounceTime * 25f) * num3;
		bounceVelocity.z = 0f;
		Vector3 zero = Vector3.zero;
		zero += bounceVelocity.x * cam.right;
		zero += bounceVelocity.y * cam.up;
		zero *= num;
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
