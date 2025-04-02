using UnityEngine;

public class Occludee : MonoBehaviour
{
	public float minTimeVisible = 0.1f;

	public bool isStatic = true;

	public bool autoRegister;

	public bool stickyGizmos;

	public OccludeeState state;

	protected int occludeeId = -1;

	protected Vector3 center;

	protected float radius;

	protected Renderer renderer;

	protected Collider collider;

	protected virtual void Awake()
	{
		renderer = GetComponent<Renderer>();
		collider = GetComponent<Collider>();
	}

	public void OnEnable()
	{
		if (autoRegister && collider != null)
		{
			Register();
		}
	}

	public void OnDisable()
	{
		if (autoRegister && occludeeId >= 0)
		{
			Unregister();
		}
	}

	public void Register()
	{
		center = collider.bounds.center;
		radius = Mathf.Max(Mathf.Max(collider.bounds.extents.x, collider.bounds.extents.y), collider.bounds.extents.z);
		occludeeId = OcclusionCulling.RegisterOccludee(center, radius, renderer.enabled, minTimeVisible, isStatic, base.gameObject.layer, OnVisibilityChanged);
		if (occludeeId < 0)
		{
			Debug.LogWarning("[OcclusionCulling] Occludee registration failed for " + base.name + ". Too many registered.");
		}
		state = OcclusionCulling.GetStateById(occludeeId);
	}

	public void Unregister()
	{
		OcclusionCulling.UnregisterOccludee(occludeeId);
	}

	protected virtual void OnVisibilityChanged(bool visible)
	{
		if (renderer != null)
		{
			renderer.enabled = visible;
		}
	}
}
