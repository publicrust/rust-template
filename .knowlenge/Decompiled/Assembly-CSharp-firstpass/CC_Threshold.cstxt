using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Threshold")]
public class CC_Threshold : CC_Base
{
	public float threshold = 128f;

	public bool useNoise;

	public float noiseRange = 48f;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_threshold", threshold / 255f);
		base.material.SetFloat("_range", noiseRange / 255f);
		Graphics.Blit(source, destination, base.material, useNoise ? 1 : 0);
	}
}
