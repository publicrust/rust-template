using UnityEngine;

public class TerrainWaterMap : TerrainMap<short>
{
	public Texture2D WaterTexture;

	private float normY;

	public override void Setup()
	{
		res = terrain.terrainData.heightmapResolution;
		src = (dst = new short[res * res]);
		normY = TerrainMeta.Size.x / TerrainMeta.Size.y / (float)res;
		if (!(WaterTexture != null))
		{
			return;
		}
		if (WaterTexture.width == WaterTexture.height && WaterTexture.width == res)
		{
			Color32[] pixels = WaterTexture.GetPixels32();
			int i = 0;
			int num = 0;
			for (; i < res; i++)
			{
				int num2 = 0;
				while (num2 < res)
				{
					Color32 c = pixels[num];
					dst[i * res + num2] = BitUtility.DecodeShort(c);
					num2++;
					num++;
				}
			}
		}
		else
		{
			Debug.LogError("Invalid water texture: " + WaterTexture.name);
		}
	}

	public void GenerateTextures()
	{
		Color32[] heights = new Color32[res * res];
		Parallel.For(0, res, delegate(int z)
		{
			for (int i = 0; i < res; i++)
			{
				heights[z * res + i] = BitUtility.EncodeShort(src[z * res + i]);
			}
		});
		WaterTexture = new Texture2D(res, res, TextureFormat.RGBA32, mipChain: true, linear: true);
		WaterTexture.name = "WaterTexture";
		WaterTexture.wrapMode = TextureWrapMode.Clamp;
		WaterTexture.SetPixels32(heights);
	}

	public void ApplyTextures()
	{
		WaterTexture.Apply(updateMipmaps: true, makeNoLongerReadable: true);
	}

	public float GetHeight(Vector3 worldPos)
	{
		return TerrainMeta.Position.y + GetHeight01(worldPos) * TerrainMeta.Size.y;
	}

	public float GetHeight(float normX, float normZ)
	{
		return TerrainMeta.Position.y + GetHeight01(normX, normZ) * TerrainMeta.Size.y;
	}

	public float GetHeightFast(Vector2 uv)
	{
		int num = res - 1;
		float num2 = uv.x * (float)num;
		float num3 = uv.y * (float)num;
		int num4 = (int)num2;
		int num5 = (int)num3;
		float num6 = num2 - (float)num4;
		float num7 = num3 - (float)num5;
		num4 = ((num4 >= 0) ? num4 : 0);
		num5 = ((num5 >= 0) ? num5 : 0);
		num4 = ((num4 <= num) ? num4 : num);
		num5 = ((num5 <= num) ? num5 : num);
		int num8 = ((num2 < (float)num) ? 1 : 0);
		int num9 = ((num3 < (float)num) ? res : 0);
		int num10 = num5 * res + num4;
		int num11 = num10 + num8;
		int num12 = num10 + num9;
		int num13 = num12 + num8;
		float num14 = (float)src[num10] * 3.051944E-05f;
		float num15 = (float)src[num11] * 3.051944E-05f;
		float num16 = (float)src[num12] * 3.051944E-05f;
		float num17 = (float)src[num13] * 3.051944E-05f;
		float num18 = (num15 - num14) * num6 + num14;
		float num19 = ((num17 - num16) * num6 + num16 - num18) * num7 + num18;
		return TerrainMeta.Position.y + num19 * TerrainMeta.Size.y;
	}

	public float GetHeight(int x, int z)
	{
		return TerrainMeta.Position.y + GetHeight01(x, z) * TerrainMeta.Size.y;
	}

	public float GetHeight01(Vector3 worldPos)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetHeight01(normX, normZ);
	}

	public float GetHeight01(float normX, float normZ)
	{
		int num = res - 1;
		float num2 = normX * (float)num;
		float num3 = normZ * (float)num;
		int num4 = Mathf.Clamp((int)num2, 0, num);
		int num5 = Mathf.Clamp((int)num3, 0, num);
		int x = Mathf.Min(num4 + 1, num);
		int z = Mathf.Min(num5 + 1, num);
		float a = Mathf.Lerp(GetHeight01(num4, num5), GetHeight01(x, num5), num2 - (float)num4);
		float b = Mathf.Lerp(GetHeight01(num4, z), GetHeight01(x, z), num2 - (float)num4);
		return Mathf.Lerp(a, b, num3 - (float)num5);
	}

	public float GetHeight01(int x, int z)
	{
		return BitUtility.Short2Float(src[z * res + x]);
	}

	public Vector3 GetNormal(Vector3 worldPos)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetNormal(normX, normZ);
	}

	public Vector3 GetNormal(float normX, float normZ)
	{
		int num = res - 1;
		float num2 = normX * (float)num;
		float num3 = normZ * (float)num;
		int num4 = Mathf.Clamp((int)num2, 0, num);
		int num5 = Mathf.Clamp((int)num3, 0, num);
		int x = Mathf.Min(num4 + 1, num);
		int z = Mathf.Min(num5 + 1, num);
		float num6 = GetHeight01(x, num5) - GetHeight01(num4, num5);
		return new Vector3(z: 0f - (GetHeight01(num4, z) - GetHeight01(num4, num5)), x: 0f - num6, y: normY).normalized;
	}

	public Vector3 GetNormalFast(Vector2 uv)
	{
		int num = res - 1;
		int num2 = (int)(uv.x * (float)num);
		int num3 = (int)(uv.y * (float)num);
		num2 = ((num2 >= 0) ? num2 : 0);
		num3 = ((num3 >= 0) ? num3 : 0);
		num2 = ((num2 <= num) ? num2 : num);
		num3 = ((num3 <= num) ? num3 : num);
		int num4 = ((num2 < num) ? 1 : 0);
		int num5 = ((num3 < num) ? res : 0);
		int num6 = num3 * res + num2;
		int num7 = num6 + num4;
		int num8 = num6 + num5;
		short num9 = src[num6];
		short num10 = src[num7];
		short num11 = src[num8];
		float num12 = (float)(num10 - num9) * 3.051944E-05f;
		float num13 = (float)(num11 - num9) * 3.051944E-05f;
		return new Vector3(0f - num12, normY, 0f - num13);
	}

	public Vector3 GetNormal(int x, int z)
	{
		int max = res - 1;
		int x2 = Mathf.Clamp(x - 1, 0, max);
		int z2 = Mathf.Clamp(z - 1, 0, max);
		int x3 = Mathf.Clamp(x + 1, 0, max);
		int z3 = Mathf.Clamp(z + 1, 0, max);
		float num = (GetHeight01(x3, z2) - GetHeight01(x2, z2)) * 0.5f;
		return new Vector3(z: 0f - (GetHeight01(x2, z3) - GetHeight01(x2, z2)) * 0.5f, x: 0f - num, y: normY).normalized;
	}

	public float GetSlope(Vector3 worldPos)
	{
		return Vector3.Angle(Vector3.up, GetNormal(worldPos));
	}

	public float GetSlope(float normX, float normZ)
	{
		return Vector3.Angle(Vector3.up, GetNormal(normX, normZ));
	}

	public float GetSlope(int x, int z)
	{
		return Vector3.Angle(Vector3.up, GetNormal(x, z));
	}

	public float GetSlope01(Vector3 worldPos)
	{
		return GetSlope(worldPos) * (1f / 90f);
	}

	public float GetSlope01(float normX, float normZ)
	{
		return GetSlope(normX, normZ) * (1f / 90f);
	}

	public float GetSlope01(int x, int z)
	{
		return GetSlope(x, z) * (1f / 90f);
	}

	public float GetDepth(Vector3 worldPos)
	{
		return GetHeight(worldPos) - TerrainMeta.HeightMap.GetHeight(worldPos);
	}

	public float GetDepth(float normX, float normZ)
	{
		return GetHeight(normX, normZ) - TerrainMeta.HeightMap.GetHeight(normX, normZ);
	}

	public void SetHeight(Vector3 worldPos, float height)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		SetHeight(normX, normZ, height);
	}

	public void SetHeight(float normX, float normZ, float height)
	{
		int x = Index(normX);
		int z = Index(normZ);
		SetHeight(x, z, height);
	}

	public void SetHeight(int x, int z, float height)
	{
		dst[z * res + x] = BitUtility.Float2Short(height);
	}
}
