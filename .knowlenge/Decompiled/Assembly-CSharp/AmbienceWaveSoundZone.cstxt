using UnityEngine;

public class AmbienceWaveSoundZone : TriggerBase, IClientComponentEx
{
	public float priority;

	public float gain = 1f;

	public virtual void PreClientComponentCull(IPrefabProcessor p)
	{
		p.RemoveComponent((Component)(object)this);
		p.NominateForDeletion(((Component)this).gameObject);
	}
}
