using System;
using System.Collections.Generic;
using UnityEngine;

public class SpinUpWeaponSounds : MonoBehaviour, IClientComponent
{
	[Serializable]
	public class GunshotLayer
	{
		public SoundDefinition startDef;

		public SoundDefinition loopDef;

		public SoundDefinition stopDef;
	}

	public SoundDefinition spinStartDef;

	public SoundDefinition spinReleaseDef;

	public SoundDefinition spinStopDef;

	public SoundDefinition spinLoopUnpitchedDef;

	public SoundDefinition spinLoopPitchedDef;

	public AnimationCurve spinUnpitchedGainCurve;

	public AnimationCurve spinPitchedGainCurve;

	public AnimationCurve spinPitchCurve;

	public AnimationCurve spinPitchedGainCurveDown;

	public AnimationCurve spinPitchCurveDown;

	public List<GunshotLayer> gunshotLayers = new List<GunshotLayer>();
}
