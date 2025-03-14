using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float rotateSpeed_X = 1f;

	public float rotateSpeed_Y = 1f;

	public float rotateSpeed_Z = 1f;

	private void Update()
	{
		base.transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed_X);
		base.transform.Rotate(base.transform.forward, Time.deltaTime * rotateSpeed_Y);
		base.transform.Rotate(base.transform.right, Time.deltaTime * rotateSpeed_Z);
	}
}
