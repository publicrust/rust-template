public class BaseVehicleSeat : BaseVehicleMountPoint
{
	public float mountedAnimationSpeed;

	public bool sendClientInputToVehicleParent;

	public bool forcePlayerModelUpdate;

	public override void ScaleDamageForPlayer(BasePlayer player, HitInfo info)
	{
		BaseVehicle vehicleParent = GetVehicleParent();
		if (!(vehicleParent == null))
		{
			vehicleParent.ScaleDamageForPlayer(player, info);
		}
	}

	public override void MounteeTookDamage(BasePlayer mountee, HitInfo info)
	{
		BaseVehicle vehicleParent = GetVehicleParent();
		if (!(vehicleParent == null))
		{
			vehicleParent.MounteeTookDamage(mountee, info);
		}
	}

	public override void PlayerServerInput(InputState inputState, BasePlayer player)
	{
		BaseVehicle vehicleParent = GetVehicleParent();
		if (vehicleParent != null)
		{
			vehicleParent.PlayerServerInput(inputState, player);
		}
		base.PlayerServerInput(inputState, player);
	}

	public override void LightToggle(BasePlayer player)
	{
		BaseVehicle vehicleParent = GetVehicleParent();
		if (!(vehicleParent == null))
		{
			vehicleParent.LightToggle(player);
		}
	}

	public override float GetSteering(BasePlayer player)
	{
		return GetVehicleParent().GetSteering(player);
	}

	public override void SwitchParent(BaseEntity ent)
	{
	}
}
