using UnityEngine;

public class InstrumentIKController : MonoBehaviour
{
	public Vector3 HitRotationVector = Vector3.forward;

	public Transform[] LeftHandIkTargets = new Transform[0];

	public Transform[] LeftHandIKTargetHitRotations = new Transform[0];

	public Transform[] RightHandIkTargets = new Transform[0];

	public Transform[] RightHandIKTargetHitRotations = new Transform[0];

	public Transform[] RightFootIkTargets = new Transform[0];

	public AnimationCurve HandHeightCurve = AnimationCurve.Constant(0f, 1f, 0f);

	public float HandHeightMultiplier = 1f;

	public float HandMoveLerpSpeed = 50f;

	public bool DebugHitRotation;

	public AnimationCurve HandHitCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float NoteHitTime = 0.5f;

	[Header("Look IK")]
	public float BodyLookWeight;

	public float HeadLookWeight;

	public float LookWeightLimit;

	public bool HoldHandsAtPlay;
}
