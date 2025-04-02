using System;
using UnityEngine;

public class ItemModContainerRestriction : ItemMod
{
	[Flags]
	public enum SlotFlags
	{
		Map = 1
	}

	[InspectorFlags]
	public SlotFlags slotFlags;

	public bool CanExistWith(ItemModContainerRestriction other)
	{
		if ((Object)(object)other == (Object)null)
		{
			return true;
		}
		if ((slotFlags & other.slotFlags) != 0)
		{
			return false;
		}
		return true;
	}
}
