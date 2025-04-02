#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class RustigeEgg : BaseCombatEntity
{
	public const Flags Flag_Spin = Flags.Reserved1;

	public Transform eggRotationTransform;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("RustigeEgg.OnRpcMessage"))
		{
			if (rpc == 4254195175u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - RPC_Open ");
				}
				using (TimeWarning.New("RPC_Open"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(4254195175u, "RPC_Open", this, player, 3f))
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
							RPC_Open(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_Open");
					}
				}
				return true;
			}
			if (rpc == 1455840454 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - RPC_Spin ");
				}
				using (TimeWarning.New("RPC_Spin"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1455840454u, "RPC_Spin", this, player, 3f))
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
							RPC_Spin(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in RPC_Spin");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool IsSpinning()
	{
		return HasFlag(Flags.Reserved1);
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void RPC_Spin(RPCMessage msg)
	{
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void RPC_Open(RPCMessage msg)
	{
		if (msg.player == null)
		{
			return;
		}
		bool flag = msg.read.Bit();
		if (flag != IsOpen())
		{
			if (flag)
			{
				ClientRPC(RpcTarget.NetworkGroup("FaceEggPosition"), msg.player.eyes.position);
				Invoke(CloseEgg, 60f);
			}
			else
			{
				CancelInvoke(CloseEgg);
			}
			SetFlag(Flags.Open, flag, recursive: false, networkupdate: false);
			if (IsSpinning() && flag)
			{
				SetFlag(Flags.Reserved1, b: false, recursive: false, networkupdate: false);
			}
			SendNetworkUpdateImmediate();
		}
	}

	public void CloseEgg()
	{
		SetFlag(Flags.Open, b: false);
	}
}
