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
	public class Modulator : Pool.IPooled
	{
		public Parameter param;

		public float value = 1f;

		void Pool.IPooled.LeavePool()
		{
		}

		void Pool.IPooled.EnterPool()
		{
			param = Parameter.Gain;
			value = 1f;
		}
	}

	private const int parameterCount = 4;
}
