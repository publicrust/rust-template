using UnityEngine;

public class AmbienceZone : TriggerBase, IClientComponentEx
{
	public AmbienceDefinitionList baseAmbience;

	public AmbienceDefinitionList stings;

	public float priority;

	public bool overrideCrossfadeTime;

	public float crossfadeTime = 1f;

	public float ambienceGain = 1f;

	public virtual void PreClientComponentCull(IPrefabProcessor p)
	{
		p.RemoveComponent((Component)(object)this);
		p.NominateForDeletion(((Component)this).gameObject);
	}
}
