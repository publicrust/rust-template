using UnityEngine;

public static class WaterCheckEx
{
	public static bool ApplyWaterChecks(this Transform transform, WaterCheck[] anchors, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		if (anchors.Length == 0)
		{
			return true;
		}
		foreach (WaterCheck obj in anchors)
		{
			Vector3 vector = Vector3.Scale(obj.worldPosition, scale);
			if (obj.Rotate)
			{
				vector = rot * vector;
			}
			Vector3 pos2 = pos + vector;
			if (!obj.Check(pos2))
			{
				return false;
			}
		}
		return true;
	}
}
