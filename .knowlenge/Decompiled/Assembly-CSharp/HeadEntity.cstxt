using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class HeadEntity : BaseEntity
{
	public HeadData CurrentTrophyData;

	private const Wearable.OccupationSlots HeadMask = Wearable.OccupationSlots.HeadTop | Wearable.OccupationSlots.Face | Wearable.OccupationSlots.HeadBack | Wearable.OccupationSlots.Mouth | Wearable.OccupationSlots.Eyes;

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.headData == null && CurrentTrophyData != null)
		{
			info.msg.headData = Pool.Get<HeadData>();
			CurrentTrophyData.CopyTo(info.msg.headData);
		}
	}

	public void SetupSourceId(uint sourceID)
	{
		InitTrophyData();
		CurrentTrophyData.entitySource = sourceID;
		CurrentTrophyData.horseBreed = 0;
		CurrentTrophyData.playerId = 0uL;
		CurrentTrophyData.playerName = string.Empty;
		CurrentTrophyData.clothing?.Clear();
	}

	public void SetupPlayerId(string playerName, ulong playerId)
	{
		InitTrophyData();
		CurrentTrophyData.playerName = playerName;
		CurrentTrophyData.playerId = playerId;
	}

	public void AssignClothing(ItemContainer container)
	{
		InitTrophyData();
		if (CurrentTrophyData.clothing == null)
		{
			CurrentTrophyData.clothing = Pool.Get<List<int>>();
		}
		foreach (Item item in container.itemList)
		{
			if (item.info.TryGetComponent<ItemModWearable>(out var component) && component.entityPrefab.isValid)
			{
				Wearable component2 = component.entityPrefab.Get().GetComponent<Wearable>();
				if ((component2.occupationOver & (Wearable.OccupationSlots.HeadTop | Wearable.OccupationSlots.Face | Wearable.OccupationSlots.HeadBack | Wearable.OccupationSlots.Mouth | Wearable.OccupationSlots.Eyes)) != 0 || component2.occupationOver == (Wearable.OccupationSlots)0)
				{
					CurrentTrophyData.clothing.Add(item.info.itemid);
				}
			}
		}
	}

	public void AssignHorseBreed(int breed)
	{
		InitTrophyData();
		CurrentTrophyData.horseBreed = breed;
	}

	private void InitTrophyData()
	{
		if (CurrentTrophyData == null)
		{
			CurrentTrophyData = Pool.Get<HeadData>();
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.headData != null)
		{
			InitTrophyData();
			info.msg.headData.CopyTo(CurrentTrophyData);
		}
		else if (CurrentTrophyData != null)
		{
			Pool.Free(ref CurrentTrophyData);
		}
	}

	public GameObject GetHeadSource()
	{
		if (CurrentTrophyData == null)
		{
			return null;
		}
		return GameManager.server.FindPrefab(CurrentTrophyData.entitySource);
	}
}
