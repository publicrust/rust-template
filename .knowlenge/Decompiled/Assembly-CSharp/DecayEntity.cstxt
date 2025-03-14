using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Oxide.Core;
using ProtoBuf;
using Rust;
using UnityEngine;

public class DecayEntity : BaseCombatEntity
{
	public GameObjectRef debrisPrefab;

	[NonSerialized]
	public uint buildingID;

	public float decayTimer;

	public float upkeepTimer;

	public Upkeep upkeep;

	public Decay decay;

	public DecayPoint[] decayPoints;

	public float lastDecayTick;

	public float decayVariance = 1f;

	public virtual bool BypassInsideDecayMultiplier => false;

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.decayEntity = Facepunch.Pool.Get<ProtoBuf.DecayEntity>();
		info.msg.decayEntity.buildingID = buildingID;
		if (info.forDisk)
		{
			info.msg.decayEntity.decayTimer = decayTimer;
			info.msg.decayEntity.upkeepTimer = upkeepTimer;
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.decayEntity == null)
		{
			return;
		}
		decayTimer = info.msg.decayEntity.decayTimer;
		upkeepTimer = info.msg.decayEntity.upkeepTimer;
		if (buildingID != info.msg.decayEntity.buildingID)
		{
			AttachToBuilding(info.msg.decayEntity.buildingID);
			if (info.fromDisk)
			{
				BuildingManager.server.LoadBuildingID(buildingID);
			}
		}
	}

	public override void ResetState()
	{
		base.ResetState();
		buildingID = 0u;
		if (base.isServer)
		{
			decayTimer = 0f;
		}
	}

	public void AttachToBuilding(uint id)
	{
		if (base.isServer)
		{
			BuildingManager.server.Remove(this);
			buildingID = id;
			BuildingManager.server.Add(this);
			SendNetworkUpdate();
		}
	}

	public BuildingManager.Building GetBuilding()
	{
		if (base.isServer)
		{
			return BuildingManager.server.GetBuilding(buildingID);
		}
		return null;
	}

	public override BuildingPrivlidge GetBuildingPrivilege()
	{
		BuildingManager.Building building = GetBuilding();
		if (building != null)
		{
			return building.GetDominatingBuildingPrivilege();
		}
		return base.GetBuildingPrivilege();
	}

	public void CalculateUpkeepCostAmounts(List<ItemAmount> itemAmounts, float multiplier)
	{
		if (upkeep == null)
		{
			return;
		}
		float num = upkeep.upkeepMultiplier * multiplier;
		if (num == 0f)
		{
			return;
		}
		List<ItemAmount> list = BuildCost();
		if (list == null)
		{
			return;
		}
		foreach (ItemAmount item in list)
		{
			if (item.itemDef.category != ItemCategory.Resources)
			{
				continue;
			}
			float num2 = item.amount * num;
			bool flag = false;
			foreach (ItemAmount itemAmount in itemAmounts)
			{
				if (itemAmount.itemDef == item.itemDef)
				{
					itemAmount.amount += num2;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				itemAmounts.Add(new ItemAmount(item.itemDef, num2));
			}
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		decayVariance = UnityEngine.Random.Range(0.95f, 1f);
		decay = PrefabAttribute.server.Find<Decay>(prefabID);
		decayPoints = PrefabAttribute.server.FindAll<DecayPoint>(prefabID);
		upkeep = PrefabAttribute.server.Find<Upkeep>(prefabID);
		BuildingManager.server.Add(this);
		if (!Rust.Application.isLoadingSave)
		{
			BuildingManager.server.CheckMerge(this);
		}
		lastDecayTick = UnityEngine.Time.time;
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		BuildingManager.server.Remove(this);
		BuildingManager.server.CheckSplit(this);
	}

	public virtual void AttachToBuilding(DecayEntity other)
	{
		if (other != null)
		{
			AttachToBuilding(other.buildingID);
			BuildingManager.server.CheckMerge(this);
			return;
		}
		BuildingBlock nearbyBuildingBlock = GetNearbyBuildingBlock();
		if ((bool)nearbyBuildingBlock)
		{
			AttachToBuilding(nearbyBuildingBlock.buildingID);
		}
	}

	public BuildingBlock GetNearbyBuildingBlock()
	{
		float num = float.MaxValue;
		BuildingBlock result = null;
		Vector3 position = PivotPoint();
		List<BuildingBlock> obj = Facepunch.Pool.GetList<BuildingBlock>();
		Vis.Entities(position, 1.5f, obj, 2097152);
		for (int i = 0; i < obj.Count; i++)
		{
			BuildingBlock buildingBlock = obj[i];
			if (buildingBlock.isServer == base.isServer)
			{
				float num2 = buildingBlock.SqrDistance(position);
				if (!buildingBlock.grounded)
				{
					num2 += 1f;
				}
				if (num2 < num)
				{
					num = num2;
					result = buildingBlock;
				}
			}
		}
		Facepunch.Pool.FreeList(ref obj);
		return result;
	}

	public void ResetUpkeepTime()
	{
		upkeepTimer = 0f;
	}

	public void DecayTouch()
	{
		decayTimer = 0f;
	}

	public void AddUpkeepTime(float time)
	{
		upkeepTimer -= time;
	}

	public float GetProtectedSeconds()
	{
		return Mathf.Max(0f, 0f - upkeepTimer);
	}

	public virtual void DecayTick()
	{
		if (decay == null)
		{
			return;
		}
		float num = UnityEngine.Time.time - lastDecayTick;
		if (num < ConVar.Decay.tick)
		{
			return;
		}
		lastDecayTick = UnityEngine.Time.time;
		if (!decay.ShouldDecay(this))
		{
			return;
		}
		float num2 = num * ConVar.Decay.scale;
		if (ConVar.Decay.upkeep)
		{
			upkeepTimer += num2;
			if (upkeepTimer > 0f)
			{
				BuildingPrivlidge buildingPrivilege = GetBuildingPrivilege();
				if (buildingPrivilege != null)
				{
					upkeepTimer -= buildingPrivilege.PurchaseUpkeepTime(this, Mathf.Max(upkeepTimer, 600f));
				}
			}
			if (upkeepTimer < 1f)
			{
				if (base.healthFraction < 1f && ConVar.Decay.upkeep_heal_scale > 0f && base.SecondsSinceAttacked > 600f && Interface.CallHook("OnDecayHeal", this) == null)
				{
					float num3 = num / decay.GetDecayDuration(this) * ConVar.Decay.upkeep_heal_scale;
					Heal(MaxHealth() * num3);
				}
				return;
			}
			upkeepTimer = 1f;
		}
		decayTimer += num2;
		if (decayTimer < decay.GetDecayDelay(this))
		{
			return;
		}
		using (TimeWarning.New("DecayTick"))
		{
			float num4 = 1f;
			if (ConVar.Decay.upkeep)
			{
				if (!BypassInsideDecayMultiplier && !IsOutside())
				{
					num4 *= ConVar.Decay.upkeep_inside_decay_scale;
				}
			}
			else
			{
				for (int i = 0; i < decayPoints.Length; i++)
				{
					DecayPoint decayPoint = decayPoints[i];
					if (decayPoint.IsOccupied(this))
					{
						num4 -= decayPoint.protection;
					}
				}
			}
			if (num4 > 0f && Interface.CallHook("OnDecayDamage", this) == null)
			{
				float num5 = num2 / decay.GetDecayDuration(this) * MaxHealth();
				Hurt(num5 * num4 * decayVariance, DamageType.Decay);
			}
		}
	}

	public override void OnRepairFinished()
	{
		base.OnRepairFinished();
		DecayTouch();
	}

	public override void OnKilled(HitInfo info)
	{
		if (debrisPrefab.isValid)
		{
			BaseEntity baseEntity = GameManager.server.CreateEntity(debrisPrefab.resourcePath, base.transform.position, base.transform.rotation);
			if ((bool)baseEntity)
			{
				baseEntity.Spawn();
			}
		}
		base.OnKilled(info);
	}
}
