using UnityEngine;

[AddComponentMenu("Colorful/Sharpen And Vignette")]
public class CC_SharpenAndVignette : CC_Base, IImageEffect
{
	[Header("Sharpen")]
	public bool applySharpen = true;

	[Range(0f, 5f)]
	public float strength = 1f;

	[Range(0f, 1f)]
	public float clamp = 1f;

	[Header("Vignette")]
	public bool applyVignette = true;

	[Range(-100f, 100f)]
	public float sharpness = 45f;

	[Range(0f, 100f)]
	public float darkness = 24f;

	public bool IsActive()
	{
		return base.enabled;
	}

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (applySharpen)
		{
			base.material.SetFloat("_px", 1f / (float)Screen.width);
			base.material.SetFloat("_py", 1f / (float)Screen.height);
			base.material.SetFloat("_strength", strength);
			base.material.SetFloat("_clamp", clamp);
		}
		if (applyVignette)
		{
			base.material.SetFloat("_sharpness", sharpness * 0.01f);
			base.material.SetFloat("_darkness", darkness * 0.02f);
		}
		if (applySharpen && !applyVignette)
		{
			Graphics.Blit(source, destination, base.material, 0);
		}
		else if (applySharpen && applyVignette)
		{
			Graphics.Blit(source, destination, base.material, 1);
		}
		else if (!applySharpen && applyVignette)
		{
			Graphics.Blit(source, destination, base.material, 2);
		}
		else
		{
			Graphics.Blit(source, destination);
		}
	}
}
