public class BaseVehicleMountPoint : BaseMountable
{
	public override bool DirectlyMountable()
	{
		return false;
	}

	public override BaseVehicle VehicleParent()
	{
		BaseVehicle baseVehicle = GetParentEntity() as BaseVehicle;
		while (baseVehicle != null && !baseVehicle.IsVehicleRoot())
		{
			BaseVehicle baseVehicle2 = baseVehicle.GetParentEntity() as BaseVehicle;
			if (baseVehicle2 == null)
			{
				return baseVehicle;
			}
			baseVehicle = baseVehicle2;
		}
		return baseVehicle;
	}

	public override bool BlocksWaterFor(BasePlayer player)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (baseVehicle == null)
		{
			return false;
		}
		return baseVehicle.BlocksWaterFor(player);
	}

	public override float WaterFactorForPlayer(BasePlayer player)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (baseVehicle == null)
		{
			return 0f;
		}
		return baseVehicle.WaterFactorForPlayer(player);
	}

	public override float AirFactor()
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (baseVehicle == null)
		{
			return 0f;
		}
		return baseVehicle.AirFactor();
	}
}
