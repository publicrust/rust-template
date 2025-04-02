using System;
using UnityEngine;

public class TerrainPlacementMap : TerrainMap<bool>
{
	private bool isEnabled;

	public override void Setup()
	{
		res = terrain.terrainData.alphamapResolution;
		src = (dst = new bool[res * res]);
		Enable();
	}

	public override void PostSetup()
	{
		res = 0;
		src = null;
		Disable();
	}

	public void Enable()
	{
		isEnabled = true;
	}

	public void Disable()
	{
		isEnabled = false;
	}

	public void Reset()
	{
		for (int i = 0; i < res; i++)
		{
			for (int j = 0; j < res; j++)
			{
				dst[i * res + j] = false;
			}
		}
	}

	public bool GetBlocked(Vector3 worldPos)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetBlocked(normX, normZ);
	}

	public bool GetBlocked(float normX, float normZ)
	{
		int x = Index(normX);
		int z = Index(normZ);
		return GetBlocked(x, z);
	}

	public bool GetBlocked(int x, int z)
	{
		if (!isEnabled || res <= 0)
		{
			return false;
		}
		return src[z * res + x];
	}

	public void SetBlocked(Vector3 worldPos)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		SetBlocked(normX, normZ);
	}

	public void SetBlocked(float normX, float normZ)
	{
		int x = Index(normX);
		int z = Index(normZ);
		SetBlocked(x, z);
	}

	public void SetBlocked(int x, int z)
	{
		dst[z * res + x] = true;
	}

	public bool GetBlocked(Vector3 worldPos, float radius)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		return GetBlocked(normX, normZ, radius);
	}

	public bool GetBlocked(float normX, float normZ, float radius)
	{
		float num = TerrainMeta.OneOverSize.x * radius;
		int num2 = Index(normX - num);
		int num3 = Index(normX + num);
		int num4 = Index(normZ - num);
		int num5 = Index(normZ + num);
		for (int i = num4; i <= num5; i++)
		{
			for (int j = num2; j <= num3; j++)
			{
				if (src[i * res + j])
				{
					return true;
				}
			}
		}
		return false;
	}

	public void SetBlocked(Vector3 worldPos, float radius, float fade = 0f)
	{
		float normX = TerrainMeta.NormalizeX(worldPos.x);
		float normZ = TerrainMeta.NormalizeZ(worldPos.z);
		SetBlocked(normX, normZ, radius, fade);
	}

	public void SetBlocked(float normX, float normZ, float radius, float fade = 0f)
	{
		Action<int, int, float> action = delegate(int x, int z, float lerp)
		{
			if ((double)lerp > 0.5)
			{
				dst[z * res + x] = true;
			}
		};
		ApplyFilter(normX, normZ, radius, fade, action);
	}
}
