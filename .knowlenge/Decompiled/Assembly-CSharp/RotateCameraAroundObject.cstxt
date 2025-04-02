using UnityEngine;

public class RotateCameraAroundObject : MonoBehaviour
{
	public GameObject m_goObjectToRotateAround;

	public float m_flRotateSpeed = 10f;

	private void FixedUpdate()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)m_goObjectToRotateAround != (Object)null)
		{
			((Component)this).transform.LookAt(m_goObjectToRotateAround.transform.position + Vector3.up * 0.75f);
			((Component)this).transform.Translate(Vector3.right * m_flRotateSpeed * Time.deltaTime);
		}
	}
}
