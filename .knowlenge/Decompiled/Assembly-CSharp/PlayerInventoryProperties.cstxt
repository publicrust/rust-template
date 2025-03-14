using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Player Inventory Properties")]
public class PlayerInventoryProperties : ScriptableObject
{
	[Serializable]
	public class ItemAmountSkinned : ItemAmount
	{
		public ulong skinOverride;
	}

	public string niceName;

	public int order = 100;

	public List<ItemAmountSkinned> belt;

	public List<ItemAmountSkinned> main;

	public List<ItemAmountSkinned> wear;

	public void GiveToPlayer(BasePlayer player)
	{
		if (player == null)
		{
			return;
		}
		player.inventory.Strip();
		foreach (ItemAmountSkinned item in belt)
		{
			player.inventory.GiveItem(ItemManager.Create(item.itemDef, (int)item.amount, item.skinOverride), player.inventory.containerBelt);
		}
		foreach (ItemAmountSkinned item2 in main)
		{
			player.inventory.GiveItem(ItemManager.Create(item2.itemDef, (int)item2.amount, item2.skinOverride), player.inventory.containerMain);
		}
		foreach (ItemAmountSkinned item3 in wear)
		{
			player.inventory.GiveItem(ItemManager.Create(item3.itemDef, (int)item3.amount, item3.skinOverride), player.inventory.containerWear);
		}
	}
}
