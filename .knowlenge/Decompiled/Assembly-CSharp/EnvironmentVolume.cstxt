using UnityEngine;

[ExecuteInEditMode]
public class EnvironmentVolume : MonoBehaviour
{
	[InspectorFlags]
	public EnvironmentType Type = EnvironmentType.Underground;

	[InspectorFlags]
	public NetworkGroupType NetworkType;

	public Vector3 Center = Vector3.zero;

	public Vector3 Size = Vector3.one;

	public Collider trigger { get; private set; }

	protected virtual void Awake()
	{
		UpdateTrigger();
	}

	protected void OnEnable()
	{
		if ((bool)trigger && !trigger.enabled)
		{
			trigger.enabled = true;
		}
		NetworkVisibilityGrid.RegisterEnvironmentVolume(this);
	}

	protected void OnDisable()
	{
		if ((bool)trigger && trigger.enabled)
		{
			trigger.enabled = false;
		}
	}

	public void UpdateTrigger()
	{
		if (!trigger)
		{
			trigger = base.gameObject.GetComponent<Collider>();
		}
		if (!trigger)
		{
			trigger = base.gameObject.AddComponent<BoxCollider>();
		}
		trigger.isTrigger = true;
		BoxCollider boxCollider = trigger as BoxCollider;
		if ((bool)boxCollider)
		{
			boxCollider.center = Center;
			boxCollider.size = Size;
		}
	}
}
