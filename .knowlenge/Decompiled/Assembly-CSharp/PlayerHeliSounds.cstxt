using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHeliSounds : MonoBehaviour, IClientComponent
{
	[Serializable]
	public class FlightSoundLayer
	{
		public SoundDefinition loopDefinition;

		public SoundDefinition startDefinition;

		public SoundDefinition stopDefinition;

		public Transform targetParent;

		public float fadeTime = 0.25f;

		public float initialGain = 1f;

		public float gainRateUp = 5f;

		public float gainRateDown = 5f;

		public float gainInterpRate = 0.5f;

		public float initialPitch = 1f;

		public float pitchRateUp = 5f;

		public float pitchRateDown = 5f;

		public float pitchInterpRate = 0.5f;

		public bool returnToInitialWhenTurnedOff;

		public bool useUpDotPitchCurve;

		public AnimationCurve upDotPitchCurve;
	}

	[FormerlySerializedAs("miniCopter")]
	public PlayerHelicopter miniCopter;

	public GameObject soundAttachPoint;

	public List<FlightSoundLayer> flightSoundLayers = new List<FlightSoundLayer>();

	public SoundDefinition engineStartDef;

	public SoundDefinition engineLoopDef;

	public SoundDefinition engineStopDef;

	public SoundDefinition rotorLoopDef;

	public SoundDefinition radarWarningDef;

	public SoundDefinition radarLockDef;

	public SoundDefinition noAmmoDef;

	public SoundDefinition noFlaresDef;

	public SoundDefinition flaresReadyDef;

	public SoundDefinition flightControlMovementSoundDef;

	public GameObject flightControlSoundPosition;

	public float engineStartFadeOutTime = 1f;

	public float engineLoopFadeInTime = 0.7f;

	public float engineLoopFadeOutTime = 0.25f;

	public float engineStopFadeOutTime = 0.25f;

	public float rotorLoopFadeInTime = 0.7f;

	public float rotorLoopFadeOutTime = 0.25f;

	public float enginePitchInterpRate = 0.5f;

	public float rotorPitchInterpRate = 1f;

	public float rotorGainInterpRate = 0.5f;

	public float rotorStartStopPitchRateUp = 7f;

	public float rotorStartStopPitchRateDown = 9f;

	public float rotorStartStopGainRateUp = 5f;

	public float rotorStartStopGainRateDown = 4f;

	public AnimationCurve engineUpDotPitchCurve;

	public AnimationCurve rotorUpDotPitchCurve;

	public Animator animator;

	public SoundDefinition reloadStartSoundDef;

	public SoundDefinition reloadLoopSoundDef;

	public SoundDefinition reloadFinishSoundDef;
}
