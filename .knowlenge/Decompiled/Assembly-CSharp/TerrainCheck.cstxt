using System;
using UnityEngine;

public class TerrainCheck : PrefabAttribute
{
	public bool Rotate = true;

	public float Extents = 1f;

	public bool Check(Vector3 pos)
	{
		float extents = Extents;
		float height = TerrainMeta.HeightMap.GetHeight(pos);
		float num = pos.y - extents;
		float num2 = pos.y + extents;
		if (num > height)
		{
			return false;
		}
		if (num2 < height)
		{
			return false;
		}
		return true;
	}

	protected override Type GetIndexedType()
	{
		return typeof(TerrainCheck);
	}
}
