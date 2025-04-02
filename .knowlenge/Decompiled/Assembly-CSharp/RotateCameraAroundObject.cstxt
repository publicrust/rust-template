using UnityEngine;

public class RotateCameraAroundObject : MonoBehaviour
{
	public GameObject m_goObjectToRotateAround;

	public float m_flRotateSpeed = 10f;

	private void FixedUpdate()
	{
		if (m_goObjectToRotateAround != null)
		{
			base.transform.LookAt(m_goObjectToRotateAround.transform.position + Vector3.up * 0.75f);
			base.transform.Translate(Vector3.right * m_flRotateSpeed * Time.deltaTime);
		}
	}
}
