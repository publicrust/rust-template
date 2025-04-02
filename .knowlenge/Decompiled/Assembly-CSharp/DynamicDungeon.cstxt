using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicDungeon : BaseEntity, IMissionEntityListener
{
	public Transform exitEntitySpawn;

	public GameObjectRef exitEntity;

	public string exitString;

	public MonumentNavMesh monumentNavMesh;

	private static List<DynamicDungeon> _dungeons = new List<DynamicDungeon>();

	public GameObjectRef portalPrefab;

	public Transform portalSpawnPoint;

	public BasePortal exitPortal;

	public GameObjectRef doorPrefab;

	public Transform doorSpawnPoint;

	public Door doorInstance;

	public static Vector3 nextDungeonPos = Vector3.zero;

	public static Vector3 dungeonStartPoint = Vector3.zero;

	public static float dungeonSpacing = 50f;

	public SpawnGroup[] spawnGroups;

	public bool AutoMergeAIZones = true;

	public static void AddDungeon(DynamicDungeon newDungeon)
	{
		_dungeons.Add(newDungeon);
		Vector3 position = newDungeon.transform.position;
		if (position.y >= nextDungeonPos.y)
		{
			nextDungeonPos = position + Vector3.up * dungeonSpacing;
		}
	}

	public static void RemoveDungeon(DynamicDungeon dungeon)
	{
		Vector3 position = dungeon.transform.position;
		if (_dungeons.Contains(dungeon))
		{
			_dungeons.Remove(dungeon);
		}
		nextDungeonPos = position;
	}

	public static Vector3 GetNextDungeonPoint()
	{
		if (nextDungeonPos == Vector3.zero)
		{
			nextDungeonPos = Vector3.one * 700f;
		}
		return nextDungeonPos;
	}

	public IEnumerator UpdateNavMesh()
	{
		Debug.Log("Dungeon Building navmesh");
		yield return StartCoroutine(monumentNavMesh.UpdateNavMeshAndWait());
		Debug.Log("Dunngeon done!");
	}

	public override void DestroyShared()
	{
		if (base.isServer)
		{
			SpawnGroup[] array = spawnGroups;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			if (exitPortal != null)
			{
				exitPortal.Kill();
			}
			RemoveDungeon(this);
		}
		base.DestroyShared();
	}

	public override void ServerInit()
	{
		base.ServerInit();
		AddDungeon(this);
		if (portalPrefab.isValid)
		{
			exitPortal = GameManager.server.CreateEntity(portalPrefab.resourcePath, portalSpawnPoint.position, portalSpawnPoint.rotation).GetComponent<BasePortal>();
			exitPortal.SetParent(this, worldPositionStays: true);
			exitPortal.Spawn();
		}
		if (doorPrefab.isValid)
		{
			doorInstance = GameManager.server.CreateEntity(doorPrefab.resourcePath, doorSpawnPoint.position, doorSpawnPoint.rotation).GetComponent<Door>();
			doorInstance.SetParent(this, worldPositionStays: true);
			doorInstance.Spawn();
		}
		MergeAIZones();
		StartCoroutine(UpdateNavMesh());
	}

	private void MergeAIZones()
	{
		if (!AutoMergeAIZones)
		{
			return;
		}
		List<AIInformationZone> list = GetComponentsInChildren<AIInformationZone>().ToList();
		foreach (AIInformationZone item in list)
		{
			item.AddInitialPoints();
		}
		GameObject gameObject = new GameObject("AIZ");
		gameObject.transform.position = base.transform.position;
		AIInformationZone.Merge(list, gameObject).ShouldSleepAI = false;
		gameObject.transform.SetParent(base.transform);
	}

	public void MissionStarted(BasePlayer assignee, BaseMission.MissionInstance instance)
	{
		foreach (MissionEntity value in instance.missionEntities.Values)
		{
			BunkerEntrance component = value.GetComponent<BunkerEntrance>();
			if (component != null)
			{
				BasePortal portalInstance = component.portalInstance;
				if ((bool)portalInstance)
				{
					portalInstance.targetPortal = exitPortal;
					exitPortal.targetPortal = portalInstance;
					Debug.Log("Dungeon portal linked...");
				}
			}
		}
	}

	public void MissionEnded(BasePlayer assignee, BaseMission.MissionInstance instance)
	{
	}
}
