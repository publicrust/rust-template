using System;
using Facepunch;
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
	public class Modulator : IPooled
	{
		public Parameter param;

		public float value = 1f;

		void IPooled.LeavePool()
		{
		}

		void IPooled.EnterPool()
		{
			param = Parameter.Gain;
			value = 1f;
		}
	}

	private const int parameterCount = 4;
}
