using UnityEngine;

public class Socket_Free : Socket_Base
{
	public Vector3 idealPlacementNormal = Vector3.up;

	public bool useTargetNormal = true;

	public bool blendAimAngle = true;

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.green;
		Gizmos.DrawLine(Vector3.zero, Vector3.forward * 1f);
		GizmosUtil.DrawWireCircleZ(Vector3.forward * 0f, 0.2f);
		Gizmos.DrawIcon(base.transform.position, "light_circle_green.png", allowScaling: false);
	}

	public override bool TestTarget(Construction.Target target)
	{
		return target.onTerrain;
	}

	public override Construction.Placement DoPlacement(Construction.Target target)
	{
		Quaternion identity = Quaternion.identity;
		if (useTargetNormal)
		{
			if (blendAimAngle)
			{
				Vector3 normalized = (target.position - target.ray.origin).normalized;
				float t = Mathf.Abs(Vector3.Dot(normalized, target.normal));
				normalized = Vector3.Lerp(normalized, idealPlacementNormal, t);
				identity = Quaternion.LookRotation(target.normal, normalized) * Quaternion.Inverse(rotation) * Quaternion.Euler(target.rotation);
			}
			else
			{
				identity = Quaternion.LookRotation(target.normal);
			}
		}
		else
		{
			Vector3 normalized2 = (target.position - target.ray.origin).normalized;
			normalized2.y = 0f;
			identity = Quaternion.LookRotation(normalized2, idealPlacementNormal) * Quaternion.Euler(target.rotation);
		}
		Vector3 vector = target.position;
		vector -= identity * position;
		return new Construction.Placement
		{
			rotation = identity,
			position = vector
		};
	}
}
