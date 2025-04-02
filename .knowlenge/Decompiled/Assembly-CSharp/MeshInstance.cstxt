using UnityEngine;

public struct MeshInstance
{
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
