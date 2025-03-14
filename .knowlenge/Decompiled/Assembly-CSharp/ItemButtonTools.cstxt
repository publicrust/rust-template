using UnityEngine;
using UnityEngine.UI;

public class ItemButtonTools : MonoBehaviour
{
	public Image image;

	public ItemDefinition itemDef;

	public void GiveSelf(int amount)
	{
		ConsoleSystem.Run(ConsoleSystem.Option.Client, "inventory.giveid", itemDef.itemid, amount);
	}

	public void GiveArmed()
	{
		ConsoleSystem.Run(ConsoleSystem.Option.Client, "inventory.givearm", itemDef.itemid);
	}

	public void GiveBlueprint()
	{
	}
}
