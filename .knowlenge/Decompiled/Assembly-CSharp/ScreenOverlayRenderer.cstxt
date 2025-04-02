using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ScreenOverlayRenderer : PostProcessEffectRenderer<ScreenOverlay>
{
	private Shader overlayShader;

	public override void Init()
	{
		base.Init();
		overlayShader = Shader.Find("Hidden/PostProcessing/ScreenOverlay");
	}

	public override void Render(PostProcessRenderContext context)
	{
	}
}
