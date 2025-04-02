using UnityEngine;

public class ItemModSculpture : ItemModAssociatedEntity<AssociatedSculptureStorage>
{
	protected override bool AllowNullParenting => true;

	protected override bool ShouldAutoCreateEntity => false;

	public void OnSculpturePickUp(NetworkableId id, uint crc, Item item)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		AssociatedSculptureStorage associatedSculptureStorage = CreateAssociatedEntity(item);
		if ((Object)(object)associatedSculptureStorage != (Object)null)
		{
			associatedSculptureStorage.InitFromSculpture(crc, id);
		}
	}
}
