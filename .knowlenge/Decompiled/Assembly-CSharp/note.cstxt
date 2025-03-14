using Facepunch.Extend;
using UnityEngine;

[Factory("note")]
public class note : ConsoleSystem
{
	[ServerUserVar]
	public static void update(Arg arg)
	{
		ItemId itemID = ArgEx.GetItemID(arg, 0);
		string @string = arg.GetString(1);
		Item item = ArgEx.Player(arg).inventory.FindItemByUID(itemID);
		if (item != null)
		{
			item.text = @string.Truncate(1024);
			item.MarkDirty();
		}
	}
}
