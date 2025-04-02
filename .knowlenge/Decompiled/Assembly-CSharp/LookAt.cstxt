using UnityEngine;

[ExecuteInEditMode]
public class LookAt : MonoBehaviour, IClientComponent
{
	public Transform target;

	private void Update()
	{
		if (!((Object)(object)target == (Object)null))
		{
			((Component)this).transform.LookAt(target);
		}
	}
}
