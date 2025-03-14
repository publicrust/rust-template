using UnityEngine;

public static class TerrainCheckEx
{
	public static bool ApplyTerrainChecks(this Transform transform, TerrainCheck[] anchors, Vector3 pos, Quaternion rot, Vector3 scale, SpawnFilter filter = null)
	{
		if (anchors.Length == 0)
		{
			return true;
		}
		foreach (TerrainCheck terrainCheck in anchors)
		{
			Vector3 vector = Vector3.Scale(terrainCheck.worldPosition, scale);
			if (terrainCheck.Rotate)
			{
				vector = rot * vector;
			}
			Vector3 vector2 = pos + vector;
			if (filter != null && filter.GetFactor(vector2) == 0f)
			{
				return false;
			}
			if (!terrainCheck.Check(vector2))
			{
				return false;
			}
		}
		return true;
	}
}
