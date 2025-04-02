using UnityEngine;

public static class TerrainModifierEx
{
	public static void ApplyTerrainModifiers(this Transform transform, TerrainModifier[] modifiers, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		foreach (TerrainModifier obj in modifiers)
		{
			Vector3 val = Vector3.Scale(obj.worldPosition, scale);
			Vector3 pos2 = pos + rot * val;
			float y = scale.y;
			obj.Apply(pos2, y);
		}
	}

	public static void ApplyTerrainModifiers(this Transform transform, TerrainModifier[] modifiers)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		transform.ApplyTerrainModifiers(modifiers, transform.position, transform.rotation, transform.lossyScale);
	}
}
