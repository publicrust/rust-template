using System;
using System.Collections.Generic;
using Oxide.Core;
using UnityEngine;

public class ResourceDepositManager : BaseEntity
{
	[Serializable]
	public class ResourceDeposit
	{
		[Serializable]
		public enum surveySpawnType
		{
			ITEM,
			OIL,
			WATER
		}

		[Serializable]
		public class ResourceDepositEntry
		{
			public ItemDefinition type;

			public float efficiency = 1f;

			public int amount;

			public int startAmount;

			public float workNeeded = 1f;

			public float workDone;

			public surveySpawnType spawnType;

			public bool isLiquid;

			public void Subtract(int subamount)
			{
				if (subamount > 0)
				{
					amount -= subamount;
					if (amount < 0)
					{
						amount = 0;
					}
				}
			}
		}

		public float lastSurveyTime = float.NegativeInfinity;

		public Vector3 origin;

		public List<ResourceDepositEntry> _resources;

		public ResourceDeposit()
		{
			_resources = new List<ResourceDepositEntry>();
		}

		public void Add(ItemDefinition type, float efficiency, int amount, float workNeeded, surveySpawnType spawnType, bool liquid = false)
		{
			ResourceDepositEntry resourceDepositEntry = new ResourceDepositEntry();
			resourceDepositEntry.type = type;
			resourceDepositEntry.efficiency = efficiency;
			resourceDepositEntry.startAmount = (resourceDepositEntry.amount = amount);
			resourceDepositEntry.spawnType = spawnType;
			resourceDepositEntry.workNeeded = workNeeded;
			resourceDepositEntry.isLiquid = liquid;
			_resources.Add(resourceDepositEntry);
		}
	}

	public static ResourceDepositManager _manager;

	private const int resolution = 20;

	public Dictionary<Vector2i, ResourceDeposit> _deposits;

	public static Vector2i GetIndexFrom(Vector3 pos)
	{
		return new Vector2i((int)pos.x / 20, (int)pos.z / 20);
	}

	public static ResourceDepositManager Get()
	{
		return _manager;
	}

	public ResourceDepositManager()
	{
		_manager = this;
		_deposits = new Dictionary<Vector2i, ResourceDeposit>();
	}

	public ResourceDeposit CreateFromPosition(Vector3 pos)
	{
		Vector2i indexFrom = GetIndexFrom(pos);
		UnityEngine.Random.State state = UnityEngine.Random.state;
		UnityEngine.Random.InitState((int)new Vector2(indexFrom.x, indexFrom.y).Seed(World.Seed + World.Salt));
		ResourceDeposit resourceDeposit = new ResourceDeposit
		{
			origin = new Vector3(indexFrom.x * 20, 0f, indexFrom.y * 20)
		};
		if (UnityEngine.Random.Range(0f, 1f) < 0.5f)
		{
			resourceDeposit.Add(ItemManager.FindItemDefinition("stones"), 1f, 100, 1f, ResourceDeposit.surveySpawnType.ITEM);
		}
		else
		{
			bool flag = false;
			float num = 0f;
			if (World.Procedural)
			{
				if (TerrainMeta.BiomeMap.GetBiome(pos, 1) > 0.5f)
				{
					num += 0.25f;
				}
			}
			else
			{
				num += 0.15f;
			}
			if (UnityEngine.Random.Range(0f, 1f) >= 1f - num)
			{
				resourceDeposit.Add(ItemManager.FindItemDefinition("crude.oil"), 1f, UnityEngine.Random.Range(5000, 10000), UnityEngine.Random.Range(8f, 10f), ResourceDeposit.surveySpawnType.ITEM, liquid: true);
				flag = true;
			}
			if (!flag)
			{
				resourceDeposit.Add(ItemManager.FindItemDefinition("stones"), 1f, UnityEngine.Random.Range(30000, 100000), UnityEngine.Random.Range(0.3f, 0.5f), ResourceDeposit.surveySpawnType.ITEM);
				float num2 = 0f;
				num2 = ((!World.Procedural) ? 0.1f : (((TerrainMeta.BiomeMap.GetBiome(pos, 2) > 0.5f) ? 1f : 0f) * 0.25f));
				if (UnityEngine.Random.Range(0f, 1f) >= 1f - num2)
				{
					resourceDeposit.Add(ItemManager.FindItemDefinition("metal.ore"), 1f, UnityEngine.Random.Range(10000, 100000), UnityEngine.Random.Range(2f, 4f), ResourceDeposit.surveySpawnType.ITEM);
				}
				float num3 = 0f;
				num3 = ((!World.Procedural) ? 0.1f : (((TerrainMeta.BiomeMap.GetBiome(pos, 1) > 0.5f) ? 1f : 0f) * (0.25f + 0.25f * (TerrainMeta.TopologyMap.GetTopology(pos, 8) ? 1f : 0f) + 0.25f * (TerrainMeta.TopologyMap.GetTopology(pos, 1) ? 1f : 0f))));
				if (UnityEngine.Random.Range(0f, 1f) >= 1f - num3)
				{
					resourceDeposit.Add(ItemManager.FindItemDefinition("sulfur.ore"), 1f, UnityEngine.Random.Range(10000, 100000), UnityEngine.Random.Range(4f, 4f), ResourceDeposit.surveySpawnType.ITEM);
				}
				float num4 = 0f;
				if (World.Procedural)
				{
					if (TerrainMeta.BiomeMap.GetBiome(pos, 8) > 0.5f || TerrainMeta.BiomeMap.GetBiome(pos, 4) > 0.5f)
					{
						num4 += 0.25f;
					}
				}
				else
				{
					num4 += 0.15f;
				}
				if (UnityEngine.Random.Range(0f, 1f) >= 1f - num4)
				{
					resourceDeposit.Add(ItemManager.FindItemDefinition("hq.metal.ore"), 1f, UnityEngine.Random.Range(5000, 10000), UnityEngine.Random.Range(30f, 50f), ResourceDeposit.surveySpawnType.ITEM);
				}
			}
		}
		_deposits.Add(indexFrom, resourceDeposit);
		Interface.CallHook("OnResourceDepositCreated", resourceDeposit);
		UnityEngine.Random.state = state;
		return resourceDeposit;
	}

	public ResourceDeposit GetFromPosition(Vector3 pos)
	{
		ResourceDeposit value = null;
		if (_deposits.TryGetValue(GetIndexFrom(pos), out value))
		{
			return value;
		}
		return null;
	}

	public static ResourceDeposit GetOrCreate(Vector3 pos)
	{
		ResourceDeposit fromPosition = Get().GetFromPosition(pos);
		if (fromPosition != null)
		{
			return fromPosition;
		}
		return Get().CreateFromPosition(pos);
	}
}
