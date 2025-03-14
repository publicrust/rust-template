using UnityEngine;

public class sRGB
{
	public static byte[] to_linear;

	public static byte[] to_srgb;

	static sRGB()
	{
		to_linear = new byte[256];
		to_srgb = new byte[256];
		to_linear = new byte[256];
		to_srgb = new byte[256];
		for (int i = 0; i < 256; i++)
		{
			to_linear[i] = (byte)(srgb_to_linear((float)i * 0.003921569f) * 255f + 0.5f);
		}
		for (int j = 0; j < 256; j++)
		{
			to_srgb[j] = (byte)(linear_to_srgb((float)j * 0.003921569f) * 255f + 0.5f);
		}
	}

	public static float linear_to_srgb(float linear)
	{
		if (float.IsNaN(linear))
		{
			return 0f;
		}
		if (linear > 1f)
		{
			return 1f;
		}
		if (linear < 0f)
		{
			return 0f;
		}
		if (linear < 0.0031308f)
		{
			return 12.92f * linear;
		}
		return 1.055f * Mathf.Pow(linear, 0.41666f) - 0.055f;
	}

	public static float srgb_to_linear(float srgb)
	{
		if (srgb <= 0.04045f)
		{
			return srgb / 12.92f;
		}
		return Mathf.Pow((srgb + 0.055f) / 1.055f, 2.4f);
	}
}
