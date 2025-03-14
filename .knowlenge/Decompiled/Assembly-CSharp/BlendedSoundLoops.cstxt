using System;
using System.Collections.Generic;
using UnityEngine;

public class BlendedSoundLoops : MonoBehaviour, IClientComponent
{
	[Serializable]
	public class Loop
	{
		public SoundDefinition soundDef;

		public AnimationCurve gainCurve;

		public AnimationCurve pitchCurve;

		[HideInInspector]
		public Sound sound;

		[HideInInspector]
		public SoundModulation.Modulator gainMod;

		[HideInInspector]
		public SoundModulation.Modulator pitchMod;
	}

	[Range(0f, 1f)]
	public float blend;

	public float blendSmoothing = 1f;

	public float loopFadeOutTime = 0.5f;

	public float loopFadeInTime = 0.5f;

	public float gainModSmoothing = 1f;

	public float pitchModSmoothing = 1f;

	public bool shouldPlay = true;

	public float gain = 1f;

	public List<Loop> loops = new List<Loop>();

	public float maxDistance;
}
