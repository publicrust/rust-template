using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DoubleVisionRenderer), PostProcessEvent.AfterStack, "Custom/DoubleVision", true)]
public class DoubleVision : PostProcessEffectSettings
{
	[Range(0f, 1f)]
	public Vector2Parameter displace = new Vector2Parameter
	{
		value = Vector2.zero
	};

	[Range(0f, 1f)]
	public FloatParameter amount = new FloatParameter
	{
		value = 0f
	};
}
