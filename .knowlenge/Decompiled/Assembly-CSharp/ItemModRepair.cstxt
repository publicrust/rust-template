using Oxide.Core;

public class ItemModRepair : ItemMod
{
	public float conditionLost = 0.05f;

	public GameObjectRef successEffect;

	public int workbenchLvlRequired;

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
			item.DoRepair(conditionLost);
			if (successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
