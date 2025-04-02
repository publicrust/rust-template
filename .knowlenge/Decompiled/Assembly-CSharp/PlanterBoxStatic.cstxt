using System.Collections.Generic;
using UnityEngine;

public class PlanterBoxStatic : PlanterBox
{
	[ServerVar(Help = "Chance of a favourable gene being picked [0-1]. Setting this to 0 does not ensure no favourable genes are picked up, but it greatly reduces the chances.")]
	public static float FavourableGeneChance = 0.5f;

	public List<GameObjectRef> staticPlantsSpawnlist;

	public bool randomPerSlot;

	public float respawnCheckTimer = 30f;

	public override void SetupTimeCaches()
	{
	}

	public override void RefreshGrowables(GrowableEntity ignoreEntity = null)
	{
	}

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRepeating(CreateStaticPlants, 1f, respawnCheckTimer);
	}

	public void CreateStaticPlants()
	{
		soilSaturation = soilSaturationMax;
		GameObjectRef randomStaticPlant = GetRandomStaticPlant();
		Socket_Base[] array = PrefabAttribute.server.FindAll<Socket_Base>(prefabID);
		foreach (Socket_Base socket_Base in array)
		{
			if (socket_Base is Socket_Specific_Female && IsSpawnPointFreeSearch(socket_Base.localPosition))
			{
				if (randomPerSlot)
				{
					randomStaticPlant = GetRandomStaticPlant();
				}
				Vector3 pos = base.transform.TransformPoint(socket_Base.localPosition);
				BaseEntity baseEntity = GameManager.server.CreateEntity(randomStaticPlant.resourcePath, pos, Quaternion.identity);
				baseEntity.SetParent(this, worldPositionStays: true);
				baseEntity.Spawn();
				GrowableEntity growableEntity = baseEntity as GrowableEntity;
				if (growableEntity != null)
				{
					growableEntity.Fertilize();
					growableEntity.SetGodQuality(qual: true);
					growableEntity.SetMaxGrowingConditions();
					growableEntity.Genes.GenerateFavourableGenes(growableEntity);
					growableEntity.SendNetworkUpdate();
					OnPlantInserted(growableEntity, null);
				}
			}
		}
	}

	private GameObjectRef GetRandomStaticPlant()
	{
		if (staticPlantsSpawnlist == null || staticPlantsSpawnlist.Count == 0)
		{
			return null;
		}
		int index = Random.Range(0, staticPlantsSpawnlist.Count);
		return staticPlantsSpawnlist[index];
	}

	private bool IsSpawnPointFreeSearch(Vector3 localPos)
	{
		foreach (BaseEntity child in children)
		{
			if (child is GrowableEntity && Vector3.Distance(child.transform.localPosition, localPos) < 0.05f)
			{
				return false;
			}
		}
		return true;
	}
}
