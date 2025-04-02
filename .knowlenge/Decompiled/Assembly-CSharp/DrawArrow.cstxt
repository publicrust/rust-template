using UnityEngine;

public class DrawArrow : MonoBehaviour
{
	public Color color = new Color(1f, 1f, 1f, 1f);

	public float length = 0.2f;

	public float arrowLength = 0.02f;

	private void OnDrawGizmos()
	{
		Vector3 forward = base.transform.forward;
		Vector3 up = Camera.current.transform.up;
		Vector3 position = base.transform.position;
		Vector3 vector = base.transform.position + forward * length;
		Gizmos.color = color;
		Gizmos.DrawLine(position, vector);
		Gizmos.DrawLine(vector, vector + up * arrowLength - forward * arrowLength);
		Gizmos.DrawLine(vector, vector - up * arrowLength - forward * arrowLength);
		Gizmos.DrawLine(vector + up * arrowLength - forward * arrowLength, vector - up * arrowLength - forward * arrowLength);
	}
}
