using UnityEngine;

public class VehicleSpawnPoint : SpaceCheckingSpawnPoint
{
	public override void ObjectSpawned(SpawnPointInstance instance)
	{
		base.ObjectSpawned(instance);
		AddStartingFuel(((Component)instance).gameObject.ToBaseEntity() as VehicleSpawner.IVehicleSpawnUser);
	}

	public static void AddStartingFuel(VehicleSpawner.IVehicleSpawnUser vehicle)
	{
		vehicle?.GetFuelSystem()?.AddFuel(vehicle.StartingFuelUnits());
	}
}
