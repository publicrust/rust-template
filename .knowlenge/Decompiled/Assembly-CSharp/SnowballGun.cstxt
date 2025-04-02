using UnityEngine;

public class SnowballGun : BaseProjectile
{
	public ItemDefinition OverrideProjectile;

	private static ItemDefinition _snowballInventoryItem;

	private static ItemDefinition _snowballAmmoItem;

	public static ItemDefinition SnowballInventoryItem
	{
		get
		{
			if ((Object)(object)_snowballInventoryItem == (Object)null)
			{
				_snowballInventoryItem = ItemManager.FindItemDefinition("snowball");
			}
			return _snowballInventoryItem;
		}
	}

	public static ItemDefinition SnowballAmmoItem
	{
		get
		{
			if ((Object)(object)_snowballAmmoItem == (Object)null)
			{
				_snowballAmmoItem = ItemManager.FindItemDefinition("ammo.snowballgun");
			}
			return _snowballAmmoItem;
		}
	}

	protected override ItemDefinition PrimaryMagazineAmmo
	{
		get
		{
			if (!((Object)(object)OverrideProjectile != (Object)null))
			{
				return base.PrimaryMagazineAmmo;
			}
			return OverrideProjectile;
		}
	}

	protected override bool CanRefundAmmo => false;

	public override bool TryReloadMagazine(IAmmoContainer ammoSource, int desiredAmount = -1)
	{
		desiredAmount = 1;
		if (!TryReload(ammoSource, desiredAmount, CanRefundAmmo))
		{
			return false;
		}
		SetAmmoCount(primaryMagazine.capacity);
		primaryMagazine.ammoType = OverrideProjectile;
		SendNetworkUpdateImmediate();
		ItemManager.DoRemoves();
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if ((Object)(object)ownerPlayer != (Object)null)
		{
			ownerPlayer.inventory.ServerUpdate(0f);
		}
		return true;
	}
}
