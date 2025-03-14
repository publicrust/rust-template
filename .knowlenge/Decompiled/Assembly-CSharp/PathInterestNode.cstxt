using UnityEngine;

public class PathInterestNode : MonoBehaviour, IAIPathInterestNode
{
	public Vector3 Position => base.transform.position;

	public float NextVisitTime { get; set; }

	public void OnDrawGizmos()
	{
		Gizmos.color = new Color(0f, 1f, 1f, 0.5f);
		Gizmos.DrawSphere(base.transform.position, 0.5f);
	}
}
