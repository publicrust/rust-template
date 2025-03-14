using UnityEngine;

public static class TerrainPlacementEx
{
	public static void ApplyTerrainPlacements(this Transform transform, TerrainPlacement[] placements, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		if (placements.Length != 0)
		{
			for (int i = 0; i < placements.Length; i++)
			{
				TerrainPlacement terrainPlacement = placements[i];
				Vector3 pos2 = pos + rot * Vector3.Scale(terrainPlacement.worldPosition, scale);
				Quaternion q = rot * terrainPlacement.worldRotation;
				Matrix4x4 localToWorld = Matrix4x4.TRS(pos2, q, scale);
				Matrix4x4 inverse = localToWorld.inverse;
				placements[i].Apply(localToWorld, inverse);
			}
		}
	}

	public static void ApplyTerrainPlacements(this Transform transform, TerrainPlacement[] placements)
	{
		transform.ApplyTerrainPlacements(placements, transform.position, transform.rotation, transform.lossyScale);
	}
}
