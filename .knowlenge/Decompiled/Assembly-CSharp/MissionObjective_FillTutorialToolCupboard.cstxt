using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Missions/OBJECTIVES/Fill Tutorial TC")]
public class MissionObjective_FillTutorialToolCupboard : MissionObjective
{
	public int RequiredUpkeepHours = 24;

	public override void MissionStarted(int index, BaseMission.MissionInstance instance, BasePlayer forPlayer)
	{
		base.MissionStarted(index, instance, forPlayer);
		instance.objectiveStatuses[index].progressCurrent = 0f;
		instance.objectiveStatuses[index].progressTarget = RequiredUpkeepHours;
	}

	public override void Think(int index, BaseMission.MissionInstance instance, BasePlayer assignee, float delta)
	{
		base.Think(index, instance, assignee, delta);
		if (!IsStarted(index, instance))
		{
			return;
		}
		BuildingPrivlidge buildingPrivilege = assignee.GetBuildingPrivilege();
		if (!(buildingPrivilege != null))
		{
			return;
		}
		int num = Mathf.RoundToInt(buildingPrivilege.GetProtectedMinutes() / 60f);
		if (num != Mathf.RoundToInt(instance.objectiveStatuses[index].progressCurrent))
		{
			instance.objectiveStatuses[index].progressCurrent = num;
			if (num >= RequiredUpkeepHours)
			{
				CompleteObjective(index, instance, assignee);
			}
			assignee.MissionDirty();
		}
	}
}
