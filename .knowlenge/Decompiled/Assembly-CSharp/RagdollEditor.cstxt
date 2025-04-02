using UnityEngine;

public class RagdollEditor : SingletonComponent<RagdollEditor>
{
	private Vector3 view;

	private Rigidbody grabbedRigid;

	private Vector3 grabPos;

	private Vector3 grabOffset;

	private void OnGUI()
	{
		GUI.Box(new Rect((float)Screen.width * 0.5f - 2f, (float)Screen.height * 0.5f - 2f, 4f, 4f), "");
	}

	protected override void Awake()
	{
		base.Awake();
	}

	private void Update()
	{
		Camera.main.fieldOfView = 75f;
		if (Input.GetKey(KeyCode.Mouse1))
		{
			view.y += Input.GetAxisRaw("Mouse X") * 3f;
			view.x -= Input.GetAxisRaw("Mouse Y") * 3f;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		Camera.main.transform.rotation = Quaternion.Euler(view);
		Vector3 zero = Vector3.zero;
		if (Input.GetKey(KeyCode.W))
		{
			zero += Vector3.forward;
		}
		if (Input.GetKey(KeyCode.S))
		{
			zero += Vector3.back;
		}
		if (Input.GetKey(KeyCode.A))
		{
			zero += Vector3.left;
		}
		if (Input.GetKey(KeyCode.D))
		{
			zero += Vector3.right;
		}
		Camera.main.transform.position += base.transform.rotation * zero * 0.05f;
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			StartGrab();
		}
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			StopGrab();
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			UpdateGrab();
		}
	}

	private void StartGrab()
	{
		if (Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, 100f))
		{
			grabbedRigid = hitInfo.collider.GetComponent<Rigidbody>();
			if (!(grabbedRigid == null))
			{
				grabPos = grabbedRigid.transform.worldToLocalMatrix.MultiplyPoint(hitInfo.point);
				grabOffset = base.transform.worldToLocalMatrix.MultiplyPoint(hitInfo.point);
			}
		}
	}

	private void UpdateGrab()
	{
		if (!(grabbedRigid == null))
		{
			Vector3 vector = base.transform.TransformPoint(grabOffset);
			Vector3 vector2 = grabbedRigid.transform.TransformPoint(grabPos);
			Vector3 vector3 = vector - vector2;
			grabbedRigid.AddForceAtPosition(vector3 * 100f, vector2, ForceMode.Acceleration);
		}
	}

	private void StopGrab()
	{
		grabbedRigid = null;
	}
}
