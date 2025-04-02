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
		TimeWarning val = TimeWarning.New("DeployedFigurine.OnRpcMessage", 0);
		try
		{
			if (rpc == 1279596472 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - Server_Poke "));
				}
				TimeWarning val2 = TimeWarning.New("Server_Poke", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(1279596472u, "Server_Poke", this, player, 3f))
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
							Server_Poke(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in Server_Poke");
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
	private void Server_Poke(RPCMessage msg)
	{
		if (CanWobble() && !((Object)(object)msg.player == (Object)null))
		{
			Hurt(HurtPerUse, DamageType.Generic, null, useProtection: false);
			SetFlag(Flags.Busy, b: true);
			((FacepunchBehaviour)this).Invoke((Action)ClearBusy, UseCooldown);
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
