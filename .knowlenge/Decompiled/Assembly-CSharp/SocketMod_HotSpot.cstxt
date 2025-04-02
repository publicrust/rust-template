using UnityEngine;

public class SocketMod_HotSpot : SocketMod
{
	public float spotSize = 0.1f;

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = new Color(1f, 1f, 0f, 0.5f);
		Gizmos.DrawSphere(Vector3.zero, spotSize);
	}

	public override void ModifyPlacement(ref Construction.Placement place)
	{
		Vector3 position = place.position + place.rotation * worldPosition;
		place.position = position;
	}
}
