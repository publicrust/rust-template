public class ItemModPager : ItemModRFListener
{
	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		base.ServerCommand(item, command, player);
		PagerEntity component = ItemModAssociatedEntity<BaseEntity>.GetAssociatedEntity(item).GetComponent<PagerEntity>();
		if ((bool)component)
		{
			switch (command)
			{
			case "stop":
				component.SetOff();
				break;
			case "silenton":
				component.SetSilentMode(wantsSilent: true);
				break;
			case "silentoff":
				component.SetSilentMode(wantsSilent: false);
				break;
			}
		}
	}
}
