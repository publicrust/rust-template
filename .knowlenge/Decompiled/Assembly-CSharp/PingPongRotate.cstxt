using UnityEngine;

public class PingPongRotate : MonoBehaviour
{
	public Vector3 rotationSpeed = Vector3.zero;

	public Vector3 offset = Vector3.zero;

	public Vector3 rotationAmount = Vector3.zero;

	private void Update()
	{
		Quaternion identity = Quaternion.identity;
		for (int i = 0; i < 3; i++)
		{
			identity *= GetRotation(i);
		}
		base.transform.rotation = identity;
	}

	public Quaternion GetRotation(int index)
	{
		Vector3 axis = Vector3.zero;
		switch (index)
		{
		case 0:
			axis = Vector3.right;
			break;
		case 1:
			axis = Vector3.up;
			break;
		case 2:
			axis = Vector3.forward;
			break;
		}
		return Quaternion.AngleAxis(Mathf.Sin((offset[index] + Time.time) * rotationSpeed[index]) * rotationAmount[index], axis);
	}
}
