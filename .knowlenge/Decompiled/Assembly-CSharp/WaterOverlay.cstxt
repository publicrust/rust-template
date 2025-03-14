using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WaterOverlay : MonoBehaviour, IClientComponent
{
	[Serializable]
	public struct EffectParams
	{
		public float scatterCoefficient;

		public bool blur;

		public float blurDistance;

		public float blurSize;

		public int blurIterations;

		public bool wiggle;

		public float wiggleSpeed;

		public bool chromaticAberration;

		public bool godRays;

		public static EffectParams DefaultAdmin = new EffectParams
		{
			scatterCoefficient = 0.025f,
			blur = false,
			blurDistance = 10f,
			blurSize = 2f,
			wiggle = false,
			wiggleSpeed = 0f,
			chromaticAberration = true,
			godRays = false
		};

		public static EffectParams DefaultGoggles = new EffectParams
		{
			scatterCoefficient = 0.05f,
			blur = true,
			blurDistance = 10f,
			blurSize = 2f,
			wiggle = true,
			wiggleSpeed = 2f,
			chromaticAberration = true,
			godRays = true
		};

		public static EffectParams DefaultSubmarine = new EffectParams
		{
			scatterCoefficient = 0.025f,
			blur = false,
			blurDistance = 10f,
			blurSize = 2f,
			wiggle = false,
			wiggleSpeed = 0f,
			chromaticAberration = false,
			godRays = false
		};

		public static EffectParams DefaultUnderwaterLab = new EffectParams
		{
			scatterCoefficient = 0.005f,
			blur = false,
			blurDistance = 10f,
			blurSize = 2f,
			wiggle = false,
			wiggleSpeed = 0f,
			chromaticAberration = true,
			godRays = false
		};
	}

	public PostProcessVolume postProcessVolume;

	public EffectParams adminParams = EffectParams.DefaultAdmin;

	public EffectParams gogglesParams = EffectParams.DefaultGoggles;

	public EffectParams submarineParams = EffectParams.DefaultSubmarine;

	public EffectParams underwaterLabParams = EffectParams.DefaultUnderwaterLab;

	public Material[] UnderwaterFogMaterials;
}
