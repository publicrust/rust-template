using ProtoBuf;
using UnityEngine;

public abstract class ItemModAssociatedEntity<T> : ItemMod where T : BaseEntity
{
	public GameObjectRef entityPrefab;

	protected virtual bool AllowNullParenting => false;

	protected virtual bool AllowHeldEntityParenting => false;

	protected virtual bool ShouldAutoCreateEntity => true;

	protected virtual bool OwnedByParentPlayer => false;

	public override void OnItemCreated(Item item)
	{
		base.OnItemCreated(item);
		if (ShouldAutoCreateEntity)
		{
			CreateAssociatedEntity(item);
		}
	}

	public T CreateAssociatedEntity(Item item)
	{
		if (item.instanceData != null)
		{
			return null;
		}
		BaseEntity baseEntity = GameManager.server.CreateEntity(entityPrefab.resourcePath, Vector3.zero);
		T component = baseEntity.GetComponent<T>();
		OnAssociatedItemCreated(component);
		baseEntity.Spawn();
		item.instanceData = new ProtoBuf.Item.InstanceData();
		item.instanceData.ShouldPool = false;
		item.instanceData.subEntity = baseEntity.net.ID;
		item.MarkDirty();
		return component;
	}

	protected virtual void OnAssociatedItemCreated(T ent)
	{
	}

	public override void OnRemove(Item item)
	{
		base.OnRemove(item);
		T associatedEntity = GetAssociatedEntity(item);
		if ((bool)associatedEntity)
		{
			associatedEntity.Kill();
		}
	}

	public override void OnMovedToWorld(Item item)
	{
		UpdateParent(item);
		base.OnMovedToWorld(item);
	}

	public override void OnRemovedFromWorld(Item item)
	{
		UpdateParent(item);
		base.OnRemovedFromWorld(item);
	}

	public void UpdateParent(Item item)
	{
		T associatedEntity = GetAssociatedEntity(item);
		if (associatedEntity == null)
		{
			return;
		}
		BaseEntity entityForParenting = GetEntityForParenting(item);
		if (entityForParenting == null)
		{
			if (AllowNullParenting)
			{
				associatedEntity.SetParent(null, worldPositionStays: false, sendImmediate: true);
			}
			if (OwnedByParentPlayer)
			{
				associatedEntity.OwnerID = 0uL;
			}
		}
		else if (entityForParenting.isServer && entityForParenting.IsFullySpawned())
		{
			associatedEntity.SetParent(entityForParenting, worldPositionStays: false, sendImmediate: true);
			if (OwnedByParentPlayer && entityForParenting is BasePlayer basePlayer)
			{
				associatedEntity.OwnerID = basePlayer.userID;
			}
		}
	}

	public override void OnParentChanged(Item item)
	{
		base.OnParentChanged(item);
		UpdateParent(item);
	}

	public BaseEntity GetEntityForParenting(Item item = null)
	{
		if (item != null)
		{
			Item item2 = item;
			Item parentItem = item.parentItem;
			if (parentItem != null && parentItem.IsBackpack())
			{
				item2 = item.parentItem;
			}
			BasePlayer ownerPlayer = item2.GetOwnerPlayer();
			if ((bool)ownerPlayer)
			{
				return ownerPlayer;
			}
			BaseEntity baseEntity = ((item2.parent == null) ? null : item2.parent.entityOwner);
			if (baseEntity != null)
			{
				return baseEntity;
			}
			BaseEntity worldEntity = item2.GetWorldEntity();
			if ((bool)worldEntity)
			{
				return worldEntity;
			}
			if (AllowHeldEntityParenting && item.parentItem != null && item.parentItem.GetHeldEntity() != null)
			{
				return item.parentItem.GetHeldEntity();
			}
			return null;
		}
		return null;
	}

	public static bool GetAssociatedEntity(Item item, out T result, bool isServer = true)
	{
		result = GetAssociatedEntity(item, isServer);
		return result != null;
	}

	public static T GetAssociatedEntity(Item item, bool isServer = true)
	{
		if (item?.instanceData == null)
		{
			return null;
		}
		BaseNetworkable baseNetworkable = null;
		if (isServer)
		{
			baseNetworkable = BaseNetworkable.serverEntities.Find(item.instanceData.subEntity);
		}
		if ((bool)baseNetworkable)
		{
			return baseNetworkable.GetComponent<T>();
		}
		return null;
	}
}
