public class ItemModCassetteContainer : ItemModContainer
{
	public ItemDefinition[] CassetteItems;

	protected override bool ForceAcceptItemCheck => true;

	protected override void SetAllowedItems(ItemContainer container)
	{
		container.SetOnlyAllowedItems(CassetteItems);
	}
}
