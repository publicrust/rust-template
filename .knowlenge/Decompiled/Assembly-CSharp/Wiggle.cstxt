using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(WiggleRenderer), PostProcessEvent.AfterStack, "Custom/Wiggle", true)]
public class Wiggle : PostProcessEffectSettings
{
	public FloatParameter speed = new FloatParameter
	{
		value = 1f
	};

	public FloatParameter scale = new FloatParameter
	{
		value = 12f
	};
}
