using UnityEngine;

public class SeparableSSS
{
	private static Vector3 Gaussian(float variance, float r, Color falloffColor)
	{
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < 3; i++)
		{
			float num = r / (0.001f + falloffColor[i]);
			zero[i] = Mathf.Exp((0f - num * num) / (2f * variance)) / (6.28f * variance);
		}
		return zero;
	}

	private static Vector3 Profile(float r, Color falloffColor)
	{
		return 0.1f * Gaussian(0.0484f, r, falloffColor) + 0.118f * Gaussian(0.187f, r, falloffColor) + 0.113f * Gaussian(0.567f, r, falloffColor) + 0.358f * Gaussian(1.99f, r, falloffColor) + 0.078f * Gaussian(7.41f, r, falloffColor);
	}

	public static void CalculateKernel(Color[] target, int targetStart, int targetSize, Color subsurfaceColor, Color falloffColor)
	{
		int num = targetSize * 2 - 1;
		float num2 = ((num > 20) ? 3f : 2f);
		float p = 2f;
		Color[] array = new Color[num];
		float num3 = 2f * num2 / (float)(num - 1);
		for (int i = 0; i < num; i++)
		{
			float num4 = 0f - num2 + (float)i * num3;
			float num5 = ((num4 < 0f) ? (-1f) : 1f);
			array[i].a = num2 * num5 * Mathf.Abs(Mathf.Pow(num4, p)) / Mathf.Pow(num2, p);
		}
		for (int j = 0; j < num; j++)
		{
			float num6 = ((j > 0) ? Mathf.Abs(array[j].a - array[j - 1].a) : 0f);
			float num7 = ((j < num - 1) ? Mathf.Abs(array[j].a - array[j + 1].a) : 0f);
			Vector3 vector = (num6 + num7) / 2f * Profile(array[j].a, falloffColor);
			array[j].r = vector.x;
			array[j].g = vector.y;
			array[j].b = vector.z;
		}
		Color color = array[num / 2];
		for (int num8 = num / 2; num8 > 0; num8--)
		{
			array[num8] = array[num8 - 1];
		}
		array[0] = color;
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
		for (uint num9 = 0u; num9 < targetSize - 1; num9++)
		{
			target[targetStart + num9 + 1] = array[targetSize + num9];
		}
	}
}
