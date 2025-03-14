using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/SpeakWith")]
public class MissionObjective_SpeakWith : MissionObjective
{
	public ItemAmount[] requiredReturnItems;

	public bool destroyReturnItems;

	public override void ObjectiveStarted(BasePlayer playerFor, int index, BaseMission.MissionInstance instance)
	{
		BaseEntity baseEntity = instance.ProviderEntity();
		if ((bool)baseEntity)
		{
			instance.missionLocation = baseEntity.transform.position;
			playerFor.MissionDirty();
		}
		base.ObjectiveStarted(playerFor, index, instance);
	}

	public override void ProcessMissionEvent(BasePlayer playerFor, BaseMission.MissionInstance instance, int index, BaseMission.MissionEventType type, string identifier, float amount)
	{
		if (IsCompleted(index, instance) || !CanProgress(index, instance))
		{
			return;
		}
		if (type == BaseMission.MissionEventType.CONVERSATION)
		{
			BaseEntity baseEntity = instance.ProviderEntity();
			if ((bool)baseEntity)
			{
				IMissionProvider component = baseEntity.GetComponent<IMissionProvider>();
				if (component != null && component.ProviderID().Value.ToString() == identifier && amount == 1f)
				{
					bool flag = true;
					if (requiredReturnItems != null && requiredReturnItems.Length != 0)
					{
						ItemAmount[] array = requiredReturnItems;
						foreach (ItemAmount itemAmount in array)
						{
							if ((float)playerFor.inventory.GetAmount(itemAmount.itemDef.itemid) < itemAmount.amount)
							{
								flag = false;
								break;
							}
						}
						if (flag && destroyReturnItems)
						{
							array = requiredReturnItems;
							foreach (ItemAmount itemAmount2 in array)
							{
								playerFor.inventory.Take(null, itemAmount2.itemDef.itemid, (int)itemAmount2.amount);
							}
						}
					}
					if (requiredReturnItems == null || requiredReturnItems.Length == 0 || flag)
					{
						CompleteObjective(index, instance, playerFor);
						playerFor.MissionDirty();
					}
				}
			}
		}
		base.ProcessMissionEvent(playerFor, instance, index, type, identifier, amount);
	}
}
