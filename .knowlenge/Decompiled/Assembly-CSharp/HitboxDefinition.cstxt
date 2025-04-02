using UnityEngine;

public class HitboxDefinition : MonoBehaviour
{
	public enum Type
	{
		BOX,
		CAPSULE
	}

	public Vector3 center;

	public Vector3 rotation;

	public Type type;

	public int priority;

	public PhysicMaterial physicMaterial;

	[SerializeField]
	private Vector3 scale = Vector3.one;

	public Vector3 Scale
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return scale;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			scale = new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
		}
	}

	public Matrix4x4 LocalMatrix => Matrix4x4.TRS(center, Quaternion.Euler(rotation), scale);

	private void OnValidate()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		Scale = Scale;
	}

	protected virtual void OnDrawGizmosSelected()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		switch (type)
		{
		case Type.BOX:
			Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
			Gizmos.matrix *= Matrix4x4.TRS(center, Quaternion.Euler(rotation), scale);
			Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			Gizmos.color = Color.white;
			Gizmos.matrix = Matrix4x4.identity;
			break;
		case Type.CAPSULE:
			Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
			Gizmos.matrix *= Matrix4x4.TRS(center, Quaternion.Euler(rotation), Vector3.one);
			Gizmos.color = Color.green;
			GizmosUtil.DrawWireCapsuleY(Vector3.zero, scale.x, scale.y);
			Gizmos.color = Color.white;
			Gizmos.matrix = Matrix4x4.identity;
			break;
		}
	}

	protected virtual void OnDrawGizmos()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		switch (type)
		{
		case Type.BOX:
			Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
			Gizmos.matrix *= Matrix4x4.TRS(center, Quaternion.Euler(rotation), scale);
			Gizmos.color = Color.black;
			Gizmos.DrawSphere(Vector3.zero, 0.005f);
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			Gizmos.color = new Color(1f, 0f, 0f, 0.2f);
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
			Gizmos.color = Color.white;
			Gizmos.matrix = Matrix4x4.identity;
			break;
		case Type.CAPSULE:
			Gizmos.matrix = ((Component)this).transform.localToWorldMatrix;
			Gizmos.matrix *= Matrix4x4.TRS(center, Quaternion.Euler(rotation), Vector3.one);
			Gizmos.color = Color.black;
			Gizmos.DrawSphere(Vector3.zero, 0.005f);
			GizmosUtil.DrawWireCapsuleY(Vector3.zero, scale.x, scale.y);
			Gizmos.color = Color.white;
			Gizmos.matrix = Matrix4x4.identity;
			break;
		}
	}
}
