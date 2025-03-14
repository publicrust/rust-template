using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionGrade : PrefabAttribute
{
	[NonSerialized]
	public Construction construction;

	public BuildingGrade gradeBase;

	public GameObjectRef skinObject;

	internal List<ItemAmount> _costToBuild;

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

	public List<ItemAmount> costToBuild
	{
		get
		{
			if (_costToBuild != null)
			{
				return _costToBuild;
			}
			_costToBuild = new List<ItemAmount>();
			foreach (ItemAmount item in gradeBase.baseCost)
			{
				_costToBuild.Add(new ItemAmount(item.itemDef, Mathf.Ceil(item.amount * construction.costMultiplier)));
			}
			return _costToBuild;
		}
	}

	protected override Type GetIndexedType()
	{
		return typeof(ConstructionGrade);
	}
}
