using UnityEngine;

public class BaseVehicleSeat : BaseVehicleMountPoint
{
	[Header("Vehicle Seat")]
	public float mountedAnimationSpeed;

	public bool sendClientInputToVehicleParent;

	public bool forcePlayerModelUpdate;

	public bool giveCrosshair;

	public bool canTeamInteract = true;

	public override void ScaleDamageForPlayer(BasePlayer player, HitInfo info)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (!((Object)(object)baseVehicle == (Object)null))
		{
			baseVehicle.ScaleDamageForPlayer(player, info);
		}
	}

	public override void MounteeTookDamage(BasePlayer mountee, HitInfo info)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (!((Object)(object)baseVehicle == (Object)null))
		{
			baseVehicle.MounteeTookDamage(mountee, info);
		}
	}

	public override void PlayerServerInput(InputState inputState, BasePlayer player)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if ((Object)(object)baseVehicle != (Object)null)
		{
			baseVehicle.PlayerServerInput(inputState, player);
		}
		base.PlayerServerInput(inputState, player);
	}

	public override void LightToggle(BasePlayer player)
	{
		BaseVehicle baseVehicle = VehicleParent();
		if (!((Object)(object)baseVehicle == (Object)null))
		{
			baseVehicle.LightToggle(player);
		}
	}

	public override void SwitchParent(BaseEntity ent)
	{
	}

	public override Vector3 GetMountRagdollVelocity(BasePlayer player)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		BaseVehicle baseVehicle = VehicleParent();
		if ((Object)(object)baseVehicle != (Object)null)
		{
			return baseVehicle.GetMountRagdollVelocity(player);
		}
		return base.GetMountRagdollVelocity(player);
	}
}
