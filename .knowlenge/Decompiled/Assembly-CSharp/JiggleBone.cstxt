using UnityEngine;

public class JiggleBone : BaseMonoBehaviour
{
	public bool debugMode = true;

	private Vector3 targetPos;

	private Vector3 dynamicPos;

	public Vector3 boneAxis = new Vector3(0f, 0f, 1f);

	public float targetDistance = 2f;

	public float bStiffness = 0.1f;

	public float bMass = 0.9f;

	public float bDamping = 0.75f;

	public float bGravity = 0.75f;

	private Vector3 force;

	private Vector3 acc;

	private Vector3 vel;

	public bool SquashAndStretch = true;

	public float sideStretch = 0.15f;

	public float frontStretch = 0.2f;

	public float disableDistance = 20f;

	private void Awake()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = ((Component)this).transform.position + ((Component)this).transform.TransformDirection(new Vector3(boneAxis.x * targetDistance, boneAxis.y * targetDistance, boneAxis.z * targetDistance));
		dynamicPos = val;
	}

	private void LateUpdate()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.rotation = default(Quaternion);
		Vector3 val = ((Component)this).transform.TransformDirection(new Vector3(boneAxis.x * targetDistance, boneAxis.y * targetDistance, boneAxis.z * targetDistance));
		Vector3 val2 = ((Component)this).transform.TransformDirection(new Vector3(0f, 1f, 0f));
		Vector3 val3 = ((Component)this).transform.position + ((Component)this).transform.TransformDirection(new Vector3(boneAxis.x * targetDistance, boneAxis.y * targetDistance, boneAxis.z * targetDistance));
		force.x = (val3.x - dynamicPos.x) * bStiffness;
		acc.x = force.x / bMass;
		vel.x += acc.x * (1f - bDamping);
		force.y = (val3.y - dynamicPos.y) * bStiffness;
		force.y -= bGravity / 10f;
		acc.y = force.y / bMass;
		vel.y += acc.y * (1f - bDamping);
		force.z = (val3.z - dynamicPos.z) * bStiffness;
		acc.z = force.z / bMass;
		vel.z += acc.z * (1f - bDamping);
		dynamicPos += vel + force;
		((Component)this).transform.LookAt(dynamicPos, val2);
		if (SquashAndStretch)
		{
			Vector3 val4 = dynamicPos - val3;
			float magnitude = ((Vector3)(ref val4)).magnitude;
			float num = ((boneAxis.x != 0f) ? (1f + magnitude * frontStretch) : (1f + (0f - magnitude) * sideStretch));
			float num2 = ((boneAxis.y != 0f) ? (1f + magnitude * frontStretch) : (1f + (0f - magnitude) * sideStretch));
			float num3 = ((boneAxis.z != 0f) ? (1f + magnitude * frontStretch) : (1f + (0f - magnitude) * sideStretch));
			((Component)this).transform.localScale = new Vector3(num, num2, num3);
		}
		if (debugMode)
		{
			Debug.DrawRay(((Component)this).transform.position, val, Color.blue);
			Debug.DrawRay(((Component)this).transform.position, val2, Color.green);
			Debug.DrawRay(val3, Vector3.up * 0.2f, Color.yellow);
			Debug.DrawRay(dynamicPos, Vector3.up * 0.2f, Color.red);
		}
	}
}
