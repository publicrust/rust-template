using System.Linq;
using Rust.Workshop;
using UnityEngine;

public static class SkinHelpers
{
	public static void SetSkin(GameObject itemModel, ItemDefinition itemDef, ulong skinID)
	{
		ItemSkinDirectory.Skin skin = itemDef.skins.FirstOrDefault((ItemSkinDirectory.Skin x) => (ulong)x.id == skinID);
		if ((ulong)skin.id == skinID)
		{
			ItemSkin itemSkin = skin.invItem as ItemSkin;
			if (itemSkin != null)
			{
				itemSkin.ApplySkin(itemModel);
			}
		}
		else if (skinID != 0L)
		{
			Rust.Workshop.WorkshopSkin.Apply(itemModel, skinID);
		}
	}
}
