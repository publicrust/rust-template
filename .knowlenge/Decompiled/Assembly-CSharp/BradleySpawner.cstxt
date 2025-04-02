using System;
using ConVar;
using Rust;
using UnityEngine;

public class BradleySpawner : MonoBehaviour, IServerComponent
{
	public BasePath path;

	public GameObjectRef bradleyPrefab;

	[NonSerialized]
	public BradleyAPC spawned;

	public bool initialSpawn;

	public float minRespawnTimeMinutes = 5f;

	public float maxRespawnTimeMinutes = 5f;

	public static BradleySpawner singleton;

	private bool pendingRespawn;

	public void Start()
	{
		singleton = this;
		Invoke("DelayedStart", 3f);
	}

	public void DelayedStart()
	{
		if (initialSpawn)
		{
			DoRespawn();
		}
		InvokeRepeating("CheckIfRespawnNeeded", 0f, 5f);
	}

	public void CheckIfRespawnNeeded()
	{
		if (!pendingRespawn && (spawned == null || !spawned.IsAlive()))
		{
			ScheduleRespawn();
		}
	}

	public void ScheduleRespawn()
	{
		CancelInvoke("DoRespawn");
		Invoke("DoRespawn", UnityEngine.Random.Range(Bradley.respawnDelayMinutes - Bradley.respawnDelayVariance, Bradley.respawnDelayMinutes + Bradley.respawnDelayVariance) * 60f);
		pendingRespawn = true;
	}

	public void DoRespawn()
	{
		if (!Rust.Application.isLoading && !Rust.Application.isLoadingSave)
		{
			SpawnBradley();
		}
		pendingRespawn = false;
	}

	public void SpawnBradley()
	{
		if (spawned != null)
		{
			Debug.LogWarning("Bradley attempting to spawn but one already exists!");
		}
		else if (Bradley.enabled)
		{
			Vector3 position = path.interestZones[UnityEngine.Random.Range(0, path.interestZones.Count)].transform.position;
			BaseEntity baseEntity = GameManager.server.CreateEntity(bradleyPrefab.resourcePath, position);
			BradleyAPC component = baseEntity.GetComponent<BradleyAPC>();
			component.RoadSpawned = false;
			if ((bool)component)
			{
				baseEntity.Spawn();
				component.InstallPatrolPath(path);
			}
			else
			{
				baseEntity.Kill();
			}
			Vector3 vector = position;
			Debug.Log("BradleyAPC Spawned at :" + vector.ToString());
			spawned = component;
		}
	}
}
