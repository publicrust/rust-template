using UnityEngine;

public static class WaterCheckEx
{
	public static bool ApplyWaterChecks(this Transform transform, WaterCheck[] anchors, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (anchors.Length == 0)
		{
			return true;
		}
		foreach (WaterCheck obj in anchors)
		{
			Vector3 val = Vector3.Scale(obj.worldPosition, scale);
			if (obj.Rotate)
			{
				val = rot * val;
			}
			Vector3 pos2 = pos + val;
			if (!obj.Check(pos2))
			{
				return false;
			}
		}
		return true;
	}
}
