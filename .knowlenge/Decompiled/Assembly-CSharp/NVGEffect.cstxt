using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/NVG Effect")]
public class NVGEffect : PostEffectsBase, IImageEffect
{
	[Serializable]
	public struct ColorCorrectionParams
	{
		public float saturation;

		public AnimationCurve redChannel;

		public AnimationCurve greenChannel;

		public AnimationCurve blueChannel;
	}

	[Serializable]
	public struct NoiseAndGrainParams
	{
		public float intensityMultiplier;

		public float generalIntensity;

		public float blackIntensity;

		public float whiteIntensity;

		public float midGrey;

		public bool monochrome;

		public Vector3 intensities;

		public Vector3 tiling;

		public float monochromeTiling;

		public FilterMode filterMode;
	}

	public ColorCorrectionParams ColorCorrection1 = new ColorCorrectionParams
	{
		saturation = 1f,
		redChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)),
		greenChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)),
		blueChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f))
	};

	public ColorCorrectionParams ColorCorrection2 = new ColorCorrectionParams
	{
		saturation = 1f,
		redChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)),
		greenChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)),
		blueChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f))
	};

	public NoiseAndGrainParams NoiseAndGrain = new NoiseAndGrainParams
	{
		intensityMultiplier = 1.5f,
		generalIntensity = 1f,
		blackIntensity = 1f,
		whiteIntensity = 1f,
		midGrey = 0.182f,
		monochrome = true,
		intensities = new Vector3(1f, 1f, 1f),
		tiling = new Vector3(60f, 70f, 80f),
		monochromeTiling = 55f,
		filterMode = FilterMode.Point
	};

	private Texture2D rgbChannelTex1;

	private Texture2D rgbChannelTex2;

	private bool updateTexturesOnStartup = true;

	public Texture2D NoiseTexture;

	private static float NOISE_TILE_AMOUNT = 64f;

	public Shader Shader;

	private Material material;

	private void Awake()
	{
		updateTexturesOnStartup = true;
	}

	private void OnDestroy()
	{
		if (rgbChannelTex1 != null)
		{
			UnityEngine.Object.DestroyImmediate(rgbChannelTex1);
			rgbChannelTex1 = null;
		}
		if (rgbChannelTex2 != null)
		{
			UnityEngine.Object.DestroyImmediate(rgbChannelTex2);
			rgbChannelTex2 = null;
		}
		if (material != null)
		{
			UnityEngine.Object.DestroyImmediate(material);
			material = null;
		}
	}

	private void UpdateColorCorrectionTexture(ColorCorrectionParams param, ref Texture2D tex)
	{
		if (param.redChannel != null && param.greenChannel != null && param.blueChannel != null)
		{
			for (float num = 0f; num <= 1f; num += 0.003921569f)
			{
				float num2 = Mathf.Clamp(param.redChannel.Evaluate(num), 0f, 1f);
				float num3 = Mathf.Clamp(param.greenChannel.Evaluate(num), 0f, 1f);
				float num4 = Mathf.Clamp(param.blueChannel.Evaluate(num), 0f, 1f);
				tex.SetPixel((int)Mathf.Floor(num * 255f), 0, new Color(num2, num2, num2));
				tex.SetPixel((int)Mathf.Floor(num * 255f), 1, new Color(num3, num3, num3));
				tex.SetPixel((int)Mathf.Floor(num * 255f), 2, new Color(num4, num4, num4));
			}
			tex.Apply();
		}
	}

	public void UpdateTextures()
	{
		CheckResources();
		UpdateColorCorrectionTexture(ColorCorrection1, ref rgbChannelTex1);
		UpdateColorCorrectionTexture(ColorCorrection2, ref rgbChannelTex2);
	}

	public override bool CheckResources()
	{
		CheckSupport(needDepth: false);
		material = CheckShaderAndCreateMaterial(Shader, material);
		if (rgbChannelTex1 == null || rgbChannelTex2 == null)
		{
			rgbChannelTex1 = new Texture2D(256, 4, TextureFormat.ARGB32, mipChain: false, linear: true)
			{
				hideFlags = HideFlags.DontSave,
				wrapMode = TextureWrapMode.Clamp
			};
			rgbChannelTex2 = new Texture2D(256, 4, TextureFormat.ARGB32, mipChain: false, linear: true)
			{
				hideFlags = HideFlags.DontSave,
				wrapMode = TextureWrapMode.Clamp
			};
		}
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		return isSupported;
	}

	public bool IsActive()
	{
		if (base.enabled && CheckResources())
		{
			return NoiseTexture != null;
		}
		return false;
	}

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			Graphics.Blit(source, destination);
			if (NoiseTexture == null)
			{
				Debug.LogWarning("[NVGEffect] Noise & Grain effect failing as noise texture is not assigned. please assign.", base.transform);
			}
			return;
		}
		if (updateTexturesOnStartup)
		{
			UpdateTextures();
			updateTexturesOnStartup = false;
		}
		material.SetTexture("_MainTex", source);
		material.SetTexture("_RgbTex1", rgbChannelTex1);
		material.SetFloat("_Saturation1", ColorCorrection1.saturation);
		material.SetTexture("_RgbTex2", rgbChannelTex2);
		material.SetFloat("_Saturation2", ColorCorrection2.saturation);
		material.SetTexture("_NoiseTex", NoiseTexture);
		material.SetVector("_NoisePerChannel", NoiseAndGrain.monochrome ? Vector3.one : NoiseAndGrain.intensities);
		material.SetVector("_NoiseTilingPerChannel", NoiseAndGrain.monochrome ? (Vector3.one * NoiseAndGrain.monochromeTiling) : NoiseAndGrain.tiling);
		material.SetVector("_MidGrey", new Vector3(NoiseAndGrain.midGrey, 1f / (1f - NoiseAndGrain.midGrey), -1f / NoiseAndGrain.midGrey));
		material.SetVector("_NoiseAmount", new Vector3(NoiseAndGrain.generalIntensity, NoiseAndGrain.blackIntensity, NoiseAndGrain.whiteIntensity) * NoiseAndGrain.intensityMultiplier);
		if ((bool)NoiseTexture)
		{
			NoiseTexture.wrapMode = TextureWrapMode.Repeat;
			NoiseTexture.filterMode = NoiseAndGrain.filterMode;
		}
		RenderTexture.active = destination;
		float num = (float)NoiseTexture.width * 1f;
		float num2 = 1f * (float)source.width / NOISE_TILE_AMOUNT;
		GL.PushMatrix();
		GL.LoadOrtho();
		float num3 = 1f * (float)source.width / (1f * (float)source.height);
		float num4 = 1f / num2;
		float num5 = num4 * num3;
		float num6 = num / ((float)NoiseTexture.width * 1f);
		material.SetPass(0);
		GL.Begin(7);
		for (float num7 = 0f; num7 < 1f; num7 += num4)
		{
			for (float num8 = 0f; num8 < 1f; num8 += num5)
			{
				float num9 = UnityEngine.Random.Range(0f, 1f);
				float num10 = UnityEngine.Random.Range(0f, 1f);
				num9 = Mathf.Floor(num9 * num) / num;
				num10 = Mathf.Floor(num10 * num) / num;
				float num11 = 1f / num;
				GL.MultiTexCoord2(0, num9, num10);
				GL.MultiTexCoord2(1, 0f, 0f);
				GL.Vertex3(num7, num8, 0.1f);
				GL.MultiTexCoord2(0, num9 + num6 * num11, num10);
				GL.MultiTexCoord2(1, 1f, 0f);
				GL.Vertex3(num7 + num4, num8, 0.1f);
				GL.MultiTexCoord2(0, num9 + num6 * num11, num10 + num6 * num11);
				GL.MultiTexCoord2(1, 1f, 1f);
				GL.Vertex3(num7 + num4, num8 + num5, 0.1f);
				GL.MultiTexCoord2(0, num9, num10 + num6 * num11);
				GL.MultiTexCoord2(1, 0f, 1f);
				GL.Vertex3(num7, num8 + num5, 0.1f);
			}
		}
		GL.End();
		GL.PopMatrix();
	}
}
