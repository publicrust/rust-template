using UnityEngine;

public static class TerrainPlacementEx
{
	public static void ApplyTerrainPlacements(this Transform transform, TerrainPlacement[] placements, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (placements.Length != 0)
		{
			for (int i = 0; i < placements.Length; i++)
			{
				TerrainPlacement terrainPlacement = placements[i];
				Vector3 val = pos + rot * Vector3.Scale(terrainPlacement.worldPosition, scale);
				Quaternion val2 = rot * terrainPlacement.worldRotation;
				Matrix4x4 localToWorld = Matrix4x4.TRS(val, val2, scale);
				Matrix4x4 inverse = ((Matrix4x4)(ref localToWorld)).inverse;
				placements[i].Apply(localToWorld, inverse);
			}
		}
	}

	public static void ApplyTerrainPlacements(this Transform transform, TerrainPlacement[] placements)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		transform.ApplyTerrainPlacements(placements, transform.position, transform.rotation, transform.lossyScale);
	}
}
