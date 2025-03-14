using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DevDressPlayer : MonoBehaviour
{
	public bool DressRandomly;

	public List<ItemAmount> clothesToWear;

	private void ServerInitComponent()
	{
		BasePlayer component = GetComponent<BasePlayer>();
		if (DressRandomly)
		{
			DoRandomClothes(component);
		}
		foreach (ItemAmount item in clothesToWear)
		{
			if (!(item.itemDef == null))
			{
				ItemManager.Create(item.itemDef, 1, 0uL).MoveToContainer(component.inventory.containerWear);
			}
		}
	}

	private void DoRandomClothes(BasePlayer player)
	{
		string text = "";
		foreach (ItemDefinition item in (from x in ItemManager.GetItemDefinitions()
			where x.GetComponent<ItemModWearable>()
			orderby Guid.NewGuid()
			select x).Take(UnityEngine.Random.Range(0, 4)))
		{
			ItemManager.Create(item, 1, 0uL).MoveToContainer(player.inventory.containerWear);
			text = text + item.shortname + " ";
		}
		text = text.Trim();
		if (text == "")
		{
			text = "naked";
		}
		player.displayName = text;
	}
}
