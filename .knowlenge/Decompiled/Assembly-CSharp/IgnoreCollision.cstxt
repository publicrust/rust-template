using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
	public Collider collider;

	protected void OnTriggerEnter(Collider other)
	{
		Physics.IgnoreCollision(other, collider, ignore: true);
	}
}
