using UnityEngine;

public class AverageVelocity
{
	private Vector3 pos;

	private float time;

	private float lastEntry;

	private float averageSpeed;

	private Vector3 averageVelocity;

	public float Speed => averageSpeed;

	public Vector3 Average => averageVelocity;

	public void Record(Vector3 newPos)
	{
		float num = Time.time - time;
		if (!(num < 0.1f))
		{
			if (pos.sqrMagnitude > 0f)
			{
				Vector3 vector = newPos - pos;
				averageVelocity = vector * (1f / num);
				averageSpeed = averageVelocity.magnitude;
			}
			time = Time.time;
			pos = newPos;
		}
	}
}
