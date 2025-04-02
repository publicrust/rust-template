using UnityEngine;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Noise/IsoNoise")]
public class ISONoise : PostEffectsBase
{
	public float monochromeTiling = 64f;

	public FilterMode filterMode = FilterMode.Bilinear;

	public Texture2D noiseTexture;

	public Shader noiseShader;

	private Material noiseMaterial;

	public override bool CheckResources()
	{
		CheckSupport(needDepth: false);
		noiseMaterial = CheckShaderAndCreateMaterial(noiseShader, noiseMaterial);
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		return isSupported;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources() || null == noiseTexture)
		{
			Graphics.Blit(source, destination);
			if (null == noiseTexture)
			{
				Debug.LogWarning("Noise & Grain effect failing as noise texture is not assigned. please assign.", base.transform);
			}
			return;
		}
		if ((bool)noiseTexture)
		{
			noiseTexture.wrapMode = TextureWrapMode.Repeat;
			noiseTexture.filterMode = filterMode;
		}
		noiseMaterial.SetTexture("_NoiseTex", noiseTexture);
		noiseMaterial.SetVector("_NoiseTilingPerChannel", Vector3.one * monochromeTiling);
		DrawNoiseQuadGrid(source, destination, noiseMaterial, noiseTexture, 0);
	}

	private static void DrawNoiseQuadGrid(RenderTexture source, RenderTexture dest, Material fxMaterial, Texture2D noise, int passNr)
	{
		RenderTexture.active = dest;
		float num = (float)noise.width * 1f;
		fxMaterial.SetTexture("_MainTex", source);
		GL.PushMatrix();
		GL.LoadOrtho();
		float num2 = 1f;
		float num3 = 1f;
		float num4 = (float)source.width / 256f;
		fxMaterial.SetPass(passNr);
		GL.Begin(7);
		for (float num5 = 0f; num5 < 1f; num5 += num2)
		{
			for (float num6 = 0f; num6 < 1f; num6 += num3)
			{
				float num7 = Random.Range(0f, 1f);
				float num8 = Random.Range(0f, 1f);
				num7 = Mathf.Floor(num7 * num) / num;
				num8 = Mathf.Floor(num8 * num) / num;
				GL.MultiTexCoord2(0, num7, num8);
				GL.MultiTexCoord2(1, 0f, 0f);
				GL.Vertex3(num5, num6, 0.1f);
				GL.MultiTexCoord2(0, num7 + num4, num8);
				GL.MultiTexCoord2(1, 1f, 0f);
				GL.Vertex3(num5 + num2, num6, 0.1f);
				GL.MultiTexCoord2(0, num7 + num4, num8 + num4);
				GL.MultiTexCoord2(1, 1f, 1f);
				GL.Vertex3(num5 + num2, num6 + num3, 0.1f);
				GL.MultiTexCoord2(0, num7, num8 + num4);
				GL.MultiTexCoord2(1, 0f, 1f);
				GL.Vertex3(num5, num6 + num3, 0.1f);
			}
		}
		GL.End();
		GL.PopMatrix();
	}
}
