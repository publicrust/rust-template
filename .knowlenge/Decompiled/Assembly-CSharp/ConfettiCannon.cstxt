#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Rust;
using UnityEngine;
using UnityEngine.Assertions;

public class ConfettiCannon : DecayEntity, IIgniteable
{
	public float InitialBlastDelay = 1f;

	public float BlastCooldown = 3f;

	public GameObjectRef ConfettiPrefab;

	public Transform ConfettiPrefabSpawnPoint;

	public const Flags Ignited = Flags.OnFire;

	public float DamagePerBlast = 3f;

	private Action blastAction;

	private Action clearBusy;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ConfettiCannon.OnRpcMessage"))
		{
			if (rpc == 2995985310u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Blast ");
				}
				using (TimeWarning.New("Blast"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(2995985310u, "Blast", this, player, 3f))
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
							Blast(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Blast");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	private void Blast(RPCMessage msg)
	{
		if (!IsBusy())
		{
			SetFlag(Flags.Busy, b: true);
			SetFlag(Flags.OnFire, b: true);
			if (blastAction == null)
			{
				blastAction = TriggerBlast;
			}
			if (clearBusy == null)
			{
				clearBusy = ClearBusy;
			}
			Invoke(blastAction, InitialBlastDelay);
			Invoke(clearBusy, InitialBlastDelay + BlastCooldown);
		}
	}

	private void TriggerBlast()
	{
		if (ConfettiPrefab.isValid && ConfettiPrefabSpawnPoint != null)
		{
			Effect.server.Run(ConfettiPrefab.resourcePath, ConfettiPrefabSpawnPoint.position, ConfettiPrefabSpawnPoint.forward);
		}
		SetFlag(Flags.OnFire, b: false);
		Hurt(DamagePerBlast, DamageType.Generic, null, useProtection: false);
	}

	private void ClearBusy()
	{
		SetFlag(Flags.Busy, b: false);
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		ClearBusy();
	}

	public void Ignite(Vector3 fromPos)
	{
		Blast(default(RPCMessage));
	}

	public bool CanIgnite()
	{
		return !IsBusy();
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		if (base.isServer && info.damageTypes.Has(DamageType.Heat))
		{
			Blast(default(RPCMessage));
		}
	}
}
