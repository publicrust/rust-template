using System;
using UnityEngine;

public class TerrainAnchor : PrefabAttribute
{
	public float Extents = 1f;

	public float Offset;

	public float Radius;

	public float SlopeScale;

	public void Apply(out float height, out float min, out float max, Vector3 pos, Vector3 scale, Quaternion rotation)
	{
		float num = 1f + SlopeScale * Mathf.InverseLerp(0f, 90f, Vector3.Angle(Vector3.up, rotation * Vector3.up));
		float num2 = Extents * scale.y * num;
		float num3 = Offset * scale.y * num;
		height = TerrainMeta.HeightMap.GetHeight(pos);
		min = height - num3 - num2;
		max = height - num3 + num2;
		if (!(Radius > 0f))
		{
			return;
		}
		int num4 = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeX(pos.x - Radius));
		int num5 = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeX(pos.x + Radius));
		int num6 = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeZ(pos.z - Radius));
		int num7 = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeZ(pos.z + Radius));
		for (int i = num6; i <= num7; i++)
		{
			if (max < min)
			{
				break;
			}
			for (int j = num4; j <= num5; j++)
			{
				if (max < min)
				{
					break;
				}
				float height2 = TerrainMeta.HeightMap.GetHeight(j, i);
				min = Mathf.Max(min, height2 - num3 - num2);
				max = Mathf.Min(max, height2 - num3 + num2);
			}
		}
	}

	protected override Type GetIndexedType()
	{
		return typeof(TerrainAnchor);
	}
}
