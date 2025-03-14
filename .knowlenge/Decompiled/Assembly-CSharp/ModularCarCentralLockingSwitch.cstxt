using System;
using UnityEngine;

[Serializable]
public class ModularCarCentralLockingSwitch : VehicleModuleButtonComponent
{
	public Transform centralLockingSwitch;

	public Vector3 switchOffPos;

	public Vector3 switchOnPos;

	public override void ServerUse(BasePlayer player, BaseVehicleModule parentModule)
	{
		if (parentModule.Vehicle is ModularCar modularCar)
		{
			modularCar.CarLock.ToggleCentralLocking();
		}
	}
}
