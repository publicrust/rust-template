using UnityEngine;

public class rottest : MonoBehaviour
{
	public Transform turretBase;

	public Vector3 aimDir;

	private void Start()
	{
	}

	private void Update()
	{
		aimDir = new Vector3(0f, 45f * Mathf.Sin(Time.time * 6f), 0f);
		UpdateAiming();
	}

	public void UpdateAiming()
	{
		if (!(aimDir == Vector3.zero))
		{
			Quaternion quaternion = Quaternion.Euler(0f, aimDir.y, 0f);
			if (base.transform.localRotation != quaternion)
			{
				base.transform.localRotation = Quaternion.Lerp(base.transform.localRotation, quaternion, Time.deltaTime * 8f);
			}
		}
	}
}
