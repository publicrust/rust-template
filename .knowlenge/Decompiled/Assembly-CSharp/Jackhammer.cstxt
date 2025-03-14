#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class Jackhammer : BaseMelee
{
	public float HotspotBonusScale = 1f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("Jackhammer.OnRpcMessage"))
		{
			if (rpc == 1699910227 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Server_SetEngineStatus ");
				}
				using (TimeWarning.New("Server_SetEngineStatus"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							Server_SetEngineStatus(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Server_SetEngineStatus");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool HasAmmo()
	{
		return true;
	}

	[RPC_Server]
	public void Server_SetEngineStatus(RPCMessage msg)
	{
		SetEngineStatus(msg.read.Bit());
	}

	public void SetEngineStatus(bool on)
	{
		SetFlag(Flags.Reserved8, on);
	}

	public override void SetHeld(bool bHeld)
	{
		if (!bHeld)
		{
			SetEngineStatus(on: false);
		}
		base.SetHeld(bHeld);
	}
}
