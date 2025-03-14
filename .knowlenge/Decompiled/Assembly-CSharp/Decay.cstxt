using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using UnityEngine;

public abstract class Decay : PrefabAttribute, IServerComponent
{
	private const float hours = 3600f;

	protected float GetDecayDelay(BuildingGrade.Enum grade)
	{
		if (ConVar.Decay.upkeep)
		{
			if (ConVar.Decay.delay_override > 0f)
			{
				return ConVar.Decay.delay_override;
			}
			return grade switch
			{
				BuildingGrade.Enum.Wood => ConVar.Decay.delay_wood * 3600f, 
				BuildingGrade.Enum.Stone => ConVar.Decay.delay_stone * 3600f, 
				BuildingGrade.Enum.Metal => ConVar.Decay.delay_metal * 3600f, 
				BuildingGrade.Enum.TopTier => ConVar.Decay.delay_toptier * 3600f, 
				_ => ConVar.Decay.delay_twig * 3600f, 
			};
		}
		return grade switch
		{
			BuildingGrade.Enum.Wood => 64800f, 
			BuildingGrade.Enum.Stone => 64800f, 
			BuildingGrade.Enum.Metal => 64800f, 
			BuildingGrade.Enum.TopTier => 86400f, 
			_ => 3600f, 
		};
	}

	protected float GetDecayDuration(BuildingGrade.Enum grade)
	{
		if (ConVar.Decay.upkeep)
		{
			if (ConVar.Decay.duration_override > 0f)
			{
				return ConVar.Decay.duration_override;
			}
			return grade switch
			{
				BuildingGrade.Enum.Wood => ConVar.Decay.duration_wood * 3600f, 
				BuildingGrade.Enum.Stone => ConVar.Decay.duration_stone * 3600f, 
				BuildingGrade.Enum.Metal => ConVar.Decay.duration_metal * 3600f, 
				BuildingGrade.Enum.TopTier => ConVar.Decay.duration_toptier * 3600f, 
				_ => ConVar.Decay.duration_twig * 3600f, 
			};
		}
		return grade switch
		{
			BuildingGrade.Enum.Wood => 86400f, 
			BuildingGrade.Enum.Stone => 172800f, 
			BuildingGrade.Enum.Metal => 259200f, 
			BuildingGrade.Enum.TopTier => 432000f, 
			_ => 3600f, 
		};
	}

	public static void BuildingDecayTouch(BuildingBlock buildingBlock)
	{
		if (ConVar.Decay.upkeep)
		{
			return;
		}
		List<DecayEntity> obj = Facepunch.Pool.GetList<DecayEntity>();
		Vis.Entities(buildingBlock.transform.position, 40f, obj, 2097408);
		for (int i = 0; i < obj.Count; i++)
		{
			DecayEntity decayEntity = obj[i];
			BuildingBlock buildingBlock2 = decayEntity as BuildingBlock;
			if (!buildingBlock2 || buildingBlock2.buildingID == buildingBlock.buildingID)
			{
				decayEntity.DecayTouch();
			}
		}
		Facepunch.Pool.FreeList(ref obj);
	}

	public static void EntityLinkDecayTouch(BaseEntity ent)
	{
		if (!ConVar.Decay.upkeep)
		{
			ent.EntityLinkBroadcast(delegate(DecayEntity decayEnt)
			{
				decayEnt.DecayTouch();
			});
		}
	}

	public static void RadialDecayTouch(Vector3 pos, float radius, int mask)
	{
		if (!ConVar.Decay.upkeep)
		{
			List<DecayEntity> obj = Facepunch.Pool.GetList<DecayEntity>();
			Vis.Entities(pos, radius, obj, mask);
			for (int i = 0; i < obj.Count; i++)
			{
				obj[i].DecayTouch();
			}
			Facepunch.Pool.FreeList(ref obj);
		}
	}

	public virtual bool ShouldDecay(BaseEntity entity)
	{
		return true;
	}

	public abstract float GetDecayDelay(BaseEntity entity);

	public abstract float GetDecayDuration(BaseEntity entity);

	protected override Type GetIndexedType()
	{
		return typeof(Decay);
	}
}
