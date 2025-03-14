using UnityEngine;

public static class TerrainPlacementEx
{
	public static void ApplyTerrainPlacements(this Transform transform, TerrainPlacement[] placements, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		if (placements.Length != 0)
		{
			Matrix4x4 localToWorld = Matrix4x4.TRS(pos, rot, scale);
			Matrix4x4 inverse = localToWorld.inverse;
			for (int i = 0; i < placements.Length; i++)
			{
				placements[i].Apply(localToWorld, inverse);
			}
		}
	}

	public static void ApplyTerrainPlacements(this Transform transform, TerrainPlacement[] placements)
	{
		transform.ApplyTerrainPlacements(placements, transform.position, transform.rotation, transform.lossyScale);
	}
}
