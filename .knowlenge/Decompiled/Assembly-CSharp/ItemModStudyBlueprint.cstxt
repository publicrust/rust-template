using Facepunch.Rust;
using Oxide.Core;
using UnityEngine;

public class ItemModStudyBlueprint : ItemMod
{
	public GameObjectRef studyEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (command != "study" || !item.IsBlueprint())
		{
			return;
		}
		if (item.GetOwnerPlayer() != player && player.inventory.GetBackpackWithInventory()?.contents != item.parent)
		{
			bool flag = false;
			foreach (ItemContainer container in player.inventory.loot.containers)
			{
				if (item.GetRootContainer() == container)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
		}
		if (IsBlueprintUnlocked(item, player, out var blueprintTargetDef, out var blueprint) || Interface.CallHook("OnPlayerStudyBlueprint", player, item) != null)
		{
			return;
		}
		Item item2 = item;
		if (item.amount > 1)
		{
			item2 = item.SplitItem(1);
		}
		item2.UseItem();
		player.blueprints.Unlock(blueprintTargetDef);
		Facepunch.Rust.Analytics.Azure.OnBlueprintLearned(player, blueprintTargetDef, "blueprint", ResearchTable.ScrapForResearch(blueprintTargetDef), player);
		if (blueprint != null && blueprint.additionalUnlocks != null && blueprint.additionalUnlocks.Count > 0)
		{
			foreach (ItemDefinition additionalUnlock in blueprint.additionalUnlocks)
			{
				player.blueprints.Unlock(additionalUnlock);
				Facepunch.Rust.Analytics.Azure.OnBlueprintLearned(player, additionalUnlock, "blueprint", 0, player);
			}
		}
		if (studyEffect.isValid)
		{
			Effect.server.Run(studyEffect.resourcePath, player, StringPool.Get("head"), Vector3.zero, Vector3.zero);
		}
	}

	private static bool IsBlueprintUnlocked(Item item, BasePlayer player, out ItemDefinition blueprintTargetDef, out ItemBlueprint blueprint)
	{
		blueprintTargetDef = item.blueprintTargetDef;
		blueprint = blueprintTargetDef.Blueprint;
		bool flag = IsBlueprintUnlocked(blueprintTargetDef, player);
		if (flag && blueprint != null && blueprint.additionalUnlocks != null && blueprint.additionalUnlocks.Count > 0)
		{
			foreach (ItemDefinition additionalUnlock in blueprint.additionalUnlocks)
			{
				if (!IsBlueprintUnlocked(additionalUnlock, player))
				{
					flag = false;
				}
			}
		}
		if (blueprint != null && blueprint.defaultBlueprint)
		{
			flag = true;
		}
		if (flag)
		{
			return true;
		}
		return false;
	}

	public static bool IsBlueprintUnlocked(ItemDefinition def, BasePlayer player)
	{
		return player.blueprints.IsUnlocked(def);
	}
}
