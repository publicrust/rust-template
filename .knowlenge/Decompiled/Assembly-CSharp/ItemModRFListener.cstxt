public class ItemModRFListener : ItemModAssociatedEntity<PagerEntity>
{
	public GameObjectRef frequencyPanelPrefab;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		base.ServerCommand(item, command, player);
		PagerEntity associatedEntity = ItemModAssociatedEntity<PagerEntity>.GetAssociatedEntity(item);
		switch (command)
		{
		case "stop":
			associatedEntity.SetOff();
			break;
		case "silenton":
			associatedEntity.SetSilentMode(wantsSilent: true);
			break;
		case "silentoff":
			associatedEntity.SetSilentMode(wantsSilent: false);
			break;
		}
	}
}
