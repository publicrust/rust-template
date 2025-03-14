using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class MapLayerRenderer : SingletonComponent<MapLayerRenderer>
{
	private NetworkableId? _currentlyRenderedDungeon;

	private int? _underwaterLabFloorCount;

	public Camera renderCamera;

	public CameraEvent cameraEvent;

	public Material renderMaterial;

	private MapLayer? _currentlyRenderedLayer;

	private void RenderDungeonsLayer()
	{
		ProceduralDynamicDungeon proceduralDynamicDungeon = FindDungeon(MainCamera.isValid ? MainCamera.position : Vector3.zero);
		if (_currentlyRenderedLayer == MapLayer.Dungeons && _currentlyRenderedDungeon == proceduralDynamicDungeon?.net?.ID)
		{
			return;
		}
		_currentlyRenderedLayer = MapLayer.Dungeons;
		_currentlyRenderedDungeon = proceduralDynamicDungeon?.net?.ID;
		using CommandBuffer cb = BuildCommandBufferDungeons(proceduralDynamicDungeon);
		RenderImpl(cb);
	}

	private CommandBuffer BuildCommandBufferDungeons(ProceduralDynamicDungeon closest)
	{
		CommandBuffer commandBuffer = new CommandBuffer
		{
			name = "DungeonsLayer Render"
		};
		if (closest != null && closest.spawnedCells != null)
		{
			Matrix4x4 matrix4x = Matrix4x4.Translate(closest.mapOffset);
			foreach (ProceduralDungeonCell spawnedCell in closest.spawnedCells)
			{
				if (spawnedCell == null || spawnedCell.mapRenderers == null || spawnedCell.mapRenderers.Length == 0)
				{
					continue;
				}
				MeshRenderer[] mapRenderers = spawnedCell.mapRenderers;
				foreach (MeshRenderer meshRenderer in mapRenderers)
				{
					if (!(meshRenderer == null) && meshRenderer.TryGetComponent<MeshFilter>(out var component))
					{
						Mesh sharedMesh = component.sharedMesh;
						int subMeshCount = sharedMesh.subMeshCount;
						Matrix4x4 matrix = matrix4x * meshRenderer.transform.localToWorldMatrix;
						for (int j = 0; j < subMeshCount; j++)
						{
							commandBuffer.DrawMesh(sharedMesh, matrix, renderMaterial, j);
						}
					}
				}
			}
		}
		return commandBuffer;
	}

	public static ProceduralDynamicDungeon FindDungeon(Vector3 position, float maxDist = 200f)
	{
		ProceduralDynamicDungeon result = null;
		float num = 100000f;
		foreach (ProceduralDynamicDungeon dungeon in ProceduralDynamicDungeon.dungeons)
		{
			if (!(dungeon == null) && dungeon.isClient)
			{
				float num2 = Vector3.Distance(position, dungeon.transform.position);
				if (!(num2 > maxDist) && !(num2 > num))
				{
					result = dungeon;
					num = num2;
				}
			}
		}
		return result;
	}

	private void RenderTrainLayer()
	{
		using CommandBuffer cb = BuildCommandBufferTrainTunnels();
		RenderImpl(cb);
	}

	private CommandBuffer BuildCommandBufferTrainTunnels()
	{
		CommandBuffer commandBuffer = new CommandBuffer
		{
			name = "TrainLayer Render"
		};
		foreach (DungeonGridCell dungeonGridCell in TerrainMeta.Path.DungeonGridCells)
		{
			if (dungeonGridCell.MapRenderers == null || dungeonGridCell.MapRenderers.Length == 0)
			{
				continue;
			}
			MeshRenderer[] mapRenderers = dungeonGridCell.MapRenderers;
			foreach (MeshRenderer meshRenderer in mapRenderers)
			{
				if (!(meshRenderer == null) && meshRenderer.TryGetComponent<MeshFilter>(out var component))
				{
					Mesh sharedMesh = component.sharedMesh;
					int subMeshCount = sharedMesh.subMeshCount;
					Matrix4x4 localToWorldMatrix = meshRenderer.transform.localToWorldMatrix;
					for (int j = 0; j < subMeshCount; j++)
					{
						commandBuffer.DrawMesh(sharedMesh, localToWorldMatrix, renderMaterial, j);
					}
				}
			}
		}
		return commandBuffer;
	}

	private void RenderUnderwaterLabs(int floor)
	{
		using CommandBuffer cb = BuildCommandBufferUnderwaterLabs(floor);
		RenderImpl(cb);
	}

	public int GetUnderwaterLabFloorCount()
	{
		if (_underwaterLabFloorCount.HasValue)
		{
			return _underwaterLabFloorCount.Value;
		}
		List<DungeonBaseInfo> dungeonBaseEntrances = TerrainMeta.Path.DungeonBaseEntrances;
		_underwaterLabFloorCount = ((dungeonBaseEntrances != null && dungeonBaseEntrances.Count > 0) ? dungeonBaseEntrances.Max((DungeonBaseInfo l) => l.Floors.Count) : 0);
		return _underwaterLabFloorCount.Value;
	}

	private CommandBuffer BuildCommandBufferUnderwaterLabs(int floor)
	{
		CommandBuffer commandBuffer = new CommandBuffer
		{
			name = "UnderwaterLabLayer Render"
		};
		foreach (DungeonBaseInfo dungeonBaseEntrance in TerrainMeta.Path.DungeonBaseEntrances)
		{
			if (dungeonBaseEntrance.Floors.Count <= floor)
			{
				continue;
			}
			foreach (DungeonBaseLink link in dungeonBaseEntrance.Floors[floor].Links)
			{
				if (link.MapRenderers == null || link.MapRenderers.Length == 0)
				{
					continue;
				}
				MeshRenderer[] mapRenderers = link.MapRenderers;
				foreach (MeshRenderer meshRenderer in mapRenderers)
				{
					if (!(meshRenderer == null) && meshRenderer.TryGetComponent<MeshFilter>(out var component))
					{
						Mesh sharedMesh = component.sharedMesh;
						int subMeshCount = sharedMesh.subMeshCount;
						Matrix4x4 localToWorldMatrix = meshRenderer.transform.localToWorldMatrix;
						for (int j = 0; j < subMeshCount; j++)
						{
							commandBuffer.DrawMesh(sharedMesh, localToWorldMatrix, renderMaterial, j);
						}
					}
				}
			}
		}
		return commandBuffer;
	}

	public void Render(MapLayer layer)
	{
		if (layer < MapLayer.TrainTunnels)
		{
			return;
		}
		if (layer == MapLayer.Dungeons)
		{
			RenderDungeonsLayer();
		}
		else if (layer != _currentlyRenderedLayer)
		{
			_currentlyRenderedLayer = layer;
			switch (layer)
			{
			case MapLayer.TrainTunnels:
				RenderTrainLayer();
				break;
			case MapLayer.Underwater1:
			case MapLayer.Underwater2:
			case MapLayer.Underwater3:
			case MapLayer.Underwater4:
			case MapLayer.Underwater5:
			case MapLayer.Underwater6:
			case MapLayer.Underwater7:
			case MapLayer.Underwater8:
				RenderUnderwaterLabs((int)(layer - 1));
				break;
			}
		}
	}

	private void RenderImpl(CommandBuffer cb)
	{
		double num = (double)World.Size * 1.5;
		renderCamera.orthographicSize = (float)num / 2f;
		renderCamera.RemoveAllCommandBuffers();
		renderCamera.AddCommandBuffer(cameraEvent, cb);
		renderCamera.Render();
		renderCamera.RemoveAllCommandBuffers();
	}

	public static MapLayerRenderer GetOrCreate()
	{
		if (SingletonComponent<MapLayerRenderer>.Instance != null)
		{
			return SingletonComponent<MapLayerRenderer>.Instance;
		}
		return GameManager.server.CreatePrefab("assets/prefabs/engine/maplayerrenderer.prefab", Vector3.zero, Quaternion.identity).GetComponent<MapLayerRenderer>();
	}
}
