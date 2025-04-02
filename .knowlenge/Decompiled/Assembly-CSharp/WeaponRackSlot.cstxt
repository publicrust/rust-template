using ProtoBuf;
using Rust;
using UnityEngine;

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
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected I4, but got Unknown
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
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		ClearAmmoDetails();
		BaseEntity heldEntity = item.GetHeldEntity();
		if (!((Object)(object)heldEntity == (Object)null))
		{
			BaseProjectile component = ((Component)heldEntity).GetComponent<BaseProjectile>();
			if (!((Object)(object)component == (Object)null))
			{
				AmmoItemDef = component.primaryMagazine.ammoType;
				AmmoItemID = (((Object)(object)AmmoItemDef != (Object)null) ? AmmoItemDef.itemid : 0);
				AmmoCount = component.primaryMagazine.contents;
				AmmoMax = component.primaryMagazine.capacity;
				AmmoTypes = component.primaryMagazine.definition.ammoTypes;
				ReloadTime = component.GetReloadDuration();
			}
		}
	}

	private void ClearAmmoDetails()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		AmmoItemDef = null;
		AmmoTypes = (AmmoTypes)0;
		AmmoItemID = 0;
		AmmoCount = 0;
		AmmoMax = 0;
		ReloadTime = 0f;
	}

	public bool CanBeReloadedAtWeaponRack()
	{
		if ((Object)(object)ItemDef == (Object)null)
		{
			return false;
		}
		WorldModelRackMountConfig forItemDef = WorldModelRackMountConfig.GetForItemDef(ItemDef);
		if ((Object)(object)forItemDef == (Object)null)
		{
			return false;
		}
		return forItemDef.CanReloadOnWeaponRack;
	}
}
