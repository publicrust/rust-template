using UnityEngine;

public class PathSpeedZone : MonoBehaviour, IAIPathSpeedZone
{
	public Bounds bounds;

	public OBB obbBounds;

	public float maxVelocityPerSec = 5f;

	public OBB WorldSpaceBounds()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		return new OBB(((Component)this).transform.position, ((Component)this).transform.lossyScale, ((Component)this).transform.rotation, bounds);
	}

	public float GetMaxSpeed()
	{
		return maxVelocityPerSec;
	}
}
