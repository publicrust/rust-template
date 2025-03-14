using UnityEngine;

public class ReverbZoneTrigger : TriggerBase, IClientComponentEx, ILOD
{
	public Collider trigger;

	public AudioReverbZone reverbZone;

	public float lodDistance = 100f;

	public bool inRange;

	public ReverbSettings reverbSettings;

	public virtual void PreClientComponentCull(IPrefabProcessor p)
	{
		p.RemoveComponent(trigger);
		p.RemoveComponent(reverbZone);
		p.RemoveComponent(this);
		p.NominateForDeletion(base.gameObject);
	}

	public bool IsSyncedToParent()
	{
		return false;
	}
}
