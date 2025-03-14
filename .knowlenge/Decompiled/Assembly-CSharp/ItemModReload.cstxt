public class ItemModReload : ItemMod
{
	public float conditionLost;

	public GameObjectRef successEffect;

	public int workbenchLvlRequired;

	public Translate.Phrase reloadPhrase = new Translate.Phrase("reload_item", "Reload Item");

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
		if (!(command == "reload") || player.IsSwimming() || !HasCraftLevel(player))
		{
			return;
		}
		BaseEntity heldEntity = item.GetHeldEntity();
		if (heldEntity == null)
		{
			return;
		}
		BaseProjectile component = heldEntity.GetComponent<BaseProjectile>();
		if (!(component == null))
		{
			int num = component.primaryMagazine.capacity - component.primaryMagazine.contents;
			if (num != 0 && component.TryReloadMagazine(player.inventory, num) && successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
