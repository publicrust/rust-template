using System;
using UnityEngine;

public class CoreEnvBrdfLut
{
	private static Texture2D runtimeEnvBrdfLut;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnRuntimeLoad()
	{
		PrepareTextureForRuntime();
		UpdateReflProbe();
	}

	private static void PrepareTextureForRuntime()
	{
		if (runtimeEnvBrdfLut == null)
		{
			runtimeEnvBrdfLut = Generate();
		}
		Shader.SetGlobalTexture("_EnvBrdfLut", runtimeEnvBrdfLut);
	}

	private static void UpdateReflProbe()
	{
		int num = (int)Mathf.Log(RenderSettings.defaultReflectionResolution, 2f) - 1;
		if (Shader.GetGlobalFloat("_ReflProbeMaxMip") != (float)num)
		{
			Shader.SetGlobalFloat("_ReflProbeMaxMip", num);
		}
	}

	public static Texture2D Generate(bool asset = false)
	{
		TextureFormat textureFormat = (asset ? TextureFormat.RGBAHalf : TextureFormat.RGHalf);
		textureFormat = (SystemInfo.SupportsTextureFormat(textureFormat) ? textureFormat : TextureFormat.ARGB32);
		int num = 128;
		int num2 = 32;
		float num3 = 1f / (float)num;
		float num4 = 1f / (float)num2;
		Texture2D texture2D = new Texture2D(num, num2, textureFormat, mipChain: false, linear: true);
		texture2D.name = "_EnvBrdfLut";
		texture2D.wrapMode = TextureWrapMode.Clamp;
		texture2D.filterMode = FilterMode.Bilinear;
		Color[] array = new Color[num * num2];
		float num5 = 1f / 128f;
		for (int i = 0; i < num2; i++)
		{
			float num6 = ((float)i + 0.5f) * num4;
			float num7 = num6 * num6;
			float num8 = num7 * num7;
			int j = 0;
			int num9 = i * num;
			for (; j < num; j++)
			{
				float num10 = ((float)j + 0.5f) * num3;
				Vector3 vector = new Vector3(Mathf.Sqrt(1f - num10 * num10), 0f, num10);
				float num11 = 0f;
				float num12 = 0f;
				for (uint num13 = 0u; num13 < 128; num13++)
				{
					float num14 = (float)num13 * num5;
					float num15 = (float)((double)ReverseBits(num13) / 4294967296.0);
					float f = (float)Math.PI * 2f * num14;
					float num16 = Mathf.Sqrt((1f - num15) / (1f + (num8 - 1f) * num15));
					float num17 = Mathf.Sqrt(1f - num16 * num16);
					Vector3 vector2 = new Vector3(num17 * Mathf.Cos(f), num17 * Mathf.Sin(f), num16);
					float num18 = Mathf.Max((2f * Vector3.Dot(vector, vector2) * vector2 - vector).z, 0f);
					float num19 = Mathf.Max(vector2.z, 0f);
					float num20 = Mathf.Max(Vector3.Dot(vector, vector2), 0f);
					if (num18 > 0f)
					{
						float num21 = num18 * (num10 * (1f - num7) + num7);
						float num22 = num10 * (num18 * (1f - num7) + num7);
						float num23 = 0.5f / (num21 + num22);
						float num24 = num18 * num23 * (4f * num20 / num19);
						float num25 = 1f - num20;
						num25 *= num25 * num25 * (num25 * num25);
						num11 += num24 * (1f - num25);
						num12 += num24 * num25;
					}
				}
				num11 = Mathf.Clamp(num11 * num5, 0f, 1f);
				num12 = Mathf.Clamp(num12 * num5, 0f, 1f);
				array[num9++] = new Color(num11, num12, 0f, 0f);
			}
		}
		texture2D.SetPixels(array);
		texture2D.Apply(updateMipmaps: false, !asset);
		return texture2D;
	}

	private static uint ReverseBits(uint Bits)
	{
		Bits = (Bits << 16) | (Bits >> 16);
		Bits = ((Bits & 0xFF00FF) << 8) | ((Bits & 0xFF00FF00u) >> 8);
		Bits = ((Bits & 0xF0F0F0F) << 4) | ((Bits & 0xF0F0F0F0u) >> 4);
		Bits = ((Bits & 0x33333333) << 2) | ((Bits & 0xCCCCCCCCu) >> 2);
		Bits = ((Bits & 0x55555555) << 1) | ((Bits & 0xAAAAAAAAu) >> 1);
		return Bits;
	}
}
