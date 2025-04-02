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
		Blur((Texture)(object)result, radius);
	}

	public void Blur(Texture source, float radius)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		RenderTexture val = CreateTemporary();
		material.SetVector("offsets", new Vector4(radius / (float)Screen.width, 0f, 0f, 0f));
		Graphics.Blit(source, val, material, 0);
		material.SetVector("offsets", new Vector4(0f, radius / (float)Screen.height, 0f, 0f));
		Graphics.Blit((Texture)(object)val, result, material, 0);
		ReleaseTemporary(val);
	}
}
