using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Wiggle")]
public class CC_Wiggle : CC_Base, IImageEffect
{
	public float timer;

	public float speed = 1f;

	public float scale = 12f;

	private void Update()
	{
		timer += speed * Time.deltaTime;
	}

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
		base.material.SetFloat("_timer", timer);
		base.material.SetFloat("_scale", scale);
		Graphics.Blit(source, destination, base.material);
	}
}
