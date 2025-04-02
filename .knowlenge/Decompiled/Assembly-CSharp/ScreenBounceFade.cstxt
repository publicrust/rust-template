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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		float num = Vector3.Distance(cam.position, ((Component)this).transform.position);
		float num2 = 1f - Mathf.InverseLerp(0f, maxDistance, num);
		bounceTime += Time.deltaTime * bounceSpeed.Evaluate(delta);
		float num3 = distanceFalloff.Evaluate(num2);
		float num4 = bounceScale.Evaluate(delta) * 0.1f * num3 * scale * timeFalloff.Evaluate(delta);
		bounceVelocity.x = Mathf.Sin(bounceTime * 20f) * num4;
		bounceVelocity.y = Mathf.Cos(bounceTime * 25f) * num4;
		bounceVelocity.z = 0f;
		Vector3 zero = Vector3.zero;
		zero += bounceVelocity.x * cam.right;
		zero += bounceVelocity.y * cam.up;
		zero *= num2;
		if ((bool)cam)
		{
			ref Vector3 position = ref cam.position;
			position += zero;
		}
		if ((bool)vm)
		{
			ref Vector3 position2 = ref vm.position;
			position2 += zero * -1f * bounceViewmodel.Evaluate(delta);
		}
	}
}
