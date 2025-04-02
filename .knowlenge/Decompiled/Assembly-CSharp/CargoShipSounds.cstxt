using UnityEngine;

public class CargoShipSounds : MonoBehaviour, IClientComponent
{
	public CargoShip cargoShip;

	public SoundDefinition waveSoundDef;

	public AnimationCurve waveSoundYGainCurve;

	public AnimationCurve waveSoundEdgeDistanceGainCurve;

	private Sound waveSoundL;

	private Sound waveSoundR;

	private SoundModulation.Modulator waveSoundLGainMod;

	private SoundModulation.Modulator waveSoundRGainMod;

	public SoundDefinition sternWakeSoundDef;

	private Sound sternWakeSound;

	private SoundModulation.Modulator sternWakeSoundGainMod;

	public SoundDefinition idleWaveSoundDef;

	public SoundDefinition engineHumSoundDef;

	private Sound engineHumSound;

	private SoundModulation.Modulator enginePitchMod;

	public GameObject engineHumTarget;

	public float enginePitchChangeSpeed = 0.03f;

	public SoundDefinition hugeRumbleSoundDef;

	public AnimationCurve hugeRumbleYDiffCurve;

	public AnimationCurve hugeRumbleRelativeSpeedCurve;

	private Sound hugeRumbleSound;

	private SoundModulation.Modulator hugeRumbleGainMod;

	private Vector3 lastCameraPos;

	private Vector3 lastRumblePos;

	private Vector3 lastRumbleLocalPos;

	public Collider soundFollowCollider;

	public Collider soundFollowColliderL;

	public Collider soundFollowColliderR;

	public Collider sternSoundFollowCollider;

	public SoundDefinition metalGroanSoundDef;

	public float metalGroanMinInterval = 1f;

	public float metalGroanMaxInterval = 30f;
}
