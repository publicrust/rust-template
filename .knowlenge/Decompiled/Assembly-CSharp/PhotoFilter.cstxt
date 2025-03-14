using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PhotoFilterRenderer), PostProcessEvent.AfterStack, "Custom/PhotoFilter", true)]
public class PhotoFilter : PostProcessEffectSettings
{
	public ColorParameter color = new ColorParameter
	{
		value = Color.white
	};

	[Range(0f, 1f)]
	public FloatParameter density = new FloatParameter
	{
		value = 0f
	};
}
