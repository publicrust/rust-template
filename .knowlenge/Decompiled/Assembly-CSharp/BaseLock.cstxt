#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class BaseLock : BaseEntity
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition itemType;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("BaseLock.OnRpcMessage"))
		{
			if (rpc == 3572556655u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_TakeLock "));
				}
				using (TimeWarning.New("RPC_TakeLock"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(3572556655u, "RPC_TakeLock", this, player, 3f))
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
							RPCMessage rpc2 = rPCMessage;
							RPC_TakeLock(rpc2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_TakeLock");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public virtual bool GetPlayerLockPermission(BasePlayer player)
	{
		return OnTryToOpen(player);
	}

	public virtual bool OnTryToOpen(BasePlayer player)
	{
		return !IsLocked();
	}

	public virtual bool OnTryToClose(BasePlayer player)
	{
		return true;
	}

	public virtual bool HasLockPermission(BasePlayer player)
	{
		return true;
	}

	[RPC_Server]
	[RPC_Server.MaxDistance(3f)]
	public void RPC_TakeLock(RPCMessage rpc)
	{
		if (rpc.player.CanInteract() && !IsLocked() && Interface.CallHook("CanPickupLock", rpc.player, this) == null)
		{
			Item item = ItemManager.Create(itemType, 1, skinID);
			if (item != null)
			{
				rpc.player.GiveItem(item);
			}
			Kill();
		}
	}

	public override float BoundsPadding()
	{
		return 2f;
	}
}
