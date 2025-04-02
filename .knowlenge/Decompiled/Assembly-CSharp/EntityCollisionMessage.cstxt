using UnityEngine;

public class EntityCollisionMessage : EntityComponent<BaseEntity>
{
	private void OnCollisionEnter(Collision collision)
	{
		if (base.baseEntity == null || base.baseEntity.IsDestroyed)
		{
			return;
		}
		BaseEntity baseEntity = CollisionEx.GetEntity(collision);
		if (baseEntity == base.baseEntity)
		{
			return;
		}
		if (baseEntity != null)
		{
			if (baseEntity.IsDestroyed)
			{
				return;
			}
			if (base.baseEntity.isServer)
			{
				baseEntity = baseEntity.ToServer<BaseEntity>();
			}
		}
		base.baseEntity.OnCollision(collision, baseEntity);
	}
}
