using System;
using UnityEngine;

public class ParticleSystemLOD : LODComponentParticleSystem
{
	[Serializable]
	public class State
	{
		public float distance;

		[Range(0f, 1f)]
		public float emission;
	}

	[Horizontal(1, 0)]
	public State[] States;
}
