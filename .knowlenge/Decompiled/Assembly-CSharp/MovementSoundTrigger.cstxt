using UnityEngine;

public class MovementSoundTrigger : TriggerBase, IClientComponentEx, ILOD
{
	public SoundDefinition softSound;

	public SoundDefinition medSound;

	public SoundDefinition hardSound;

	public Collider collider;

	public virtual void PreClientComponentCull(IPrefabProcessor p)
	{
		p.RemoveComponent(collider);
		p.RemoveComponent(this);
		p.NominateForDeletion(base.gameObject);
	}
}
