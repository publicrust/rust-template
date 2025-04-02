using System.Linq;
using UnityEngine;

public class ItemModConditionHasContents : ItemMod
{
	[Tooltip("Can be null to mean any item")]
	public ItemDefinition itemDef;

	public bool requiredState;

	public override bool Passes(Item item)
	{
		if (item.contents == null)
		{
			return !requiredState;
		}
		if (item.contents.itemList.Count == 0)
		{
			return !requiredState;
		}
		if ((bool)itemDef && !item.contents.itemList.Any((Item x) => x.info == itemDef))
		{
			return !requiredState;
		}
		return requiredState;
	}
}
