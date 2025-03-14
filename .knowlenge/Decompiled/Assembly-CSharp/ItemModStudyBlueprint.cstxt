using Oxide.Core;
using UnityEngine;

public class ItemModStudyBlueprint : ItemMod
{
	public GameObjectRef studyEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (item.GetOwnerPlayer() != player)
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
		if (!(command == "study") || !item.IsBlueprint())
		{
			return;
		}
		ItemDefinition blueprintTargetDef = item.blueprintTargetDef;
		ItemBlueprint blueprint = blueprintTargetDef.Blueprint;
		bool flag2 = player.blueprints.IsUnlocked(blueprintTargetDef);
		if (flag2 && blueprint != null && blueprint.additionalUnlocks != null && blueprint.additionalUnlocks.Count > 0)
		{
			foreach (ItemDefinition additionalUnlock in blueprint.additionalUnlocks)
			{
				if (!player.blueprints.IsUnlocked(additionalUnlock))
				{
					flag2 = false;
				}
			}
		}
		if (flag2 || Interface.CallHook("OnPlayerStudyBlueprint", player, item) != null)
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
		if (blueprint != null && blueprint.additionalUnlocks != null && blueprint.additionalUnlocks.Count > 0)
		{
			foreach (ItemDefinition additionalUnlock2 in blueprint.additionalUnlocks)
			{
				player.blueprints.Unlock(additionalUnlock2);
			}
		}
		if (studyEffect.isValid)
		{
			Effect.server.Run(studyEffect.resourcePath, player, StringPool.Get("head"), Vector3.zero, Vector3.zero);
		}
	}
}
