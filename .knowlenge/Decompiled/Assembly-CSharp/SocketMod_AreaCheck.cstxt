using UnityEngine;

public class SocketMod_AreaCheck : SocketMod
{
	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one * 0.1f);

	public LayerMask layerMask;

	public bool wantsInside = true;

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		bool flag = true;
		if (!wantsInside)
		{
			flag = !flag;
		}
		Gizmos.color = (flag ? Color.green.WithAlpha(0.5f) : Color.red.WithAlpha(0.5f));
		Gizmos.DrawCube(bounds.center, bounds.size);
	}

	public static bool IsInArea(Vector3 position, Quaternion rotation, Bounds bounds, LayerMask layerMask, BaseEntity entity = null)
	{
		return GamePhysics.CheckOBBAndEntity(new OBB(position, rotation, bounds), layerMask.value, QueryTriggerInteraction.UseGlobal, entity);
	}

	public bool DoCheck(Vector3 position, Quaternion rotation, BaseEntity entity = null)
	{
		Vector3 position2 = position + rotation * worldPosition;
		Quaternion rotation2 = rotation * worldRotation;
		return IsInArea(position2, rotation2, bounds, layerMask, entity) == wantsInside;
	}

	public override bool DoCheck(Construction.Placement place)
	{
		if (DoCheck(place.position, place.rotation))
		{
			return true;
		}
		Construction.lastPlacementError = "Failed Check: IsInArea (" + hierachyName + ")";
		return false;
	}
}
