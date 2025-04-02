using UnityEngine;

public class FollowCamera : MonoBehaviour, IClientComponent
{
	private void LateUpdate()
	{
		if (!(MainCamera.mainCamera == null))
		{
			base.transform.position = MainCamera.position;
		}
	}
}
