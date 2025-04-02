using UnityEngine;

public class Socket_Free : Socket_Base
{
	public Vector3 idealPlacementNormal = Vector3.up;

	public bool useTargetNormal = true;

	public bool blendAimAngle = true;

	public override bool TestTarget(Construction.Target target)
	{
		return target.onTerrain;
	}

	public override Construction.Placement DoPlacement(Construction.Target target)
	{
		Quaternion identity = Quaternion.identity;
		if (useTargetNormal)
		{
			Vector3 normal = target.normal;
			Vector3 upwards = idealPlacementNormal;
			if (blendAimAngle || Mathf.Abs(target.normal.y) > 0.98f)
			{
				Vector3 normalized = (target.position - target.ray.origin).normalized;
				upwards = Vector3.Lerp(t: Mathf.Abs(Vector3.Dot(normalized, normal)), a: normalized, b: idealPlacementNormal);
			}
			identity = Quaternion.LookRotation(normal, upwards) * Quaternion.Inverse(rotation) * Quaternion.Euler(target.rotation);
		}
		else
		{
			Vector3 normalized2 = (target.position - target.ray.origin).normalized;
			normalized2.y = 0f;
			identity = Quaternion.LookRotation(normalized2, idealPlacementNormal) * Quaternion.Euler(target.rotation);
		}
		Vector3 vector = target.position;
		vector -= identity * position;
		Construction.Placement result = new Construction.Placement(target);
		result.rotation = identity;
		result.position = vector;
		return result;
	}
}
