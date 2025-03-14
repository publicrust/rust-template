using UnityEngine;

public class PathSpeedZone : MonoBehaviour, IAIPathSpeedZone
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
}
