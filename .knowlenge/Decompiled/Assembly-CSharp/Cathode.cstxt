using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(CathodeRenderer), PostProcessEvent.AfterStack, "Custom/Cathode - Analogue Video", true)]
public class Cathode : PostProcessEffectSettings
{
	[Range(0f, 1f)]
	public FloatParameter intensity = new FloatParameter
	{
		value = 0f
	};

	[Range(1f, 16f)]
	public IntParameter downscale = new IntParameter
	{
		value = 1
	};

	[Range(1f, 16f)]
	public IntParameter downscaleTemporal = new IntParameter
	{
		value = 1
	};

	[Range(0f, 3f)]
	public FloatParameter horizontalBlur = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 3f)]
	public FloatParameter verticalBlur = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 5f)]
	public FloatParameter chromaSubsampling = new FloatParameter
	{
		value = 1.7f
	};

	[Range(0f, 5f)]
	public FloatParameter sharpen = new FloatParameter
	{
		value = 1.2f
	};

	[Range(0f, 5f)]
	public FloatParameter sharpenRadius = new FloatParameter
	{
		value = 1.2f
	};

	[Range(0f, 0.5f)]
	public FloatParameter colorNoise = new FloatParameter
	{
		value = 0.05f
	};

	[Range(0f, 5f)]
	public FloatParameter restlessFoot = new FloatParameter
	{
		value = 0.2f
	};

	[Range(0f, 0.1f)]
	public FloatParameter footAmplitude = new FloatParameter
	{
		value = 0.02f
	};

	[Range(0f, 3f)]
	public FloatParameter chromaIntensity = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 1f)]
	public FloatParameter chromaInstability = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 0.1f)]
	public FloatParameter chromaOffset = new FloatParameter
	{
		value = 0.02f
	};

	[Range(-2f, 2f)]
	public FloatParameter responseCurve = new FloatParameter
	{
		value = 0f
	};

	[Range(-1f, 1f)]
	public FloatParameter saturation = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 1f)]
	public FloatParameter cometTrailing = new FloatParameter
	{
		value = 0.3f
	};

	[Range(0f, 1f)]
	public FloatParameter burnIn = new FloatParameter
	{
		value = 0.1f
	};

	[Range(0f, 1f)]
	public FloatParameter tapeDust = new FloatParameter
	{
		value = 0.1f
	};

	[Range(0f, 2f)]
	public FloatParameter wobble = new FloatParameter
	{
		value = 1f
	};

	[Range(0f, 1f)]
	public Vector2Parameter blackWhiteLevels = new Vector2Parameter
	{
		value = new Vector2(0f, 1f)
	};

	[Range(0f, 1f)]
	public Vector2Parameter dynamicRange = new Vector2Parameter
	{
		value = new Vector2(0f, 1f)
	};

	[Range(-1f, 1f)]
	public FloatParameter whiteBallance = new FloatParameter
	{
		value = 0f
	};
}
