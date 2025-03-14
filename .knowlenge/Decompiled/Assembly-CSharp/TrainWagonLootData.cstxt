using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Scriptable Object/Vehicles/Train Wagon Loot Data", fileName = "Train Wagon Loot Data")]
public class TrainWagonLootData : ScriptableObject
{
	[Serializable]
	public class LootOption
	{
		public bool showsFX = true;

		public ItemDefinition lootItem;

		[FormerlySerializedAs("lootAmount")]
		public int maxLootAmount;

		public int minLootAmount;

		public Material lootMaterial;

		public float spawnWeighting = 1f;

		public Color fxTint;

		[FormerlySerializedAs("indoorFXTint")]
		public Color particleFXTint;
	}

	[SerializeField]
	private LootOption[] oreOptions;

	[SerializeField]
	[ReadOnly]
	private LootOption lootWagonContent;

	[SerializeField]
	private LootOption fuelWagonContent;

	private static TrainWagonLootData _instance;

	private const int LOOT_WAGON_INDEX = 1000;

	private const int FUEL_WAGON_INDEX = 1001;

	public static TrainWagonLootData instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Resources.Load<TrainWagonLootData>("Train Wagon Loot Data");
			}
			return _instance;
		}
	}

	public LootOption GetLootOption(TrainCarUnloadable.WagonType wagonType, out int index)
	{
		switch (wagonType)
		{
		case TrainCarUnloadable.WagonType.Lootboxes:
			index = 1000;
			return lootWagonContent;
		case TrainCarUnloadable.WagonType.Fuel:
			index = 1001;
			return fuelWagonContent;
		default:
		{
			float num = 0f;
			LootOption[] array = oreOptions;
			foreach (LootOption lootOption in array)
			{
				num += lootOption.spawnWeighting;
			}
			float num2 = UnityEngine.Random.value * num;
			for (index = 0; index < oreOptions.Length; index++)
			{
				if ((num2 -= oreOptions[index].spawnWeighting) < 0f)
				{
					return oreOptions[index];
				}
			}
			return oreOptions[index];
		}
		}
	}

	public bool TryGetLootFromIndex(int index, out LootOption lootOption)
	{
		switch (index)
		{
		case 1000:
			lootOption = lootWagonContent;
			return true;
		case 1001:
			lootOption = fuelWagonContent;
			return true;
		default:
			index = Mathf.Clamp(index, 0, oreOptions.Length - 1);
			lootOption = oreOptions[index];
			return true;
		}
	}

	public bool TryGetIndexFromLoot(LootOption lootOption, out int index)
	{
		if (lootOption == lootWagonContent)
		{
			index = 1000;
			return true;
		}
		if (lootOption == fuelWagonContent)
		{
			index = 1001;
			return true;
		}
		for (index = 0; index < oreOptions.Length; index++)
		{
			if (oreOptions[index] == lootOption)
			{
				return true;
			}
		}
		index = -1;
		return false;
	}

	public static float GetOrePercent(int lootTypeIndex, StorageContainer sc)
	{
		if (instance.TryGetLootFromIndex(lootTypeIndex, out var lootOption))
		{
			return GetOrePercent(lootOption, sc);
		}
		return 0f;
	}

	public static float GetOrePercent(LootOption lootOption, StorageContainer sc)
	{
		float result = 0f;
		if (sc.IsValid())
		{
			int maxLootAmount = lootOption.maxLootAmount;
			result = (((float)maxLootAmount != 0f) ? Mathf.Clamp01((float)sc.inventory.GetAmount(lootOption.lootItem.itemid, onlyUsableAmounts: false) / (float)maxLootAmount) : 0f);
		}
		return result;
	}
}
