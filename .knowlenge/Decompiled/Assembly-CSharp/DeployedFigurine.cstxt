#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Rust;
using UnityEngine;
using UnityEngine.Assertions;

public class DeployedFigurine : BaseCombatEntity
{
	public float UseCooldown = 4f;

	public float HurtPerUse = 5f;

	public Animator WobbleAnimator;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("DeployedFigurine.OnRpcMessage"))
		{
			if (rpc == 1279596472 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Server_Poke ");
				}
				using (TimeWarning.New("Server_Poke"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1279596472u, "Server_Poke", this, player, 3f))
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
							Server_Poke(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Server_Poke");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	private void Server_Poke(RPCMessage msg)
	{
		if (CanWobble() && !(msg.player == null))
		{
			Hurt(HurtPerUse, DamageType.Generic, null, useProtection: false);
			SetFlag(Flags.Busy, b: true);
			Invoke(ClearBusy, UseCooldown);
		}
	}

	private void ClearBusy()
	{
		SetFlag(Flags.Busy, b: false);
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		SetFlag(Flags.Busy, b: false);
	}

	private bool CanWobble()
	{
		return !HasFlag(Flags.Busy);
	}
}
