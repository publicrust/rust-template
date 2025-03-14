using UnityEngine;

public class AimConeUtil
{
	public static Vector3 GetModifiedAimConeDirection(float aimCone, Vector3 inputVec, bool anywhereInside = true)
	{
		Quaternion quaternion = Quaternion.LookRotation(inputVec);
		Vector2 vector = (anywhereInside ? Random.insideUnitCircle : Random.insideUnitCircle.normalized);
		return quaternion * Quaternion.Euler(vector.x * aimCone * 0.5f, vector.y * aimCone * 0.5f, 0f) * Vector3.forward;
	}

	public static Quaternion GetAimConeQuat(float aimCone)
	{
		Vector3 insideUnitSphere = Random.insideUnitSphere;
		return Quaternion.Euler(insideUnitSphere.x * aimCone * 0.5f, insideUnitSphere.y * aimCone * 0.5f, 0f);
	}
}
