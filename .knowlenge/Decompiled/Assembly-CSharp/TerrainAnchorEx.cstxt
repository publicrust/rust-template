using UnityEngine;

public static class TerrainAnchorEx
{
	public static bool ApplyTerrainAnchors(this Transform transform, TerrainAnchor[] anchors, ref Vector3 pos, Quaternion rot, Vector3 scale, SpawnFilter filter = null)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return transform.ApplyTerrainAnchors(anchors, ref pos, rot, scale, TerrainAnchorMode.MinimizeError, filter);
	}

	public static bool ApplyTerrainAnchors(this Transform transform, TerrainAnchor[] anchors, ref Vector3 pos, Quaternion rot, Vector3 scale, TerrainAnchorMode mode, SpawnFilter filter = null)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if (anchors.Length == 0)
		{
			return true;
		}
		float num = 0f;
		float num2 = float.MinValue;
		float num3 = float.MaxValue;
		foreach (TerrainAnchor terrainAnchor in anchors)
		{
			Vector3 val = Vector3.Scale(terrainAnchor.worldPosition, scale);
			val = rot * val;
			Vector3 val2 = pos + val;
			if (filter != null && filter.GetFactor(val2) == 0f)
			{
				return false;
			}
			terrainAnchor.Apply(out var height, out var min, out var max, val2, scale, rot);
			num += height - val.y;
			num2 = Mathf.Max(num2, min - val.y);
			num3 = Mathf.Min(num3, max - val.y);
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 pos = transform.position;
		transform.ApplyTerrainAnchors(anchors, ref pos, transform.rotation, transform.lossyScale);
		transform.position = pos;
	}
}
