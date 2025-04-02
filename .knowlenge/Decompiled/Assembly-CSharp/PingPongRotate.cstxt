using UnityEngine;

public class PingPongRotate : MonoBehaviour
{
	public Vector3 rotationSpeed = Vector3.zero;

	public Vector3 offset = Vector3.zero;

	public Vector3 rotationAmount = Vector3.zero;

	private void Update()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Quaternion val = Quaternion.identity;
		for (int i = 0; i < 3; i++)
		{
			val *= GetRotation(i);
		}
		((Component)this).transform.rotation = val;
	}

	public Quaternion GetRotation(int index)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Vector3.zero;
		switch (index)
		{
		case 0:
			val = Vector3.right;
			break;
		case 1:
			val = Vector3.up;
			break;
		case 2:
			val = Vector3.forward;
			break;
		}
		return Quaternion.AngleAxis(Mathf.Sin((((Vector3)(ref offset))[index] + Time.time) * ((Vector3)(ref rotationSpeed))[index]) * ((Vector3)(ref rotationAmount))[index], val);
	}
}
