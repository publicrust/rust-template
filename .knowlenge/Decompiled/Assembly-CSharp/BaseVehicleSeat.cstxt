public class BaseVehicleSeat : BaseVehicleMountPoint
{
	public float mountedAnimationSpeed;

	public bool sendClientInputToVehicleParent;

	public bool forcePlayerModelUpdate;

	public override void ScaleDamageForPlayer(BasePlayer player, HitInfo info)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (!(baseVehicle == null))
		{
			baseVehicle.ScaleDamageForPlayer(player, info);
		}
	}

	public override void MounteeTookDamage(BasePlayer mountee, HitInfo info)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (!(baseVehicle == null))
		{
			baseVehicle.MounteeTookDamage(mountee, info);
		}
	}

	public override void PlayerServerInput(InputState inputState, BasePlayer player)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (baseVehicle != null)
		{
			baseVehicle.PlayerServerInput(inputState, player);
		}
		base.PlayerServerInput(inputState, player);
	}

	public override void LightToggle(BasePlayer player)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (!(baseVehicle == null))
		{
			baseVehicle.LightToggle(player);
		}
	}

	public override void SwitchParent(BaseEntity ent)
	{
	}
}
