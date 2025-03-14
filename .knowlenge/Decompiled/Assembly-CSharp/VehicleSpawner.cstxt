using System;
using System.Collections.Generic;
using Facepunch;
using Facepunch.Rust;
using UnityEngine;

public class VehicleSpawner : BaseEntity
{
	[Serializable]
	public class SpawnPair
	{
		public string message;

		public GameObjectRef prefabToSpawn;
	}

	public float spawnNudgeRadius = 6f;

	public float cleanupRadius = 10f;

	public float occupyRadius = 5f;

	public SpawnPair[] objectsToSpawn;

	public Transform spawnOffset;

	public float safeRadius = 10f;

	protected virtual bool LogAnalytics => true;

	public virtual int GetOccupyLayer()
	{
		return 32768;
	}

	public BaseVehicle GetVehicleOccupying()
	{
		BaseVehicle result = null;
		List<BaseVehicle> obj = Pool.GetList<BaseVehicle>();
		Vis.Entities(spawnOffset.transform.position, occupyRadius, obj, GetOccupyLayer(), QueryTriggerInteraction.Ignore);
		if (obj.Count > 0)
		{
			result = obj[0];
		}
		Pool.FreeList(ref obj);
		return result;
	}

	public bool IsPadOccupied()
	{
		BaseVehicle vehicleOccupying = GetVehicleOccupying();
		if (vehicleOccupying != null)
		{
			return !vehicleOccupying.IsDespawnEligable();
		}
		return false;
	}

	public override void OnEntityMessage(BaseEntity from, string msg)
	{
		BasePlayer newOwner = null;
		NPCTalking component = from.GetComponent<NPCTalking>();
		if ((bool)component)
		{
			newOwner = component.GetActionPlayer();
		}
		SpawnPair[] array = objectsToSpawn;
		foreach (SpawnPair spawnPair in array)
		{
			if (msg == spawnPair.message)
			{
				SpawnVehicle(spawnPair.prefabToSpawn.resourcePath, newOwner);
				break;
			}
		}
	}

	public BaseVehicle SpawnVehicle(string prefabToSpawn, BasePlayer newOwner)
	{
		CleanupArea(cleanupRadius);
		NudgePlayersInRadius(spawnNudgeRadius);
		BaseEntity baseEntity = GameManager.server.CreateEntity(prefabToSpawn, spawnOffset.transform.position, spawnOffset.transform.rotation);
		baseEntity.Spawn();
		BaseVehicle component = baseEntity.GetComponent<BaseVehicle>();
		if (newOwner != null)
		{
			component.SetupOwner(newOwner, spawnOffset.transform.position, safeRadius);
		}
		VehicleSpawnPoint.AddStartingFuel(component);
		if (LogAnalytics)
		{
			Analytics.Server.VehiclePurchased(component.ShortPrefabName);
		}
		if (newOwner != null)
		{
			Analytics.Azure.OnVehiclePurchased(newOwner, baseEntity);
		}
		return component;
	}

	public void CleanupArea(float radius)
	{
		List<BaseVehicle> obj = Pool.GetList<BaseVehicle>();
		Vis.Entities(spawnOffset.transform.position, radius, obj, 32768);
		foreach (BaseVehicle item in obj)
		{
			if (!item.isClient && !item.IsDestroyed)
			{
				item.Kill();
			}
		}
		List<ServerGib> obj2 = Pool.GetList<ServerGib>();
		Vis.Entities(spawnOffset.transform.position, radius, obj2, 67108865);
		foreach (ServerGib item2 in obj2)
		{
			if (!item2.isClient)
			{
				item2.Kill();
			}
		}
		Pool.FreeList(ref obj);
		Pool.FreeList(ref obj2);
	}

	public void NudgePlayersInRadius(float radius)
	{
		List<BasePlayer> obj = Pool.GetList<BasePlayer>();
		Vis.Entities(spawnOffset.transform.position, radius, obj, 131072);
		foreach (BasePlayer item in obj)
		{
			if (!item.IsNpc && !item.isMounted && item.IsConnected)
			{
				Vector3 position = spawnOffset.transform.position;
				position += Vector3Ex.Direction2D(item.transform.position, spawnOffset.transform.position) * radius;
				position += Vector3.up * 0.1f;
				item.MovePosition(position);
				item.ClientRPCPlayer(null, item, "ForcePositionTo", position);
			}
		}
		Pool.FreeList(ref obj);
	}
}
