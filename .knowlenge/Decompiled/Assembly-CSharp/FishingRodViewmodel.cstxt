using System;
using UnityEngine;

public class FishingRodViewmodel : MonoBehaviour
{
	[Serializable]
	public struct FishViewmodel
	{
		public ItemDefinition Item;

		public GameObject Root;
	}

	public Transform PitchTransform;

	public Transform YawTransform;

	public float YawLerpSpeed = 1f;

	public float PitchLerpSpeed = 1f;

	public Transform LineRendererStartPos;

	public ParticleSystem[] StrainParticles;

	public bool ApplyTransformRotation = true;

	public GameObject CatchRoot;

	public Transform CatchLinePoint;

	public FishViewmodel[] FishViewmodels;

	public float ShakeMaxScale = 0.1f;
}
