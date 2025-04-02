using ProtoBuf;
using Rust;

public class WeaponRackSlot
{
	[InspectorFlags]
	public AmmoTypes AmmoTypes;

	public bool Used { get; private set; }

	public ItemDefinition ItemDef { get; private set; }

	public int ClientItemID { get; private set; }

	public ulong ClientItemSkinID { get; private set; }

	public ItemDefinition AmmoItemDef { get; private set; }

	public int AmmoItemID { get; private set; }

	public int AmmoCount { get; private set; }

	public int AmmoMax { get; private set; }

	public float Condition { get; private set; }

	public int InventoryIndex { get; private set; }

	public int GridSlotIndex { get; private set; }

	public int Rotation { get; private set; }

	public float ReloadTime { get; private set; }

	public void SetUsed(bool flag)
	{
		Used = flag;
	}

	public WeaponRackItem SaveToProto(Item item, WeaponRackItem proto)
	{
		proto.itemID = item?.info.itemid ?? 0;
		proto.skinid = item?.skin ?? 0;
		proto.inventorySlot = InventoryIndex;
		proto.gridSlotIndex = GridSlotIndex;
		proto.rotation = Rotation;
		proto.ammoCount = AmmoCount;
		proto.ammoMax = AmmoMax;
		proto.ammoID = AmmoItemID;
		proto.condition = Condition;
		proto.ammoTypes = (int)AmmoTypes;
		proto.reloadTime = ReloadTime;
		return proto;
	}

	public void InitFromProto(WeaponRackItem item)
	{
		ClientItemID = item.itemID;
		ClientItemSkinID = item.skinid;
		ItemDef = ItemManager.FindItemDefinition(ClientItemID);
		InventoryIndex = item.inventorySlot;
		GridSlotIndex = item.gridSlotIndex;
		AmmoCount = item.ammoCount;
		AmmoMax = item.ammoMax;
		AmmoItemID = item.ammoID;
		AmmoItemDef = ((AmmoItemID != 0) ? ItemManager.FindItemDefinition(AmmoItemID) : null);
		Condition = item.condition;
		Rotation = item.rotation;
		AmmoTypes = (AmmoTypes)item.ammoTypes;
		ReloadTime = item.reloadTime;
	}

	public void SetItem(Item item, ItemDefinition updatedItemDef, int gridCellIndex, int rotation)
	{
		InventoryIndex = item.position;
		GridSlotIndex = gridCellIndex;
		Condition = item.conditionNormalized;
		Rotation = rotation;
		SetAmmoDetails(item);
		ItemDef = updatedItemDef;
	}

	public void SetAmmoDetails(Item item)
	{
		ClearAmmoDetails();
		BaseEntity heldEntity = item.GetHeldEntity();
		if (!(heldEntity == null))
		{
			BaseProjectile component = heldEntity.GetComponent<BaseProjectile>();
			if (!(component == null))
			{
				AmmoItemDef = component.primaryMagazine.ammoType;
				AmmoItemID = ((AmmoItemDef != null) ? AmmoItemDef.itemid : 0);
				AmmoCount = component.primaryMagazine.contents;
				AmmoMax = component.primaryMagazine.capacity;
				AmmoTypes = component.primaryMagazine.definition.ammoTypes;
				ReloadTime = component.GetReloadDuration();
			}
		}
	}

	private void ClearAmmoDetails()
	{
		AmmoItemDef = null;
		AmmoTypes = (AmmoTypes)0;
		AmmoItemID = 0;
		AmmoCount = 0;
		AmmoMax = 0;
		ReloadTime = 0f;
	}

	public bool CanBeReloadedAtWeaponRack()
	{
		if (ItemDef == null)
		{
			return false;
		}
		WorldModelRackMountConfig forItemDef = WorldModelRackMountConfig.GetForItemDef(ItemDef);
		if (forItemDef == null)
		{
			return false;
		}
		return forItemDef.CanReloadOnWeaponRack;
	}
}
