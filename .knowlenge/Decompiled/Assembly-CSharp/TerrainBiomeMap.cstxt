using UnityEngine;

public class TerrainBiomeMap : TerrainMap<byte>
{
	public Texture2D BiomeTexture;

	internal int num;

	public override void Setup()
	{
		res = terrain.terrainData.alphamapResolution;
		this.num = 4;
		src = (dst = new byte[this.num * res * res]);
		if (!(BiomeTexture != null))
		{
			return;
		}
		if (BiomeTexture.width == BiomeTexture.height && BiomeTexture.width == res)
		{
			Color32[] pixels = BiomeTexture.GetPixels32();
			int i = 0;
			int num = 0;
			for (; i < res; i++)
			{
				int num2 = 0;
				while (num2 < res)
				{
					Color32 color = pixels[num];
					byte[] array = dst;
					_ = res;
					array[(0 + i) * res + num2] = color.r;
					dst[(res + i) * res + num2] = color.g;
					dst[(2 * res + i) * res + num2] = color.b;
					dst[(3 * res + i) * res + num2] = color.a;
					num2++;
					num++;
				}
			}
		}
		else
		{
			Debug.LogError("Invalid biome texture: " + BiomeTexture.name);
		}
	}

	public void GenerateTextures()
	{
		BiomeTexture = new Texture2D(res, res, TextureFormat.RGBA32, mipChain: true, linear: true);
		BiomeTexture.name = "BiomeTexture";
		BiomeTexture.wrapMode = TextureWrapMode.Clamp;
		Color32[] col = new Color32[res * res];
		Parallel.For(0, res, delegate(int z)
		{
			for (int i = 0; i < res; i++)
			{
				byte[] array = src;
				_ = res;
				byte r = array[(0 + z) * res + i];
				byte g = src[(res + z) * res + i];
				byte b = src[(2 * res + z) * res + i];
				byte a = src[(3 * res + z) * res + i];
				col[z * res + i] = new Color32(r, g, b, a);
			}
		});
		BiomeTexture.SetPixels32(col);
	}

	public void ApplyTextures()
	{
		BiomeTexture.Apply(updateMipmaps: true, makeNoLongerReadable: false);
		BiomeTexture.Compress(highQuality: false);
		BiomeTexture.Apply(updateMipmaps: false, makeNoLongerReadable: true);
	}

	public float GetBiomeMax(Vector3 worldPos, int mask = -1)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetBiomeMax(normX, normZ, mask);
	}

	public float GetBiomeMax(float normX, float normZ, int mask = -1)
	{
		int x = Index(normX);
		int z = Index(normZ);
		return GetBiomeMax(x, z, mask);
	}

	public float GetBiomeMax(int x, int z, int mask = -1)
	{
		byte b = 0;
		for (int i = 0; i < num; i++)
		{
			if ((TerrainBiome.IndexToType(i) & mask) != 0)
			{
				byte b2 = src[(i * res + z) * res + x];
				if (b2 >= b)
				{
					b = b2;
				}
			}
		}
		return (int)b;
	}

	public int GetBiomeMaxIndex(Vector3 worldPos, int mask = -1)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetBiomeMaxIndex(normX, normZ, mask);
	}

	public int GetBiomeMaxIndex(float normX, float normZ, int mask = -1)
	{
		int x = Index(normX);
		int z = Index(normZ);
		return GetBiomeMaxIndex(x, z, mask);
	}

	public int GetBiomeMaxIndex(int x, int z, int mask = -1)
	{
		byte b = 0;
		int result = 0;
		for (int i = 0; i < num; i++)
		{
			if ((TerrainBiome.IndexToType(i) & mask) != 0)
			{
				byte b2 = src[(i * res + z) * res + x];
				if (b2 >= b)
				{
					b = b2;
					result = i;
				}
			}
		}
		return result;
	}

	public int GetBiomeMaxType(Vector3 worldPos, int mask = -1)
	{
		return TerrainBiome.IndexToType(GetBiomeMaxIndex(worldPos, mask));
	}

	public int GetBiomeMaxType(float normX, float normZ, int mask = -1)
	{
		return TerrainBiome.IndexToType(GetBiomeMaxIndex(normX, normZ, mask));
	}

	public int GetBiomeMaxType(int x, int z, int mask = -1)
	{
		return TerrainBiome.IndexToType(GetBiomeMaxIndex(x, z, mask));
	}

	public float GetBiome(Vector3 worldPos, int mask)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetBiome(normX, normZ, mask);
	}

	public float GetBiome(float normX, float normZ, int mask)
	{
		int x = Index(normX);
		int z = Index(normZ);
		return GetBiome(x, z, mask);
	}

	public float GetBiome(int x, int z, int mask)
	{
		if (Mathf.IsPowerOfTwo(mask))
		{
			return BitUtility.Byte2Float(src[(TerrainBiome.TypeToIndex(mask) * res + z) * res + x]);
		}
		int num = 0;
		for (int i = 0; i < this.num; i++)
		{
			if ((TerrainBiome.IndexToType(i) & mask) != 0)
			{
				num += src[(i * res + z) * res + x];
			}
		}
		return Mathf.Clamp01(BitUtility.Byte2Float(num));
	}

	public void SetBiome(Vector3 worldPos, int id)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		SetBiome(normX, normZ, id);
	}

	public void SetBiome(float normX, float normZ, int id)
	{
		int x = Index(normX);
		int z = Index(normZ);
		SetBiome(x, z, id);
	}

	public void SetBiome(int x, int z, int id)
	{
		int num = TerrainBiome.TypeToIndex(id);
		for (int i = 0; i < this.num; i++)
		{
			if (i == num)
			{
				dst[(i * res + z) * res + x] = byte.MaxValue;
			}
			else
			{
				dst[(i * res + z) * res + x] = 0;
			}
		}
	}

	public void SetBiome(Vector3 worldPos, int id, float v)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		SetBiome(normX, normZ, id, v);
	}

	public void SetBiome(float normX, float normZ, int id, float v)
	{
		int x = Index(normX);
		int z = Index(normZ);
		SetBiome(x, z, id, v);
	}

	public void SetBiome(int x, int z, int id, float v)
	{
		SetBiome(x, z, id, GetBiome(x, z, id), v);
	}

	public void SetBiomeRaw(int x, int z, Vector4 v, float opacity)
	{
		if (opacity == 0f)
		{
			return;
		}
		float num = Mathf.Clamp01(v.x + v.y + v.z + v.w);
		if (num != 0f)
		{
			float num2 = 1f - opacity * num;
			if (num2 == 0f && opacity == 1f)
			{
				byte[] array = dst;
				_ = res;
				array[(0 + z) * res + x] = BitUtility.Float2Byte(v.x);
				dst[(res + z) * res + x] = BitUtility.Float2Byte(v.y);
				dst[(2 * res + z) * res + x] = BitUtility.Float2Byte(v.z);
				dst[(3 * res + z) * res + x] = BitUtility.Float2Byte(v.w);
			}
			else
			{
				byte[] array2 = dst;
				_ = res;
				int num3 = (0 + z) * res + x;
				byte[] array3 = src;
				_ = res;
				array2[num3] = BitUtility.Float2Byte(BitUtility.Byte2Float(array3[(0 + z) * res + x]) * num2 + v.x * opacity);
				dst[(res + z) * res + x] = BitUtility.Float2Byte(BitUtility.Byte2Float(src[(res + z) * res + x]) * num2 + v.y * opacity);
				dst[(2 * res + z) * res + x] = BitUtility.Float2Byte(BitUtility.Byte2Float(src[(2 * res + z) * res + x]) * num2 + v.z * opacity);
				dst[(3 * res + z) * res + x] = BitUtility.Float2Byte(BitUtility.Byte2Float(src[(3 * res + z) * res + x]) * num2 + v.w * opacity);
			}
		}
	}

	private void SetBiome(int x, int z, int id, float old_val, float new_val)
	{
		int num = TerrainBiome.TypeToIndex(id);
		if (old_val >= 1f)
		{
			return;
		}
		float num2 = (1f - new_val) / (1f - old_val);
		for (int i = 0; i < this.num; i++)
		{
			if (i == num)
			{
				dst[(i * res + z) * res + x] = BitUtility.Float2Byte(new_val);
			}
			else
			{
				dst[(i * res + z) * res + x] = BitUtility.Float2Byte(num2 * BitUtility.Byte2Float(dst[(i * res + z) * res + x]));
			}
		}
	}
}
