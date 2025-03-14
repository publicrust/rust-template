public class ItemModBurnable : ItemMod
{
	public float fuelAmount = 10f;

	[ItemSelector(ItemCategory.All)]
	public ItemDefinition byproductItem;

	public int byproductAmount = 1;

	public float byproductChance = 0.5f;

	public override void OnItemCreated(Item item)
	{
		item.fuel = fuelAmount;
	}
}
