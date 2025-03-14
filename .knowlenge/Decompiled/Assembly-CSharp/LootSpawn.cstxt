using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Loot Spawn")]
public class LootSpawn : ScriptableObject
{
	[Serializable]
	public struct Entry
	{
		[Tooltip("If this category is chosen, we will spawn 1+ this amount")]
		public int extraSpawns;

		[Tooltip("If a subcategory exists we'll choose from there instead of any items specified")]
		public LootSpawn category;

		[Tooltip("The higher this number, the more likely this will be chosen")]
		public int weight;
	}

	public ItemAmountRanged[] items;

	public Entry[] subSpawn;

	public ItemDefinition GetBlueprintBaseDef()
	{
		return ItemManager.FindItemDefinition("blueprintbase");
	}

	public void SpawnIntoContainer(ItemContainer container)
	{
		if (subSpawn != null && subSpawn.Length != 0)
		{
			SubCategoryIntoContainer(container);
		}
		else
		{
			if (items == null)
			{
				return;
			}
			ItemAmountRanged[] array = items;
			foreach (ItemAmountRanged itemAmountRanged in array)
			{
				if (itemAmountRanged == null)
				{
					continue;
				}
				Item item = null;
				if (itemAmountRanged.itemDef.spawnAsBlueprint)
				{
					ItemDefinition blueprintBaseDef = GetBlueprintBaseDef();
					if (blueprintBaseDef == null)
					{
						continue;
					}
					Item item2 = ItemManager.Create(blueprintBaseDef, 1, 0uL);
					item2.blueprintTarget = itemAmountRanged.itemDef.itemid;
					item = item2;
				}
				else
				{
					item = ItemManager.CreateByItemID(itemAmountRanged.itemid, (int)itemAmountRanged.GetAmount(), 0uL);
				}
				if (item == null)
				{
					continue;
				}
				item.OnVirginSpawn();
				if (!item.MoveToContainer(container))
				{
					if ((bool)container.playerOwner)
					{
						item.Drop(container.playerOwner.GetDropPosition(), container.playerOwner.GetDropVelocity());
					}
					else
					{
						item.Remove();
					}
				}
			}
		}
	}

	private void SubCategoryIntoContainer(ItemContainer container)
	{
		int num = subSpawn.Sum((Entry x) => x.weight);
		int num2 = UnityEngine.Random.Range(0, num);
		for (int i = 0; i < subSpawn.Length; i++)
		{
			if (subSpawn[i].category == null)
			{
				continue;
			}
			num -= subSpawn[i].weight;
			if (num2 >= num)
			{
				for (int j = 0; j < 1 + subSpawn[i].extraSpawns; j++)
				{
					subSpawn[i].category.SpawnIntoContainer(container);
				}
				return;
			}
		}
		string text = ((container.entityOwner != null) ? container.entityOwner.name : "Unknown");
		Debug.LogWarning($"SubCategoryIntoContainer for loot '{base.name}' for entity '{text}' ended with randomWeight ({num2}) < totalWeight ({num}). This should never happen! ", this);
	}
}
