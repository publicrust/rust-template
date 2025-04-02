using Rust;

public class ItemPickup : DroppedItem
{
	public ItemDefinition itemDef;

	public int amount = 1;

	public ulong skinOverride;

	public override float GetDespawnDuration()
	{
		return float.PositiveInfinity;
	}

	public override void Spawn()
	{
		base.Spawn();
		if (!Application.isLoadingSave)
		{
			Item item = ItemManager.Create(itemDef, amount, skinOverride);
			InitializeItem(item);
			item.SetWorldEntity(this);
		}
	}

	internal override void DoServerDestroy()
	{
		if (item != null)
		{
			item.Remove();
			item = null;
		}
		base.DoServerDestroy();
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		IdleDestroy();
	}

	public override void TryApplyOwnershipOnPickup(BasePlayer player, Item item)
	{
		item.SetItemOwnership(player, ItemOwnershipPhrases.LootedPhrase);
	}
}
