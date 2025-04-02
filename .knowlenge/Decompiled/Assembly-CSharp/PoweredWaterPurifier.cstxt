using UnityEngine;

public class PoweredWaterPurifier : WaterPurifier
{
	public float ConvertInterval = 5f;

	public int PowerDrain = 5;

	public Material PoweredMaterial;

	public Material UnpoweredMaterial;

	public MeshRenderer TargetRenderer;

	public override void ResetState()
	{
		base.ResetState();
	}

	public override bool CanPickup(BasePlayer player)
	{
		if (base.isClient)
		{
			return base.CanPickup(player);
		}
		if (base.CanPickup(player) && !HasDirtyWater() && waterStorage != null)
		{
			if (waterStorage.inventory != null)
			{
				return waterStorage.inventory.itemList.Count == 0;
			}
			return true;
		}
		return false;
	}

	protected override void SpawnStorageEnt(bool load)
	{
		if (load)
		{
			foreach (BaseEntity child in children)
			{
				if (child is LiquidContainer liquidContainer)
				{
					waterStorage = liquidContainer;
				}
			}
		}
		if (waterStorage != null)
		{
			waterStorage.SetConnectedTo(this);
			return;
		}
		waterStorage = GameManager.server.CreateEntity(storagePrefab.resourcePath, storagePrefabAnchor.position, storagePrefabAnchor.rotation) as LiquidContainer;
		waterStorage.SetParent(this, worldPositionStays: true);
		waterStorage.Spawn();
		waterStorage.SetConnectedTo(this);
	}

	public override void OnItemAddedOrRemoved(Item item, bool added)
	{
		base.OnItemAddedOrRemoved(item, added);
		if (HasLiquidItem())
		{
			if (HasFlag(Flags.Reserved8) && !IsInvoking(ConvertWater))
			{
				InvokeRandomized(ConvertWater, ConvertInterval, ConvertInterval, ConvertInterval * 0.1f);
			}
		}
		else if (IsInvoking(ConvertWater))
		{
			CancelInvoke(ConvertWater);
		}
	}

	private void ConvertWater()
	{
		if (HasDirtyWater())
		{
			ConvertWater(ConvertInterval);
		}
	}

	public override int ConsumptionAmount()
	{
		return PowerDrain;
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (!base.isServer)
		{
			return;
		}
		if (old.HasFlag(Flags.Reserved8) != next.HasFlag(Flags.Reserved8))
		{
			if (next.HasFlag(Flags.Reserved8))
			{
				if (!IsInvoking(ConvertWater))
				{
					InvokeRandomized(ConvertWater, ConvertInterval, ConvertInterval, ConvertInterval * 0.1f);
				}
			}
			else if (IsInvoking(ConvertWater))
			{
				CancelInvoke(ConvertWater);
			}
		}
		if (waterStorage != null)
		{
			waterStorage.SetFlag(Flags.Reserved8, HasFlag(Flags.Reserved8));
		}
	}
}
