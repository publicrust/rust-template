using UnityEngine;

public class SocketMod_AngleCheck : SocketMod
{
	public bool wantsAngle = true;

	public Vector3 worldNormal = Vector3.up;

	public float withinDegrees = 45f;

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.yellow;
		Gizmos.DrawFrustum(Vector3.zero, withinDegrees, 1f, 0f, 1f);
	}

	public override bool DoCheck(Construction.Placement place)
	{
		if (worldNormal.DotDegrees(place.rotation * Vector3.up) < withinDegrees)
		{
			return true;
		}
		Construction.lastPlacementError = "Failed Check: AngleCheck (" + hierachyName + ")";
		return false;
	}
}
