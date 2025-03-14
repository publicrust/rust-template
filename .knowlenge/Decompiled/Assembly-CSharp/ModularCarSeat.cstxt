using Oxide.Core;
using UnityEngine;

public class ModularCarSeat : BaseVehicleSeat
{
	[SerializeField]
	private bool supportsMouseSteer;

	[SerializeField]
	private Vector3 leftFootIKPos;

	[SerializeField]
	private Vector3 rightFootIKPos;

	public VehicleModuleSeating associatedSeatingModule;

	public override bool CanSwapToThis(BasePlayer player)
	{
		object obj = Interface.CallHook("CanSwapToSeat", player, this);
		if (obj is bool)
		{
			return (bool)obj;
		}
		if (associatedSeatingModule.DoorsAreLockable)
		{
			ModularCar modularCar = associatedSeatingModule.Vehicle as ModularCar;
			if (modularCar != null)
			{
				return modularCar.PlayerCanOpenThis(player, ModularCarLock.LockType.Door);
			}
		}
		return true;
	}
}
