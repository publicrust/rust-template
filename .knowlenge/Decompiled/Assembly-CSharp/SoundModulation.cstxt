using System;
using UnityEngine;

public class SoundModulation : MonoBehaviour, IClientComponent
{
	public enum Parameter
	{
		Gain,
		Pitch,
		Spread,
		MaxDistance
	}

	[Serializable]
	public class Modulator
	{
		public Parameter param;

		public float value = 1f;
	}

	private const int parameterCount = 4;
}
