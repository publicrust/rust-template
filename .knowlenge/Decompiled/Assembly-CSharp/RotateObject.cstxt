using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float rotateSpeed_X = 1f;

	public float rotateSpeed_Y = 1f;

	public float rotateSpeed_Z = 1f;

	public bool localSpace;

	public bool randomizeRotation;

	public Vector3 randomVariationRange = new Vector3(0.5f, 0.5f, 0.5f);

	private void Start()
	{
		if (randomizeRotation)
		{
			rotateSpeed_Y = Random.Range(0f - Mathf.Abs(rotateSpeed_X), Mathf.Abs(rotateSpeed_X));
			rotateSpeed_Z = Random.Range(0f - Mathf.Abs(rotateSpeed_X), Mathf.Abs(rotateSpeed_X));
		}
		rotateSpeed_X *= 1f + Random.Range(0f - randomVariationRange.x, randomVariationRange.x);
		rotateSpeed_Y *= 1f + Random.Range(0f - randomVariationRange.y, randomVariationRange.y);
		rotateSpeed_Z *= 1f + Random.Range(0f - randomVariationRange.z, randomVariationRange.z);
	}

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
