#define UNITY_ASSERTIONS
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
		using (TimeWarning.New("StaticInstrument.OnRpcMessage"))
		{
			if (rpc == 1625188589 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Server_PlayNote ");
				}
				using (TimeWarning.New("Server_PlayNote"))
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
							Server_PlayNote(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Server_PlayNote");
					}
				}
				return true;
			}
			if (rpc == 705843933 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Server_StopNote ");
				}
				using (TimeWarning.New("Server_StopNote"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg3 = rPCMessage;
							Server_StopNote(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in Server_StopNote");
					}
				}
				return true;
			}
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
