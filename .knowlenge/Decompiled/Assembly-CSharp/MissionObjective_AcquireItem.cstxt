using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/AcquireItem")]
public class MissionObjective_AcquireItem : MissionObjective
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition targetItem;

	public int targetItemAmount;

	public bool allowStackEvents;

	public bool showResourcePings;

	public bool acceptExistingItems;

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = targetItemAmount;
		if (showResourcePings)
		{
			forPlayer.EnableResourcePings(targetItem, BasePlayer.PingType.GoTo);
		}
		if (acceptExistingItems)
		{
			int amount = forPlayer.inventory.GetAmount(targetItem);
			if (amount > 0)
			{
				ProcessMissionEvent(forPlayer, instance, index, BaseMission.MissionEventType.ACQUIRE_ITEM, new BaseMission.MissionEventPayload
				{
					IntIdentifier = targetItem.itemid
				}, amount);
			}
		}
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, BaseMission.MissionEventPayload payload, float amount)
	{
		base.ProcessMissionEvent(playerFor, instance, index, type, payload, amount);
		if (((type == BaseMission.MissionEventType.ACQUITE_ITEM_STACK && allowStackEvents) || type == BaseMission.MissionEventType.ACQUIRE_ITEM) && !IsCompleted(index, instance) && CanProgress(index, instance) && targetItem.itemid == payload.IntIdentifier)
		{
			instance.objectiveStatuses[index].progressCurrent += (int)amount;
			if (instance.objectiveStatuses[index].progressCurrent >= (float)targetItemAmount)
			{
				CompleteObjective(index, instance, playerFor);
			}
			if (showResourcePings)
			{
				playerFor.DisableResourcePings(targetItem, BasePlayer.PingType.GoTo);
			}
			playerFor.MissionDirty();
		}
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
	}
}
