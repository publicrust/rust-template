using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(UnderWaterEffectRenderer), PostProcessEvent.AfterStack, "Custom/UnderWaterEffect", false)]
public class UnderwaterPostEffect : PostProcessEffectSettings
{
	[Header("Wiggle")]
	public BoolParameter wiggle = new BoolParameter();

	public FloatParameter speed = new FloatParameter
	{
		value = 1f
	};

	public FloatParameter scale = new FloatParameter
	{
		value = 12f
	};

	[Header("Water Line")]
	public ColorParameter waterLineColor = new ColorParameter();

	[Range(1f, 4f)]
	public FixedIntParameter waterLineBlurIterations = new FixedIntParameter
	{
		value = 1
	};

	[Range(0f, 10f)]
	public FloatParameter waterLineBlurSize = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 2f)]
	[Header("Blur")]
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
}
