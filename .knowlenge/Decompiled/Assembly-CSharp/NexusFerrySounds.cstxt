using UnityEngine;

public class NexusFerrySounds : MonoBehaviour, IClientComponent
{
	[SerializeField]
	private NexusFerry ferry;

	[SerializeField]
	private float roughHalfWidth = 5f;

	[SerializeField]
	private float roughHalfLength = 10f;

	private float soundCullDistanceSq;

	[Header("Engine")]
	[SerializeField]
	private SoundDefinition engineLoopDef;

	private Sound engineLoop;

	private SoundModulation.Modulator engineGainMod;

	private SoundModulation.Modulator enginePitchMod;

	[SerializeField]
	private SoundDefinition engineStartDef;

	[SerializeField]
	private SoundDefinition engineStopDef;

	[SerializeField]
	private AnimationCurve engineGainCurve;

	[SerializeField]
	private AnimationCurve enginePitchCurve;

	[SerializeField]
	private float engineGainChangeRate = 1f;

	[SerializeField]
	private float enginePitchChangeRate = 0.5f;

	[SerializeField]
	private Transform engineTransform;

	[Header("Water")]
	[SerializeField]
	private SoundDefinition waterIdleDef;

	[SerializeField]
	private SoundDefinition waterSideMovementSlowDef;

	[SerializeField]
	private SoundDefinition waterSideMovementFastDef;

	[SerializeField]
	private AnimationCurve waterMovementGainCurve;

	[SerializeField]
	private float waterMovementGainChangeRate = 0.5f;

	[SerializeField]
	private AnimationCurve waterDistanceGainCurve;

	private Sound leftWaterSound;

	private SoundModulation.Modulator leftWaterGainMod;

	private Sound rightWaterSound;

	private SoundModulation.Modulator rightWaterGainMod;

	[SerializeField]
	private Vector3 sideSoundLineStern;

	[SerializeField]
	private Vector3 sideSoundLineBow;

	[Header("Dock")]
	[SerializeField]
	private SoundDefinition dockArrivalSoundDef;

	[SerializeField]
	private SoundDefinition dockDepartureSoundDef;

	[SerializeField]
	private Transform dockSoundTransform;

	[Header("Ambient")]
	private Sound ambientIdleSound;

	[SerializeField]
	private SoundDefinition ambientActiveLoopDef;

	private Sound ambientActiveSound;

	private Line leftSoundLine;

	private Line rightSoundLine;

	[Header("Runtime")]
	public bool engineOn = true;
}
