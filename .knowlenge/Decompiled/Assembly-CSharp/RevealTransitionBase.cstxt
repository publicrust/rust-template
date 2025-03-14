using System;
using Facepunch.Flexbox;
using UnityEngine;

public abstract class RevealTransitionBase : BaseMonoBehaviour
{
	[Serializable]
	public struct Reveal
	{
		public FlexTransition Transition;

		[Min(0f)]
		public float Delay;
	}

	public Reveal[] Reveals = Array.Empty<Reveal>();
}
