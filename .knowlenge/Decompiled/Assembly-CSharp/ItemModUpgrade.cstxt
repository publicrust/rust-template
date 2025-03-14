using Oxide.Core;
using UnityEngine;

public class ItemModUpgrade : ItemMod
{
	public static readonly Translate.Phrase UpgradeItemTitle = new Translate.Phrase("upgrade_item", "Upgrade");

	public static readonly Translate.Phrase UpgradeItemDesc = new Translate.Phrase("upgrade_item_desc", "Upgrade item");

	public int numForUpgrade = 10;

	public float upgradeSuccessChance = 1f;

	public int numToLoseOnFail = 2;

	public ItemDefinition upgradedItem;

	public int numUpgradedItem = 1;

	public GameObjectRef successEffect;

	public GameObjectRef failEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (!(command == "upgrade_item") || item.amount < numForUpgrade)
		{
			return;
		}
		if (UnityEngine.Random.Range(0f, 1f) <= upgradeSuccessChance)
		{
			item.UseItem(numForUpgrade);
			Item item2 = ItemManager.Create(upgradedItem, numUpgradedItem, 0uL);
			Interface.CallHook("OnItemUpgrade", item, item2, player);
			item2.SetItemOwnership(player, ItemOwnershipPhrases.UpgradeItem);
			if (!item2.MoveToContainer(player.inventory.containerMain))
			{
				item2.Drop(player.GetDropPosition(), player.GetDropVelocity());
			}
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
		else
		{
			item.UseItem(numToLoseOnFail);
			if (failEffect.isValid)
			{
				Effect.server.Run(failEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
