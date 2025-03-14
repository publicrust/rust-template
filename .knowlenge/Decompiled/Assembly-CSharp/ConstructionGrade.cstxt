using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionGrade : PrefabAttribute
{
	[NonSerialized]
	public Construction construction;

	public BuildingGrade gradeBase;

	public GameObjectRef skinObject;

	private Dictionary<BuildingGrade.Enum, List<ItemAmount>> _costs;

	public float maxHealth
	{
		get
		{
			if (!gradeBase || !construction)
			{
				return 0f;
			}
			return gradeBase.baseHealth * construction.healthMultiplier;
		}
	}

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.AttributeSetup(rootObj, name, serverside, clientside, bundling);
		_costs = new Dictionary<BuildingGrade.Enum, List<ItemAmount>>();
		foreach (BuildingGrade.Enum value in Enum.GetValues(typeof(BuildingGrade.Enum)))
		{
			List<ItemAmount> list = new List<ItemAmount>();
			float num = ((value == gradeBase.type) ? 0.2f : 1f);
			foreach (ItemAmount item in gradeBase.baseCost)
			{
				list.Add(new ItemAmount(item.itemDef, Mathf.Ceil(item.amount * construction.costMultiplier * num)));
			}
			_costs.Add(value, list);
		}
	}

	public List<ItemAmount> CostToBuild(BuildingGrade.Enum fromGrade = BuildingGrade.Enum.None)
	{
		return _costs[fromGrade];
	}

	protected override Type GetIndexedType()
	{
		return typeof(ConstructionGrade);
	}
}
