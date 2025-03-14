using System;
using System.Collections;
using System.Collections.Generic;
using ConVar;
using Rust.Ai;
using UnityEngine;
using UnityEngine.AI;

public static class NavMeshTools
{
	public static IEnumerator CollectSourcesAsync(Bounds bounds, int mask, NavMeshCollectGeometry geometry, int area, bool useBakedTerrainMesh, int cellSize, List<NavMeshBuildSource> sources, Action<List<NavMeshBuildSource>> append, Action callback, Transform customNavMeshDataRoot)
	{
		while (!AI.move && !AiManager.nav_wait)
		{
			yield return CoroutineEx.waitForSeconds(1f);
		}
		if (customNavMeshDataRoot != null)
		{
			customNavMeshDataRoot.gameObject.SetActive(value: true);
			yield return new WaitForEndOfFrame();
		}
		float time = UnityEngine.Time.realtimeSinceStartup;
		Debug.Log("Starting Navmesh Source Collecting");
		mask = ((!useBakedTerrainMesh) ? (mask | 0x800000) : (mask & -8388609));
		List<NavMeshBuildMarkup> markups = new List<NavMeshBuildMarkup>();
		NavMeshBuilder.CollectSources(bounds, mask, geometry, area, markups, sources);
		if (useBakedTerrainMesh && TerrainMeta.HeightMap != null)
		{
			for (float x = 0f - bounds.extents.x; x < bounds.extents.x - (float)(cellSize / 2); x += (float)cellSize)
			{
				for (float z = 0f - bounds.extents.z; z < bounds.extents.z - (float)(cellSize / 2); z += (float)cellSize)
				{
					AsyncTerrainNavMeshBake terrainSource = new AsyncTerrainNavMeshBake(new Vector3(x, 0f, z), cellSize, cellSize, normal: false, alpha: true);
					yield return terrainSource;
					sources.Add(terrainSource.CreateNavMeshBuildSource(area));
				}
			}
		}
		append?.Invoke(sources);
		Debug.Log($"Navmesh Source Collecting took {UnityEngine.Time.realtimeSinceStartup - time:0.00} seconds");
		if (customNavMeshDataRoot != null)
		{
			customNavMeshDataRoot.gameObject.SetActive(value: false);
		}
		callback?.Invoke();
	}

	public static IEnumerator CollectSourcesAsync(Transform root, int mask, NavMeshCollectGeometry geometry, int area, List<NavMeshBuildSource> sources, Action<List<NavMeshBuildSource>> append, Action callback)
	{
		while (!AI.move && !AiManager.nav_wait)
		{
			yield return CoroutineEx.waitForSeconds(1f);
		}
		float realtimeSinceStartup = UnityEngine.Time.realtimeSinceStartup;
		Debug.Log("Starting Navmesh Source Collecting");
		List<NavMeshBuildMarkup> markups = new List<NavMeshBuildMarkup>();
		NavMeshBuilder.CollectSources(root, mask, geometry, area, markups, sources);
		append?.Invoke(sources);
		Debug.Log($"Navmesh Source Collecting took {UnityEngine.Time.realtimeSinceStartup - realtimeSinceStartup:0.00} seconds");
		callback?.Invoke();
	}
}
