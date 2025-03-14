using System;
using Oxide.Core;
using UnityEngine;

public class ModularCarSeat : MouseSteerableSeat
{
	[SerializeField]
	public Vector3 leftFootIKPos;

	[SerializeField]
	public Vector3 rightFootIKPos;

	[SerializeField]
	private Vector3 leftHandIKPos;

	[SerializeField]
	private Vector3 rightHandIKPos;

	public float providesComfort;

	[NonSerialized]
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
				return modularCar.PlayerCanUseThis(player, ModularCarCodeLock.LockType.Door);
			}
		}
		return true;
	}

	public override float GetComfort()
	{
		return providesComfort;
	}
}
