using UnityEngine;

public class RagdollEditor : SingletonComponent<RagdollEditor>
{
	private Vector3 view;

	private Rigidbody grabbedRigid;

	private Vector3 grabPos;

	private Vector3 grabOffset;

	private void OnGUI()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		GUI.Box(new Rect((float)Screen.width * 0.5f - 2f, (float)Screen.height * 0.5f - 2f, 4f, 4f), "");
	}

	protected override void Awake()
	{
		((SingletonComponent)this).Awake();
	}

	private void Update()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		Camera.main.fieldOfView = 75f;
		if (Input.GetKey((KeyCode)324))
		{
			view.y += Input.GetAxisRaw("Mouse X") * 3f;
			view.x -= Input.GetAxisRaw("Mouse Y") * 3f;
			Cursor.lockState = (CursorLockMode)1;
			Cursor.visible = false;
		}
		else
		{
			Cursor.lockState = (CursorLockMode)0;
			Cursor.visible = true;
		}
		((Component)Camera.main).transform.rotation = Quaternion.Euler(view);
		Vector3 val = Vector3.zero;
		if (Input.GetKey((KeyCode)119))
		{
			val += Vector3.forward;
		}
		if (Input.GetKey((KeyCode)115))
		{
			val += Vector3.back;
		}
		if (Input.GetKey((KeyCode)97))
		{
			val += Vector3.left;
		}
		if (Input.GetKey((KeyCode)100))
		{
			val += Vector3.right;
		}
		Transform transform = ((Component)Camera.main).transform;
		transform.position += ((Component)this).transform.rotation * val * 0.05f;
		if (Input.GetKeyDown((KeyCode)323))
		{
			StartGrab();
		}
		if (Input.GetKeyUp((KeyCode)323))
		{
			StopGrab();
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetKey((KeyCode)323))
		{
			UpdateGrab();
		}
	}

	private void StartGrab()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		RaycastHit val = default(RaycastHit);
		if (Physics.Raycast(((Component)this).transform.position, ((Component)this).transform.forward, ref val, 100f))
		{
			grabbedRigid = ((Component)((RaycastHit)(ref val)).collider).GetComponent<Rigidbody>();
			if (!((Object)(object)grabbedRigid == (Object)null))
			{
				Matrix4x4 worldToLocalMatrix = ((Component)grabbedRigid).transform.worldToLocalMatrix;
				grabPos = ((Matrix4x4)(ref worldToLocalMatrix)).MultiplyPoint(((RaycastHit)(ref val)).point);
				worldToLocalMatrix = ((Component)this).transform.worldToLocalMatrix;
				grabOffset = ((Matrix4x4)(ref worldToLocalMatrix)).MultiplyPoint(((RaycastHit)(ref val)).point);
			}
		}
	}

	private void UpdateGrab()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)grabbedRigid == (Object)null))
		{
			Vector3 val = ((Component)this).transform.TransformPoint(grabOffset);
			Vector3 val2 = ((Component)grabbedRigid).transform.TransformPoint(grabPos);
			Vector3 val3 = val - val2;
			grabbedRigid.AddForceAtPosition(val3 * 100f, val2, (ForceMode)5);
		}
	}

	private void StopGrab()
	{
		grabbedRigid = null;
	}
}
