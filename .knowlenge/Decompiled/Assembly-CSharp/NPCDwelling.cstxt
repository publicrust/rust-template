using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class NPCDwelling : BaseEntity
{
	public NPCSpawner npcSpawner;

	public float NPCSpawnChance = 1f;

	public SpawnGroup[] spawnGroups;

	public AIMovePoint[] movePoints;

	public AICoverPoint[] coverPoints;

	public override void ServerInit()
	{
		base.ServerInit();
		UpdateInformationZone(remove: false);
		if (npcSpawner != null && Random.Range(0f, 1f) <= NPCSpawnChance)
		{
			npcSpawner.SpawnInitial();
		}
		SpawnGroup[] array = spawnGroups;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SpawnInitial();
		}
	}

	public override void DestroyShared()
	{
		if (base.isServer)
		{
			CleanupSpawned();
		}
		base.DestroyShared();
		if (base.isServer)
		{
			UpdateInformationZone(remove: true);
		}
	}

	public bool ValidateAIPoint(Vector3 pos)
	{
		base.gameObject.SetActive(value: false);
		bool result = !GamePhysics.CheckSphere(pos + Vector3.up * 0.6f, 0.5f, 65537);
		base.gameObject.SetActive(value: true);
		return result;
	}

	public void UpdateInformationZone(bool remove)
	{
		AIInformationZone forPoint = AIInformationZone.GetForPoint(base.transform.position);
		if (!(forPoint == null))
		{
			if (remove)
			{
				forPoint.RemoveDynamicAIPoints(movePoints, coverPoints);
			}
			else
			{
				forPoint.AddDynamicAIPoints(movePoints, coverPoints, ValidateAIPoint);
			}
		}
	}

	public void CheckDespawn()
	{
		if (!PlayersNearby() && (!npcSpawner || npcSpawner.currentPopulation <= 0))
		{
			CleanupSpawned();
			Kill();
		}
	}

	public void CleanupSpawned()
	{
		if (spawnGroups != null)
		{
			SpawnGroup[] array = spawnGroups;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
		}
		if ((bool)npcSpawner)
		{
			npcSpawner.Clear();
		}
	}

	public bool PlayersNearby()
	{
		List<BasePlayer> obj = Pool.Get<List<BasePlayer>>();
		Vis.Entities(base.transform.position, TimeoutPlayerCheckRadius(), obj, 131072);
		bool result = false;
		foreach (BasePlayer item in obj)
		{
			if (!item.IsSleeping() && item.IsAlive())
			{
				result = true;
				break;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return result;
	}

	public virtual float TimeoutPlayerCheckRadius()
	{
		return 10f;
	}
}
