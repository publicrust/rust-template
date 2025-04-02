using UnityEngine;

public class KayakSeat : BaseVehicleSeat
{
	public ItemDefinition PaddleItem;

	public override void OnPlayerMounted()
	{
		base.OnPlayerMounted();
		if ((Object)(object)VehicleParent() != (Object)null)
		{
			VehicleParent().OnPlayerMounted();
		}
	}

	public override void OnPlayerDismounted(BasePlayer player)
	{
		base.OnPlayerDismounted(player);
		if ((Object)(object)VehicleParent() != (Object)null)
		{
			VehicleParent().OnPlayerDismounted(player);
		}
	}
}
