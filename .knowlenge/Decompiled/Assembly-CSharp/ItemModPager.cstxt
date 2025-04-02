public class ItemModPager : ItemModRFListener
{
	public static readonly Translate.Phrase SilentOffTitle = new Translate.Phrase("silent_off", "Silent OFF");

	public static readonly Translate.Phrase SilentOffDesc = new Translate.Phrase("silent_off_desc", "Emits a small buzzing sound at short distance");

	public static readonly Translate.Phrase SilentOnTitle = new Translate.Phrase("silent_on", "Silent ON");

	public static readonly Translate.Phrase SilentOnDesc = new Translate.Phrase("silent_on_desc", "Emits an audible sound at a distance");

	public static readonly Translate.Phrase StopTitle = new Translate.Phrase("stop", "Stop");

	public static readonly Translate.Phrase StopDesc = new Translate.Phrase("stop_desc", "Stop the alert");

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
