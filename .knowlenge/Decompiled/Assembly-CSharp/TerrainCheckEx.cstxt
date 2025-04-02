using UnityEngine;

public static class TerrainCheckEx
{
	public static bool ApplyTerrainChecks(this Transform transform, TerrainCheck[] anchors, Vector3 pos, Quaternion rot, Vector3 scale, SpawnFilter filter = null)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (anchors.Length == 0)
		{
			return true;
		}
		foreach (TerrainCheck terrainCheck in anchors)
		{
			Vector3 val = Vector3.Scale(terrainCheck.worldPosition, scale);
			if (terrainCheck.Rotate)
			{
				val = rot * val;
			}
			Vector3 val2 = pos + val;
			if (filter != null && filter.GetFactor(val2) == 0f)
			{
				return false;
			}
			if (!terrainCheck.Check(val2))
			{
				return false;
			}
		}
		return true;
	}
}
