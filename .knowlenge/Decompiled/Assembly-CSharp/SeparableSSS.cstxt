using UnityEngine;

public class SeparableSSS
{
	private static Vector3 Gaussian(float variance, float r, Color falloffColor)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < 3; i++)
		{
			float num = r / (0.001f + ((Color)(ref falloffColor))[i]);
			((Vector3)(ref zero))[i] = Mathf.Exp((0f - num * num) / (2f * variance)) / (6.28f * variance);
		}
		return zero;
	}

	private static Vector3 Profile(float r, Color falloffColor)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		return 0.1f * Gaussian(0.0484f, r, falloffColor) + 0.118f * Gaussian(0.187f, r, falloffColor) + 0.113f * Gaussian(0.567f, r, falloffColor) + 0.358f * Gaussian(1.99f, r, falloffColor) + 0.078f * Gaussian(7.41f, r, falloffColor);
	}

	public static void CalculateKernel(Color[] target, int targetStart, int targetSize, Color subsurfaceColor, Color falloffColor)
	{
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		int num = targetSize * 2 - 1;
		float num2 = ((num > 20) ? 3f : 2f);
		float num3 = 2f;
		Color[] array = (Color[])(object)new Color[num];
		float num4 = 2f * num2 / (float)(num - 1);
		for (int i = 0; i < num; i++)
		{
			float num5 = 0f - num2 + (float)i * num4;
			float num6 = ((num5 < 0f) ? (-1f) : 1f);
			array[i].a = num2 * num6 * Mathf.Abs(Mathf.Pow(num5, num3)) / Mathf.Pow(num2, num3);
		}
		for (int j = 0; j < num; j++)
		{
			float num7 = ((j > 0) ? Mathf.Abs(array[j].a - array[j - 1].a) : 0f);
			float num8 = ((j < num - 1) ? Mathf.Abs(array[j].a - array[j + 1].a) : 0f);
			Vector3 val = (num7 + num8) / 2f * Profile(array[j].a, falloffColor);
			array[j].r = val.x;
			array[j].g = val.y;
			array[j].b = val.z;
		}
		Color val2 = array[num / 2];
		for (int num9 = num / 2; num9 > 0; num9--)
		{
			array[num9] = array[num9 - 1];
		}
		array[0] = val2;
		Vector3 zero = Vector3.zero;
		for (int k = 0; k < num; k++)
		{
			zero.x += array[k].r;
			zero.y += array[k].g;
			zero.z += array[k].b;
		}
		for (int l = 0; l < num; l++)
		{
			array[l].r /= zero.x;
			array[l].g /= zero.y;
			array[l].b /= zero.z;
		}
		target[targetStart] = array[0];
		for (uint num10 = 0u; num10 < targetSize - 1; num10++)
		{
			target[targetStart + num10 + 1] = array[targetSize + num10];
		}
	}
}
