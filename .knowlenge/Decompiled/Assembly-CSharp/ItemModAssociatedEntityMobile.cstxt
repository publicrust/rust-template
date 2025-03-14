public class ItemModAssociatedEntityMobile : ItemModAssociatedEntity<MobileInventoryEntity>
{
	protected override bool AllowNullParenting => true;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		base.ServerCommand(item, command, player);
		MobileInventoryEntity associatedEntity = ItemModAssociatedEntity<MobileInventoryEntity>.GetAssociatedEntity(item);
		if (command == "silenton")
		{
			associatedEntity.SetSilentMode(wantsSilent: true);
		}
		else if (command == "silentoff")
		{
			associatedEntity.SetSilentMode(wantsSilent: false);
		}
	}
}
