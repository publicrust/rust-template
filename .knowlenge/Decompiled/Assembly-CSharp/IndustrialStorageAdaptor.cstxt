using UnityEngine;

public class IndustrialStorageAdaptor : IndustrialEntity, IIndustrialStorage
{
	public GameObject GreenLight;

	public GameObject RedLight;

	private ItemContainer cachedContainer;

	private BaseEntity _cachedParent;

	public ItemContainer Container
	{
		get
		{
			if (cachedContainer == null)
			{
				cachedContainer = (cachedParent as StorageContainer)?.inventory;
			}
			return cachedContainer;
		}
	}

	private BaseEntity cachedParent
	{
		get
		{
			if (_cachedParent == null)
			{
				_cachedParent = GetParentEntity();
			}
			return _cachedParent;
		}
	}

	public BaseEntity IndustrialEntity => this;

	public override void ServerInit()
	{
		base.ServerInit();
		_cachedParent = null;
		cachedContainer = null;
	}

	public Vector2i InputSlotRange(int slotIndex)
	{
		if (cachedParent != null)
		{
			if (cachedParent is IIndustrialStorage industrialStorage)
			{
				return industrialStorage.InputSlotRange(slotIndex);
			}
			if (cachedParent is Locker locker)
			{
				Vector3 localPosition = base.transform.localPosition;
				return locker.GetIndustrialSlotRange(localPosition);
			}
		}
		if (Container != null)
		{
			return new Vector2i(0, Container.capacity - 1);
		}
		return new Vector2i(0, 0);
	}

	public Vector2i OutputSlotRange(int slotIndex)
	{
		if (cachedParent != null)
		{
			if (cachedParent is DropBox && Container != null)
			{
				return new Vector2i(0, Container.capacity - 2);
			}
			if (cachedParent is IIndustrialStorage industrialStorage)
			{
				return industrialStorage.OutputSlotRange(slotIndex);
			}
			if (cachedParent is Locker locker)
			{
				Vector3 localPosition = base.transform.localPosition;
				return locker.GetIndustrialSlotRange(localPosition);
			}
		}
		if (Container != null)
		{
			return new Vector2i(0, Container.capacity - 1);
		}
		return new Vector2i(0, 0);
	}

	public void OnStorageItemTransferBegin()
	{
		if (cachedParent != null && cachedParent is VendingMachine vendingMachine)
		{
			vendingMachine.OnIndustrialItemTransferBegins();
		}
	}

	public void OnStorageItemTransferEnd()
	{
		if (cachedParent != null && cachedParent is VendingMachine vendingMachine)
		{
			vendingMachine.OnIndustrialItemTransferEnds();
		}
	}

	public override int ConsumptionAmount()
	{
		return 0;
	}

	public void ClientNotifyItemAddRemoved(bool add)
	{
		if (add)
		{
			GreenLight.SetActive(value: false);
			GreenLight.SetActive(value: true);
		}
		else
		{
			RedLight.SetActive(value: false);
			RedLight.SetActive(value: true);
		}
	}
}
