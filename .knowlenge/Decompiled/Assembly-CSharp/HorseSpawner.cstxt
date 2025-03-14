using UnityEngine;

public class HorseSpawner : VehicleSpawner
{
	public float respawnDelay = 10f;

	public float respawnDelayVariance = 5f;

	public bool spawnForSale = true;

	protected override bool LogAnalytics => false;

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRandomized(RespawnHorse, Random.Range(0f, 4f), respawnDelay, respawnDelayVariance);
	}

	public override int GetOccupyLayer()
	{
		return 2048;
	}

	public void RespawnHorse()
	{
		if (GetVehicleOccupying() != null)
		{
			return;
		}
		BaseVehicle baseVehicle = SpawnVehicle(objectsToSpawn[0].prefabToSpawn.resourcePath, null);
		if (spawnForSale)
		{
			RidableHorse ridableHorse = baseVehicle as RidableHorse;
			if (ridableHorse != null)
			{
				ridableHorse.SetForSale();
			}
		}
	}
}
