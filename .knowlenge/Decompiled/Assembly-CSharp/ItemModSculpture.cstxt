public class ItemModSculpture : ItemModAssociatedEntity<AssociatedSculptureStorage>
{
	protected override bool AllowNullParenting => true;

	protected override bool ShouldAutoCreateEntity => false;

	public void OnSculpturePickUp(NetworkableId id, uint crc, Item item)
	{
		AssociatedSculptureStorage associatedSculptureStorage = CreateAssociatedEntity(item);
		if (associatedSculptureStorage != null)
		{
			associatedSculptureStorage.InitFromSculpture(crc, id);
		}
	}
}
