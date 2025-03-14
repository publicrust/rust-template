public class ItemModBaitContainer : ItemModContainer
{
	protected override bool ForceAcceptItemCheck => true;

	protected override bool CanAcceptItem(Item item, int count)
	{
		ItemModCompostable component = item.info.GetComponent<ItemModCompostable>();
		if (component != null)
		{
			return component.BaitValue > 0f;
		}
		return false;
	}

	protected override void SetAllowedItems(ItemContainer container)
	{
		FishLookup.LoadFish();
		container.SetOnlyAllowedItems(FishLookup.BaitItems);
	}
}
