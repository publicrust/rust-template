using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(BlurOptimizedRenderer), PostProcessEvent.AfterStack, "Custom/BlurOptimized", true)]
public class BlurOptimized : PostProcessEffectSettings
{
	[Range(0f, 2f)]
	public FixedIntParameter downsample = new FixedIntParameter
	{
		value = 0
	};

	[Range(1f, 4f)]
	public FixedIntParameter blurIterations = new FixedIntParameter
	{
		value = 1
	};

	[Range(0f, 10f)]
	public FloatParameter blurSize = new FloatParameter
	{
		value = 0f
	};

	public FloatParameter fadeToBlurDistance = new FloatParameter
	{
		value = 0f
	};

	public BlurTypeParameter blurType = new BlurTypeParameter
	{
		value = BlurType.StandardGauss
	};
}
