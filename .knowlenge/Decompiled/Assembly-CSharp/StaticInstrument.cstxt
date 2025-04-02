using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class StaticInstrument : BaseMountable
{
	public AnimatorOverrideController AnimatorOverride;

	public bool ShowDeployAnimation;

	public InstrumentKeyController KeyController;

	public bool ShouldSuppressHandsAnimationLayer;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("StaticInstrument.OnRpcMessage", 0);
		try
		{
			if (rpc == 1625188589 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - Server_PlayNote "));
				}
				TimeWarning val2 = TimeWarning.New("Server_PlayNote", 0);
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
						Server_PlayNote(msg2);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
					player.Kick("RPC Error in Server_PlayNote");
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
			if (rpc == 705843933 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - Server_StopNote "));
				}
				TimeWarning val2 = TimeWarning.New("Server_StopNote", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Call", 0);
					try
					{
						RPCMessage rPCMessage = default(RPCMessage);
						rPCMessage.connection = msg.connection;
						rPCMessage.player = player;
						rPCMessage.read = msg.read;
						RPCMessage msg3 = rPCMessage;
						Server_StopNote(msg3);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
				catch (Exception ex2)
				{
					Debug.LogException(ex2);
					player.Kick("RPC Error in Server_StopNote");
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
	private void Server_PlayNote(RPCMessage msg)
	{
		int arg = msg.read.Int32();
		int arg2 = msg.read.Int32();
		int arg3 = msg.read.Int32();
		float arg4 = msg.read.Float();
		KeyController.ProcessServerPlayedNote(GetMounted());
		ClientRPC(RpcTarget.NetworkGroup("Client_PlayNote"), arg, arg2, arg3, arg4);
	}

	[RPC_Server]
	private void Server_StopNote(RPCMessage msg)
	{
		int arg = msg.read.Int32();
		int arg2 = msg.read.Int32();
		int arg3 = msg.read.Int32();
		ClientRPC(RpcTarget.NetworkGroup("Client_StopNote"), arg, arg2, arg3);
	}

	public override bool IsInstrument()
	{
		return true;
	}
}
