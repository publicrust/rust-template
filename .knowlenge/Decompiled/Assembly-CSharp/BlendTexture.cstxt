using UnityEngine;

public class BlendTexture : ProcessedTexture
{
	public BlendTexture(int width, int height, bool linear = true)
	{
		material = CreateMaterial("Hidden/BlitCopyAlpha");
		result = CreateRenderTexture("Blend Texture", width, height, linear);
	}

	public void Blend(Texture source, Texture target, float alpha)
	{
		material.SetTexture("_BlendTex", target);
		material.SetFloat("_Alpha", Mathf.Clamp01(alpha));
		Graphics.Blit(source, result, material);
	}

	public void CopyTo(BlendTexture target)
	{
		Graphics.Blit(result, target.result);
	}
}
