using Facepunch;
using ProtoBuf;
using UnityEngine;

public class CardGamePlayerStorage : StorageContainer
{
	private EntityRef cardTableRef;

	public BaseCardGameEntity GetCardGameEntity()
	{
		BaseEntity baseEntity = cardTableRef.Get(base.isServer);
		if ((Object)(object)baseEntity != (Object)null && baseEntity.IsValid())
		{
			return baseEntity as BaseCardGameEntity;
		}
		return null;
	}

	public override void Load(LoadInfo info)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
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
		if ((Object)(object)cardGameEntity != (Object)null)
		{
			cardGameEntity.PlayerStorageChanged();
		}
	}

	public override void Save(SaveInfo info)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		base.Save(info);
		info.msg.simpleUID = Pool.Get<SimpleUID>();
		info.msg.simpleUID.uid = cardTableRef.uid;
	}

	public void SetCardTable(BaseCardGameEntity cardGameEntity)
	{
		cardTableRef.Set(cardGameEntity);
	}
}
