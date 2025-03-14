using UnityEngine;

public class CatapultSounds : GroundVehicleAudio
{
	[Header("Reload")]
	public SoundDefinition reloadLoopDef;

	public SoundDefinition reloadStartDef;

	public SoundDefinition reloadStopDef;

	[SerializeField]
	[Header("Suspension")]
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
	[Header("Movement")]
	private SoundDefinition movementLoopDef;

	[SerializeField]
	private AnimationCurve movementGainCurve;

	[SerializeField]
	private float movementGainAdjustmentSpeed = 5f;
}
