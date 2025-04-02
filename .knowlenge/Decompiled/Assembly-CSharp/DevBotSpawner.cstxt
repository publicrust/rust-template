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
			if (baseEntity == null || baseEntity.Health() <= 0f)
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
		while (HasFreePopulation())
		{
			Vector3 position = waypoints[0].position;
			BaseEntity baseEntity = GameManager.server.CreateEntity(bot.resourcePath, position);
			if (baseEntity == null)
			{
				break;
			}
			_spawned.Add(baseEntity);
			baseEntity.SendMessage("SetWaypoints", waypoints, SendMessageOptions.DontRequireReceiver);
			baseEntity.Spawn();
		}
	}

	public void Start()
	{
		waypoints = waypointParent.GetComponentsInChildren<Transform>();
		InvokeRepeating(SpawnBot, 5f, spawnRate);
	}
}
