using UnityEngine;

public class ChippyMoveTest : MonoBehaviour
{
	public Vector3 heading = new Vector3(0f, 1f, 0f);

	public float speed = 0.2f;

	public float maxSpeed = 1f;

	private void FixedUpdate()
	{
		float num = ((Mathf.Abs(heading.magnitude) > 0f) ? 1f : 0f);
		speed = Mathf.MoveTowards(speed, maxSpeed * num, Time.fixedDeltaTime * ((num == 0f) ? 2f : 2f));
		Ray ray = new Ray(base.transform.position, new Vector3(heading.x, heading.y, 0f).normalized);
		if (!Physics.Raycast(ray, speed * Time.fixedDeltaTime, 16777216))
		{
			base.transform.position += ray.direction * Time.fixedDeltaTime * speed;
			if (Mathf.Abs(heading.magnitude) > 0f)
			{
				base.transform.rotation = QuaternionEx.LookRotationForcedUp(base.transform.forward, new Vector3(heading.x, heading.y, 0f).normalized);
			}
		}
	}
}
