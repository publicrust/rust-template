using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Fast Vignette")]
public class CC_FastVignette : CC_Base
{
	public float sharpness = 10f;

	public float darkness = 30f;

	public bool desaturate;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_sharpness", sharpness * 0.01f);
		base.material.SetFloat("_darkness", darkness * 0.02f);
		Graphics.Blit(source, destination, base.material, desaturate ? 1 : 0);
	}
}
