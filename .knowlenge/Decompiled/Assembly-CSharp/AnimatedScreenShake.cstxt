using UnityEngine;

public class AnimatedScreenShake : BaseScreenShake
{
	public AnimationClip TargetClip;

	[ReadOnly]
	public AnimationCurve rotX;

	[ReadOnly]
	public AnimationCurve rotY;

	[ReadOnly]
	public AnimationCurve rotZ;

	[ReadOnly]
	public AnimationCurve posX;

	[ReadOnly]
	public AnimationCurve posY;

	[ReadOnly]
	public AnimationCurve posZ;

	private const float VALID_RANGE = 0.1f;

	private bool canPlay;

	public override void Setup()
	{
	}

	public override void Run(float delta, ref CachedTransform<Camera> cam, ref CachedTransform<BaseViewModel> vm)
	{
		if (canPlay)
		{
			float x = rotX.Evaluate(delta);
			float y = rotY.Evaluate(delta);
			float z = rotZ.Evaluate(delta);
			float x2 = posX.Evaluate(delta);
			float y2 = posY.Evaluate(delta);
			float z2 = posZ.Evaluate(delta);
			Vector3 vector = new Vector3(x, y, z);
			Vector3 vector2 = new Vector3(x2, y2, z2);
			if ((bool)cam)
			{
				cam.rotation = Quaternion.Euler(cam.rotation.eulerAngles + vector);
				cam.position += vector2;
			}
			if ((bool)vm)
			{
				vm.rotation = Quaternion.Euler(vm.rotation.eulerAngles + vector);
				vm.position += vector2;
			}
		}
	}
}
