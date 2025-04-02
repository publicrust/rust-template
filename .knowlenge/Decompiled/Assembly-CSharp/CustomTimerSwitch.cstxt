using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class CustomTimerSwitch : TimerSwitch
{
	public GameObjectRef timerPanelPrefab;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("CustomTimerSwitch.OnRpcMessage", 0);
		try
		{
			if (rpc == 1019813162 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - SERVER_SetTime "));
				}
				TimeWarning val2 = TimeWarning.New("SERVER_SetTime", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(1019813162u, "SERVER_SetTime", this, player, 3f))
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
							SERVER_SetTime(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in SERVER_SetTime");
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

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void SERVER_SetTime(RPCMessage msg)
	{
		if (CanPlayerAdmin(msg.player))
		{
			float num = msg.read.Float();
			timerLength = num;
			SendNetworkUpdate();
		}
	}

	public bool CanPlayerAdmin(BasePlayer player)
	{
		if ((Object)(object)player != (Object)null && player.CanBuild())
		{
			return !IsOn();
		}
		return false;
	}
}
