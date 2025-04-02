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
		TimeWarning val = TimeWarning.New("ConfettiCannon.OnRpcMessage", 0);
		try
		{
			if (rpc == 2995985310u && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - Blast "));
				}
				TimeWarning val2 = TimeWarning.New("Blast", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(2995985310u, "Blast", this, player, 3f))
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
							Blast(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in Blast");
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
			((FacepunchBehaviour)this).Invoke(blastAction, InitialBlastDelay);
			((FacepunchBehaviour)this).Invoke(clearBusy, InitialBlastDelay + BlastCooldown);
		}
	}

	private void TriggerBlast()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (ConfettiPrefab.isValid && (Object)(object)ConfettiPrefabSpawnPoint != (Object)null)
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
