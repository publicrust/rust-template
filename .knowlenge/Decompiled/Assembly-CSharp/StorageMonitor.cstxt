using System;
using Facepunch;
using Network;
using ProtoBuf;

public class StorageMonitor : AppIOEntity
{
	public readonly Action<Item, bool> _onContainerChangedHandler;

	private readonly Action _resetSwitchHandler;

	private double _lastPowerOnUpdate;

	public override AppEntityType Type => AppEntityType.StorageMonitor;

	public override bool Value
	{
		get
		{
			return IsOn();
		}
		set
		{
		}
	}

	public StorageMonitor()
	{
		_onContainerChangedHandler = OnContainerChanged;
		_resetSwitchHandler = ResetSwitch;
	}

	internal override void FillEntityPayload(AppEntityPayload payload)
	{
		base.FillEntityPayload(payload);
		StorageContainer storageContainer = GetStorageContainer();
		if (storageContainer == null || !HasFlag(Flags.Reserved8))
		{
			return;
		}
		payload.items = Pool.GetList<AppEntityPayload.Item>();
		foreach (Item item2 in storageContainer.inventory.itemList)
		{
			AppEntityPayload.Item item = Pool.Get<AppEntityPayload.Item>();
			item.itemId = (item2.IsBlueprint() ? item2.blueprintTargetDef.itemid : item2.info.itemid);
			item.quantity = item2.amount;
			item.itemIsBlueprint = item2.IsBlueprint();
			payload.items.Add(item);
		}
		payload.capacity = storageContainer.inventory.capacity;
		if (storageContainer is BuildingPrivlidge buildingPrivlidge)
		{
			payload.hasProtection = true;
			float protectedMinutes = buildingPrivlidge.GetProtectedMinutes();
			if (protectedMinutes > 0f)
			{
				payload.protectionExpiry = (uint)DateTimeOffset.UtcNow.AddMinutes(protectedMinutes).ToUnixTimeSeconds();
			}
		}
	}

	public override void Init()
	{
		base.Init();
		StorageContainer storageContainer = GetStorageContainer();
		if (storageContainer != null && storageContainer.inventory != null)
		{
			ItemContainer inventory = storageContainer.inventory;
			inventory.onItemAddedRemoved = (Action<Item, bool>)Delegate.Combine(inventory.onItemAddedRemoved, _onContainerChangedHandler);
		}
	}

	public override void DestroyShared()
	{
		base.DestroyShared();
		StorageContainer storageContainer = GetStorageContainer();
		if (storageContainer != null && storageContainer.inventory != null)
		{
			ItemContainer inventory = storageContainer.inventory;
			inventory.onItemAddedRemoved = (Action<Item, bool>)Delegate.Remove(inventory.onItemAddedRemoved, _onContainerChangedHandler);
		}
	}

	private StorageContainer GetStorageContainer()
	{
		return GetParentEntity() as StorageContainer;
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (!IsOn())
		{
			return 0;
		}
		return GetCurrentEnergy();
	}

	public override void UpdateHasPower(int inputAmount, int inputSlot)
	{
		bool flag = HasFlag(Flags.Reserved8);
		base.UpdateHasPower(inputAmount, inputSlot);
		if (inputSlot == 0)
		{
			bool num = inputAmount >= ConsumptionAmount();
			double realtimeSinceStartup = TimeEx.realtimeSinceStartup;
			if (num && !flag && _lastPowerOnUpdate < realtimeSinceStartup - 1.0)
			{
				_lastPowerOnUpdate = realtimeSinceStartup;
				BroadcastValueChange();
			}
		}
	}

	public void OnContainerChanged(Item item, bool added)
	{
		if (HasFlag(Flags.Reserved8))
		{
			Invoke(_resetSwitchHandler, 0.5f);
			if (!IsOn())
			{
				SetFlag(Flags.On, b: true);
				SendNetworkUpdateImmediate();
				MarkDirty();
				BroadcastValueChange();
			}
		}
	}

	private void ResetSwitch()
	{
		SetFlag(Flags.On, b: false);
		SendNetworkUpdateImmediate();
		MarkDirty();
		BroadcastValueChange();
	}
}
