using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(SharpenAndVignetteRenderer), PostProcessEvent.AfterStack, "Custom/SharpenAndVignette", true)]
public class SharpenAndVignette : PostProcessEffectSettings
{
	[Header("Sharpen")]
	public BoolParameter applySharpen = new BoolParameter
	{
		value = true
	};

	[Range(0f, 5f)]
	public FloatParameter strength = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 1f)]
	public FloatParameter clamp = new FloatParameter
	{
		value = 1f
	};

	[Header("Vignette")]
	public BoolParameter applyVignette = new BoolParameter
	{
		value = true
	};

	[Range(-100f, 100f)]
	public FloatParameter sharpness = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 100f)]
	public FloatParameter darkness = new FloatParameter
	{
		value = 0f
	};
}
