using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(LensDirtinessRenderer), PostProcessEvent.AfterStack, "Custom/LensDirtiness", true)]
public class LensDirtinessEffect : PostProcessEffectSettings
{
	public TextureParameter dirtinessTexture = new TextureParameter();

	public BoolParameter sceneTintsBloom = new BoolParameter
	{
		value = false
	};

	public FloatParameter gain = new FloatParameter
	{
		value = 1f
	};

	public FloatParameter threshold = new FloatParameter
	{
		value = 1f
	};

	public FloatParameter bloomSize = new FloatParameter
	{
		value = 5f
	};

	public FloatParameter dirtiness = new FloatParameter
	{
		value = 1f
	};

	public ColorParameter bloomColor = new ColorParameter
	{
		value = Color.white
	};
}
