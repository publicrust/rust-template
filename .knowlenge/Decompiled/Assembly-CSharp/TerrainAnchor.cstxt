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
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
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
