using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(GreyScaleRenderer), PostProcessEvent.AfterStack, "Custom/GreyScale", true)]
public class GreyScale : PostProcessEffectSettings
{
	[Range(0f, 1f)]
	public FloatParameter redLuminance = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 1f)]
	public FloatParameter greenLuminance = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 1f)]
	public FloatParameter blueLuminance = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 1f)]
	public FloatParameter amount = new FloatParameter
	{
		value = 0f
	};

	[ColorUsage(false, true)]
	public ColorParameter color = new ColorParameter
	{
		value = Color.white
	};
}
