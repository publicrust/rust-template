using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(FrostRenderer), PostProcessEvent.AfterStack, "Custom/Frost", true)]
public class Frost : PostProcessEffectSettings
{
	[Range(0f, 16f)]
	public FloatParameter scale = new FloatParameter
	{
		value = 0f
	};

	public BoolParameter enableVignette = new BoolParameter
	{
		value = true
	};

	[Range(0f, 100f)]
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
