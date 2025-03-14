using UnityEngine;

public class BurstClothCollider : MonoBehaviour, IClientComponent
{
	public float Height;

	public float Radius;

	public void GetParams(out Vector3 pointA, out Vector3 pointB, out Vector3 up, out float halfHeight)
	{
		Vector3 position = base.transform.position;
		halfHeight = Height / 2f;
		up = base.transform.rotation * Vector3.up;
		pointA = position + up * halfHeight;
		pointB = position - up * halfHeight;
	}
}
