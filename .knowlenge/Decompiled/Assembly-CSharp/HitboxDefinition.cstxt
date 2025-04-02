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
			return scale;
		}
		set
		{
			scale = new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
		}
	}

	public Matrix4x4 LocalMatrix => Matrix4x4.TRS(center, Quaternion.Euler(rotation), scale);

	private void OnValidate()
	{
		Scale = Scale;
	}

	protected virtual void OnDrawGizmosSelected()
	{
		switch (type)
		{
		case Type.BOX:
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.matrix *= Matrix4x4.TRS(center, Quaternion.Euler(rotation), scale);
			Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			Gizmos.color = Color.white;
			Gizmos.matrix = Matrix4x4.identity;
			break;
		case Type.CAPSULE:
			Gizmos.matrix = base.transform.localToWorldMatrix;
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
		switch (type)
		{
		case Type.BOX:
			Gizmos.matrix = base.transform.localToWorldMatrix;
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
			Gizmos.matrix = base.transform.localToWorldMatrix;
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
