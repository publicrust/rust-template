using UnityEngine;

public class PathInterestNode : MonoBehaviour, IAIPathInterestNode
{
	public Vector3 Position => ((Component)this).transform.position;

	public float NextVisitTime { get; set; }

	public void OnDrawGizmos()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.color = new Color(0f, 1f, 1f, 0.5f);
		Gizmos.DrawSphere(((Component)this).transform.position, 0.5f);
	}
}
