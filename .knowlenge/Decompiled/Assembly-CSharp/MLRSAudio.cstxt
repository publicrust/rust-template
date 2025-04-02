using UnityEngine;

public class MLRSAudio : MonoBehaviour
{
	[SerializeField]
	private MLRS mlrs;

	[SerializeField]
	private Transform pitchTransform;

	[SerializeField]
	private Transform yawTransform;

	[SerializeField]
	private float pitchDeltaSmoothRate = 5f;

	[SerializeField]
	private float yawDeltaSmoothRate = 5f;

	[SerializeField]
	private float pitchDeltaThreshold = 0.5f;

	[SerializeField]
	private float yawDeltaThreshold = 0.5f;

	private float lastPitch;

	private float lastYaw;

	private float pitchDelta;

	private float yawDelta;

	public SoundDefinition turretMovementStartDef;

	public SoundDefinition turretMovementLoopDef;

	public SoundDefinition turretMovementStopDef;

	private Sound turretMovementLoop;
}
