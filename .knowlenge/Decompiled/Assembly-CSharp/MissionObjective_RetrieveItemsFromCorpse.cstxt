using System.Collections.Generic;
using Facepunch;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Retrieve Items from corpse")]
public class MissionObjective_RetrieveItemsFromCorpse : MissionObjective
{
	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
		if (playerFor.ServerCurrentDeathNote == null)
		{
			return;
		}
		List<PlayerCorpse> obj = Pool.Get<List<PlayerCorpse>>();
		Vis.Entities(playerFor.ServerCurrentDeathNote.worldPosition, 3f, obj, 512);
		foreach (PlayerCorpse item in obj)
		{
			if (item != null && item.isServer)
			{
				playerFor.RegisterPingedEntity(item, BasePlayer.PingType.Loot);
				break;
			}
		}
		Pool.FreeUnmanaged(ref obj);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type != BaseMission.MissionEventType.OPEN_STORAGE || IsCompleted(index, instance) || !CanProgress(index, instance))
		{
			return;
		}
		BaseNetworkable baseNetworkable = BaseNetworkable.serverEntities.Find(payload.NetworkIdentifier);
		if (baseNetworkable != null)
		{
			bool flag = baseNetworkable is PlayerCorpse playerCorpse && playerCorpse.playerSteamID == (ulong)playerFor.userID;
			if (!flag && baseNetworkable is DroppedItemContainer droppedItemContainer && droppedItemContainer.playerSteamID == (ulong)playerFor.userID)
			{
				flag = true;
			}
			if (flag)
			{
				playerFor.DeregisterPingedEntity(payload.NetworkIdentifier, BasePlayer.PingType.Loot);
				CompleteObjective(index, instance, playerFor);
			}
		}
	}
}
