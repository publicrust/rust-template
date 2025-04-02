using ConVar;
using UnityEngine;

public class BuildingBlockDecay : Decay
{
	private bool isFoundation;

	public override float GetDecayDelay(BaseEntity entity)
	{
		BuildingBlock buildingBlock = entity as BuildingBlock;
		BuildingGrade.Enum grade = (buildingBlock ? buildingBlock.grade : BuildingGrade.Enum.Twigs);
		return GetDecayDelay(grade);
	}

	public override float GetDecayDuration(BaseEntity entity)
	{
		BuildingBlock buildingBlock = entity as BuildingBlock;
		BuildingGrade.Enum grade = (buildingBlock ? buildingBlock.grade : BuildingGrade.Enum.Twigs);
		return GetDecayDuration(grade);
	}

	public override bool ShouldDecay(BaseEntity entity)
	{
		if (entity.net.group != null && entity.net.group.restricted)
		{
			return false;
		}
		if (ConVar.Decay.upkeep)
		{
			return true;
		}
		if (isFoundation)
		{
			return true;
		}
		BuildingBlock buildingBlock = entity as BuildingBlock;
		return !buildingBlock || buildingBlock.grade == BuildingGrade.Enum.Twigs;
	}

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		isFoundation = name.Contains("foundation");
	}
}
