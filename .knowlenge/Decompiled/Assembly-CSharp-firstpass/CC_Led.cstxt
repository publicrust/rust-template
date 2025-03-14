using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/LED")]
public class CC_Led : CC_Base
{
	public float scale = 80f;

	public bool automaticRatio;

	public float ratio = 1f;

	public float brightness = 1f;

	public int mode;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		switch (mode)
		{
		case 0:
			base.material.SetFloat("_scale", scale);
			break;
		default:
			base.material.SetFloat("_scale", (float)GetComponent<Camera>().pixelWidth / scale);
			break;
		}
		base.material.SetFloat("_ratio", automaticRatio ? ((float)(GetComponent<Camera>().pixelWidth / GetComponent<Camera>().pixelHeight)) : ratio);
		base.material.SetFloat("_brightness", brightness);
		Graphics.Blit(source, destination, base.material);
	}
}
