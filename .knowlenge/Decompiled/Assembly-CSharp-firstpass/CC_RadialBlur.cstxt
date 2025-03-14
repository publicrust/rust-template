using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Radial Blur")]
public class CC_RadialBlur : CC_Base
{
	public float amount = 0.1f;

	public Vector2 center = new Vector2(0.5f, 0.5f);

	public int quality = 1;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("amount", amount);
		base.material.SetVector("center", center);
		if (amount == 0f)
		{
			Graphics.Blit(source, destination);
		}
		else
		{
			Graphics.Blit(source, destination, base.material, quality);
		}
	}
}
