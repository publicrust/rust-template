using UnityEngine;

public class BikeVehicleAudio : GroundVehicleAudio
{
	[Header("Engine")]
	[SerializeField]
	private EngineAudioSet engineAudioSet;

	[Header("Suspension")]
	[SerializeField]
	private SoundDefinition suspensionDef;

	[SerializeField]
	private float suspensionMinExtensionDelta = 0.4f;

	[SerializeField]
	private float suspensionMinTimeBetweenSounds = 0.25f;

	[SerializeField]
	[Header("Tires")]
	private SoundDefinition tireDirtSoundDef;

	[SerializeField]
	private SoundDefinition tireGrassSoundDef;

	[SerializeField]
	private SoundDefinition tireSnowSoundDef;

	[SerializeField]
	private SoundDefinition tireWaterSoundDef;

	[SerializeField]
	private AnimationCurve tireGainCurve;

	[SerializeField]
	[Header("Skid")]
	private SoundDefinition skidSoundLoop;

	[SerializeField]
	private SoundDefinition skidSoundDirtLoop;

	[SerializeField]
	private SoundDefinition skidSoundSnowLoop;

	[SerializeField]
	private float skidMinSlip = 10f;

	[SerializeField]
	private float skidMaxSlip = 25f;
}
