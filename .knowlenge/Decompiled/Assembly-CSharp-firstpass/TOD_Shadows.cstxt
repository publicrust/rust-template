using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera Cloud Shadows")]
public class TOD_Shadows : TOD_ImageEffect
{
	public Shader ShadowShader;

	public Texture2D CloudTexture;

	[Header("Shadows")]
	[Range(0f, 1f)]
	public float Cutoff;

	[Range(0f, 1f)]
	public float Fade;

	[Range(0f, 1f)]
	public float Intensity = 0.5f;

	private Material shadowMaterial;

	protected void OnEnable()
	{
		if (!ShadowShader)
		{
			ShadowShader = Shader.Find("Hidden/Time of Day/Cloud Shadows");
		}
		shadowMaterial = CreateMaterial(ShadowShader);
	}

	protected void OnDisable()
	{
		if ((bool)shadowMaterial)
		{
			Object.DestroyImmediate(shadowMaterial);
		}
	}

	[ImageEffectOpaque]
	protected void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckSupport(needDepth: true))
		{
			Graphics.Blit(source, destination);
			return;
		}
		sky.Components.Shadows = this;
		shadowMaterial.SetMatrix("_FrustumCornersWS", FrustumCorners());
		Shader.SetGlobalTexture("TOD_CloudTexture", CloudTexture);
		Shader.SetGlobalFloat("TOD_CloudShadowCutoff", Cutoff);
		Shader.SetGlobalFloat("TOD_CloudShadowFade", Fade);
		Shader.SetGlobalFloat("TOD_CloudShadowIntensity", Intensity * Mathf.Clamp01(1f - sky.SunZenith / 90f));
		Graphics.Blit(source, destination, shadowMaterial);
	}
}
