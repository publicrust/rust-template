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
		TimeWarning val = TimeWarning.New("Jackhammer.OnRpcMessage", 0);
		try
		{
			if (rpc == 1699910227 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - Server_SetEngineStatus "));
				}
				TimeWarning val2 = TimeWarning.New("Server_SetEngineStatus", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Call", 0);
					try
					{
						RPCMessage rPCMessage = default(RPCMessage);
						rPCMessage.connection = msg.connection;
						rPCMessage.player = player;
						rPCMessage.read = msg.read;
						RPCMessage msg2 = rPCMessage;
						Server_SetEngineStatus(msg2);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
					player.Kick("RPC Error in Server_SetEngineStatus");
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
