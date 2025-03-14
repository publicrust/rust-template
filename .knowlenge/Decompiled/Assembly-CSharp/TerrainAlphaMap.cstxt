using System;
using UnityEngine;
using UnityEngine.Serialization;

public class TerrainAlphaMap : TerrainMap<byte>
{
	[FormerlySerializedAs("ColorTexture")]
	public Texture2D AlphaTexture;

	public override void Setup()
	{
		if (AlphaTexture != null)
		{
			if (AlphaTexture.width == AlphaTexture.height)
			{
				res = AlphaTexture.width;
				src = (dst = new byte[res * res]);
				Color32[] pixels = AlphaTexture.GetPixels32();
				int i = 0;
				int num = 0;
				for (; i < res; i++)
				{
					int num2 = 0;
					while (num2 < res)
					{
						dst[i * res + num2] = pixels[num].a;
						num2++;
						num++;
					}
				}
			}
			else
			{
				Debug.LogError("Invalid alpha texture: " + AlphaTexture.name);
			}
			return;
		}
		res = terrain.terrainData.alphamapResolution;
		src = (dst = new byte[res * res]);
		for (int j = 0; j < res; j++)
		{
			for (int k = 0; k < res; k++)
			{
				dst[j * res + k] = byte.MaxValue;
			}
		}
	}

	public void GenerateTextures()
	{
		AlphaTexture = new Texture2D(res, res, TextureFormat.Alpha8, mipChain: false, linear: true);
		AlphaTexture.name = "AlphaTexture";
		AlphaTexture.wrapMode = TextureWrapMode.Clamp;
		Color32[] col = new Color32[res * res];
		Parallel.For(0, res, delegate(int z)
		{
			for (int i = 0; i < res; i++)
			{
				byte b = src[z * res + i];
				col[z * res + i] = new Color32(b, b, b, b);
			}
		});
		AlphaTexture.SetPixels32(col);
	}

	public void ApplyTextures()
	{
		AlphaTexture.Apply(updateMipmaps: true, makeNoLongerReadable: false);
		AlphaTexture.Compress(highQuality: false);
		AlphaTexture.Apply(updateMipmaps: false, makeNoLongerReadable: true);
	}

	public float GetAlpha(Vector3 worldPos)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetAlpha(normX, normZ);
	}

	public float GetAlpha(float normX, float normZ)
	{
		int num = res - 1;
		float num2 = normX * (float)num;
		float num3 = normZ * (float)num;
		int num4 = Mathf.Clamp((int)num2, 0, num);
		int num5 = Mathf.Clamp((int)num3, 0, num);
		int x = Mathf.Min(num4 + 1, num);
		int z = Mathf.Min(num5 + 1, num);
		float a = Mathf.Lerp(GetAlpha(num4, num5), GetAlpha(x, num5), num2 - (float)num4);
		float b = Mathf.Lerp(GetAlpha(num4, z), GetAlpha(x, z), num2 - (float)num4);
		return Mathf.Lerp(a, b, num3 - (float)num5);
	}

	public float GetAlpha(int x, int z)
	{
		return BitUtility.Byte2Float(src[z * res + x]);
	}

	public void SetAlpha(Vector3 worldPos, float a)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		SetAlpha(normX, normZ, a);
	}

	public void SetAlpha(float normX, float normZ, float a)
	{
		int x = Index(normX);
		int z = Index(normZ);
		SetAlpha(x, z, a);
	}

	public void SetAlpha(int x, int z, float a)
	{
		dst[z * res + x] = BitUtility.Float2Byte(a);
	}

	public void SetAlpha(int x, int z, float a, float opacity)
	{
		SetAlpha(x, z, Mathf.Lerp(GetAlpha(x, z), a, opacity));
	}

	public void SetAlpha(Vector3 worldPos, float a, float opacity, float radius, float fade = 0f)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		SetAlpha(normX, normZ, a, opacity, radius, fade);
	}

	public void SetAlpha(float normX, float normZ, float a, float opacity, float radius, float fade = 0f)
	{
		Action<int, int, float> action = delegate(int x, int z, float lerp)
		{
			lerp *= opacity;
			if (lerp > 0f)
			{
				SetAlpha(x, z, a, lerp);
			}
		};
		ApplyFilter(normX, normZ, radius, fade, action);
	}
}
