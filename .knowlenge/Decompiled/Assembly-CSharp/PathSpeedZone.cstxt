using UnityEngine;

public class PathSpeedZone : MonoBehaviour
{
	public Bounds bounds;

	public OBB obbBounds;

	public float maxVelocityPerSec = 5f;

	public OBB WorldSpaceBounds()
	{
		return new OBB(base.transform.position, base.transform.lossyScale, base.transform.rotation, bounds);
	}

	public float GetMaxSpeed()
	{
		return maxVelocityPerSec;
	}

	public virtual void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = new Color(1f, 0.5f, 0f, 0.5f);
		Gizmos.DrawCube(bounds.center, bounds.size);
		Gizmos.color = new Color(1f, 0.7f, 0f, 1f);
		Gizmos.DrawWireCube(bounds.center, bounds.size);
	}
}
