using System.Collections.Generic;
using Facepunch;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Fishing Lookup")]
public class FishLookup : BaseScriptableObject
{
	public ItemModFishable FallbackFish;

	private static FishLookup _instance;

	private static ItemModFishable[] AvailableFish;

	public static ItemDefinition[] BaitItems;

	private static TimeSince lastShuffle;

	public const int ALL_FISH_COUNT = 9;

	public const string ALL_FISH_ACHIEVEMENT_NAME = "PRO_ANGLER";

	public static FishLookup Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FileSystem.Load<FishLookup>("assets/prefabs/tools/fishing rod/fishlookup.asset");
			}
			return _instance;
		}
	}

	public static void LoadFish()
	{
		if (AvailableFish != null)
		{
			if ((float)lastShuffle > 5f)
			{
				ArrayEx.Shuffle(AvailableFish, (uint)Random.Range(0, 10000));
			}
			return;
		}
		List<ItemModFishable> obj = Pool.Get<List<ItemModFishable>>();
		List<ItemDefinition> obj2 = Pool.Get<List<ItemDefinition>>();
		foreach (ItemDefinition item in ItemManager.itemList)
		{
			if (item.TryGetComponent<ItemModFishable>(out var component))
			{
				obj.Add(component);
			}
			if (item.TryGetComponent<ItemModCompostable>(out var component2) && component2.BaitValue > 0f)
			{
				obj2.Add(item);
			}
		}
		AvailableFish = obj.ToArray();
		BaitItems = obj2.ToArray();
		Pool.FreeUnmanaged(ref obj);
		Pool.FreeUnmanaged(ref obj2);
	}

	public ItemDefinition GetFish(Vector3 worldPos, WaterBody bodyType, Item lure, out ItemModFishable fishable, ItemModFishable ignoreFish, out int usedLureAmount, float overrideDepth = 0f)
	{
		LoadFish();
		usedLureAmount = 1;
		ItemModCompostable component;
		float num = (lure.info.TryGetComponent<ItemModCompostable>(out component) ? component.BaitValue : 0f);
		if (component != null && component.MaxBaitStack > 0)
		{
			usedLureAmount = Mathf.Min(lure.amount, component.MaxBaitStack);
			num *= (float)usedLureAmount;
		}
		WaterBody.FishingTag fishingTag = ((bodyType != null) ? bodyType.FishingType : WaterBody.FishingTag.Ocean);
		if (WaterResource.IsFreshWater(worldPos))
		{
			fishingTag |= WaterBody.FishingTag.River;
		}
		float num2 = WaterLevel.GetOverallWaterDepth(worldPos, waves: true, volumes: false);
		if (worldPos.y < -10f)
		{
			num2 = 10f;
		}
		if (overrideDepth != 0f)
		{
			num2 = overrideDepth;
		}
		int num3 = Random.Range(0, AvailableFish.Length);
		for (int i = 0; i < AvailableFish.Length; i++)
		{
			num3++;
			if (num3 >= AvailableFish.Length)
			{
				num3 = 0;
			}
			ItemModFishable itemModFishable = AvailableFish[num3];
			if (itemModFishable.CanBeFished && !(itemModFishable.MinimumBaitLevel > num) && (!(itemModFishable.MaximumBaitLevel > 0f) || !(num > itemModFishable.MaximumBaitLevel)) && !(itemModFishable == ignoreFish) && (itemModFishable.RequiredTag == (WaterBody.FishingTag)(-1) || (itemModFishable.RequiredTag & fishingTag) != 0) && ((fishingTag & WaterBody.FishingTag.Ocean) != WaterBody.FishingTag.Ocean || ((!(itemModFishable.MinimumWaterDepth > 0f) || !(num2 < itemModFishable.MinimumWaterDepth)) && (!(itemModFishable.MaximumWaterDepth > 0f) || !(num2 > itemModFishable.MaximumWaterDepth)))) && !(Random.Range(0f, 1f) - num * 3f * 0.01f > itemModFishable.Chance))
			{
				fishable = itemModFishable;
				return itemModFishable.GetComponent<ItemDefinition>();
			}
		}
		fishable = FallbackFish;
		return FallbackFish.GetComponent<ItemDefinition>();
	}

	public void CheckCatchAllAchievement(BasePlayer player)
	{
		LoadFish();
		int num = 0;
		ItemModFishable[] availableFish = AvailableFish;
		foreach (ItemModFishable itemModFishable in availableFish)
		{
			if (!string.IsNullOrEmpty(itemModFishable.SteamStatName) && player.stats.steam.Get(itemModFishable.SteamStatName) > 0)
			{
				num++;
			}
		}
		if (num == 9)
		{
			player.GiveAchievement("PRO_ANGLER");
		}
	}
}
