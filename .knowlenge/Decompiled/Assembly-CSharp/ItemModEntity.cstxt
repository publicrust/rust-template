using UnityEngine;

public class ItemModEntity : ItemMod
{
	public GameObjectRef entityPrefab = new GameObjectRef();

	public string defaultBone;

	public override void OnItemCreated(Item item)
	{
		if (item.GetHeldEntity() == null)
		{
			BaseEntity baseEntity = GameManager.server.CreateEntity(entityPrefab.resourcePath);
			if (baseEntity == null)
			{
				Debug.LogWarning("Couldn't create item entity " + item.info.displayName.english + " (" + entityPrefab.resourcePath + ")");
			}
			else
			{
				baseEntity.skinID = item.skin;
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
		if (item.parentItem == null)
		{
			return false;
		}
		BaseEntity baseEntity = item.parentItem.GetWorldEntity();
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
		BasePlayer ownerPlayer = item.GetOwnerPlayer();
		if ((bool)ownerPlayer)
		{
			heldEntity.SetOwnerPlayer(ownerPlayer);
			return true;
		}
		heldEntity.ClearOwnerPlayer();
		return true;
	}

	public override void OnParentChanged(Item item)
	{
		BaseEntity heldEntity = item.GetHeldEntity();
		if (!(heldEntity == null) && !ParentToParent(item, heldEntity) && !ParentToPlayer(item, heldEntity))
		{
			heldEntity.SetParent(null);
			heldEntity.limitNetworking = true;
			heldEntity.SetFlag(BaseEntity.Flags.Disabled, b: true);
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
