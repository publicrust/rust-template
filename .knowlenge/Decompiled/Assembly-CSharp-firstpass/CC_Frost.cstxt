using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Frost")]
public class CC_Frost : CC_Base, IImageEffect
{
	public float scale = 1.2f;

	public float sharpness = 40f;

	public float darkness = 35f;

	public bool enableVignette = true;

	public bool IsActive()
	{
		if (base.enabled)
		{
			return scale != 0f;
		}
		return false;
	}

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (scale == 0f)
		{
			Graphics.Blit(source, destination);
			return;
		}
		base.material.SetFloat("_scale", scale);
		base.material.SetFloat("_sharpness", sharpness * 0.01f);
		base.material.SetFloat("_darkness", darkness * 0.02f);
		Graphics.Blit(source, destination, base.material, enableVignette ? 1 : 0);
	}
}
