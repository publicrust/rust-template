using UnityEngine;

public class TravellingVendorSounds : MonoBehaviour
{
	[Header("Engine")]
	[SerializeField]
	private EngineAudioSet EngineAudioSet;

	[SerializeField]
	private BlendedLoopEngineSound blendedEngineLoops;

	[SerializeField]
	private float engineRPMThrottleWeight = 0.75f;

	[SerializeField]
	private float engineRPMThrottleSpeedWeight = 0.25f;

	[SerializeField]
	private float engineRPMSpeedWeight = 0.25f;

	[SerializeField]
	private float wheelRatioMultiplier = 600f;

	[SerializeField]
	private SoundDefinition missGearSoundDef;

	[SerializeField]
	private float gearMissCooldown = 5f;

	[Header("Suspension")]
	[SerializeField]
	private SoundDefinition suspensionDef;

	[SerializeField]
	private float suspensionMinTimeBetweenSounds = 0.25f;

	[SerializeField]
	private float suspensionUpAngleDeltaThreshold = 0.05f;

	[SerializeField]
	private AnimationCurve suspensionDeltaSpeedGain;

	[SerializeField]
	private AnimationCurve suspensionUpAngleDeltaGain;

	[Header("Tires")]
	[SerializeField]
	private SoundDefinition tireDirtSoundDef;

	[SerializeField]
	private SoundDefinition tireGrassSoundDef;

	[SerializeField]
	private SoundDefinition tireSnowSoundDef;

	[SerializeField]
	private SoundDefinition tireWaterSoundDef;

	[SerializeField]
	private AnimationCurve tireGainCurve;

	[Header("Movement")]
	[SerializeField]
	private SoundDefinition movementLoopDef;

	[SerializeField]
	private AnimationCurve movementLoopGainCurve;

	[SerializeField]
	[Header("Brakes")]
	private SoundDefinition brakeLoopDef;

	[SerializeField]
	private SoundDefinition brakeHissDef;

	[SerializeField]
	private float brakeHissCooldown = 2f;

	[SerializeField]
	[Header("Misc")]
	private SoundDefinition angryHornSoundDef;

	[SerializeField]
	private SoundDefinition musicLoopSoundDef;
}
