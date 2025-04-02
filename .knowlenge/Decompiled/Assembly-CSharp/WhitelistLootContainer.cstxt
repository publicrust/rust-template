using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class WhitelistLootContainer : LootContainer
{
	public static readonly Translate.Phrase CantLootToast = new Translate.Phrase("whitelistcontainer.noloot", "You are not authorized to access this box");

	[NonSerialized]
	public List<ulong> whitelist = new List<ulong>();

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (!info.forDisk)
		{
			return;
		}
		info.msg.whitelist = Pool.Get<Whitelist>();
		info.msg.whitelist.users = Pool.Get<List<ulong>>();
		foreach (ulong item in whitelist)
		{
			info.msg.whitelist.users.Add(item);
			Debug.Log("Whitelistcontainer saving user " + item);
		}
	}

	public override void Load(LoadInfo info)
	{
		if (info.fromDisk && info.msg.whitelist != null)
		{
			foreach (ulong user in info.msg.whitelist.users)
			{
				whitelist.Add(user);
			}
		}
		base.Load(info);
	}

	public void MissionSetupPlayer(BasePlayer player)
	{
		AddToWhitelist(player.userID);
	}

	public void AddToWhitelist(ulong userid)
	{
		if (!whitelist.Contains(userid))
		{
			whitelist.Add(userid);
		}
	}

	public void RemoveFromWhitelist(ulong userid)
	{
		if (whitelist.Contains(userid))
		{
			whitelist.Remove(userid);
		}
	}

	public override bool PlayerOpenLoot(BasePlayer player, string panelToOpen = "", bool doPositionChecks = true)
	{
		ulong item = player.userID.Get();
		if (!whitelist.Contains(item))
		{
			player.ShowToast(GameTip.Styles.Red_Normal, CantLootToast, false);
			return false;
		}
		return base.PlayerOpenLoot(player, panelToOpen, doPositionChecks);
	}
}
