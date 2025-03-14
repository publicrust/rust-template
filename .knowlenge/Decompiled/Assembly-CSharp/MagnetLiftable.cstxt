using UnityEngine;

public class MagnetLiftable : EntityComponent<BaseEntity>
{
	public ItemAmount[] shredResources;

	public bool scaleScrapResourcesByHealth;

	public Vector3 shredDirection = Vector3.forward;

	public bool requireObjectOff;

	public BasePlayer associatedPlayer { get; private set; }

	public virtual void SetMagnetized(bool wantsOn, BaseMagnet magnetSource, BasePlayer player)
	{
		associatedPlayer = player;
	}
}
