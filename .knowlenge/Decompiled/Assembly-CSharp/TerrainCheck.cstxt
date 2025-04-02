using System;
using UnityEngine;

public class TerrainCheck : PrefabAttribute
{
	public bool Rotate = true;

	public float Extents = 1f;

	public bool Check(Vector3 pos)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
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
