using UnityEngine;

public class EntityCollisionMessage : EntityComponent<BaseEntity>
{
	private void OnCollisionEnter(Collision collision)
	{
		if ((Object)(object)base.baseEntity == (Object)null || base.baseEntity.IsDestroyed)
		{
			return;
		}
		BaseEntity baseEntity = collision.GetEntity();
		if ((Object)(object)baseEntity == (Object)(object)base.baseEntity)
		{
			return;
		}
		if ((Object)(object)baseEntity != (Object)null)
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
