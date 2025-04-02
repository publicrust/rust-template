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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		Vector3 zero = Vector3.zero;
		zero.x = Pitch.Evaluate(delta);
		zero.y = Yaw.Evaluate(delta);
		zero.z = Roll.Evaluate(delta);
		if ((bool)cam)
		{
			ref Quaternion rotation = ref cam.rotation;
			rotation *= Quaternion.Euler(zero * scale);
		}
		if ((bool)vm && useViewModelEffect)
		{
			ref Quaternion rotation2 = ref vm.rotation;
			rotation2 *= Quaternion.Euler(zero * scale * -1f * (1f - ViewmodelEffect.Evaluate(delta)));
		}
	}
}
