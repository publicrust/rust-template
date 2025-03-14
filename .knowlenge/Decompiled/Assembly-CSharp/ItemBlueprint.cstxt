using System.Collections.Generic;
using Rust;
using UnityEngine;

public class ItemBlueprint : MonoBehaviour
{
	public List<ItemAmount> ingredients = new List<ItemAmount>();

	public List<ItemDefinition> additionalUnlocks = new List<ItemDefinition>();

	public bool defaultBlueprint;

	public bool userCraftable = true;

	public bool isResearchable = true;

	public bool forceShowInConveyorFilter;

	public Rarity rarity;

	[Header("Workbench")]
	public int workbenchLevelRequired;

	[Header("Scrap")]
	public int scrapRequired;

	public int scrapFromRecycle;

	[Header("Unlocking")]
	[Tooltip("This item won't show anywhere unless you have the corresponding SteamItem in your inventory - which is defined on the ItemDefinition")]
	public bool NeedsSteamItem;

	public int blueprintStackSize = -1;

	public float time = 1f;

	public int amountToCreate = 1;

	public string UnlockAchievment;

	public string RecycleStat;

	public ItemDefinition targetItem => GetComponent<ItemDefinition>();

	public bool NeedsSteamDLC => targetItem.steamDlc != null;
}
