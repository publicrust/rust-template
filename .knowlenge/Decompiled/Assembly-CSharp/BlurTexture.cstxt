using UnityEngine;

public class BlurTexture : ProcessedTexture
{
	public BlurTexture(int width, int height, bool linear = true)
	{
		material = CreateMaterial("Hidden/Rust/SeparableBlur");
		result = CreateRenderTexture("Blur Texture", width, height, linear);
	}

	public void Blur(float radius)
	{
		Blur(result, radius);
	}

	public void Blur(Texture source, float radius)
	{
		RenderTexture renderTexture = CreateTemporary();
		material.SetVector("offsets", new Vector4(radius / (float)Screen.width, 0f, 0f, 0f));
		Graphics.Blit(source, renderTexture, material, 0);
		material.SetVector("offsets", new Vector4(0f, radius / (float)Screen.height, 0f, 0f));
		Graphics.Blit(renderTexture, result, material, 0);
		ReleaseTemporary(renderTexture);
	}
}
