using System;
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
		if (base.CanPickup(player) && !HasDirtyWater() && (Object)(object)waterStorage != (Object)null)
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
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
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
		if ((Object)(object)waterStorage != (Object)null)
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
			if (HasFlag(Flags.Reserved8) && !((FacepunchBehaviour)this).IsInvoking((Action)ConvertWater))
			{
				((FacepunchBehaviour)this).InvokeRandomized((Action)ConvertWater, ConvertInterval, ConvertInterval, ConvertInterval * 0.1f);
			}
		}
		else if (((FacepunchBehaviour)this).IsInvoking((Action)ConvertWater))
		{
			((FacepunchBehaviour)this).CancelInvoke((Action)ConvertWater);
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
				if (!((FacepunchBehaviour)this).IsInvoking((Action)ConvertWater))
				{
					((FacepunchBehaviour)this).InvokeRandomized((Action)ConvertWater, ConvertInterval, ConvertInterval, ConvertInterval * 0.1f);
				}
			}
			else if (((FacepunchBehaviour)this).IsInvoking((Action)ConvertWater))
			{
				((FacepunchBehaviour)this).CancelInvoke((Action)ConvertWater);
			}
		}
		if ((Object)(object)waterStorage != (Object)null)
		{
			waterStorage.SetFlag(Flags.Reserved8, HasFlag(Flags.Reserved8));
		}
	}
}
