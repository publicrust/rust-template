using System;
using System.Collections.Generic;
using UnityEngine;

public class DevBotSpawner : FacepunchBehaviour
{
	public GameObjectRef bot;

	public Transform waypointParent;

	public bool autoSelectLatestSpawnedGameObject = true;

	public float spawnRate = 1f;

	public int maxPopulation = 1;

	private Transform[] waypoints;

	private List<BaseEntity> _spawned = new List<BaseEntity>();

	public bool HasFreePopulation()
	{
		for (int num = _spawned.Count - 1; num >= 0; num--)
		{
			BaseEntity baseEntity = _spawned[num];
			if ((Object)(object)baseEntity == (Object)null || baseEntity.Health() <= 0f)
			{
				_spawned.Remove(baseEntity);
			}
		}
		if (_spawned.Count < maxPopulation)
		{
			return true;
		}
		return false;
	}

	public void SpawnBot()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		while (HasFreePopulation())
		{
			Vector3 position = waypoints[0].position;
			BaseEntity baseEntity = GameManager.server.CreateEntity(bot.resourcePath, position);
			if ((Object)(object)baseEntity == (Object)null)
			{
				break;
			}
			_spawned.Add(baseEntity);
			((Component)baseEntity).SendMessage("SetWaypoints", (object)waypoints, (SendMessageOptions)1);
			baseEntity.Spawn();
		}
	}

	public void Start()
	{
		waypoints = ((Component)waypointParent).GetComponentsInChildren<Transform>();
		((FacepunchBehaviour)this).InvokeRepeating((Action)SpawnBot, 5f, spawnRate);
	}
}
