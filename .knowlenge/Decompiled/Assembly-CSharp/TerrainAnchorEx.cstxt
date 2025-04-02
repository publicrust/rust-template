using UnityEngine;

public static class TerrainAnchorEx
{
	public static bool ApplyTerrainAnchors(this Transform transform, TerrainAnchor[] anchors, ref Vector3 pos, Quaternion rot, Vector3 scale, SpawnFilter filter = null)
	{
		return transform.ApplyTerrainAnchors(anchors, ref pos, rot, scale, TerrainAnchorMode.MinimizeError, filter);
	}

	public static bool ApplyTerrainAnchors(this Transform transform, TerrainAnchor[] anchors, ref Vector3 pos, Quaternion rot, Vector3 scale, TerrainAnchorMode mode, SpawnFilter filter = null)
	{
		if (anchors.Length == 0)
		{
			return true;
		}
		float num = 0f;
		float num2 = float.MinValue;
		float num3 = float.MaxValue;
		foreach (TerrainAnchor terrainAnchor in anchors)
		{
			Vector3 vector = Vector3.Scale(terrainAnchor.worldPosition, scale);
			vector = rot * vector;
			Vector3 vector2 = pos + vector;
			if (filter != null && filter.GetFactor(vector2) == 0f)
			{
				return false;
			}
			terrainAnchor.Apply(out var height, out var min, out var max, vector2, scale, rot);
			num += height - vector.y;
			num2 = Mathf.Max(num2, min - vector.y);
			num3 = Mathf.Min(num3, max - vector.y);
			if (num3 < num2)
			{
				return false;
			}
		}
		if (num3 > 1f && num2 < 1f)
		{
			num2 = 1f;
		}
		switch (mode)
		{
		case TerrainAnchorMode.MinimizeError:
			pos.y = Mathf.Clamp(num / (float)anchors.Length, num2, num3);
			break;
		case TerrainAnchorMode.MinimizeMovement:
			pos.y = Mathf.Clamp(pos.y, num2, num3);
			break;
		default:
			pos.y = num3;
			break;
		}
		return true;
	}

	public static void ApplyTerrainAnchors(this Transform transform, TerrainAnchor[] anchors)
	{
		Vector3 pos = transform.position;
		transform.ApplyTerrainAnchors(anchors, ref pos, transform.rotation, transform.lossyScale);
		transform.position = pos;
	}
}
