using System;
using UnityEngine;

public class WeightedAnimationRandomiser : StateMachineBehaviour
{
	[Serializable]
	public struct IdleChance
	{
		public string StateName;

		[Range(0f, 100f)]
		public int Chance;
	}

	public int LoopRangeMin = 3;

	public int LoopRangeMax = 5;

	public float NormalizedTransitionDuration;

	public IdleChance[] IdleTransitions = new IdleChance[0];

	public bool AllowRepeats;
}
