using UnityEngine;

public class LTBezier
{
	public float length;

	private Vector3 a;

	private Vector3 aa;

	private Vector3 bb;

	private Vector3 cc;

	private float len;

	private float[] arcLengths;

	public LTBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float precision)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		this.a = a;
		aa = -a + 3f * (b - c) + d;
		bb = 3f * (a + c) - 6f * b;
		cc = 3f * (b - a);
		len = 1f / precision;
		arcLengths = new float[(int)len + 1];
		arcLengths[0] = 0f;
		Vector3 val = a;
		float num = 0f;
		for (int i = 1; (float)i <= len; i++)
		{
			Vector3 val2 = bezierPoint((float)i * precision);
			float num2 = num;
			Vector3 val3 = val - val2;
			num = num2 + ((Vector3)(ref val3)).magnitude;
			arcLengths[i] = num;
			val = val2;
		}
		length = num;
	}

	private float map(float u)
	{
		float num = u * arcLengths[(int)len];
		int num2 = 0;
		int num3 = (int)len;
		int num4 = 0;
		while (num2 < num3)
		{
			num4 = num2 + ((int)((float)(num3 - num2) / 2f) | 0);
			if (arcLengths[num4] < num)
			{
				num2 = num4 + 1;
			}
			else
			{
				num3 = num4;
			}
		}
		if (arcLengths[num4] > num)
		{
			num4--;
		}
		if (num4 < 0)
		{
			num4 = 0;
		}
		return ((float)num4 + (num - arcLengths[num4]) / (arcLengths[num4 + 1] - arcLengths[num4])) / len;
	}

	private Vector3 bezierPoint(float t)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		return ((aa * t + bb) * t + cc) * t + a;
	}

	public Vector3 point(float t)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return bezierPoint(map(t));
	}
}
