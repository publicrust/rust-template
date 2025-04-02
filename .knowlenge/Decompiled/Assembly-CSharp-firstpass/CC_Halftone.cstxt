using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Halftone")]
public class CC_Halftone : CC_Base
{
	public float density = 64f;

	public int mode = 1;

	public bool antialiasing = true;

	public bool showOriginal;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_density", density);
		int pass = 0;
		if (mode == 0)
		{
			if (antialiasing && showOriginal)
			{
				pass = 3;
			}
			else if (antialiasing)
			{
				pass = 1;
			}
			else if (showOriginal)
			{
				pass = 2;
			}
		}
		else if (mode == 1)
		{
			pass = (antialiasing ? 5 : 4);
		}
		Graphics.Blit(source, destination, base.material, pass);
	}
}
