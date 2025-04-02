using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Hue, Saturation, Value")]
public class CC_HueSaturationValue : CC_Base
{
	public float hue;

	public float saturation;

	public float value;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (hue == 0f && saturation == 0f && value == 0f)
		{
			Graphics.Blit(source, destination);
			return;
		}
		base.material.SetFloat("_hue", hue / 360f);
		base.material.SetFloat("_saturation", saturation * 0.01f);
		base.material.SetFloat("_value", value * 0.01f);
		Graphics.Blit(source, destination, base.material);
	}
}
