using System;
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
			if ((Object)(object)itemSkin != (Object)null)
			{
				itemSkin.ApplySkin(itemModel);
			}
		}
		else if (skinID != 0L)
		{
			WorkshopSkin.Apply(itemModel, skinID, (Action<Skin>)null, (Action)null);
		}
	}
}
