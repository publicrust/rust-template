using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(RadialBlurRenderer), PostProcessEvent.AfterStack, "Custom/RadialBlur", true)]
public class RadialBlur : PostProcessEffectSettings
{
	[Header("Radial Controls")]
	public Vector2Parameter center = new Vector2Parameter
	{
		value = new Vector2(0.5f, 0.5f)
	};

	[Range(0.1f, 2f)]
	public FloatParameter start = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 2f)]
	public FloatParameter amount = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 3f)]
	[Header("Blur Quality")]
	public FixedIntParameter downsample = new FixedIntParameter
	{
		value = 1
	};

	[Range(1f, 4f)]
	public FixedIntParameter iterations = new FixedIntParameter
	{
		value = 2
	};
}
