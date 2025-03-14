public class AmbienceWaveSoundZone : TriggerBase, IClientComponentEx
{
	public float priority;

	public float gain = 1f;

	public virtual void PreClientComponentCull(IPrefabProcessor p)
	{
		p.RemoveComponent(this);
		p.NominateForDeletion(base.gameObject);
	}
}
