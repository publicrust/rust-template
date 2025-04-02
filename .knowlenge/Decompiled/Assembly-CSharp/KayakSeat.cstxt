public class KayakSeat : BaseVehicleSeat
{
	public ItemDefinition PaddleItem;

	public override void OnPlayerMounted()
	{
		base.OnPlayerMounted();
		if (VehicleParent() != null)
		{
			VehicleParent().OnPlayerMounted();
		}
	}

	public override void OnPlayerDismounted(BasePlayer player)
	{
		base.OnPlayerDismounted(player);
		if (VehicleParent() != null)
		{
			VehicleParent().OnPlayerDismounted(player);
		}
	}
}
