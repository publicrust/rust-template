using UnityEngine;

public class AimConeUtil
{
	public static Vector3 GetModifiedAimConeDirection(float aimCone, Vector3 inputVec, bool anywhereInside = true)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Quaternion val = Quaternion.LookRotation(inputVec);
		aimCone = Mathf.Max(aimCone, 0f);
		Vector2 val2;
		if (!anywhereInside)
		{
			Vector2 insideUnitCircle = Random.insideUnitCircle;
			val2 = ((Vector2)(ref insideUnitCircle)).normalized;
		}
		else
		{
			val2 = Random.insideUnitCircle;
		}
		Vector2 val3 = val2;
		return val * Quaternion.Euler(val3.x * aimCone * 0.5f, val3.y * aimCone * 0.5f, 0f) * Vector3.forward;
	}

	public static Quaternion GetAimConeQuat(float aimCone)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Vector3 insideUnitSphere = Random.insideUnitSphere;
		return Quaternion.Euler(insideUnitSphere.x * aimCone * 0.5f, insideUnitSphere.y * aimCone * 0.5f, 0f);
	}
}
