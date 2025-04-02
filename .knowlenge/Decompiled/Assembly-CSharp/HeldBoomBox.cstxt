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
		TimeWarning val = TimeWarning.New("HeldBoomBox.OnRpcMessage", 0);
		try
		{
			if (rpc == 1918716764 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - Server_UpdateRadioIP "));
				}
				TimeWarning val2 = TimeWarning.New("Server_UpdateRadioIP", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
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
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					try
					{
						val3 = TimeWarning.New("Call", 0);
						try
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							Server_UpdateRadioIP(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in Server_UpdateRadioIP");
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
			if (rpc == 1785864031 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - ServerTogglePlay "));
				}
				TimeWarning val2 = TimeWarning.New("ServerTogglePlay", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsActiveItem.Test(1785864031u, "ServerTogglePlay", this, player))
						{
							return true;
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					try
					{
						val3 = TimeWarning.New("Call", 0);
						try
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg3 = rPCMessage;
							ServerTogglePlay(msg3);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex2)
					{
						Debug.LogException(ex2);
						player.Kick("RPC Error in ServerTogglePlay");
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
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
		if ((Object)(object)GetOwnerPlayer() != (Object)null && GetOwnerPlayer().IsSleeping())
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
