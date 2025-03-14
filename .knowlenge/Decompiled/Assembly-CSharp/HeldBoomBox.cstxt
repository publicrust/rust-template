#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class HeldBoomBox : HeldEntity, ICassettePlayer
{
	public BoomBox BoxController;

	public SwapKeycard cassetteSwapper;

	public BaseEntity ToBaseEntity => this;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("HeldBoomBox.OnRpcMessage"))
		{
			if (rpc == 1918716764 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Server_UpdateRadioIP ");
				}
				using (TimeWarning.New("Server_UpdateRadioIP"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(1918716764u, "Server_UpdateRadioIP", this, player, 2uL))
						{
							return true;
						}
						if (!RPC_Server.IsActiveItem.Test(1918716764u, "Server_UpdateRadioIP", this, player))
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
							Server_UpdateRadioIP(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Server_UpdateRadioIP");
					}
				}
				return true;
			}
			if (rpc == 1785864031 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - ServerTogglePlay ");
				}
				using (TimeWarning.New("ServerTogglePlay"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsActiveItem.Test(1785864031u, "ServerTogglePlay", this, player))
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
							RPCMessage msg3 = rPCMessage;
							ServerTogglePlay(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in ServerTogglePlay");
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
		BoxController.HurtCallback = HurtCallback;
	}

	[RPC_Server]
	[RPC_Server.IsActiveItem]
	public void ServerTogglePlay(RPCMessage msg)
	{
		BoxController.ServerTogglePlay(msg);
	}

	[RPC_Server]
	[RPC_Server.CallsPerSecond(2uL)]
	[RPC_Server.IsActiveItem]
	private void Server_UpdateRadioIP(RPCMessage msg)
	{
		BoxController.Server_UpdateRadioIP(msg);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		BoxController.Save(info);
	}

	public void OnCassetteInserted(Cassette c)
	{
		BoxController.OnCassetteInserted(c);
	}

	public void OnCassetteRemoved(Cassette c)
	{
		BoxController.OnCassetteRemoved(c);
	}

	public bool ClearRadioByUserId(ulong id)
	{
		return BoxController.ClearRadioByUserId(id);
	}

	public void HurtCallback(float amount)
	{
		if (GetOwnerPlayer() != null && GetOwnerPlayer().IsSleeping())
		{
			BoxController.ServerTogglePlay(play: false);
		}
		else
		{
			GetItem()?.LoseCondition(amount);
		}
	}

	public override void OnHeldChanged()
	{
		base.OnHeldChanged();
		if (IsDisabled())
		{
			BoxController.ServerTogglePlay(play: false);
		}
	}

	public override void Load(LoadInfo info)
	{
		BoxController.Load(info);
		base.Load(info);
	}
}
