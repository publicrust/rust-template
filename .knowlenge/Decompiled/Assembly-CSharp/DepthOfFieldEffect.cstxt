using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DepthOfFieldEffectRenderer), "Unity/Depth of Field (Custom)", false)]
public class DepthOfFieldEffect : PostProcessEffectSettings
{
	public FloatParameter focalLength = new FloatParameter
	{
		value = 10f
	};

	public FloatParameter focalSize = new FloatParameter
	{
		value = 0.05f
	};

	public FloatParameter aperture = new FloatParameter
	{
		value = 11.5f
	};

	public FloatParameter maxBlurSize = new FloatParameter
	{
		value = 2f
	};

	public BoolParameter highResolution = new BoolParameter
	{
		value = true
	};

	public DOFBlurSampleCountParameter blurSampleCount = new DOFBlurSampleCountParameter
	{
		value = DOFBlurSampleCount.Low
	};

	public Transform focalTransform;
}
