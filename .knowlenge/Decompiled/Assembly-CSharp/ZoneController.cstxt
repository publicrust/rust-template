using System;
using Facepunch.Nexus;
using UnityEngine;

public abstract class ZoneController
{
	protected readonly NexusZoneClient ZoneClient;

	public static ZoneController Instance { get; set; }

	protected ZoneController(NexusZoneClient zoneClient)
	{
		ZoneClient = zoneClient ?? throw new ArgumentNullException("zoneClient");
	}

	public abstract string ChooseSpawnZone(ulong steamId, bool isAlreadyAssignedToThisZone);

	public virtual (Vector3 Position, Quaternion Rotation, bool PreserveY) ChooseTransferDestination(string sourceZone, string method, string from, string to, Vector3 position, Quaternion rotation)
	{
		switch (method)
		{
		case "console":
			return ChooseConsoleTransferDestination(sourceZone);
		case "ferry":
			return ChooseFerryTransferDestination(sourceZone);
		case "ocean":
			return ChooseOceanTransferDestination(sourceZone);
		default:
			Debug.LogError("Unhandled transfer method '" + method + "', using default destination");
			return ChooseTransferFallbackDestination(sourceZone);
		}
	}

	protected virtual (Vector3, Quaternion, bool) ChooseConsoleTransferDestination(string sourceZone)
	{
		BasePlayer.SpawnPoint spawnPoint = ServerMgr.FindSpawnPoint();
		return (spawnPoint.pos, spawnPoint.rot, false);
	}

	protected virtual (Vector3, Quaternion, bool) ChooseFerryTransferDestination(string sourceZone)
	{
		if (!NexusServer.TryGetIsland(sourceZone, out var island))
		{
			return ChooseTransferFallbackDestination(sourceZone);
		}
		if (!island.TryFindPosition(out var position))
		{
			Debug.LogWarning("Couldn't find a destination position for source zone '" + sourceZone + "'");
			return ChooseTransferFallbackDestination(sourceZone);
		}
		return (position, island.transform.rotation, true);
	}

	protected virtual (Vector3, Quaternion, bool) ChooseOceanTransferDestination(string sourceZone)
	{
		if (!NexusServer.TryGetIsland(sourceZone, out var island))
		{
			Debug.LogWarning("Couldn't find nexus island for source zone '" + sourceZone + "'");
			return ChooseTransferFallbackDestination(sourceZone);
		}
		if (!island.TryFindPosition(out var position))
		{
			Debug.LogWarning("Couldn't find a destination position for source zone '" + sourceZone + "'");
			return ChooseTransferFallbackDestination(sourceZone);
		}
		return (position, island.transform.rotation, true);
	}

	protected virtual (Vector3, Quaternion, bool) ChooseTransferFallbackDestination(string sourceZone)
	{
		Bounds worldBounds = NexusServer.GetWorldBounds();
		float num = Mathf.Max(worldBounds.extents.x, worldBounds.extents.z);
		Vector3 position;
		Vector3 obj = (NexusServer.TryGetIslandPosition(sourceZone, out position) ? (position + new Vector3(UnityEngine.Random.Range(-1, 1), 0f, UnityEngine.Random.Range(-1, 1)) * 100f) : (UnityEngine.Random.insideUnitCircle.XZ3D() * num * 0.75f));
		Vector3 vector = obj.WithY(WaterLevel.GetWaterSurface(obj, waves: false, volumes: false));
		Quaternion item = Quaternion.LookRotation((TerrainMeta.Center.WithY(vector.y) - vector).normalized, Vector3.up);
		return (vector, item, true);
	}

	public virtual bool CanRespawnAcrossZones(BasePlayer player)
	{
		return true;
	}
}
