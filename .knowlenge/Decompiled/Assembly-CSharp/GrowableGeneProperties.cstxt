using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Growable Gene Properties")]
public class GrowableGeneProperties : ScriptableObject
{
	[Serializable]
	public struct GeneWeight
	{
		public float BaseWeight;

		public float[] SlotWeights;

		public float CrossBreedingWeight;
	}

	[ArrayIndexIsEnum(enumType = typeof(GrowableGenetics.GeneType))]
	public GeneWeight[] Weights = new GeneWeight[5];
}
