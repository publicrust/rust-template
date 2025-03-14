using Facepunch;
using ProtoBuf;

public class CardGamePlayerStorage : StorageContainer
{
	private EntityRef cardTableRef;

	public BaseCardGameEntity GetCardGameEntity()
	{
		BaseEntity baseEntity = cardTableRef.Get(base.isServer);
		if (baseEntity != null && baseEntity.IsValid())
		{
			return baseEntity as BaseCardGameEntity;
		}
		return null;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.simpleUID != null)
		{
			cardTableRef.uid = info.msg.simpleUID.uid;
		}
	}

	protected override void OnInventoryDirty()
	{
		base.OnInventoryDirty();
		BaseCardGameEntity cardGameEntity = GetCardGameEntity();
		if (cardGameEntity != null)
		{
			cardGameEntity.PlayerStorageChanged();
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.simpleUID = Pool.Get<SimpleUID>();
		info.msg.simpleUID.uid = cardTableRef.uid;
	}

	public void SetCardTable(BaseCardGameEntity cardGameEntity)
	{
		cardTableRef.Set(cardGameEntity);
	}
}
