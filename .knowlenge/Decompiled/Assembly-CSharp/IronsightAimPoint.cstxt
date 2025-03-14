using UnityEngine;

public class IronsightAimPoint : MonoBehaviour
{
	public Transform targetPoint;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Vector3 normalized = (targetPoint.position - base.transform.position).normalized;
		Gizmos.color = Color.red;
		DrawArrow(base.transform.position, base.transform.position + normalized * 0.1f, 0.1f);
		Gizmos.color = Color.cyan;
		DrawArrow(base.transform.position, targetPoint.position, 0.02f);
		Gizmos.color = Color.yellow;
		DrawArrow(targetPoint.position, targetPoint.position + normalized * 3f, 0.02f);
	}

	private void DrawArrow(Vector3 start, Vector3 end, float arrowLength)
	{
		Vector3 normalized = (end - start).normalized;
		Vector3 up = Camera.current.transform.up;
		Gizmos.DrawLine(start, end);
		Gizmos.DrawLine(end, end + up * arrowLength - normalized * arrowLength);
		Gizmos.DrawLine(end, end - up * arrowLength - normalized * arrowLength);
		Gizmos.DrawLine(end + up * arrowLength - normalized * arrowLength, end - up * arrowLength - normalized * arrowLength);
	}
}
