using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera God Rays")]
public class TOD_Rays : TOD_ImageEffect
{
	public enum BlendModeType
	{
		Screen,
		Add
	}

	public Shader GodRayShader;

	public Shader ScreenClearShader;

	public Shader SkyMaskShader;

	[Tooltip("Whether or not to use the depth buffer.")]
	public bool UseDepthTexture = true;

	[Header("Rays")]
	[Tooltip("The god ray rendering blend mode.")]
	public BlendModeType BlendMode;

	[Tooltip("The intensity of the god rays.")]
	[TOD_Min(0f)]
	public float Intensity = 1f;

	[Header("Blur")]
	[Tooltip("The god ray rendering resolution.")]
	public ResolutionType Resolution = ResolutionType.Normal;

	[Tooltip("The number of blur iterations to be performed.")]
	[TOD_Range(0f, 4f)]
	public int BlurIterations = 2;

	[Tooltip("The radius to blur filter applied to the god rays.")]
	[TOD_Min(0f)]
	public float BlurRadius = 2f;

	[Tooltip("The maximum radius of the god rays.")]
	[TOD_Min(0f)]
	public float MaxRadius = 0.5f;

	private Material godRayMaterial;

	private Material screenClearMaterial;

	private Material skyMaskMaterial;

	private const int PASS_SCREEN = 0;

	private const int PASS_ADD = 1;

	protected void OnEnable()
	{
		if (!GodRayShader)
		{
			GodRayShader = Shader.Find("Hidden/Time of Day/God Rays");
		}
		if (!ScreenClearShader)
		{
			ScreenClearShader = Shader.Find("Hidden/Time of Day/Screen Clear");
		}
		if (!SkyMaskShader)
		{
			SkyMaskShader = Shader.Find("Hidden/Time of Day/Sky Mask");
		}
		godRayMaterial = CreateMaterial(GodRayShader);
		screenClearMaterial = CreateMaterial(ScreenClearShader);
		skyMaskMaterial = CreateMaterial(SkyMaskShader);
	}

	protected void OnDisable()
	{
		if ((bool)godRayMaterial)
		{
			Object.DestroyImmediate(godRayMaterial);
		}
		if ((bool)screenClearMaterial)
		{
			Object.DestroyImmediate(screenClearMaterial);
		}
		if ((bool)skyMaskMaterial)
		{
			Object.DestroyImmediate(skyMaskMaterial);
		}
	}

	protected void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckSupport(UseDepthTexture))
		{
			Graphics.Blit(source, destination);
			return;
		}
		sky.Components.Rays = this;
		Vector3 lightPos = cam.WorldToViewportPoint(sky.Components.LightTransform.position);
		RenderTexture skyMask = GetSkyMask(source, skyMaskMaterial, screenClearMaterial, Resolution, lightPos, BlurIterations, BlurRadius, MaxRadius);
		Color value = Color.black;
		if ((double)lightPos.z >= 0.0)
		{
			value = ((!sky.IsDay) ? (Intensity * sky.MoonVisibility * sky.MoonRayColor) : (Intensity * sky.SunVisibility * sky.SunRayColor));
		}
		godRayMaterial.SetColor("_LightColor", value);
		godRayMaterial.SetTexture("_SkyMask", skyMask);
		if (BlendMode == BlendModeType.Screen)
		{
			Graphics.Blit(source, destination, godRayMaterial, 0);
		}
		else
		{
			Graphics.Blit(source, destination, godRayMaterial, 1);
		}
		RenderTexture.ReleaseTemporary(skyMask);
	}
}
