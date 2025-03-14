using UnityEngine;

public struct OccludeeSphere
{
	public int id;

	public OccludeeState state;

	public OcclusionCulling.Sphere sphere;

	public bool IsRegistered => id >= 0;

	public void Invalidate()
	{
		id = -1;
		state = null;
		sphere = default(OcclusionCulling.Sphere);
	}

	public OccludeeSphere(int id)
	{
		this.id = id;
		state = ((id < 0) ? null : OcclusionCulling.GetStateById(id));
		sphere = new OcclusionCulling.Sphere(Vector3.zero, 0f);
	}

	public OccludeeSphere(int id, OcclusionCulling.Sphere sphere)
	{
		this.id = id;
		state = ((id < 0) ? null : OcclusionCulling.GetStateById(id));
		this.sphere = sphere;
	}
}
