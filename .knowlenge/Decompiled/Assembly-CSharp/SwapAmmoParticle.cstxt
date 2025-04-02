using System;
using UnityEngine;

public class SwapAmmoParticle : MonoBehaviour, IClientComponent, IEffect
{
	[Serializable]
	public struct Override
	{
		public ItemDefinition TargetAmmo;

		public Material TargetMaterial;
	}

	public ParticleSystem Target;

	public Override[] Overrides;
}
