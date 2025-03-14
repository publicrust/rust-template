public class SnowballGun : BaseProjectile
{
	public ItemDefinition OverrideProjectile;

	protected override ItemDefinition PrimaryMagazineAmmo
	{
		get
		{
			if (!(OverrideProjectile != null))
			{
				return base.PrimaryMagazineAmmo;
			}
			return OverrideProjectile;
		}
	}

	protected override bool CanRefundAmmo => false;

	protected override void ReloadMagazine(int desiredAmount = -1)
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if ((bool)ownerPlayer)
		{
			desiredAmount = 1;
			primaryMagazine.Reload(ownerPlayer, desiredAmount, CanRefundAmmo);
			primaryMagazine.contents = primaryMagazine.capacity;
			primaryMagazine.ammoType = OverrideProjectile;
			SendNetworkUpdateImmediate();
			ItemManager.DoRemoves();
			ownerPlayer.inventory.ServerUpdate(0f);
		}
	}
}
