using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Gradient Ramp")]
public class CC_GradientRamp : CC_Base
{
	public Texture rampTexture;

	public float amount = 1f;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (rampTexture == null || amount == 0f)
		{
			Graphics.Blit(source, destination);
			return;
		}
		base.material.SetTexture("_RampTex", rampTexture);
		base.material.SetFloat("_amount", amount);
		Graphics.Blit(source, destination, base.material);
	}
}
