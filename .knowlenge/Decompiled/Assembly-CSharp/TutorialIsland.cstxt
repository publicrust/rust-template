using System;
using System.Collections;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Facepunch.Rust;
using Network;
using Network.Visibility;
using ProtoBuf;
using UnityEngine;

public class TutorialIsland : BaseEntity, IEntityPingSource
{
	public struct IslandBounds
	{
		public OBB WorldBounds;

		public uint Id;

		public bool Contains(Vector3 pos)
		{
			return WorldBounds.Contains(pos);
		}
	}

	public EntityRef<BasePlayer> ForPlayer;

	public Transform InitialSpawnPoint;

	public Transform MidMissionSpawnPoint;

	public int SpawnLocationIndex;

	public TutorialNPC StartTutorialNPC;

	public TutorialContainer TutorialContainer;

	public MonumentNavMesh MonumentNavMesh;

	public FoliageGridBaked FoliageGrid;

	public MeshTerrainRoot MeshTerrain;

	public Transform KayakPoint;

	public BaseMission FinalMission;

	[Range(0f, 24f)]
	public float TimeOfDay = 18f;

	public ItemDefinition rockDefinition;

	public WeatherPreset Weather;

	[Header("Debugging")]
	public BaseMission TestMission;

	private TutorialBuildTarget[] buildTargets;

	public static Translate.Phrase NoTutorialIslandsAvailablePhrase = new Translate.Phrase("no_tutorial_islands_available", "No Tutorial Islands are currently available, please try again later...");

	public static Translate.Phrase TutorialIslandStartCooldown = new Translate.Phrase("tutorial_island_start_cooldown", "Please wait {0} seconds before starting the tutorial again");

	public static ListHashSet<IslandBounds> BoundsListServer = new ListHashSet<IslandBounds>();

	public static float TutorialBoundsSize = 400f;

	[ServerVar(Saved = true)]
	public static bool SpawnTutorialIslandForNewPlayer = true;

	private static ListHashSet<TutorialIsland> ActiveIslandsServer = new ListHashSet<TutorialIsland>();

	[ServerVar(Saved = true)]
	public static bool EnforceTrespassChecks = true;

	[ServerVar(Help = "Will place the tutorial as close as possible to this pos, only for debugging")]
	public static Vector3 OverrideTutorialLocation = Vector3.zero;

	private const string TutorialIslandAssetPath = "assets/prefabs/missions/tutorialisland/tutorialisland.prefab";

	private static float _tutorialWorldStart = 0f;

	public static Bounds WorldBoundsMinusTutorialIslands;

	private static List<Vector3> islandSpawnLocations;

	private static List<int> freeIslandLocations;

	private float tutorialDuration;

	private float disconnectedDuration;

	private bool readyToStartConversation;

	private float tickRate = 1f;

	private Vector3 kayakAnchorPoint = Vector3.zero;

	private Kayak kayakToAnchor;

	private TimeSince rockCheck;

	public static float TutorialWorldStart
	{
		get
		{
			if (_tutorialWorldStart <= 0f)
			{
				_tutorialWorldStart = ValidBounds.GetMaximumPoint() - TutorialBoundsSize;
			}
			return _tutorialWorldStart;
		}
	}

	public static float TutorialWorldNetworkThreshold => TutorialWorldStart - TutorialBoundsSize;

	public static int MaxTutorialIslandCount => islandSpawnLocations?.Count ?? 0;

	public TimeSpan TutorialDuration => TimeSpan.FromSeconds(tutorialDuration);

	public float DisconnectTimeOutDuration
	{
		get
		{
			if (AvailableIslandCount() > 0)
			{
				return 900f;
			}
			return 300f;
		}
	}

	public static bool HasAvailableTutorialIsland
	{
		get
		{
			if (ConVar.Server.tutorialEnabled)
			{
				return freeIslandLocations.Count > 0;
			}
			return false;
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("TutorialIsland.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public static ListHashSet<TutorialIsland> GetTutorialList(bool isServer)
	{
		if (isServer)
		{
			return ActiveIslandsServer;
		}
		return null;
	}

	public static uint GetTutorialGroupId(int index)
	{
		return (uint)(2 + index);
	}

	public static bool IsTutorialNetworkGroup(uint grp)
	{
		if (grp > 1)
		{
			return grp < 1000;
		}
		return false;
	}

	public static void GenerateIslandSpawnPoints(bool loadingSave = false)
	{
		if (islandSpawnLocations != null && islandSpawnLocations.Count > 0)
		{
			return;
		}
		Vector3 vector = new Vector3(0f - ValidBounds.GetMaximumPointTutorial(), 0f, 0f - ValidBounds.GetMaximumPointTutorial());
		Vector3 vector2 = new Vector3(ValidBounds.GetMaximumPointTutorial(), 0f, ValidBounds.GetMaximumPointTutorial());
		islandSpawnLocations = TutorialIslandSpawner.GetEdgeSpawnPoints(cellSize: new Vector3(400f, 0f, 400f), start: vector, bounds: vector2 - vector, loopCount: 1, worldBoundsMinusTutorialIslands: out WorldBoundsMinusTutorialIslands);
		freeIslandLocations = new List<int>();
		for (int i = 0; i < islandSpawnLocations.Count; i++)
		{
			freeIslandLocations.Add(i);
		}
		int num = 0;
		foreach (Vector3 islandSpawnLocation in islandSpawnLocations)
		{
			Group tutorialGroup = GetTutorialGroup(num++);
			tutorialGroup.bounds = new OBB(islandSpawnLocation, Quaternion.identity, new Bounds(new Vector3(0f, 25f, 0f), new Vector3(400f, 80f, 400f))).ToBounds();
			tutorialGroup.restricted = true;
		}
	}

	public static Group GetTutorialGroup(int index)
	{
		return Network.Net.sv.visibility.Get((uint)(BaseNetworkable.LimboNetworkGroup.ID + 1 + index));
	}

	public static int AvailableIslandCount()
	{
		return freeIslandLocations.Count;
	}

	public static bool ShouldPlayerResumeTutorial(BasePlayer player)
	{
		if (player == null)
		{
			return false;
		}
		return player.IsInTutorial;
	}

	public static bool ShouldPlayerBeAskedToStartTutorial(BasePlayer player)
	{
		if (!ConVar.Server.tutorialEnabled)
		{
			return false;
		}
		if (player.IsNpc || player.IsBot)
		{
			return false;
		}
		if (player.IsInTutorial)
		{
			return false;
		}
		if (!SpawnTutorialIslandForNewPlayer)
		{
			return false;
		}
		if (!HasAvailableTutorialIsland)
		{
			return false;
		}
		bool infoBool = player.GetInfoBool("client.hasdeclinedtutorial", defaultVal: false);
		if (!player.GetInfoBool("client.hascompletedtutorial", defaultVal: false))
		{
			return !infoBool;
		}
		return false;
	}

	public static TutorialIsland RestoreOrCreateIslandForPlayer(BasePlayer player, bool triggerAnalytics)
	{
		if (player.IsNpc || player.IsBot)
		{
			return null;
		}
		bool flag = !player.HasPlayerFlag(BasePlayer.PlayerFlags.IsInTutorial);
		TutorialIsland tutorialIsland = (flag ? CreateIslandForPlayer(player) : player.GetCurrentTutorialIsland());
		if (!flag && tutorialIsland != null)
		{
			SetupGroup(tutorialIsland.SpawnLocationIndex, tutorialIsland.transform.position, tutorialIsland.transform.rotation);
		}
		if (tutorialIsland == null)
		{
			return null;
		}
		tutorialIsland.UpdateNetworkGroup();
		player.SetPlayerFlag(BasePlayer.PlayerFlags.IsInTutorial, b: true);
		if (flag)
		{
			player.net.SwitchGroup(tutorialIsland.net.group);
			player.Teleport(tutorialIsland.InitialSpawnPoint.position);
			player.ForceUpdateTriggers();
			player.transform.rotation = tutorialIsland.InitialSpawnPoint.rotation;
			player.OnStartedTutorial();
			player.inventory.GiveDefaultItems();
			if (triggerAnalytics)
			{
				Analytics.Azure.OnTutorialStarted(player);
			}
		}
		else
		{
			player.net.SwitchGroup(BaseNetworkable.LimboNetworkGroup);
			player.UpdateNetworkGroup();
			foreach (BaseEntity child in tutorialIsland.children)
			{
				if (child is TutorialContainer tutorialContainer)
				{
					tutorialIsland.TutorialContainer = tutorialContainer;
				}
			}
		}
		player.UpdateNetworkGroup();
		player.SendNetworkUpdateImmediate();
		player.ClientRPC(RpcTarget.Player("OnTutorialStarted", player), tutorialIsland.TimeOfDay, tutorialIsland.Weather.name);
		tutorialIsland.TestMission = null;
		if (flag)
		{
			if (tutorialIsland.TestMission == null)
			{
				SingletonComponent<InvokeHandler>.Instance.Invoke(tutorialIsland.StartInitialConversation, 1.5f);
			}
			else
			{
				Debug.LogWarning("Starting test mission instead of initial conversation, clear TestMission field to test actual tutorial");
			}
			if (tutorialIsland.TestMission != null)
			{
				BaseMission.AssignMission(player, tutorialIsland.StartTutorialNPC, tutorialIsland.TestMission);
			}
		}
		Debug.Log(player.displayName + " is being placed on a tutorial island");
		return tutorialIsland;
	}

	private static TutorialIsland CreateIslandForPlayer(BasePlayer player)
	{
		Vector3 worldPos;
		Quaternion worldRot;
		int unusedTutorialIslandLocationRotation = GetUnusedTutorialIslandLocationRotation(out worldPos, out worldRot);
		if (unusedTutorialIslandLocationRotation == -1)
		{
			return null;
		}
		Group group = SetupGroup(unusedTutorialIslandLocationRotation, worldPos, worldRot);
		TutorialIsland tutorialIsland = GameManager.server.CreateEntity("assets/prefabs/missions/tutorialisland/tutorialisland.prefab", worldPos, worldRot) as TutorialIsland;
		tutorialIsland.SpawnLocationIndex = unusedTutorialIslandLocationRotation;
		tutorialIsland.GenerateNavMesh();
		ActiveIslandsServer.Add(tutorialIsland);
		AddIslandBounds(tutorialIsland.WorldSpaceBounds(), group.ID, isServer: true);
		tutorialIsland.ForPlayer.Set(player);
		tutorialIsland.Spawn();
		return tutorialIsland;
	}

	private static Group SetupGroup(int spawnLocationIndex, Vector3 worldPos, Quaternion worldRot)
	{
		Group tutorialGroup = GetTutorialGroup(spawnLocationIndex);
		tutorialGroup.bounds = new OBB(worldPos, worldRot, new Bounds(new Vector3(0f, 25f, 0f), new Vector3(400f, 80f, 400f))).ToBounds();
		tutorialGroup.restricted = true;
		return tutorialGroup;
	}

	private static int GetUnusedTutorialIslandLocationRotation(out Vector3 worldPos, out Quaternion worldRot)
	{
		worldRot = Quaternion.identity;
		worldPos = Vector3.zero;
		if (AvailableIslandCount() == 0)
		{
			return -1;
		}
		if (OverrideTutorialLocation != Vector3.zero)
		{
			int num = -1;
			float num2 = float.MaxValue;
			for (int i = 0; i < freeIslandLocations.Count; i++)
			{
				float num3 = Vector3.Distance(OverrideTutorialLocation, islandSpawnLocations[freeIslandLocations[i]]);
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			worldPos = islandSpawnLocations[num];
			freeIslandLocations.RemoveAt(num);
			return num;
		}
		int num4 = freeIslandLocations[0];
		worldPos = islandSpawnLocations[num4];
		freeIslandLocations.RemoveAt(0);
		float height = TerrainMeta.HeightMap.GetHeight(worldPos);
		if (worldPos.y < height)
		{
			worldPos.y = height;
		}
		return num4;
	}

	public static void AddIslandFromSave(TutorialIsland island)
	{
		Debug.Log("Island being added! Location index: " + island.SpawnLocationIndex);
		if (ActiveIslandsServer.Contains(island))
		{
			Debug.Log("Warning, attempting to add duplicate Island!");
			return;
		}
		ActiveIslandsServer.Add(island);
		AddIslandBounds(island.WorldSpaceBounds(), GetTutorialGroupId(island.SpawnLocationIndex), isServer: true);
		freeIslandLocations.Remove(island.SpawnLocationIndex);
		Debug.Log("Free locations remaining: " + freeIslandLocations.Count + ". Next Index: " + freeIslandLocations[0]);
		island.GenerateNavMesh();
	}

	public void GenerateNavMesh()
	{
		if (!(MonumentNavMesh == null))
		{
			StartCoroutine(UpdateNavMesh());
		}
	}

	public IEnumerator UpdateNavMesh()
	{
		yield return StartCoroutine(MonumentNavMesh.UpdateNavMeshAndWait());
	}

	private void StartInitialConversation()
	{
		BasePlayer basePlayer = ForPlayer.Get(base.isServer);
		if (basePlayer != null && (basePlayer.IsSleeping() || basePlayer.IsDucked()))
		{
			Invoke(StartInitialConversation, 0.1f);
		}
		else if (!readyToStartConversation)
		{
			readyToStartConversation = true;
			Invoke(StartInitialConversation, 0.5f);
		}
		else
		{
			StartTutorialNPC.Server_BeginTalking(ForPlayer.Get(base.isServer));
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(InitSpawnGroups, 1f);
		InvokeRandomized(Tick, tickRate, tickRate, 0.1f);
	}

	private void InitSpawnGroups()
	{
		List<SpawnGroup> obj = Facepunch.Pool.Get<List<SpawnGroup>>();
		base.gameObject.GetComponentsInChildren(obj);
		foreach (SpawnGroup item in obj)
		{
			if (item != null)
			{
				item.Spawn();
			}
		}
		Facepunch.Pool.FreeUnmanaged(ref obj);
	}

	public void OnPlayerBuiltConstruction(BasePlayer player)
	{
		ClientRPC(RpcTarget.Player("ClientOnPlayerBuiltConstruction", player));
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.tutorialIsland == null)
		{
			info.msg.tutorialIsland = Facepunch.Pool.Get<ProtoBuf.TutorialIsland>();
		}
		ProtoBuf.TutorialIsland tutorialIsland = info.msg.tutorialIsland;
		tutorialIsland.targetPlayer = ForPlayer.uid;
		tutorialIsland.disconnectDuration = disconnectedDuration;
		tutorialIsland.spawnLocationIndex = SpawnLocationIndex;
		if (info.forDisk)
		{
			tutorialIsland.tutorialDuration = tutorialDuration;
		}
	}

	public void GetBuildTargets(List<TutorialBuildTarget> targetList, uint targetPrefab)
	{
		TutorialBuildTarget[] array = buildTargets;
		foreach (TutorialBuildTarget tutorialBuildTarget in array)
		{
			if (tutorialBuildTarget.TargetPrefab.isValid && tutorialBuildTarget.TargetPrefab.Get().prefabID == targetPrefab)
			{
				targetList.Add(tutorialBuildTarget);
			}
		}
	}

	public Vector3 GetWorldPosOfBuildTarget(int index)
	{
		if (buildTargets.Length != 0)
		{
			return buildTargets[index].transform.position;
		}
		return base.transform.position;
	}

	public void StartEndingCinematic(BasePlayer player)
	{
		BaseMountable mounted = player.GetMounted();
		Vector3 pos = player.transform.position.WithY(Env.oceanlevel);
		if (mounted != null && mounted.VehicleParent() != null)
		{
			kayakToAnchor = mounted.VehicleParent() as Kayak;
			if (kayakToAnchor != null)
			{
				kayakToAnchor.PrepareForTutorialCinematic(KayakPoint.rotation);
				kayakAnchorPoint = pos;
				kayakToAnchor.rigidBody.isKinematic = true;
				kayakToAnchor.rigidBody.useGravity = false;
				InvokeRepeating(AnchorKayak, 0f, 0f);
			}
		}
		CinematicScenePlaybackEntity obj = GameManager.server.CreateEntity("assets/prefabs/missions/tutorialisland/endtutorialcinematic.prefab", pos, KayakPoint.rotation) as CinematicScenePlaybackEntity;
		obj.AssignPlayer(player);
		obj.Spawn();
	}

	private void AnchorKayak()
	{
		if (kayakToAnchor != null)
		{
			kayakToAnchor.transform.position = kayakAnchorPoint;
		}
	}

	public void OnPlayerCompletedTutorial(BasePlayer player, bool isQuit, bool triggerAnalytics)
	{
		if (ForPlayer.Get(serverside: true) != player)
		{
			Debug.LogWarning($"Attempting to complete tutorial for non-matching player {ForPlayer.Get(serverside: true)} != {player}");
			return;
		}
		_ = player.IsInTutorial;
		if (triggerAnalytics)
		{
			if (isQuit)
			{
				BaseMission.MissionInstance activeMissionInstance = player.GetActiveMissionInstance();
				Analytics.Azure.OnTutorialQuit(player, (activeMissionInstance != null && activeMissionInstance.GetMission() != null) ? activeMissionInstance.GetMission().shortname : "NULL");
			}
			else
			{
				Analytics.Azure.OnTutorialCompleted(player, tutorialDuration);
				player.GiveAchievement("COMPLETE_TUTORIAL", allowTutorial: true);
			}
		}
		Invoke(KillPlayerAtEndOfTutorial, 0.1f);
		InvokeRepeating(DelayedCompleteTutorial, 0.5f, 0.5f);
	}

	private void KillPlayerAtEndOfTutorial()
	{
		Debug.Log("Kill player");
		BasePlayer basePlayer = ForPlayer.Get(serverside: true);
		basePlayer.ClientRPC(RpcTarget.Player("NotifyTutorialCompleted", basePlayer));
		basePlayer.ClearTutorial();
		ServerMgr.SendReplicatedVars(basePlayer.Connection);
		PlayerLifeStory.DeathInfo deathInfo = Facepunch.Pool.Get<PlayerLifeStory.DeathInfo>();
		deathInfo.attackerName = "scientistnpc_full_any";
		if (basePlayer.IsGod())
		{
			basePlayer.net.connection.info.Set("global.god", "0");
		}
		basePlayer.SetOverrideDeathBlow(deathInfo);
		basePlayer.Hurt(9999f);
		if (basePlayer.IsGod())
		{
			Debug.LogWarning("Attempting to kill player " + basePlayer.displayName + " at end of tutorial but god mode is active!");
		}
		basePlayer.ClearTutorial_PostDeath();
	}

	private void DelayedCompleteTutorial()
	{
		BasePlayer basePlayer = ForPlayer.Get(serverside: true);
		if (!(basePlayer != null) || !basePlayer.IsDead())
		{
			ForPlayer.Set(null);
			Return();
		}
	}

	public void Return()
	{
		List<BaseEntity> obj = Facepunch.Pool.Get<List<BaseEntity>>();
		Vis.Entities(WorldSpaceBounds(), obj);
		foreach (BaseEntity item in obj)
		{
			if (!(item is BasePlayer) && !(item is TutorialIsland) && !item.isClient && !item.IsDestroyed)
			{
				item.Kill();
			}
		}
		Facepunch.Pool.FreeUnmanaged(ref obj);
		BasePlayer basePlayer = ForPlayer.Get(serverside: true);
		if (basePlayer != null)
		{
			basePlayer.AbandonActiveMission();
		}
		ForPlayer.Set(null);
		ReturnIsland(this);
		disconnectedDuration = 0f;
	}

	private static void ReturnIsland(TutorialIsland island)
	{
		freeIslandLocations.Add(island.SpawnLocationIndex);
		island.Kill();
	}

	public void Tick()
	{
		TickPlayerConnectionStatus();
	}

	private void TickPlayerConnectionStatus()
	{
		BasePlayer basePlayer = ForPlayer.Get(base.isServer);
		tutorialDuration += tickRate;
		if (basePlayer == null || basePlayer.IsSleeping())
		{
			disconnectedDuration += tickRate;
			if (disconnectedDuration >= DisconnectTimeOutDuration)
			{
				if (basePlayer != null)
				{
					basePlayer.ClearTutorial();
					basePlayer.Hurt(99999f);
					basePlayer.ClearTutorial_PostDeath();
					basePlayer.ClientRPCPlayer(null, basePlayer, "NotifyTutorialCompleted");
				}
				Return();
			}
			return;
		}
		disconnectedDuration = 0f;
		if (!(basePlayer != null) || !(rockDefinition != null) || !((float)rockCheck > 10f))
		{
			return;
		}
		rockCheck = 0f;
		if (basePlayer.inventory.GetAmount(rockDefinition) == 0 && basePlayer.inventory.HasEmptySlotInBeltOrMain())
		{
			Item item = ItemManager.Create(rockDefinition, 1, 0uL);
			if (!basePlayer.inventory.GiveItem(item))
			{
				item.Remove();
			}
		}
	}

	public bool IsPingValid(MapNote note)
	{
		TutorialBuildTarget[] array = buildTargets;
		foreach (TutorialBuildTarget tutorialBuildTarget in array)
		{
			if (tutorialBuildTarget.gameObject.activeSelf && Vector3.Distance(tutorialBuildTarget.transform.position, note.worldPosition) < 0.1f)
			{
				return true;
			}
		}
		if ((note.worldPosition - KayakPoint.position).sqrMagnitude < 10f)
		{
			return true;
		}
		return false;
	}

	public static TutorialIsland GetClosestTutorialIsland(Vector3 position, float maxRange)
	{
		int num = -1;
		float num2 = float.MaxValue;
		for (int i = 0; i < ActiveIslandsServer.Count; i++)
		{
			TutorialIsland tutorialIsland = ActiveIslandsServer[i];
			if (tutorialIsland != null)
			{
				float num3 = tutorialIsland.Distance2D(position);
				if (num3 < maxRange && num3 < num2)
				{
					num2 = num3;
					num = i;
				}
			}
		}
		if (num < 0)
		{
			return null;
		}
		return ActiveIslandsServer[num];
	}

	public void OnPlayerStartedMission(BasePlayer player)
	{
		TutorialBuildTarget[] array = buildTargets;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateActive(player);
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.tutorialIsland != null)
		{
			ProtoBuf.TutorialIsland tutorialIsland = info.msg.tutorialIsland;
			ForPlayer.uid = tutorialIsland.targetPlayer;
			SpawnLocationIndex = tutorialIsland.spawnLocationIndex;
			disconnectedDuration = tutorialIsland.disconnectDuration;
			tutorialDuration = tutorialIsland.tutorialDuration;
			if (base.isServer && info.fromDisk)
			{
				AddIslandFromSave(this);
			}
		}
	}

	public bool CheckPlacement(Construction toConstruct, Construction.Target target, ref Construction.Placement placement)
	{
		TutorialBuildTarget[] array = buildTargets;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].IsValid(toConstruct, target, ref placement))
			{
				return true;
			}
		}
		return false;
	}

	public bool CheckPlacement(BasePlayer forPlayer, Deployable deployable, Vector3 worldPosition, Quaternion worldRotation)
	{
		TutorialBuildTarget[] array = buildTargets;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].IsValid(forPlayer, deployable, worldPosition, worldRotation))
			{
				return true;
			}
		}
		return false;
	}

	public override void InitShared()
	{
		base.InitShared();
		buildTargets = GetComponentsInChildren<TutorialBuildTarget>();
	}

	public override void DestroyShared()
	{
		base.DestroyShared();
		if (base.isServer && ActiveIslandsServer.Contains(this))
		{
			RemoveIslandBounds(GetTutorialGroupId(SpawnLocationIndex), isServer: true);
			ActiveIslandsServer.Remove(this);
		}
	}

	private static void AddIslandBounds(OBB worldBounds, uint netId, bool isServer)
	{
		if (isServer)
		{
			BoundsListServer.Add(new IslandBounds
			{
				Id = netId,
				WorldBounds = worldBounds
			});
		}
	}

	private static void RemoveIslandBounds(uint netId, bool isServer)
	{
		if (!isServer)
		{
			return;
		}
		for (int i = 0; i < BoundsListServer.Count; i++)
		{
			if (BoundsListServer[i].Id == netId)
			{
				BoundsListServer.RemoveAt(i);
				break;
			}
		}
	}

	public override bool SupportsChildDeployables()
	{
		return true;
	}

	public override bool ForceDeployableSetParent()
	{
		return true;
	}
}
