using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rust;
using Rust.Ai;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class DynamicNavMesh : SingletonComponent<DynamicNavMesh>, IServerComponent
{
	public int NavMeshAgentTypeIndex;

	[Tooltip("The default area associated with the NavMeshAgent index.")]
	public string DefaultAreaName = "Walkable";

	public int AsyncTerrainNavMeshBakeCellSize = 80;

	public int AsyncTerrainNavMeshBakeCellHeight = 100;

	public Bounds Bounds;

	public NavMeshData NavMeshData;

	public NavMeshDataInstance NavMeshDataInstance;

	public LayerMask LayerMask;

	public NavMeshCollectGeometry NavMeshCollectGeometry;

	[ServerVar]
	public static bool use_baked_terrain_mesh;

	private List<NavMeshBuildSource> sources;

	private AsyncOperation BuildingOperation;

	private bool HasBuildOperationStarted;

	private Stopwatch BuildTimer = new Stopwatch();

	private int defaultArea;

	private int agentTypeId;

	public bool IsBuilding
	{
		get
		{
			if (!HasBuildOperationStarted || BuildingOperation != null)
			{
				return true;
			}
			return false;
		}
	}

	private void OnEnable()
	{
		agentTypeId = NavMesh.GetSettingsByIndex(NavMeshAgentTypeIndex).agentTypeID;
		NavMeshData = new NavMeshData(agentTypeId);
		sources = new List<NavMeshBuildSource>();
		defaultArea = NavMesh.GetAreaFromName(DefaultAreaName);
		InvokeRepeating(FinishBuildingNavmesh, 0f, 1f);
	}

	private void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			CancelInvoke(FinishBuildingNavmesh);
			NavMeshDataInstance.Remove();
		}
	}

	[ContextMenu("Update Nav Mesh")]
	public void UpdateNavMeshAsync()
	{
		if (!HasBuildOperationStarted && !AiManager.nav_disable)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			UnityEngine.Debug.Log("Starting Navmesh Build with " + sources.Count + " sources");
			NavMeshBuildSettings settingsByIndex = NavMesh.GetSettingsByIndex(NavMeshAgentTypeIndex);
			settingsByIndex.overrideVoxelSize = true;
			settingsByIndex.voxelSize *= 2f;
			BuildingOperation = NavMeshBuilder.UpdateNavMeshDataAsync(NavMeshData, settingsByIndex, sources, Bounds);
			BuildTimer.Reset();
			BuildTimer.Start();
			HasBuildOperationStarted = true;
			float num = Time.realtimeSinceStartup - realtimeSinceStartup;
			if (num > 0.1f)
			{
				UnityEngine.Debug.LogWarning("Calling UpdateNavMesh took " + num);
			}
		}
	}

	public IEnumerator UpdateNavMeshAndWait()
	{
		if (HasBuildOperationStarted || AiManager.nav_disable)
		{
			yield break;
		}
		HasBuildOperationStarted = false;
		Bounds.size = TerrainMeta.Size;
		NavMesh.pathfindingIterationsPerFrame = AiManager.pathfindingIterationsPerFrame;
		IEnumerator enumerator = NavMeshTools.CollectSourcesAsync(Bounds, LayerMask, NavMeshCollectGeometry, defaultArea, use_baked_terrain_mesh, AsyncTerrainNavMeshBakeCellSize, sources, AppendModifierVolumes, UpdateNavMeshAsync, null);
		if (AiManager.nav_wait)
		{
			yield return enumerator;
		}
		else
		{
			StartCoroutine(enumerator);
		}
		if (!AiManager.nav_wait)
		{
			UnityEngine.Debug.Log("nav_wait is false, so we're not waiting for the navmesh to finish generating. This might cause your server to sputter while it's generating.");
			yield break;
		}
		int lastPct = 0;
		while (!HasBuildOperationStarted)
		{
			yield return CoroutineEx.waitForSecondsRealtime(0.25f);
		}
		while (BuildingOperation != null)
		{
			int num = (int)(BuildingOperation.progress * 100f);
			if (lastPct != num)
			{
				UnityEngine.Debug.LogFormat("{0}%", num);
				lastPct = num;
			}
			yield return CoroutineEx.waitForSecondsRealtime(0.25f);
			FinishBuildingNavmesh();
		}
	}

	private void AppendModifierVolumes(List<NavMeshBuildSource> sources)
	{
		foreach (NavMeshModifierVolume activeModifier in NavMeshModifierVolume.activeModifiers)
		{
			if (((int)LayerMask & (1 << activeModifier.gameObject.layer)) != 0 && activeModifier.AffectsAgentType(agentTypeId))
			{
				Vector3 pos = activeModifier.transform.TransformPoint(activeModifier.center);
				Vector3 lossyScale = activeModifier.transform.lossyScale;
				Vector3 size = new Vector3(activeModifier.size.x * Mathf.Abs(lossyScale.x), activeModifier.size.y * Mathf.Abs(lossyScale.y), activeModifier.size.z * Mathf.Abs(lossyScale.z));
				NavMeshBuildSource item = default(NavMeshBuildSource);
				item.shape = NavMeshBuildSourceShape.ModifierBox;
				item.transform = Matrix4x4.TRS(pos, activeModifier.transform.rotation, Vector3.one);
				item.size = size;
				item.area = activeModifier.area;
				sources.Add(item);
			}
		}
	}

	public void FinishBuildingNavmesh()
	{
		if (BuildingOperation != null && BuildingOperation.isDone)
		{
			if (!NavMeshDataInstance.valid)
			{
				NavMeshDataInstance = NavMesh.AddNavMeshData(NavMeshData);
			}
			UnityEngine.Debug.Log($"Navmesh Build took {BuildTimer.Elapsed.TotalSeconds:0.00} seconds");
			BuildingOperation = null;
		}
	}
}
