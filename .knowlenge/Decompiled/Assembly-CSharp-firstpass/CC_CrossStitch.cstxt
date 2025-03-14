using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Cross Stitch")]
public class CC_CrossStitch : CC_Base
{
	public int size = 8;

	public float brightness = 1.5f;

	public bool invert;

	public bool pixelize = true;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_stitchSize", size);
		base.material.SetFloat("_brightness", brightness);
		int num = (invert ? 1 : 0);
		if (pixelize)
		{
			num += 2;
			base.material.SetFloat("_scale", GetComponent<Camera>().pixelWidth / size);
			base.material.SetFloat("_ratio", GetComponent<Camera>().pixelWidth / GetComponent<Camera>().pixelHeight);
		}
		Graphics.Blit(source, destination, base.material, num);
	}
}
