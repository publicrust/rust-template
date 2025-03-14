using UnityEngine;

public class ExplosionsBillboard : MonoBehaviour
{
	public Camera Camera;

	public bool Active = true;

	public bool AutoInitCamera = true;

	private GameObject myContainer;

	private Transform t;

	private Transform camT;

	private Transform contT;

	private void Awake()
	{
		if (AutoInitCamera)
		{
			Camera = Camera.main;
			Active = true;
		}
		t = base.transform;
		Vector3 localScale = t.parent.transform.localScale;
		localScale.z = localScale.x;
		t.parent.transform.localScale = localScale;
		camT = Camera.transform;
		Transform parent = t.parent;
		myContainer = new GameObject
		{
			name = "Billboard_" + t.gameObject.name
		};
		contT = myContainer.transform;
		contT.position = t.position;
		t.parent = myContainer.transform;
		contT.parent = parent;
	}

	private void Update()
	{
		if (Active)
		{
			contT.LookAt(contT.position + camT.rotation * Vector3.back, camT.rotation * Vector3.up);
		}
	}
}
