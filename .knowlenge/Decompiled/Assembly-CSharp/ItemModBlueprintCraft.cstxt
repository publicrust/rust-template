using UnityEngine;

public class ItemModBlueprintCraft : ItemMod
{
	public static readonly Phrase CraftItemTitle = new Phrase("craft_item", "Craft");

	public static readonly Phrase CraftItemDesc = new Phrase("craft_item_desc", "Create the item the blueprint is referring to");

	public static readonly Phrase CraftAllTitle = new Phrase("craft_all", "Craft All");

	public static readonly Phrase CraftAllDesc = new Phrase("craft_all_desc", "Craft all available blueprints into items");

	public GameObjectRef successEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)item.GetOwnerPlayer() != (Object)(object)player)
		{
			return;
		}
		if (command == "craft")
		{
			if (!item.IsBlueprint() || !player.inventory.crafting.CanCraft(item.blueprintTargetDef.Blueprint))
			{
				return;
			}
			Item fromTempBlueprint = item;
			if (item.amount > 1)
			{
				fromTempBlueprint = item.SplitItem(1);
			}
			player.inventory.crafting.CraftItem(item.blueprintTargetDef.Blueprint, player, null, 1, 0, fromTempBlueprint);
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
		if (command == "craft_all" && item.IsBlueprint() && player.inventory.crafting.CanCraft(item.blueprintTargetDef.Blueprint, item.amount))
		{
			player.inventory.crafting.CraftItem(item.blueprintTargetDef.Blueprint, player, null, item.amount, 0, item);
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
