using ConVar;
using Oxide.Core;
using UnityEngine;
using UnityEngine.AI;

public class ServerBuildingManager : BuildingManager
{
	private int decayTickBuildingIndex;

	private int decayTickEntityIndex;

	private int decayTickWorldIndex;

	private int navmeshCarveTickBuildingIndex;

	private uint maxBuildingID;

	public void CheckSplit(DecayEntity ent)
	{
		if (ent.buildingID != 0)
		{
			Building building = ent.GetBuilding();
			if (building != null && ShouldSplit(building))
			{
				Split(building);
			}
		}
	}

	private bool ShouldSplit(Building building)
	{
		if (building.HasBuildingBlocks())
		{
			building.buildingBlocks[0].EntityLinkBroadcast();
			foreach (BuildingBlock buildingBlock in building.buildingBlocks)
			{
				if (!buildingBlock.ReceivedEntityLinkBroadcast())
				{
					return true;
				}
			}
		}
		return false;
	}

	private void Split(Building building)
	{
		while (building.HasBuildingBlocks())
		{
			BuildingBlock buildingBlock = building.buildingBlocks[0];
			uint newID = BuildingManager.server.NewBuildingID();
			Interface.CallHook("OnBuildingSplit", building, newID);
			buildingBlock.EntityLinkBroadcast(delegate(BuildingBlock b)
			{
				b.AttachToBuilding(newID);
			});
		}
		while (building.HasBuildingPrivileges())
		{
			BuildingPrivlidge buildingPrivlidge = building.buildingPrivileges[0];
			BuildingBlock nearbyBuildingBlock = buildingPrivlidge.GetNearbyBuildingBlock();
			buildingPrivlidge.AttachToBuilding(nearbyBuildingBlock ? nearbyBuildingBlock.buildingID : 0u);
		}
		while (building.HasDecayEntities())
		{
			DecayEntity decayEntity = building.decayEntities[0];
			BuildingBlock nearbyBuildingBlock2 = decayEntity.GetNearbyBuildingBlock();
			decayEntity.AttachToBuilding(nearbyBuildingBlock2 ? nearbyBuildingBlock2.buildingID : 0u);
		}
		if (AI.nav_carve_use_building_optimization)
		{
			building.isNavMeshCarvingDirty = true;
			int ticks = 2;
			UpdateNavMeshCarver(building, ref ticks, 0);
		}
	}

	public void CheckMerge(DecayEntity ent)
	{
		if (ent.buildingID == 0)
		{
			return;
		}
		Building building = ent.GetBuilding();
		if (building == null)
		{
			return;
		}
		ent.EntityLinkMessage(delegate(BuildingBlock b)
		{
			if (b.buildingID != building.ID)
			{
				Building building2 = b.GetBuilding();
				if (building2 != null)
				{
					Merge(building, building2);
				}
			}
		});
		if (AI.nav_carve_use_building_optimization)
		{
			building.isNavMeshCarvingDirty = true;
			int ticks = 2;
			UpdateNavMeshCarver(building, ref ticks, 0);
		}
	}

	private void Merge(Building building1, Building building2)
	{
		Interface.CallHook("OnBuildingMerge", this, building1, building2);
		while (building2.HasDecayEntities())
		{
			building2.decayEntities[0].AttachToBuilding(building1.ID);
		}
		if (AI.nav_carve_use_building_optimization)
		{
			building1.isNavMeshCarvingDirty = true;
			building2.isNavMeshCarvingDirty = true;
			int ticks = 3;
			UpdateNavMeshCarver(building1, ref ticks, 0);
			UpdateNavMeshCarver(building1, ref ticks, 0);
		}
	}

	public void Cycle()
	{
		using (TimeWarning.New("StabilityCheckQueue"))
		{
			StabilityEntity.stabilityCheckQueue.RunQueue(Stability.stabilityqueue);
		}
		using (TimeWarning.New("UpdateSurroundingsQueue"))
		{
			StabilityEntity.updateSurroundingsQueue.RunQueue(Stability.surroundingsqueue);
		}
		using (TimeWarning.New("UpdateSkinQueue"))
		{
			BuildingBlock.updateSkinQueueServer.RunQueue(1.0);
		}
		using (TimeWarning.New("BuildingDecayTick"))
		{
			int num = 5;
			BufferList<Building> values = buildingDictionary.Values;
			for (int i = decayTickBuildingIndex; i < values.Count; i++)
			{
				if (num <= 0)
				{
					break;
				}
				BufferList<DecayEntity> values2 = values[i].decayEntities.Values;
				for (int j = decayTickEntityIndex; j < values2.Count; j++)
				{
					if (num <= 0)
					{
						break;
					}
					values2[j].DecayTick();
					num--;
					if (num <= 0)
					{
						decayTickBuildingIndex = i;
						decayTickEntityIndex = j;
					}
				}
				if (num > 0)
				{
					decayTickEntityIndex = 0;
				}
			}
			if (num > 0)
			{
				decayTickBuildingIndex = 0;
			}
		}
		using (TimeWarning.New("WorldDecayTick"))
		{
			int num2 = 5;
			BufferList<DecayEntity> values3 = decayEntities.Values;
			for (int k = decayTickWorldIndex; k < values3.Count; k++)
			{
				if (num2 <= 0)
				{
					break;
				}
				values3[k].DecayTick();
				num2--;
				if (num2 <= 0)
				{
					decayTickWorldIndex = k;
				}
			}
			if (num2 > 0)
			{
				decayTickWorldIndex = 0;
			}
		}
		if (!AI.nav_carve_use_building_optimization)
		{
			return;
		}
		using (TimeWarning.New("NavMeshCarving"))
		{
			int ticks = 5;
			BufferList<Building> values4 = buildingDictionary.Values;
			for (int l = navmeshCarveTickBuildingIndex; l < values4.Count; l++)
			{
				if (ticks <= 0)
				{
					break;
				}
				Building building = values4[l];
				UpdateNavMeshCarver(building, ref ticks, l);
			}
			if (ticks > 0)
			{
				navmeshCarveTickBuildingIndex = 0;
			}
		}
	}

	public void UpdateNavMeshCarver(Building building, ref int ticks, int i)
	{
		if (!AI.nav_carve_use_building_optimization || (!building.isNavMeshCarveOptimized && building.navmeshCarvers.Count < AI.nav_carve_min_building_blocks_to_apply_optimization) || !building.isNavMeshCarvingDirty)
		{
			return;
		}
		building.isNavMeshCarvingDirty = false;
		if (building.navmeshCarvers == null)
		{
			if (building.buildingNavMeshObstacle != null)
			{
				Object.Destroy(building.buildingNavMeshObstacle.gameObject);
				building.buildingNavMeshObstacle = null;
				building.isNavMeshCarveOptimized = false;
			}
			return;
		}
		Vector3 vector = new Vector3(World.Size, World.Size, World.Size);
		Vector3 vector2 = new Vector3(0L - (long)World.Size, 0L - (long)World.Size, 0L - (long)World.Size);
		int count = building.navmeshCarvers.Count;
		if (count > 0)
		{
			for (int j = 0; j < count; j++)
			{
				NavMeshObstacle navMeshObstacle = building.navmeshCarvers[j];
				if (navMeshObstacle.enabled)
				{
					navMeshObstacle.enabled = false;
				}
				for (int k = 0; k < 3; k++)
				{
					if (navMeshObstacle.transform.position[k] < vector[k])
					{
						vector[k] = navMeshObstacle.transform.position[k];
					}
					if (navMeshObstacle.transform.position[k] > vector2[k])
					{
						vector2[k] = navMeshObstacle.transform.position[k];
					}
				}
			}
			Vector3 position = (vector2 + vector) * 0.5f;
			Vector3 zero = Vector3.zero;
			float num = Mathf.Abs(position.x - vector.x);
			float num2 = Mathf.Abs(position.y - vector.y);
			float num3 = Mathf.Abs(position.z - vector.z);
			float num4 = Mathf.Abs(vector2.x - position.x);
			float num5 = Mathf.Abs(vector2.y - position.y);
			float num6 = Mathf.Abs(vector2.z - position.z);
			zero.x = Mathf.Max((num > num4) ? num : num4, AI.nav_carve_min_base_size);
			zero.y = Mathf.Max((num2 > num5) ? num2 : num5, AI.nav_carve_min_base_size);
			zero.z = Mathf.Max((num3 > num6) ? num3 : num6, AI.nav_carve_min_base_size);
			if (count < 10)
			{
				zero *= AI.nav_carve_size_multiplier;
			}
			else
			{
				zero *= AI.nav_carve_size_multiplier - 1f;
			}
			if (building.navmeshCarvers.Count > 0)
			{
				if (building.buildingNavMeshObstacle == null)
				{
					building.buildingNavMeshObstacle = new GameObject($"Building ({building.ID}) NavMesh Carver").AddComponent<NavMeshObstacle>();
					building.buildingNavMeshObstacle.enabled = false;
					building.buildingNavMeshObstacle.carving = true;
					building.buildingNavMeshObstacle.shape = NavMeshObstacleShape.Box;
					building.buildingNavMeshObstacle.height = AI.nav_carve_height;
					building.isNavMeshCarveOptimized = true;
				}
				if (building.buildingNavMeshObstacle != null)
				{
					building.buildingNavMeshObstacle.transform.position = position;
					building.buildingNavMeshObstacle.size = zero;
					if (!building.buildingNavMeshObstacle.enabled)
					{
						building.buildingNavMeshObstacle.enabled = true;
					}
				}
			}
		}
		else if (building.buildingNavMeshObstacle != null)
		{
			Object.Destroy(building.buildingNavMeshObstacle.gameObject);
			building.buildingNavMeshObstacle = null;
			building.isNavMeshCarveOptimized = false;
		}
		ticks--;
		if (ticks <= 0)
		{
			navmeshCarveTickBuildingIndex = i;
		}
	}

	public uint NewBuildingID()
	{
		return ++maxBuildingID;
	}

	public void LoadBuildingID(uint id)
	{
		maxBuildingID = Mathx.Max(maxBuildingID, id);
	}

	protected override Building CreateBuilding(uint id)
	{
		return new Building
		{
			ID = id
		};
	}

	protected override void DisposeBuilding(ref Building building)
	{
		building = null;
	}
}
