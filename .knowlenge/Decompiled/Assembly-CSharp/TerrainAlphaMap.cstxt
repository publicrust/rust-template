using System;
using UnityEngine;
using UnityEngine.Serialization;

public class TerrainAlphaMap : TerrainMap<byte>
{
	[FormerlySerializedAs("ColorTexture")]
	public Texture2D AlphaTexture;

	public override void Setup()
	{
		res = terrain.terrainData.alphamapResolution;
		src = (dst = new byte[res * res]);
		for (int i = 0; i < res; i++)
		{
			for (int j = 0; j < res; j++)
			{
				dst[i * res + j] = byte.MaxValue;
			}
		}
		if (!((Object)(object)AlphaTexture != (Object)null))
		{
			return;
		}
		if (((Texture)AlphaTexture).width == ((Texture)AlphaTexture).height && ((Texture)AlphaTexture).width == res)
		{
			Color32[] pixels = AlphaTexture.GetPixels32();
			int k = 0;
			int num = 0;
			for (; k < res; k++)
			{
				int num2 = 0;
				while (num2 < res)
				{
					dst[k * res + num2] = pixels[num].a;
					num2++;
					num++;
				}
			}
		}
		else
		{
			Debug.LogError((object)("Invalid alpha texture: " + ((Object)AlphaTexture).name));
		}
	}

	public void GenerateTextures()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		AlphaTexture = new Texture2D(res, res, (TextureFormat)1, false, true);
		((Object)AlphaTexture).name = "AlphaTexture";
		((Texture)AlphaTexture).wrapMode = (TextureWrapMode)1;
		Color32[] col = (Color32[])(object)new Color32[res * res];
		Parallel.For(0, res, (Action<int>)delegate(int z)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
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
		AlphaTexture.Apply(true, false);
		AlphaTexture.Compress(false);
		AlphaTexture.Apply(false, true);
	}

	public float GetAlpha(Vector3 worldPos)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
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
		float num6 = Mathf.Lerp(GetAlpha(num4, num5), GetAlpha(x, num5), num2 - (float)num4);
		float num7 = Mathf.Lerp(GetAlpha(num4, z), GetAlpha(x, z), num2 - (float)num4);
		return Mathf.Lerp(num6, num7, num3 - (float)num5);
	}

	public float GetAlpha(int x, int z)
	{
		return BitUtility.Byte2Float((int)src[z * res + x]);
	}

	public void SetAlpha(Vector3 worldPos, float a)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
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
