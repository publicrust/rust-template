using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAchievement : TriggerBase
{
	public string statToIncrease = "";

	public string achievementOnEnter = "";

	public string requiredVehicleName = "";

	[Tooltip("Always set to true, clientside does not work, currently")]
	public bool serverSide = true;

	public bool allowDuringTutorial;

	[NonSerialized]
	private List<ulong> triggeredPlayers = new List<ulong>();

	public void OnPuzzleReset()
	{
		Reset();
	}

	public void Reset()
	{
		triggeredPlayers.Clear();
	}

	public override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity == null)
		{
			return null;
		}
		if (baseEntity.isClient && serverSide)
		{
			return null;
		}
		if (baseEntity.isServer && !serverSide)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	public override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if (ent == null)
		{
			return;
		}
		BasePlayer component = ent.GetComponent<BasePlayer>();
		if (component == null || !component.IsAlive() || component.IsSleeping() || component.IsNpc || triggeredPlayers.Contains(component.userID))
		{
			return;
		}
		if (!string.IsNullOrEmpty(requiredVehicleName))
		{
			BaseVehicle mountedVehicle = component.GetMountedVehicle();
			if (mountedVehicle == null || !mountedVehicle.ShortPrefabName.Contains(requiredVehicleName))
			{
				return;
			}
		}
		if (serverSide)
		{
			if (!string.IsNullOrEmpty(achievementOnEnter))
			{
				component.GiveAchievement(achievementOnEnter, allowDuringTutorial);
			}
			if (!string.IsNullOrEmpty(statToIncrease))
			{
				component.stats.Add(statToIncrease, 1);
				component.stats.Save(forceSteamSave: true);
			}
			triggeredPlayers.Add(component.userID);
		}
	}
}
