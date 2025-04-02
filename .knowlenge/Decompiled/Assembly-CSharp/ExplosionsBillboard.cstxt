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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		if (AutoInitCamera)
		{
			Camera = Camera.main;
			Active = true;
		}
		t = ((Component)this).transform;
		Vector3 localScale = ((Component)t.parent).transform.localScale;
		localScale.z = localScale.x;
		((Component)t.parent).transform.localScale = localScale;
		camT = ((Component)Camera).transform;
		Transform parent = t.parent;
		myContainer = new GameObject
		{
			name = "Billboard_" + ((Object)((Component)t).gameObject).name
		};
		contT = myContainer.transform;
		contT.position = t.position;
		t.parent = myContainer.transform;
		contT.parent = parent;
	}

	private void Update()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (Active)
		{
			contT.LookAt(contT.position + camT.rotation * Vector3.back, camT.rotation * Vector3.up);
		}
	}
}
