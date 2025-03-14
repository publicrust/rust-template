using Oxide.Core;
using UnityEngine;

public class ItemModUnwrap : ItemMod
{
	public LootSpawn revealList;

	public GameObjectRef successEffect;

	public int minTries = 1;

	public int maxTries = 1;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (command == "unwrap" && item.amount > 0 && Interface.CallHook("OnItemUnwrap", item, player, this) == null)
		{
			item.UseItem();
			int num = UnityEngine.Random.Range(minTries, maxTries + 1);
			for (int i = 0; i < num; i++)
			{
				revealList.SpawnIntoContainer(player.inventory.containerMain);
			}
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
