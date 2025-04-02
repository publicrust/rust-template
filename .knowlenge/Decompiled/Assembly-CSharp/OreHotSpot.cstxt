public class OreHotSpot : BaseCombatEntity, ILOD
{
	public float visualDistance = 20f;

	public GameObjectRef visualEffect;

	public GameObjectRef finishEffect;

	public GameObjectRef damageEffect;

	public OreResourceEntity owner;

	public void OreOwner(OreResourceEntity newOwner)
	{
		owner = newOwner;
	}

	public override void ServerInit()
	{
		base.ServerInit();
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		if (!base.isClient && (bool)owner)
		{
			owner.OnAttacked(info);
		}
	}

	public override void OnDied(HitInfo info)
	{
		FireFinishEffect();
		base.OnDied(info);
	}

	public void FireFinishEffect()
	{
		if (finishEffect.isValid)
		{
			Effect.server.Run(finishEffect.resourcePath, base.transform.position, base.transform.forward);
		}
	}
}
