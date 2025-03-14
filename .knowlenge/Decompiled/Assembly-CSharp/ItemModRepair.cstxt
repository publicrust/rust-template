using Facepunch.Rust;
using Oxide.Core;

public class ItemModRepair : ItemMod
{
	public static readonly Translate.Phrase RefillItemTitle = new Translate.Phrase("refill_item", "Refill");

	public static readonly Translate.Phrase RefillItemDesc = new Translate.Phrase("refill_item_desc", "Refill the item.");

	public float conditionLost = 0.05f;

	public GameObjectRef successEffect;

	public int workbenchLvlRequired;

	public bool canUseRepairBench;

	public bool HasCraftLevel(BasePlayer player = null)
	{
		if (player != null && player.isServer)
		{
			return player.currentCraftLevel >= (float)workbenchLvlRequired;
		}
		return false;
	}

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (command == "refill" && !player.IsSwimming() && HasCraftLevel(player) && !(item.conditionNormalized >= 1f) && Interface.CallHook("OnItemRefill", item, player) == null)
		{
			float conditionNormalized = item.conditionNormalized;
			float maxConditionNormalized = item.maxConditionNormalized;
			item.DoRepair(conditionLost);
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
			Facepunch.Rust.Analytics.Azure.OnItemRepaired(player, player.GetCachedCraftLevelWorkbench(), item, conditionNormalized, maxConditionNormalized);
		}
	}
}
