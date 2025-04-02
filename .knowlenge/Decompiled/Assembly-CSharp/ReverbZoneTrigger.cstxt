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
		p.RemoveComponent((Component)(object)trigger);
		p.RemoveComponent((Component)(object)reverbZone);
		p.RemoveComponent((Component)(object)this);
		p.NominateForDeletion(((Component)this).gameObject);
	}

	public bool IsSyncedToParent()
	{
		return false;
	}
}
