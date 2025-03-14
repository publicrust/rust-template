using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Recoil Properties")]
public class RecoilProperties : ScriptableObject
{
	public float recoilYawMin;

	public float recoilYawMax;

	public float recoilPitchMin;

	public float recoilPitchMax;

	public float timeToTakeMin;

	public float timeToTakeMax = 0.1f;

	public float ADSScale = 0.5f;

	public float movementPenalty;

	public float clampPitch = float.NegativeInfinity;

	public AnimationCurve pitchCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));

	public AnimationCurve yawCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));

	public bool useCurves;

	public bool curvesAsScalar;

	public int shotsUntilMax = 30;

	public float maxRecoilRadius = 5f;

	[Header("AimCone")]
	public bool overrideAimconeWithCurve;

	public float aimconeCurveScale = 1f;

	[Tooltip("How much to scale aimcone by based on how far into the shot sequence we are (shots v shotsUntilMax)")]
	public AnimationCurve aimconeCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));

	[Tooltip("Randomly select how much to scale final aimcone by per shot, you can use this to weigh a fraction of shots closer to the center")]
	public AnimationCurve aimconeProbabilityCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.5f, 0f), new Keyframe(1f, 1f));

	[Tooltip("Scale the actual final aimcone produced by the ammunition itself if the ammo contains multiple projectiles")]
	public float ammoAimconeScaleMultiProjectile = 1f;

	[Tooltip("Scale the actual final aimcone produced by the ammunition itself if the ammo contains only one projectile")]
	public float ammoAimconeScaleSingleProjectile = 1f;

	public RecoilProperties newRecoilOverride;

	public RecoilProperties GetRecoil()
	{
		if (!(newRecoilOverride != null))
		{
			return this;
		}
		return newRecoilOverride;
	}
}
