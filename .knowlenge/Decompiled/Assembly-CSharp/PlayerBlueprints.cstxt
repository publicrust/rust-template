using System.Collections.Generic;
using Oxide.Core;
using ProtoBuf;

public class PlayerBlueprints : EntityComponent<BasePlayer>
{
	public SteamInventory steamInventory;

	public void Reset()
	{
		PersistantPlayer playerInfo = SingletonComponent<ServerMgr>.Instance.persistance.GetPlayerInfo(base.baseEntity.userID);
		playerInfo.unlockedItems = new List<int>();
		SingletonComponent<ServerMgr>.Instance.persistance.SetPlayerInfo(base.baseEntity.userID, playerInfo);
		base.baseEntity.SendNetworkUpdate();
	}

	public void UnlockAll()
	{
		foreach (ItemBlueprint bp in ItemManager.bpList)
		{
			if (bp.userCraftable && !bp.defaultBlueprint)
			{
				PersistantPlayer playerInfo = SingletonComponent<ServerMgr>.Instance.persistance.GetPlayerInfo(base.baseEntity.userID);
				if (!playerInfo.unlockedItems.Contains(bp.targetItem.itemid))
				{
					playerInfo.unlockedItems.Add(bp.targetItem.itemid);
					SingletonComponent<ServerMgr>.Instance.persistance.SetPlayerInfo(base.baseEntity.userID, playerInfo);
				}
			}
		}
		base.baseEntity.SendNetworkUpdateImmediate();
		base.baseEntity.ClientRPCPlayer(null, base.baseEntity, "UnlockedBlueprint", 0);
	}

	public bool IsUnlocked(ItemDefinition itemDef)
	{
		PersistantPlayer playerInfo = SingletonComponent<ServerMgr>.Instance.persistance.GetPlayerInfo(base.baseEntity.userID);
		if (playerInfo.unlockedItems != null)
		{
			return playerInfo.unlockedItems.Contains(itemDef.itemid);
		}
		return false;
	}

	public void Unlock(ItemDefinition itemDef)
	{
		PersistantPlayer playerInfo = SingletonComponent<ServerMgr>.Instance.persistance.GetPlayerInfo(base.baseEntity.userID);
		if (!playerInfo.unlockedItems.Contains(itemDef.itemid))
		{
			playerInfo.unlockedItems.Add(itemDef.itemid);
			SingletonComponent<ServerMgr>.Instance.persistance.SetPlayerInfo(base.baseEntity.userID, playerInfo);
			base.baseEntity.SendNetworkUpdateImmediate();
			base.baseEntity.ClientRPCPlayer(null, base.baseEntity, "UnlockedBlueprint", itemDef.itemid);
			base.baseEntity.stats.Add("blueprint_studied", 1, (Stats)5);
		}
	}

	public bool HasUnlocked(ItemDefinition targetItem)
	{
		if ((bool)targetItem.Blueprint)
		{
			if (targetItem.Blueprint.NeedsSteamItem)
			{
				if (targetItem.steamItem != null && !steamInventory.HasItem(targetItem.steamItem.id))
				{
					return false;
				}
				if (targetItem.steamItem == null)
				{
					bool flag = false;
					ItemSkinDirectory.Skin[] skins = targetItem.skins;
					for (int i = 0; i < skins.Length; i++)
					{
						ItemSkinDirectory.Skin skin = skins[i];
						if (steamInventory.HasItem(skin.id))
						{
							flag = true;
							break;
						}
					}
					if (!flag && targetItem.skins2 != null)
					{
						IPlayerItemDefinition[] skins2 = targetItem.skins2;
						foreach (IPlayerItemDefinition playerItemDefinition in skins2)
						{
							if (steamInventory.HasItem(playerItemDefinition.DefinitionId))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						return false;
					}
				}
				return true;
			}
			if (targetItem.Blueprint.NeedsSteamDLC && targetItem.steamDlc != null && targetItem.steamDlc.HasLicense(base.baseEntity.userID))
			{
				return true;
			}
		}
		int[] defaultBlueprints = ItemManager.defaultBlueprints;
		for (int i = 0; i < defaultBlueprints.Length; i++)
		{
			if (defaultBlueprints[i] == targetItem.itemid)
			{
				return true;
			}
		}
		if (base.baseEntity.isServer)
		{
			return IsUnlocked(targetItem);
		}
		return false;
	}

	public bool CanCraft(int itemid, int skinItemId, ulong playerId)
	{
		ItemDefinition itemDefinition = ItemManager.FindItemDefinition(itemid);
		if (itemDefinition == null)
		{
			return false;
		}
		object obj = Interface.CallHook("CanCraft", this, itemDefinition, skinItemId);
		if (obj is bool)
		{
			return (bool)obj;
		}
		if (skinItemId != 0 && !CheckSkinOwnership(skinItemId, playerId))
		{
			return false;
		}
		if (base.baseEntity.currentCraftLevel < (float)itemDefinition.Blueprint.workbenchLevelRequired)
		{
			return false;
		}
		if (HasUnlocked(itemDefinition))
		{
			return true;
		}
		return false;
	}

	public bool CheckSkinOwnership(int skinItemId, ulong playerId)
	{
		ItemSkinDirectory.Skin skin = ItemSkinDirectory.FindByInventoryDefinitionId(skinItemId);
		if (skin.invItem != null && skin.invItem.HasUnlocked(playerId))
		{
			return true;
		}
		return steamInventory.HasItem(skinItemId);
	}
}
