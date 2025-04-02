using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(ScreenOverlayRenderer), PostProcessEvent.AfterStack, "Custom/ScreenOverlay", true)]
public class ScreenOverlay : PostProcessEffectSettings
{
	public OverlayBlendModeParameter blendMode = new OverlayBlendModeParameter
	{
		value = OverlayBlendMode.Multiply
	};

	public FloatParameter intensity = new FloatParameter
	{
		value = 0f
	};

	public TextureParameter texture = new TextureParameter
	{
		value = null
	};

	public TextureParameter normals = new TextureParameter
	{
		value = null
	};

	public BoolParameter respectUseLightingConvar = new BoolParameter
	{
		value = false
	};
}
