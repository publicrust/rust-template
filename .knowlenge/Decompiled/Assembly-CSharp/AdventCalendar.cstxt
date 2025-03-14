#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class AdventCalendar : BaseCombatEntity
{
	[Serializable]
	public class DayReward
	{
		public ItemAmount[] rewards;
	}

	public int startMonth;

	public int startDay;

	public DayReward[] days;

	public GameObject[] crosses;

	public static List<AdventCalendar> all = new List<AdventCalendar>();

	public static Dictionary<ulong, List<int>> playerRewardHistory = new Dictionary<ulong, List<int>>();

	public static readonly Translate.Phrase CheckLater = new Translate.Phrase("adventcalendar.checklater", "You've already claimed today's gift. Come back tomorrow.");

	public static readonly Translate.Phrase EventOver = new Translate.Phrase("adventcalendar.eventover", "The Advent Calendar event is over. See you next year.");

	public GameObjectRef giftEffect;

	public GameObjectRef boxCloseEffect;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("AdventCalendar.OnRpcMessage"))
		{
			if (rpc == 1911254136 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_RequestGift "));
				}
				using (TimeWarning.New("RPC_RequestGift"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(1911254136u, "RPC_RequestGift", this, player, 1uL))
						{
							return true;
						}
						if (!RPC_Server.IsVisible.Test(1911254136u, "RPC_RequestGift", this, player, 3f))
						{
							return true;
						}
					}
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							RPC_RequestGift(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_RequestGift");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		all.Add(this);
	}

	public override void DestroyShared()
	{
		all.Remove(this);
		base.DestroyShared();
	}

	public void AwardGift(BasePlayer player)
	{
		if (Interface.CallHook("OnAdventGiftAward", this, player) != null)
		{
			return;
		}
		DateTime now = DateTime.Now;
		int num = now.Day - startDay;
		if (now.Month == startMonth && num >= 0 && num < days.Length)
		{
			if (!playerRewardHistory.ContainsKey(player.userID))
			{
				playerRewardHistory.Add(player.userID, new List<int>());
			}
			playerRewardHistory[player.userID].Add(num);
			Effect.server.Run(giftEffect.resourcePath, player.transform.position);
			if (num >= 0 && num < crosses.Length)
			{
				Effect.server.Run(boxCloseEffect.resourcePath, base.transform.position + Vector3.up * 1.5f);
			}
			DayReward dayReward = days[num];
			for (int i = 0; i < dayReward.rewards.Length; i++)
			{
				ItemAmount itemAmount = dayReward.rewards[i];
				player.GiveItem(ItemManager.CreateByItemID(itemAmount.itemid, Mathf.CeilToInt(itemAmount.amount), 0uL), GiveItemReason.PickedUp);
			}
			Interface.CallHook("OnAdventGiftAwarded", this, player);
		}
	}

	public bool WasAwardedTodaysGift(BasePlayer player)
	{
		object obj = Interface.CallHook("CanBeAwardedAdventGift", this, player);
		if (obj is bool)
		{
			return !(bool)obj;
		}
		if (!playerRewardHistory.ContainsKey(player.userID))
		{
			return false;
		}
		DateTime now = DateTime.Now;
		if (now.Month != startMonth)
		{
			return true;
		}
		int num = now.Day - startDay;
		if (num < 0 || num >= days.Length)
		{
			return true;
		}
		if (playerRewardHistory[player.userID].Contains(num))
		{
			return true;
		}
		return false;
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	[RPC_Server.CallsPerSecond(1uL)]
	public void RPC_RequestGift(RPCMessage msg)
	{
		BasePlayer player = msg.player;
		if (WasAwardedTodaysGift(player))
		{
			player.ShowToast(GameTip.Styles.Red_Normal, CheckLater);
		}
		else
		{
			AwardGift(player);
		}
	}
}
