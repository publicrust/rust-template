using System;
using UnityEngine;

public class TerrainDistanceMap : TerrainMap<byte>
{
	public Texture2D DistanceTexture;

	public override void Setup()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		res = terrain.terrainData.heightmapResolution;
		src = (dst = new byte[4 * res * res]);
		if (!((Object)(object)DistanceTexture != (Object)null))
		{
			return;
		}
		if (((Texture)DistanceTexture).width == ((Texture)DistanceTexture).height && ((Texture)DistanceTexture).width == res)
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
			Debug.LogError((object)("Invalid distance texture: " + ((Object)DistanceTexture).name), (Object)(object)DistanceTexture);
		}
	}

	public void GenerateTextures()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		DistanceTexture = new Texture2D(res, res, (TextureFormat)4, true, true);
		((Object)DistanceTexture).name = "DistanceTexture";
		((Texture)DistanceTexture).wrapMode = (TextureWrapMode)1;
		Color32[] cols = (Color32[])(object)new Color32[res * res];
		Parallel.For(0, res, (Action<int>)delegate(int z)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			for (int i = 0; i < res; i++)
			{
				cols[z * res + i] = BitUtility.EncodeVector2i(GetDistance(i, z));
			}
		});
		DistanceTexture.SetPixels32(cols);
	}

	public void ApplyTextures()
	{
		DistanceTexture.Apply(true, true);
	}

	public Vector2i GetDistance(Vector3 worldPos)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetDistance(normX, normZ);
	}

	public Vector2i GetDistance(float normX, float normZ)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		int num = res - 1;
		int x = Mathf.Clamp(Mathf.RoundToInt(normX * (float)num), 0, num);
		int z = Mathf.Clamp(Mathf.RoundToInt(normZ * (float)num), 0, num);
		return GetDistance(x, z);
	}

	public Vector2i GetDistance(int x, int z)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		byte[] array = dst;
		_ = res;
		array[(0 + z) * res + x] = (byte)Mathf.Clamp(v.x, 0, 255);
		dst[(res + z) * res + x] = (byte)Mathf.Clamp(-v.x, 0, 255);
		dst[(2 * res + z) * res + x] = (byte)Mathf.Clamp(v.y, 0, 255);
		dst[(3 * res + z) * res + x] = (byte)Mathf.Clamp(-v.y, 0, 255);
	}
}
