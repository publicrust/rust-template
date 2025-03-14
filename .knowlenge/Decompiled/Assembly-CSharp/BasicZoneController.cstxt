using System.Collections.Generic;
using Facepunch;
using Facepunch.Nexus;
using Facepunch.Nexus.Models;
using UnityEngine;

public class BasicZoneController : ZoneController
{
	public BasicZoneController(NexusZoneClient zoneClient)
		: base(zoneClient)
	{
	}

	public override string ChooseSpawnZone(ulong steamId, bool isAlreadyAssignedToThisZone)
	{
		if (NexusUtil.IsStarterZone(ZoneClient.Zone))
		{
			return ZoneClient.Zone.Key;
		}
		string key = ZoneClient.Zone.Key;
		List<NexusZoneDetails> obj = Pool.Get<List<NexusZoneDetails>>();
		GetStarterZones(obj);
		if (obj.Count > 0)
		{
			int index = Random.Range(0, obj.Count);
			key = obj[index].Key;
		}
		Pool.FreeUnmanaged(ref obj);
		return key;
	}

	private void GetStarterZones(List<NexusZoneDetails> zones)
	{
		if (ZoneClient?.Nexus?.Zones == null)
		{
			return;
		}
		foreach (NexusZoneDetails zone in ZoneClient.Nexus.Zones)
		{
			if (NexusUtil.IsStarterZone(zone))
			{
				zones.Add(zone);
			}
		}
	}
}
