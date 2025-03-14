using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(GodRaysRenderer), PostProcessEvent.BeforeStack, "Custom/GodRays", true)]
public class GodRays : PostProcessEffectSettings
{
	public BoolParameter UseDepth = new BoolParameter
	{
		value = true
	};

	public BlendModeTypeParameter BlendMode = new BlendModeTypeParameter
	{
		value = BlendModeType.Screen
	};

	public FloatParameter Intensity = new FloatParameter
	{
		value = 0f
	};

	public ResolutionTypeParameter Resolution = new ResolutionTypeParameter
	{
		value = ResolutionType.High
	};

	public IntParameter BlurIterations = new IntParameter
	{
		value = 2
	};

	public FloatParameter BlurRadius = new FloatParameter
	{
		value = 2f
	};

	public FloatParameter MaxRadius = new FloatParameter
	{
		value = 0.5f
	};
}
