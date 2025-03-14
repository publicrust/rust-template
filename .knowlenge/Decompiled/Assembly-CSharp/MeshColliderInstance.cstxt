using UnityEngine;

public struct MeshColliderInstance
{
	public Transform transform;

	public Rigidbody rigidbody;

	public Collider collider;

	public OBB bounds;

	public Vector3 position;

	public Quaternion rotation;

	public Vector3 scale;

	public MeshCache.Data data;

	public Mesh mesh
	{
		get
		{
			return data.mesh;
		}
		set
		{
			data = MeshCache.Get(value);
		}
	}
}
