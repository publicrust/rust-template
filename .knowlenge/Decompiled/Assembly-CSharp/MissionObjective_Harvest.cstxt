using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Harvest")]
public class MissionObjective_Harvest : MissionObjective
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition[] targetItems;

	public int targetItemAmount;

	public ItemDefinition[] pingResourceDispensers;

	public BasePlayer.PingType pingType = BasePlayer.PingType.GoTo;

	public bool countExisting;

	public override void PostServerLoad(BasePlayer player, BaseMission.MissionInstance.ObjectiveStatus status)
	{
		base.PostServerLoad(player, status);
		if (status.started && !status.completed)
		{
			InitialiseResourcePings(player);
		}
	}

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = targetItemAmount;
	}

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveStarted(playerFor, index, instance);
		InitialiseResourcePings(playerFor);
		if (countExisting && targetItems.Length != 0)
		{
			int num = 0;
			ItemDefinition[] array = targetItems;
			foreach (ItemDefinition definition in array)
			{
				num += playerFor.inventory.GetAmount(definition);
			}
			ProcessMissionEvent(playerFor, instance, index, BaseMission.MissionEventType.HARVEST, new BaseMission.MissionEventPayload
			{
				IntIdentifier = targetItems[0].itemid
			}, num);
		}
	}

	private void InitialiseResourcePings(BasePlayer forPlayer)
	{
		if (pingResourceDispensers != null)
		{
			ItemDefinition[] array = pingResourceDispensers;
			foreach (ItemDefinition forItem in array)
			{
				forPlayer.EnableResourcePings(forItem, pingType);
			}
		}
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (type != BaseMission.MissionEventType.HARVEST || IsCompleted(index, instance) || !CanProgress(index, instance))
		{
			return;
		}
		ItemDefinition[] array = targetItems;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].itemid == payload.IntIdentifier)
			{
				instance.objectiveStatuses[index].progressCurrent += (int)amount;
				if (instance.objectiveStatuses[index].progressCurrent >= (float)targetItemAmount)
				{
					CompleteObjective(index, instance, playerFor);
				}
				playerFor.MissionDirty();
				break;
			}
		}
	}

	public override void ObjectiveCompleted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		base.ObjectiveCompleted(playerFor, index, instance);
		if (pingResourceDispensers != null)
		{
			ItemDefinition[] array = pingResourceDispensers;
			foreach (ItemDefinition forItem in array)
			{
				playerFor.DisableResourcePings(forItem, pingType);
			}
		}
	}
}
