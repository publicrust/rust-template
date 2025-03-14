using System;
using System.Collections.Generic;
using ConVar;
using UnityEngine;

public class ConstructionGrade : PrefabAttribute
{
	private struct CachedAmount
	{
		public List<ItemAmount> costs;

		public float cachedConVarMultiplier;
	}

	[NonSerialized]
	public Construction construction;

	public BuildingGrade gradeBase;

	public GameObjectRef skinObject;

	private Dictionary<BuildingGrade.Enum, CachedAmount> _costs;

	private float _costBuildPercent;

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
		_costs = new Dictionary<BuildingGrade.Enum, CachedAmount>();
		foreach (BuildingGrade.Enum value in Enum.GetValues(typeof(BuildingGrade.Enum)))
		{
			UpdateCosts(value);
		}
	}

	private void UpdateCosts(BuildingGrade.Enum grade)
	{
		List<ItemAmount> list = new List<ItemAmount>();
		float num = ((grade == gradeBase.type) ? 0.2f : 1f);
		float costMultiplier = ConVar.Decay.GetCostMultiplier(gradeBase.type);
		foreach (ItemAmount item in gradeBase.baseCost)
		{
			list.Add(new ItemAmount(item.itemDef, Mathf.Ceil(item.amount * construction.costMultiplier * num * costMultiplier)));
		}
		_costs[grade] = new CachedAmount
		{
			cachedConVarMultiplier = costMultiplier,
			costs = list
		};
	}

	public List<ItemAmount> CostToBuild(BuildingGrade.Enum fromGrade = BuildingGrade.Enum.None)
	{
		if (ConVar.Decay.GetCostMultiplier(gradeBase.type) != _costs[fromGrade].cachedConVarMultiplier)
		{
			UpdateCosts(fromGrade);
		}
		return _costs[fromGrade].costs;
	}

	protected override Type GetIndexedType()
	{
		return typeof(ConstructionGrade);
	}
}
