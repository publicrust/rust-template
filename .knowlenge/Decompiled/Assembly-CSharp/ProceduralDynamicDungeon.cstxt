using System.Collections;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using Rust;
using UnityEngine;

public class ProceduralDynamicDungeon : BaseEntity
{
	public int gridResolution = 6;

	public float gridSpacing = 12f;

	public bool[] grid;

	public List<GameObjectRef> cellPrefabReferences = new List<GameObjectRef>();

	public List<ProceduralDungeonCell> spawnedCells = new List<ProceduralDungeonCell>();

	public EnvironmentVolume envVolume;

	public MonumentNavMesh monumentNavMesh;

	public GameObjectRef exitPortalPrefab;

	private EntityRef<BasePortal> exitPortal;

	public TriggerRadiation exitRadiation;

	public uint seed;

	public uint baseseed;

	public Vector3 mapOffset = Vector3.zero;

	public static readonly List<ProceduralDynamicDungeon> dungeons = new List<ProceduralDynamicDungeon>();

	public ProceduralDungeonCell entranceHack;

	public override void InitShared()
	{
		base.InitShared();
		dungeons.Add(this);
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		foreach (ProceduralDungeonCell spawnedCell in spawnedCells)
		{
			EntityFlag_Toggle[] componentsInChildren = spawnedCell.GetComponentsInChildren<EntityFlag_Toggle>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DoUpdate(this);
			}
		}
	}

	public BaseEntity GetExitPortal(bool serverSide)
	{
		return exitPortal.Get(serverSide);
	}

	public override void DestroyShared()
	{
		dungeons.Remove(this);
		RetireAllCells();
		base.DestroyShared();
	}

	public bool ContainsAnyPlayers()
	{
		Bounds bounds = new Bounds(base.transform.position, new Vector3((float)gridResolution * gridSpacing, 20f, (float)gridResolution * gridSpacing));
		for (int i = 0; i < BasePlayer.activePlayerList.Count; i++)
		{
			BasePlayer basePlayer = BasePlayer.activePlayerList[i];
			if (bounds.Contains(basePlayer.transform.position))
			{
				return true;
			}
		}
		for (int j = 0; j < BasePlayer.sleepingPlayerList.Count; j++)
		{
			BasePlayer basePlayer2 = BasePlayer.sleepingPlayerList[j];
			if (bounds.Contains(basePlayer2.transform.position))
			{
				return true;
			}
		}
		return false;
	}

	public void KillPlayers()
	{
		Bounds bounds = new Bounds(base.transform.position, new Vector3((float)gridResolution * gridSpacing, 20f, (float)gridResolution * gridSpacing));
		for (int i = 0; i < BasePlayer.activePlayerList.Count; i++)
		{
			BasePlayer basePlayer = BasePlayer.activePlayerList[i];
			if (bounds.Contains(basePlayer.transform.position))
			{
				basePlayer.Hurt(10000f, DamageType.Suicide, null, useProtection: false);
			}
		}
		for (int j = 0; j < BasePlayer.sleepingPlayerList.Count; j++)
		{
			BasePlayer basePlayer2 = BasePlayer.sleepingPlayerList[j];
			if (bounds.Contains(basePlayer2.transform.position))
			{
				basePlayer2.Hurt(10000f, DamageType.Suicide, null, useProtection: false);
			}
		}
	}

	internal override void DoServerDestroy()
	{
		KillPlayers();
		if (exitPortal.IsValid(serverside: true))
		{
			exitPortal.Get(serverside: true).Kill();
		}
		base.DoServerDestroy();
	}

	public override void ServerInit()
	{
		if (!Rust.Application.isLoadingSave)
		{
			baseseed = (seed = (uint)Random.Range(0, 12345567));
			int num = (int)seed;
			Debug.Log("Spawning dungeon with seed :" + num);
		}
		base.ServerInit();
		if (!Rust.Application.isLoadingSave)
		{
			DoGeneration();
			BasePortal component = GameManager.server.CreateEntity(exitPortalPrefab.resourcePath, entranceHack.exitPointHack.position, entranceHack.exitPointHack.rotation).GetComponent<BasePortal>();
			component.Spawn();
			exitPortal.Set(component);
		}
	}

	public void DoGeneration()
	{
		GenerateGrid();
		CreateAIZ();
		if (base.isServer)
		{
			Debug.Log("Server DoGeneration,calling routine update nav mesh");
			StartCoroutine(UpdateNavMesh());
		}
		Invoke(InitSpawnGroups, 1f);
	}

	private void CreateAIZ()
	{
		AIInformationZone aIInformationZone = base.gameObject.AddComponent<AIInformationZone>();
		aIInformationZone.UseCalculatedCoverDistances = false;
		aIInformationZone.bounds.extents = new Vector3((float)gridResolution * gridSpacing * 0.75f, 10f, (float)gridResolution * gridSpacing * 0.75f);
		aIInformationZone.Init();
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		DoGeneration();
	}

	public IEnumerator UpdateNavMesh()
	{
		Debug.Log("Dungeon Building navmesh");
		yield return StartCoroutine(monumentNavMesh.UpdateNavMeshAndWait());
		Debug.Log("Dungeon done!");
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.proceduralDungeon == null)
		{
			info.msg.proceduralDungeon = Pool.Get<ProceduralDungeon>();
		}
		info.msg.proceduralDungeon.seed = baseseed;
		info.msg.proceduralDungeon.exitPortalID = exitPortal.uid;
		info.msg.proceduralDungeon.mapOffset = mapOffset;
	}

	public BasePortal GetExitPortal()
	{
		return exitPortal.Get(serverside: true);
	}

	public void InitSpawnGroups()
	{
		foreach (ProceduralDungeonCell spawnedCell in spawnedCells)
		{
			if (!(entranceHack != null) || !(Vector3.Distance(entranceHack.transform.position, spawnedCell.transform.position) < 20f))
			{
				SpawnGroup[] spawnGroups = spawnedCell.spawnGroups;
				for (int i = 0; i < spawnGroups.Length; i++)
				{
					spawnGroups[i].Spawn();
				}
			}
		}
	}

	public void CleanupSpawnGroups()
	{
		foreach (ProceduralDungeonCell spawnedCell in spawnedCells)
		{
			SpawnGroup[] spawnGroups = spawnedCell.spawnGroups;
			for (int i = 0; i < spawnGroups.Length; i++)
			{
				spawnGroups[i].Clear();
			}
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.proceduralDungeon != null)
		{
			baseseed = (seed = info.msg.proceduralDungeon.seed);
			exitPortal.uid = info.msg.proceduralDungeon.exitPortalID;
			mapOffset = info.msg.proceduralDungeon.mapOffset;
		}
	}

	[ContextMenu("Test Grid")]
	[ExecuteInEditMode]
	public void GenerateGrid()
	{
		Vector3 vector = base.transform.position - new Vector3((float)gridResolution * gridSpacing * 0.5f, 0f, (float)gridResolution * gridSpacing * 0.5f);
		RetireAllCells();
		grid = new bool[gridResolution * gridResolution];
		for (int i = 0; i < grid.Length; i++)
		{
			grid[i] = SeedRandom.Range(ref seed, 0, 2) == 0;
		}
		SetEntrance(3, 0);
		for (int j = 0; j < gridResolution; j++)
		{
			for (int k = 0; k < gridResolution; k++)
			{
				if (GetGridState(j, k) && !HasPathToEntrance(j, k))
				{
					SetGridState(j, k, state: false);
				}
			}
		}
		for (int l = 0; l < gridResolution; l++)
		{
			for (int m = 0; m < gridResolution; m++)
			{
				if (!GetGridState(l, m))
				{
					continue;
				}
				bool gridState = GetGridState(l, m + 1);
				bool gridState2 = GetGridState(l, m - 1);
				bool gridState3 = GetGridState(l - 1, m);
				bool gridState4 = GetGridState(l + 1, m);
				bool flag = IsEntrance(l, m);
				GameObjectRef gameObjectRef = null;
				ProceduralDungeonCell proceduralDungeonCell = null;
				if (proceduralDungeonCell == null)
				{
					foreach (GameObjectRef cellPrefabReference in cellPrefabReferences)
					{
						ProceduralDungeonCell component = cellPrefabReference.Get().GetComponent<ProceduralDungeonCell>();
						if (component.north == gridState && component.south == gridState2 && component.west == gridState3 && component.east == gridState4 && component.entrance == flag)
						{
							proceduralDungeonCell = component;
							gameObjectRef = cellPrefabReference;
							break;
						}
					}
				}
				if (proceduralDungeonCell != null)
				{
					ProceduralDungeonCell proceduralDungeonCell2 = CellInstantiate(gameObjectRef.resourcePath);
					proceduralDungeonCell2.transform.position = vector + new Vector3((float)l * gridSpacing, 0f, (float)m * gridSpacing);
					spawnedCells.Add(proceduralDungeonCell2);
					proceduralDungeonCell2.transform.SetParent(base.transform);
					if (proceduralDungeonCell2.entrance && entranceHack == null)
					{
						entranceHack = proceduralDungeonCell2;
					}
				}
			}
		}
	}

	public ProceduralDungeonCell CellInstantiate(string path)
	{
		if (base.isServer)
		{
			return GameManager.server.CreatePrefab(path).GetComponent<ProceduralDungeonCell>();
		}
		return null;
	}

	public void RetireCell(GameObject cell)
	{
		if (!(cell == null) && base.isServer)
		{
			GameManager.server.Retire(cell);
		}
	}

	public void RetireAllCells()
	{
		if (base.isServer)
		{
			CleanupSpawnGroups();
		}
		for (int num = spawnedCells.Count - 1; num >= 0; num--)
		{
			ProceduralDungeonCell proceduralDungeonCell = spawnedCells[num];
			if ((bool)proceduralDungeonCell)
			{
				RetireCell(proceduralDungeonCell.gameObject);
			}
		}
		spawnedCells.Clear();
	}

	public bool CanSeeEntrance(int x, int y, ref List<int> checkedCells)
	{
		int gridIndex = GetGridIndex(x, y);
		if (checkedCells.Contains(gridIndex))
		{
			return false;
		}
		checkedCells.Add(gridIndex);
		if (!GetGridState(x, y))
		{
			return false;
		}
		if (IsEntrance(x, y))
		{
			return true;
		}
		bool num = CanSeeEntrance(x, y + 1, ref checkedCells);
		bool flag = CanSeeEntrance(x, y - 1, ref checkedCells);
		bool flag2 = CanSeeEntrance(x - 1, y, ref checkedCells);
		bool flag3 = CanSeeEntrance(x + 1, y, ref checkedCells);
		return num || flag3 || flag2 || flag;
	}

	public bool HasPathToEntrance(int x, int y)
	{
		List<int> checkedCells = new List<int>();
		bool result = CanSeeEntrance(x, y, ref checkedCells);
		checkedCells.Clear();
		return result;
	}

	public bool CanFindEntrance(int x, int y)
	{
		new List<int>();
		GetGridState(x, y + 1);
		GetGridState(x, y - 1);
		GetGridState(x - 1, y);
		GetGridState(x + 1, y);
		return true;
	}

	public bool IsEntrance(int x, int y)
	{
		return GetGridIndex(x, y) == GetEntranceIndex();
	}

	public int GetEntranceIndex()
	{
		return GetGridIndex(3, 0);
	}

	public void SetEntrance(int x, int y)
	{
		grid[GetGridIndex(x, y)] = true;
		grid[GetGridIndex(x, y + 1)] = true;
		grid[GetGridIndex(x - 1, y)] = false;
		grid[GetGridIndex(x + 1, y)] = false;
		grid[GetGridIndex(x, y + 2)] = true;
		grid[GetGridIndex(x + 1, y + 2)] = SeedRandom.Range(ref seed, 0, 1) == 1;
		grid[GetGridIndex(x + 2, y + 2)] = SeedRandom.Range(ref seed, 0, 1) == 1;
		grid[GetGridIndex(x, y + 3)] = true;
		grid[GetGridIndex(x, y + 4)] = true;
		grid[GetGridIndex(x - 1, y + 4)] = SeedRandom.Range(ref seed, 0, 1) == 1;
		grid[GetGridIndex(x - 2, y + 4)] = SeedRandom.Range(ref seed, 0, 1) == 1;
	}

	public void SetGridState(int x, int y, bool state)
	{
		int gridIndex = GetGridIndex(x, y);
		grid[gridIndex] = state;
	}

	public bool GetGridState(int x, int y)
	{
		if (GetGridIndex(x, y) >= grid.Length)
		{
			return false;
		}
		if (x < 0 || x >= gridResolution)
		{
			return false;
		}
		if (y < 0 || y >= gridResolution)
		{
			return false;
		}
		return grid[GetGridIndex(x, y)];
	}

	public int GetGridX(int index)
	{
		return index % gridResolution;
	}

	public int GetGridY(int index)
	{
		return Mathf.FloorToInt((float)index / (float)gridResolution);
	}

	public int GetGridIndex(int x, int y)
	{
		return y * gridResolution + x;
	}
}
