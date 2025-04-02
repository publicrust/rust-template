using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(FlashbangEffectRenderer), PostProcessEvent.AfterStack, "Custom/FlashbangEffect", false)]
public class FlashbangEffect : PostProcessEffectSettings
{
	[Range(0f, 1f)]
	public FloatParameter burnIntensity = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 1f)]
	public FloatParameter whiteoutIntensity = new FloatParameter
	{
		value = 0f
	};
}
