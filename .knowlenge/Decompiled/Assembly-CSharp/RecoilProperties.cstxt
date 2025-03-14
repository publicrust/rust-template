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

	public int shotsUntilMax = 30;
}
