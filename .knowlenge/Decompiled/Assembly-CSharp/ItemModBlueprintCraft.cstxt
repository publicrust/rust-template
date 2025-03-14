public class ItemModBlueprintCraft : ItemMod
{
	public static readonly Translate.Phrase CraftItemTitle = new Translate.Phrase("craft_item", "Craft");

	public static readonly Translate.Phrase CraftItemDesc = new Translate.Phrase("craft_item_desc", "Create the item the blueprint is referring to");

	public static readonly Translate.Phrase CraftAllTitle = new Translate.Phrase("craft_all", "Craft All");

	public static readonly Translate.Phrase CraftAllDesc = new Translate.Phrase("craft_all_desc", "Craft all available blueprints into items");

	public GameObjectRef successEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (item.GetOwnerPlayer() != player)
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
