#define UNITY_ASSERTIONS
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
		using (TimeWarning.New("CustomTimerSwitch.OnRpcMessage"))
		{
			if (rpc == 1019813162 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - SERVER_SetTime ");
				}
				using (TimeWarning.New("SERVER_SetTime"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1019813162u, "SERVER_SetTime", this, player, 3f))
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
							SERVER_SetTime(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in SERVER_SetTime");
					}
				}
				return true;
			}
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
		if (player != null && player.CanBuild())
		{
			return !IsOn();
		}
		return false;
	}
}
