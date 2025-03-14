using UnityEngine;

public class ItemModProjectileSpawn : ItemModProjectile
{
	public float createOnImpactChance;

	public GameObjectRef createOnImpact = new GameObjectRef();

	public float spreadAngle = 30f;

	public float spreadVelocityMin = 1f;

	public float spreadVelocityMax = 3f;

	public int numToCreateChances = 1;

	public override void ServerProjectileHit(HitInfo info)
	{
		for (int i = 0; i < numToCreateChances; i++)
		{
			if (!createOnImpact.isValid || !(Random.Range(0f, 1f) < createOnImpactChance))
			{
				continue;
			}
			BaseEntity baseEntity = GameManager.server.CreateEntity(createOnImpact.resourcePath);
			if ((bool)baseEntity)
			{
				Vector3 hitPositionWorld = info.HitPositionWorld;
				Vector3 normalized = info.HitNormalWorld.normalized;
				Vector3 normalized2 = info.ProjectileVelocity.normalized;
				baseEntity.transform.position = hitPositionWorld - normalized2 * 0.1f;
				baseEntity.transform.rotation = Quaternion.LookRotation(-normalized2);
				baseEntity.Spawn();
				if (spreadAngle > 0f)
				{
					Vector3 modifiedAimConeDirection = AimConeUtil.GetModifiedAimConeDirection(spreadAngle, normalized);
					baseEntity.SetVelocity(modifiedAimConeDirection * Random.Range(1f, 3f));
				}
			}
		}
		base.ServerProjectileHit(info);
	}
}
