using Oxide.Core;
using UnityEngine;

public class TerrainGenerator : SingletonComponent<TerrainGenerator>
{
	public TerrainConfig config;

	private const float HeightMapRes = 1f;

	private const float SplatMapRes = 0.5f;

	private const float BaseMapRes = 0.01f;

	public static int GetHeightMapRes()
	{
		return Mathf.Min(4096, Mathf.ClosestPowerOfTwo((int)((float)World.Size * 1f))) + 1;
	}

	public static int GetSplatMapRes()
	{
		return Mathf.Min(2048, Mathf.NextPowerOfTwo((int)((float)World.Size * 0.5f)));
	}

	public static int GetBaseMapRes()
	{
		return Mathf.Min(2048, Mathf.NextPowerOfTwo((int)((float)World.Size * 0.01f)));
	}

	public GameObject CreateTerrain()
	{
		return CreateTerrain(GetHeightMapRes(), GetSplatMapRes());
	}

	public GameObject CreateTerrain(int heightmapResolution, int alphamapResolution)
	{
		Interface.CallHook("OnTerrainCreate", this);
		Terrain component = Terrain.CreateTerrainGameObject(new TerrainData
		{
			baseMapResolution = GetBaseMapRes(),
			heightmapResolution = heightmapResolution,
			alphamapResolution = alphamapResolution,
			size = new Vector3(World.Size, 1000f, World.Size)
		}).GetComponent<Terrain>();
		component.transform.position = base.transform.position + new Vector3((float)(0L - (long)World.Size) * 0.5f, 0f, (float)(0L - (long)World.Size) * 0.5f);
		component.drawInstanced = false;
		component.castShadows = config.CastShadows;
		component.materialType = Terrain.MaterialType.Custom;
		component.materialTemplate = config.Material;
		component.gameObject.tag = base.gameObject.tag;
		component.gameObject.layer = base.gameObject.layer;
		component.gameObject.GetComponent<TerrainCollider>().sharedMaterial = config.GenericMaterial;
		TerrainMeta terrainMeta = component.gameObject.AddComponent<TerrainMeta>();
		component.gameObject.AddComponent<TerrainPhysics>();
		component.gameObject.AddComponent<TerrainColors>();
		component.gameObject.AddComponent<TerrainCollision>();
		component.gameObject.AddComponent<TerrainBiomeMap>();
		component.gameObject.AddComponent<TerrainAlphaMap>();
		component.gameObject.AddComponent<TerrainHeightMap>();
		component.gameObject.AddComponent<TerrainSplatMap>();
		component.gameObject.AddComponent<TerrainTopologyMap>();
		component.gameObject.AddComponent<TerrainWaterMap>();
		component.gameObject.AddComponent<TerrainPlacementMap>();
		component.gameObject.AddComponent<TerrainPath>();
		component.gameObject.AddComponent<TerrainTexturing>();
		component.gameObject.AddComponent<TerrainWaterFlowMap>();
		terrainMeta.terrain = component;
		terrainMeta.config = config;
		Object.DestroyImmediate(base.gameObject);
		return component.gameObject;
	}
}
