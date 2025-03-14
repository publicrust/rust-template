using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/NPC Vending Order")]
public class NPCVendingOrder : ScriptableObject
{
	[Serializable]
	public class Entry
	{
		public ItemDefinition sellItem;

		public int sellItemAmount;

		public bool sellItemAsBP;

		public ItemDefinition currencyItem;

		public int currencyAmount;

		public bool currencyAsBP;

		public int refillAmount = 1;

		public float refillDelay = 10f;

		public EntryRandom randomDetails;
	}

	[Serializable]
	public struct EntryRandom
	{
		public bool useRandom;

		[Tooltip("The higher this number, the more likely this will be chosen")]
		[Range(0f, 1f)]
		public float weight;

		[Tooltip("Minimum price for the currency item")]
		public int minPrice;

		[Tooltip("Maximum price for the currency item")]
		public int maxPrice;

		[Tooltip("Chance for a very low price to occur (0 to 1)")]
		[Range(0f, 1f)]
		public float veryLowPriceChance;

		[Tooltip("Minimum very low price")]
		public int veryLowPriceMin;

		[Tooltip("Maximum very low price")]
		public int veryLowPriceMax;

		public int GetRandomPrice()
		{
			int num = ((!(UnityEngine.Random.value < veryLowPriceChance)) ? UnityEngine.Random.Range(minPrice, maxPrice + 1) : UnityEngine.Random.Range(veryLowPriceMin, veryLowPriceMax + 1));
			return Mathf.RoundToInt(((float)num + 2.5f) / 5f) * 5;
		}
	}

	public Entry[] orders;

	public void GetRandomEntries(int count, List<Entry> selectedEntries)
	{
		if (orders == null || orders.Length == 0 || count <= 0)
		{
			return;
		}
		List<bool> obj = Pool.Get<List<bool>>();
		for (int i = 0; i < orders.Length; i++)
		{
			obj.Add(item: false);
		}
		float num = 0f;
		count = Mathf.Min(count, orders.Length);
		Entry[] array = orders;
		foreach (Entry entry in array)
		{
			num += entry.randomDetails.weight;
		}
		for (int k = 0; k < count; k++)
		{
			if (num == 0f)
			{
				break;
			}
			float num2 = UnityEngine.Random.Range(0f, num);
			for (int l = 0; l < orders.Length; l++)
			{
				Entry entry2 = orders[l];
				if (!obj[l])
				{
					if (num2 < entry2.randomDetails.weight)
					{
						selectedEntries.Add(entry2);
						obj[l] = true;
						num -= entry2.randomDetails.weight;
						break;
					}
					num2 -= entry2.randomDetails.weight;
				}
			}
		}
		Pool.FreeUnmanaged(ref obj);
	}
}
