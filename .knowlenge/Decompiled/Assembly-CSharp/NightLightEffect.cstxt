using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(NightLightEffectRenderer), PostProcessEvent.BeforeStack, "Custom/NightLight", true)]
public class NightLightEffect : PostProcessEffectSettings
{
	[Range(0f, 25f)]
	public FloatParameter distance = new FloatParameter
	{
		value = 5f
	};

	[Range(0f, 1f)]
	public FloatParameter fadeFraction = new FloatParameter
	{
		value = 0.1f
	};

	[Range(0f, 1f)]
	public FloatParameter brightness = new FloatParameter
	{
		value = 0.1f
	};
}
