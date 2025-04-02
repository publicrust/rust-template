using UnityEngine;

public struct TextureData
{
	public int width;

	public int height;

	public Color32[] colors;

	public TextureData(Texture2D tex)
	{
		if ((Object)(object)tex != (Object)null)
		{
			width = ((Texture)tex).width;
			height = ((Texture)tex).height;
			colors = tex.GetPixels32();
		}
		else
		{
			width = 0;
			height = 0;
			colors = null;
		}
	}

	public Color32 GetColor(int x, int y)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return colors[y * width + x];
	}

	public int GetShort(int x, int y)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return BitUtility.DecodeShort(GetColor(x, y));
	}

	public int GetInt(int x, int y)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return BitUtility.DecodeInt(GetColor(x, y));
	}

	public float GetFloat(int x, int y)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return BitUtility.DecodeFloat(GetColor(x, y));
	}

	public float GetHalf(int x, int y)
	{
		return BitUtility.Short2Float(GetShort(x, y));
	}

	public Vector4 GetVector(int x, int y)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return BitUtility.DecodeVector(GetColor(x, y));
	}

	public Vector3 GetNormal(int x, int y)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return BitUtility.DecodeNormal(Color32.op_Implicit(GetColor(x, y)));
	}

	public Color32 GetInterpolatedColor(float x, float y)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int num3 = Mathf.Clamp((int)num, 1, width - 2);
		int num4 = Mathf.Clamp((int)num2, 1, height - 2);
		int x2 = Mathf.Min(num3 + 1, width - 2);
		int y2 = Mathf.Min(num4 + 1, height - 2);
		Color val = Color32.op_Implicit(GetColor(num3, num4));
		Color val2 = Color32.op_Implicit(GetColor(x2, num4));
		Color val3 = Color32.op_Implicit(GetColor(num3, y2));
		Color val4 = Color32.op_Implicit(GetColor(x2, y2));
		float num5 = num - (float)num3;
		float num6 = num2 - (float)num4;
		Color val5 = Color.Lerp(val, val2, num5);
		Color val6 = Color.Lerp(val3, val4, num5);
		return Color32.op_Implicit(Color.Lerp(val5, val6, num6));
	}

	public int GetInterpolatedInt(float x, float y)
	{
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int x2 = Mathf.Clamp(Mathf.RoundToInt(num), 1, width - 2);
		int y2 = Mathf.Clamp(Mathf.RoundToInt(num2), 1, height - 2);
		return GetInt(x2, y2);
	}

	public int GetInterpolatedShort(float x, float y)
	{
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int x2 = Mathf.Clamp(Mathf.RoundToInt(num), 1, width - 2);
		int y2 = Mathf.Clamp(Mathf.RoundToInt(num2), 1, height - 2);
		return GetShort(x2, y2);
	}

	public float GetInterpolatedFloat(float x, float y)
	{
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int num3 = Mathf.Clamp((int)num, 1, width - 2);
		int num4 = Mathf.Clamp((int)num2, 1, height - 2);
		int x2 = Mathf.Min(num3 + 1, width - 2);
		int y2 = Mathf.Min(num4 + 1, height - 2);
		float @float = GetFloat(num3, num4);
		float float2 = GetFloat(x2, num4);
		float float3 = GetFloat(num3, y2);
		float float4 = GetFloat(x2, y2);
		float num5 = num - (float)num3;
		float num6 = num2 - (float)num4;
		float num7 = Mathf.Lerp(@float, float2, num5);
		float num8 = Mathf.Lerp(float3, float4, num5);
		return Mathf.Lerp(num7, num8, num6);
	}

	public float GetInterpolatedHalf(float x, float y)
	{
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int num3 = Mathf.Clamp((int)num, 1, width - 2);
		int num4 = Mathf.Clamp((int)num2, 1, height - 2);
		int x2 = Mathf.Min(num3 + 1, width - 2);
		int y2 = Mathf.Min(num4 + 1, height - 2);
		float half = GetHalf(num3, num4);
		float half2 = GetHalf(x2, num4);
		float half3 = GetHalf(num3, y2);
		float half4 = GetHalf(x2, y2);
		float num5 = num - (float)num3;
		float num6 = num2 - (float)num4;
		float num7 = Mathf.Lerp(half, half2, num5);
		float num8 = Mathf.Lerp(half3, half4, num5);
		return Mathf.Lerp(num7, num8, num6);
	}

	public Vector4 GetInterpolatedVector(float x, float y)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int num3 = Mathf.Clamp((int)num, 1, width - 2);
		int num4 = Mathf.Clamp((int)num2, 1, height - 2);
		int x2 = Mathf.Min(num3 + 1, width - 2);
		int y2 = Mathf.Min(num4 + 1, height - 2);
		Vector4 vector = GetVector(num3, num4);
		Vector4 vector2 = GetVector(x2, num4);
		Vector4 vector3 = GetVector(num3, y2);
		Vector4 vector4 = GetVector(x2, y2);
		float num5 = num - (float)num3;
		float num6 = num2 - (float)num4;
		Vector4 val = Vector4.Lerp(vector, vector2, num5);
		Vector4 val2 = Vector4.Lerp(vector3, vector4, num5);
		return Vector4.Lerp(val, val2, num6);
	}

	public Vector3 GetInterpolatedNormal(float x, float y)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int num3 = Mathf.Clamp((int)num, 1, width - 2);
		int num4 = Mathf.Clamp((int)num2, 1, height - 2);
		int x2 = Mathf.Min(num3 + 1, width - 2);
		int y2 = Mathf.Min(num4 + 1, height - 2);
		Vector3 normal = GetNormal(num3, num4);
		Vector3 normal2 = GetNormal(x2, num4);
		Vector3 normal3 = GetNormal(num3, y2);
		Vector3 normal4 = GetNormal(x2, y2);
		float num5 = num - (float)num3;
		float num6 = num2 - (float)num4;
		Vector3 val = Vector3.Lerp(normal, normal2, num5);
		Vector3 val2 = Vector3.Lerp(normal3, normal4, num5);
		return Vector3.Lerp(val, val2, num6);
	}
}
