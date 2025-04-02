using UnityEngine;

public static class EnvironmentVolumeCheckEx
{
	public static bool ApplyEnvironmentVolumeChecks(this Transform transform, EnvironmentVolumeCheck[] anchors, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		if (anchors.Length == 0)
		{
			return true;
		}
		foreach (EnvironmentVolumeCheck environmentVolumeCheck in anchors)
		{
			Vector3 a = environmentVolumeCheck.worldPosition + environmentVolumeCheck.worldRotation * environmentVolumeCheck.Center;
			Vector3 vector = rot * Vector3.Scale(a, scale);
			OBB obb = new OBB(pos + vector, Vector3.Scale(environmentVolumeCheck.Size, scale), rot);
			if (!environmentVolumeCheck.Check(obb))
			{
				return false;
			}
		}
		return true;
	}
}
