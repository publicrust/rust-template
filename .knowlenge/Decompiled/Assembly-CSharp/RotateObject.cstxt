using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float rotateSpeed_X = 1f;

	public float rotateSpeed_Y = 1f;

	public float rotateSpeed_Z = 1f;

	public bool localSpace;

	private Vector3 rotateVector;

	private void Awake()
	{
		rotateVector = new Vector3(rotateSpeed_X, rotateSpeed_Y, rotateSpeed_Z);
	}

	private void Update()
	{
		if (localSpace)
		{
			base.transform.Rotate(rotateVector * Time.deltaTime, Space.Self);
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
