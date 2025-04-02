using UnityEngine;

public class ItemModReload : ItemMod
{
	public float conditionLost;

	public GameObjectRef successEffect;

	public int workbenchLvlRequired;

	public Phrase reloadPhrase = new Phrase("reload_item", "Reload Item");

	public bool HasCraftLevel(BasePlayer player = null)
	{
		if ((Object)(object)player != (Object)null && player.isServer)
		{
			return player.currentCraftLevel >= (float)workbenchLvlRequired;
		}
		return false;
	}

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		if (!(command == "reload") || player.IsSwimming() || !HasCraftLevel(player))
		{
			return;
		}
		BaseEntity heldEntity = item.GetHeldEntity();
		if ((Object)(object)heldEntity == (Object)null)
		{
			return;
		}
		BaseProjectile component = ((Component)heldEntity).GetComponent<BaseProjectile>();
		if (!((Object)(object)component == (Object)null))
		{
			int num = component.primaryMagazine.capacity - component.primaryMagazine.contents;
			if (num != 0 && component.TryReloadMagazine(player.inventory, num) && successEffect.isValid)
			{
				Effect.server.Run(successEffect.resourcePath, player.eyes.position);
			}
		}
	}
}
