using Facepunch;
using ProtoBuf;
using UnityEngine;

public class PercentFullStorageContainer : StorageContainer
{
	private float prevPercentFull = -1f;

	public bool IsFull()
	{
		return GetPercentFull() == 1f;
	}

	public bool IsEmpty()
	{
		return GetPercentFull() == 0f;
	}

	protected virtual void OnPercentFullChanged(float newPercentFull)
	{
	}

	public float GetPercentFull()
	{
		if (base.isServer)
		{
			float num = 0f;
			if (base.inventory != null)
			{
				foreach (Item item in base.inventory.itemList)
				{
					num += (float)item.amount / (float)item.MaxStackable();
				}
				num /= (float)base.inventory.capacity;
			}
			return num;
		}
		return 0f;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		_ = info.msg.simpleInt;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.simpleInt = Pool.Get<SimpleInt>();
		info.msg.simpleInt.value = Mathf.CeilToInt(GetPercentFull() * 100f);
	}

	protected override void OnInventoryDirty()
	{
		base.OnInventoryDirty();
		float percentFull = GetPercentFull();
		if (percentFull != prevPercentFull)
		{
			OnPercentFullChanged(percentFull);
			SendNetworkUpdate();
			prevPercentFull = percentFull;
		}
	}
}
