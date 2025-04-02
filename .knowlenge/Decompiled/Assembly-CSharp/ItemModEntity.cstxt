using UnityEngine;

public class ItemModEntity : ItemMod
{
	public GameObjectRef entityPrefab = new GameObjectRef();

	public string defaultBone;

	public bool playerOnlyEntity;

	public bool destroyEntityWhenBroken;

	public override void OnChanged(Item item)
	{
		HeldEntity heldEntity = item.GetHeldEntity() as HeldEntity;
		if (heldEntity != null)
		{
			heldEntity.OnItemChanged(item);
		}
		base.OnChanged(item);
	}

	public override void OnItemCreated(Item item)
	{
		if (item.GetHeldEntity() == null && !playerOnlyEntity)
		{
			CreateEntity(item);
		}
	}

	private void CreateEntity(Item item)
	{
		if (!destroyEntityWhenBroken || !item.isBroken)
		{
			BaseEntity baseEntity = GameManager.server.CreateEntity(entityPrefab.resourcePath);
			if (baseEntity == null)
			{
				Debug.LogWarning("Couldn't create item entity " + item.info.displayName.english + " (" + entityPrefab.resourcePath + ")");
			}
			else
			{
				baseEntity.skinID = item.skin;
				baseEntity.limitNetworking = true;
				baseEntity.Spawn();
				item.SetHeldEntity(baseEntity);
			}
		}
	}

	public override void OnRemove(Item item)
	{
		BaseEntity heldEntity = item.GetHeldEntity();
		if (!(heldEntity == null))
		{
			heldEntity.Kill();
			item.SetHeldEntity(null);
		}
	}

	private bool ParentToParent(Item item, BaseEntity ourEntity)
	{
		Item parentItem = item.parentItem;
		if (parentItem == null)
		{
			return false;
		}
		if (parentItem.IsBackpack())
		{
			return false;
		}
		BaseEntity baseEntity = parentItem.GetWorldEntity();
		if (baseEntity == null)
		{
			baseEntity = item.parentItem.GetHeldEntity();
		}
		ourEntity.SetFlag(BaseEntity.Flags.Disabled, b: false);
		ourEntity.limitNetworking = false;
		ourEntity.SetParent(baseEntity, defaultBone);
		return true;
	}

	private bool ParentToPlayer(Item item, BaseEntity ourEntity)
	{
		HeldEntity heldEntity = ourEntity as HeldEntity;
		if (heldEntity == null)
		{
			return false;
		}
		BasePlayer basePlayer = item.GetRootContainer()?.GetOwnerPlayer();
		if ((bool)basePlayer)
		{
			heldEntity.SetOwnerPlayer(basePlayer);
			return true;
		}
		heldEntity.ClearOwnerPlayer();
		return true;
	}

	public override void OnParentChanged(Item item)
	{
		BaseEntity baseEntity = item.GetHeldEntity();
		if (playerOnlyEntity)
		{
			BasePlayer ownerPlayer = item.GetOwnerPlayer();
			if (ownerPlayer == null && baseEntity != null)
			{
				baseEntity.Kill();
				baseEntity = null;
				item.SetHeldEntity(null);
			}
			else if (ownerPlayer != null && baseEntity == null)
			{
				CreateEntity(item);
				baseEntity = item.GetHeldEntity();
			}
		}
		if (!(baseEntity == null) && !ParentToParent(item, baseEntity) && !ParentToPlayer(item, baseEntity))
		{
			baseEntity.SetParent(null);
			baseEntity.limitNetworking = true;
			baseEntity.SetFlag(BaseEntity.Flags.Disabled, b: true);
		}
	}

	public override void CollectedForCrafting(Item item, BasePlayer crafter)
	{
		BaseEntity heldEntity = item.GetHeldEntity();
		if (!(heldEntity == null))
		{
			HeldEntity heldEntity2 = heldEntity as HeldEntity;
			if (!(heldEntity2 == null))
			{
				heldEntity2.CollectedForCrafting(item, crafter);
			}
		}
	}

	public override void ReturnedFromCancelledCraft(Item item, BasePlayer crafter)
	{
		BaseEntity heldEntity = item.GetHeldEntity();
		if (!(heldEntity == null))
		{
			HeldEntity heldEntity2 = heldEntity as HeldEntity;
			if (!(heldEntity2 == null))
			{
				heldEntity2.ReturnedFromCancelledCraft(item, crafter);
			}
		}
	}
}
