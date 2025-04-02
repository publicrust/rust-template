using UnityEngine;

public class EnvironmentVolumeTrigger : MonoBehaviour
{
	[HideInInspector]
	public Vector3 Center = Vector3.zero;

	[HideInInspector]
	public Vector3 Size = Vector3.one;

	public EnvironmentVolume volume { get; private set; }

	protected void Awake()
	{
		volume = base.gameObject.GetComponent<EnvironmentVolume>();
		if (volume == null)
		{
			volume = base.gameObject.AddComponent<EnvironmentVolume>();
			volume.Center = Center;
			volume.Size = Size;
		}
		volume.UpdateTrigger();
		OnVolumeTriggerUpdate();
	}

	protected virtual void OnVolumeTriggerUpdate()
	{
	}
}
