using Facepunch;
using ProtoBuf;

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
		_ = info.msg.simpleFloat;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.simpleFloat = Pool.Get<SimpleFloat>();
		info.msg.simpleFloat.value = GetPercentFull();
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
