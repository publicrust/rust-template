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
		renderer = ((Component)this).GetComponent<Renderer>();
		collider = ((Component)this).GetComponent<Collider>();
	}

	public void OnEnable()
	{
		if (autoRegister && (Object)(object)collider != (Object)null)
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		Bounds bounds = collider.bounds;
		center = ((Bounds)(ref bounds)).center;
		bounds = collider.bounds;
		float x = ((Bounds)(ref bounds)).extents.x;
		bounds = collider.bounds;
		float num = Mathf.Max(x, ((Bounds)(ref bounds)).extents.y);
		bounds = collider.bounds;
		radius = Mathf.Max(num, ((Bounds)(ref bounds)).extents.z);
		occludeeId = OcclusionCulling.RegisterOccludee(center, radius, renderer.enabled, minTimeVisible, isStatic, ((Component)this).gameObject.layer, OnVisibilityChanged);
		if (occludeeId < 0)
		{
			Debug.LogWarning((object)("[OcclusionCulling] Occludee registration failed for " + ((Object)this).name + ". Too many registered."));
		}
		state = OcclusionCulling.GetStateById(occludeeId);
	}

	public void Unregister()
	{
		OcclusionCulling.UnregisterOccludee(occludeeId);
	}

	protected virtual void OnVisibilityChanged(bool visible)
	{
		if ((Object)(object)renderer != (Object)null)
		{
			renderer.enabled = visible;
		}
	}
}
