using UnityEngine;

[ExecuteInEditMode]
public class LookAt : MonoBehaviour, IClientComponent
{
	public Transform target;

	private void Update()
	{
		if (!(target == null))
		{
			base.transform.LookAt(target);
		}
	}
}
