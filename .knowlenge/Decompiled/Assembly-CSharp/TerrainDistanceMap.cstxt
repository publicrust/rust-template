using UnityEngine;

public class TerrainDistanceMap : TerrainMap<byte>
{
	public Texture2D DistanceTexture;

	public override void Setup()
	{
		res = terrain.terrainData.heightmapResolution;
		src = (dst = new byte[4 * res * res]);
		if (!(DistanceTexture != null))
		{
			return;
		}
		if (DistanceTexture.width == DistanceTexture.height && DistanceTexture.width == res)
		{
			Color32[] pixels = DistanceTexture.GetPixels32();
			int i = 0;
			int num = 0;
			for (; i < res; i++)
			{
				int num2 = 0;
				while (num2 < res)
				{
					SetDistance(num2, i, BitUtility.DecodeVector2i(pixels[num]));
					num2++;
					num++;
				}
			}
		}
		else
		{
			Debug.LogError("Invalid distance texture: " + DistanceTexture.name, DistanceTexture);
		}
	}

	public void GenerateTextures()
	{
		DistanceTexture = new Texture2D(res, res, TextureFormat.RGBA32, mipChain: true, linear: true);
		DistanceTexture.name = "DistanceTexture";
		DistanceTexture.wrapMode = TextureWrapMode.Clamp;
		Color32[] cols = new Color32[res * res];
		Parallel.For(0, res, delegate(int z)
		{
			for (int i = 0; i < res; i++)
			{
				cols[z * res + i] = BitUtility.EncodeVector2i(GetDistance(i, z));
			}
		});
		DistanceTexture.SetPixels32(cols);
	}

	public void ApplyTextures()
	{
		DistanceTexture.Apply(updateMipmaps: true, makeNoLongerReadable: true);
	}

	public Vector2i GetDistance(Vector3 worldPos)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetDistance(normX, normZ);
	}

	public Vector2i GetDistance(float normX, float normZ)
	{
		int num = res - 1;
		int x = Mathf.Clamp(Mathf.RoundToInt(normX * (float)num), 0, num);
		int z = Mathf.Clamp(Mathf.RoundToInt(normZ * (float)num), 0, num);
		return GetDistance(x, z);
	}

	public Vector2i GetDistance(int x, int z)
	{
		byte[] array = src;
		_ = res;
		byte b = array[(0 + z) * res + x];
		byte b2 = src[(res + z) * res + x];
		byte b3 = src[(2 * res + z) * res + x];
		byte b4 = src[(3 * res + z) * res + x];
		if (b == byte.MaxValue && b2 == byte.MaxValue && b3 == byte.MaxValue && b4 == byte.MaxValue)
		{
			return new Vector2i(256, 256);
		}
		return new Vector2i(b - b2, b3 - b4);
	}

	public void SetDistance(int x, int z, Vector2i v)
	{
		byte[] array = dst;
		_ = res;
		array[(0 + z) * res + x] = (byte)Mathf.Clamp(v.x, 0, 255);
		dst[(res + z) * res + x] = (byte)Mathf.Clamp(-v.x, 0, 255);
		dst[(2 * res + z) * res + x] = (byte)Mathf.Clamp(v.y, 0, 255);
		dst[(3 * res + z) * res + x] = (byte)Mathf.Clamp(-v.y, 0, 255);
	}
}
