using UnityEngine;

public static class LODUtil
{
	public const float DefaultDistance = 1000f;

	public const float FarCameraDistance = 30f;

	public static float GetDistance(Transform transform, LODDistanceMode mode = LODDistanceMode.XYZ)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return GetDistance(transform.position, mode);
	}

	public static float GetDistance(Vector3 meshPos, LODDistanceMode mode = LODDistanceMode.XYZ)
	{
		return 1000f;
	}

	private static float GetDistanceInternal(Vector3 cameraPos, Vector3 worldPos, LODDistanceMode mode)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		return mode switch
		{
			LODDistanceMode.XYZ => Vector3.Distance(cameraPos, worldPos), 
			LODDistanceMode.XZ => Vector3Ex.Distance2D(cameraPos, worldPos), 
			LODDistanceMode.Y => Mathf.Abs(cameraPos.y - worldPos.y), 
			_ => 1000f, 
		};
	}

	public static float VerifyDistance(float distance)
	{
		return Mathf.Min(500f, distance);
	}

	public static LODEnvironmentMode DetermineEnvironmentMode(Transform transform)
	{
		if (((Component)transform).CompareTag("OnlyVisibleUnderground") || ((Component)transform.root).CompareTag("OnlyVisibleUnderground"))
		{
			return LODEnvironmentMode.Underground;
		}
		return LODEnvironmentMode.Default;
	}
}
