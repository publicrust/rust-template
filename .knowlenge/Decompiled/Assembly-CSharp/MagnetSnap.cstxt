using UnityEngine;

public class MagnetSnap
{
	private Transform snapLocation;

	private Vector3 prevSnapLocation;

	public MagnetSnap(Transform snapLocation)
	{
		this.snapLocation = snapLocation;
		prevSnapLocation = snapLocation.position;
	}

	public void FixedUpdate(Transform target)
	{
		PositionTarget(target);
		if (snapLocation.hasChanged)
		{
			prevSnapLocation = snapLocation.position;
			snapLocation.hasChanged = false;
		}
	}

	public void PositionTarget(Transform target)
	{
		if (!(target == null))
		{
			Transform transform = target.transform;
			Quaternion rotation = snapLocation.rotation;
			if (Vector3.Angle(transform.forward, snapLocation.forward) > 90f)
			{
				rotation *= Quaternion.Euler(0f, 180f, 0f);
			}
			if (transform.position != snapLocation.position)
			{
				transform.position += snapLocation.position - prevSnapLocation;
				transform.position = Vector3.MoveTowards(transform.position, snapLocation.position, 1f * Time.fixedDeltaTime);
			}
			if (transform.rotation != rotation)
			{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 40f * Time.fixedDeltaTime);
			}
		}
	}
}
