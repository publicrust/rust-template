using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDanceAchievement : TriggerBase
{
	public int RequiredPlayerCount = 3;

	public string AchievementName;

	[NonSerialized]
	private List<NetworkableId> triggeredPlayers = new List<NetworkableId>();

	public void OnPuzzleReset()
	{
		Reset();
	}

	public void Reset()
	{
		triggeredPlayers.Clear();
	}

	internal override GameObject InterestedInObject(GameObject obj)
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
		if (!(baseEntity is BasePlayer))
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	public void NotifyDanceStarted()
	{
		if (entityContents == null)
		{
			return;
		}
		int num = 0;
		foreach (BaseEntity entityContent in entityContents)
		{
			if (entityContent.ToPlayer() != null && entityContent.ToPlayer().CurrentGestureIsDance)
			{
				num++;
				if (num >= RequiredPlayerCount)
				{
					break;
				}
			}
		}
		if (num < RequiredPlayerCount)
		{
			return;
		}
		foreach (BaseEntity entityContent2 in entityContents)
		{
			if (!triggeredPlayers.Contains(entityContent2.net.ID) && entityContent2.ToPlayer() != null)
			{
				entityContent2.ToPlayer().GiveAchievement(AchievementName);
				triggeredPlayers.Add(entityContent2.net.ID);
			}
		}
	}
}
