using System;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceWaveSounds : SingletonComponent<AmbienceWaveSounds>, IClientComponent
{
	[Serializable]
	public class WaveLayer
	{
		public SoundDefinition soundDefinition;

		public AnimationCurve oceanScaleGainCurve;
	}

	public int emitterCount = 3;

	public float emitterDistance = 10f;

	public List<WaveLayer> waveLayers = new List<WaveLayer>();
}
