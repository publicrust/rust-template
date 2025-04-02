using UnityEngine;

public class ItemModMenuOption : ItemMod
{
	public string commandName;

	public ItemMod actionTarget;

	public BaseEntity.Menu.Option option;

	[Tooltip("If true, this is the command that will run when an item is 'selected' on the toolbar")]
	public bool isPrimaryOption = true;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (!(command != commandName) && actionTarget.CanDoAction(item, player))
		{
			actionTarget.DoAction(item, player);
		}
	}

	private void OnValidate()
	{
		if (actionTarget == null)
		{
			Debug.LogWarning("ItemModMenuOption: actionTarget is null!", base.gameObject);
		}
		if (string.IsNullOrEmpty(commandName))
		{
			Debug.LogWarning("ItemModMenuOption: commandName can't be empty!", base.gameObject);
		}
		if (option.icon == null)
		{
			Debug.LogWarning("No icon set for ItemModMenuOption " + base.gameObject.name, base.gameObject);
		}
	}
}
