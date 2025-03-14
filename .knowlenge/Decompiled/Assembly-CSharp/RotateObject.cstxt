using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float rotateSpeed_X = 1f;

	public float rotateSpeed_Y = 1f;

	public float rotateSpeed_Z = 1f;

	public bool localSpace;

	protected void Update()
	{
		if (localSpace)
		{
			Vector3 vector = new Vector3(rotateSpeed_X, rotateSpeed_Y, rotateSpeed_Z);
			base.transform.Rotate(vector * Time.deltaTime, Space.Self);
			return;
		}
		if (rotateSpeed_X != 0f)
		{
			base.transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed_X);
		}
		if (rotateSpeed_Y != 0f)
		{
			base.transform.Rotate(base.transform.forward, Time.deltaTime * rotateSpeed_Y);
		}
		if (rotateSpeed_Z != 0f)
		{
			base.transform.Rotate(base.transform.right, Time.deltaTime * rotateSpeed_Z);
		}
	}
}
