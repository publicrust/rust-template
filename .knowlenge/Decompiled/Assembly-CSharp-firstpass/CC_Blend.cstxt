using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Blend")]
public class CC_Blend : CC_Base
{
	public Texture texture;

	public float amount = 1f;

	public int mode;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (texture == null || amount == 0f)
		{
			Graphics.Blit(source, destination);
			return;
		}
		base.material.SetTexture("_overlayTex", texture);
		base.material.SetFloat("_amount", amount);
		Graphics.Blit(source, destination, base.material, mode);
	}
}
