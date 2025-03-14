using Oxide.Core;
using UnityEngine;

public class FlameExplosive : TimedExplosive
{
	public GameObjectRef createOnExplode;

	public float numToCreate = 10f;

	public float minVelocity = 2f;

	public float maxVelocity = 5f;

	public float spreadAngle = 90f;

	public override void Explode()
	{
		Explode(-base.transform.forward);
	}

	public void Explode(Vector3 surfaceNormal)
	{
		if (!base.isServer)
		{
			return;
		}
		for (int i = 0; (float)i < numToCreate; i++)
		{
			BaseEntity baseEntity = GameManager.server.CreateEntity(createOnExplode.resourcePath, base.transform.position);
			if ((bool)baseEntity)
			{
				Vector3 modifiedAimConeDirection = AimConeUtil.GetModifiedAimConeDirection(spreadAngle, surfaceNormal);
				baseEntity.transform.SetPositionAndRotation(base.transform.position, Quaternion.LookRotation(modifiedAimConeDirection));
				baseEntity.creatorEntity = ((creatorEntity == null) ? baseEntity : creatorEntity);
				Interface.CallHook("OnFlameExplosion", this, baseEntity);
				baseEntity.Spawn();
				baseEntity.SetVelocity(modifiedAimConeDirection * UnityEngine.Random.Range(minVelocity, maxVelocity));
			}
		}
		base.Explode();
	}

	public override void ProjectileImpact(RaycastHit info)
	{
		Explode(info.normal);
	}
}
