using UnityEngine;

public struct TextureData
{
	public int width;

	public int height;

	public Color32[] colors;

	public TextureData(Texture2D tex)
	{
		if (tex != null)
		{
			width = tex.width;
			height = tex.height;
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
		return colors[y * width + x];
	}

	public int GetShort(int x, int y)
	{
		return BitUtility.DecodeShort(GetColor(x, y));
	}

	public int GetInt(int x, int y)
	{
		return BitUtility.DecodeInt(GetColor(x, y));
	}

	public float GetFloat(int x, int y)
	{
		return BitUtility.DecodeFloat(GetColor(x, y));
	}

	public float GetHalf(int x, int y)
	{
		return BitUtility.Short2Float(GetShort(x, y));
	}

	public Vector4 GetVector(int x, int y)
	{
		return BitUtility.DecodeVector(GetColor(x, y));
	}

	public Vector3 GetNormal(int x, int y)
	{
		return BitUtility.DecodeNormal(GetColor(x, y));
	}

	public Color32 GetInterpolatedColor(float x, float y)
	{
		float num = x * (float)(width - 1);
		float num2 = y * (float)(height - 1);
		int num3 = Mathf.Clamp((int)num, 1, width - 2);
		int num4 = Mathf.Clamp((int)num2, 1, height - 2);
		int x2 = Mathf.Min(num3 + 1, width - 2);
		int y2 = Mathf.Min(num4 + 1, height - 2);
		Color a = GetColor(num3, num4);
		Color b = GetColor(x2, num4);
		Color a2 = GetColor(num3, y2);
		Color b2 = GetColor(x2, y2);
		float t = num - (float)num3;
		float t2 = num2 - (float)num4;
		Color a3 = Color.Lerp(a, b, t);
		Color b3 = Color.Lerp(a2, b2, t);
		return Color.Lerp(a3, b3, t2);
	}

	public int GetInterpolatedInt(float x, float y)
	{
		float f = x * (float)(width - 1);
		float f2 = y * (float)(height - 1);
		int x2 = Mathf.Clamp(Mathf.RoundToInt(f), 1, width - 2);
		int y2 = Mathf.Clamp(Mathf.RoundToInt(f2), 1, height - 2);
		return GetInt(x2, y2);
	}

	public int GetInterpolatedShort(float x, float y)
	{
		float f = x * (float)(width - 1);
		float f2 = y * (float)(height - 1);
		int x2 = Mathf.Clamp(Mathf.RoundToInt(f), 1, width - 2);
		int y2 = Mathf.Clamp(Mathf.RoundToInt(f2), 1, height - 2);
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
		float t = num - (float)num3;
		float t2 = num2 - (float)num4;
		float a = Mathf.Lerp(@float, float2, t);
		float b = Mathf.Lerp(float3, float4, t);
		return Mathf.Lerp(a, b, t2);
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
		float t = num - (float)num3;
		float t2 = num2 - (float)num4;
		float a = Mathf.Lerp(half, half2, t);
		float b = Mathf.Lerp(half3, half4, t);
		return Mathf.Lerp(a, b, t2);
	}

	public Vector4 GetInterpolatedVector(float x, float y)
	{
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
		float t = num - (float)num3;
		float t2 = num2 - (float)num4;
		Vector4 a = Vector4.Lerp(vector, vector2, t);
		Vector4 b = Vector4.Lerp(vector3, vector4, t);
		return Vector4.Lerp(a, b, t2);
	}

	public Vector3 GetInterpolatedNormal(float x, float y)
	{
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
		float t = num - (float)num3;
		float t2 = num2 - (float)num4;
		Vector3 a = Vector3.Lerp(normal, normal2, t);
		Vector3 b = Vector3.Lerp(normal3, normal4, t);
		return Vector3.Lerp(a, b, t2);
	}
}
